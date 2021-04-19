using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;
using MohamadShop.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MohamadShop.Controllers
{
    public class OrdersController : Controller
    {
        private Eshopecontex _ctx;
     
        public OrdersController(Eshopecontex ctx)
        {
            _ctx = ctx;
        }

        [Authorize]
        public IActionResult AddToCart(int id)
        {

      
           


                var product = _ctx.Product.SingleOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                //var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                //var userId = _ctx.Users.Where(p=>p.Id==);
              


                var order = _ctx.Order.FirstOrDefault(o => o.UserName == User.Identity.Name && !o.IsFinaly);
                    if (order != null)
                    {

                   
                    var orderDetail =
                            _ctx.orderdetails.FirstOrDefault(d =>
                                d.OrderId == order.OrderId && d.ProductId == product.ProductId);
                        if (orderDetail != null)
                        {
                            orderDetail.Count += 1;
                        _ctx.Update(orderDetail);
                    }
                        else
                        {
                            _ctx.orderdetails.Add(new OrderDetail()
                            {
                                OrderId = order.OrderId,
                                ProductId = product.ProductId,
                                Price = product.Price,
                                Count = 1
                            });
                        }



                }
                    else
                    {



                        order = new Order()
                        {

                         
                            Sum = product.Price ,
                            productId = id,
                            IsFinaly = false,
                            CreateDate = DateTime.Now,
                            UserName = User.Identity.Name
                        };
                        _ctx.Order.Add(order);
                        _ctx.SaveChanges();
                        _ctx.orderdetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.ProductId,
                            Price = product.Price,
                            Count = 1
                        });
                    }

                    _ctx.SaveChanges();
                UpdateSumOrder(order.OrderId);

            }


            return RedirectToAction("ShowOrder");
        }

        public void UpdateSumOrder(int orderId)
        {
            var order = _ctx.Order.Find(orderId);
            order.Sum = _ctx.orderdetails.Where(o => o.OrderId == order.OrderId).Select(d => d.Count * d.Price).Sum();
            _ctx.Update(order);
            _ctx.SaveChanges();
        }

        [Authorize]
            public IActionResult ShowOrder()
            {
                var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _ctx.Order.Where(o => o.UserName == User.Identity.Name && !o.IsFinaly)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(c => c.Product).FirstOrDefault();
            List<ShowOrderViewModel> _list = new List<ShowOrderViewModel>();
            if (order != null)
            {
                var details = _ctx.orderdetails.Where(d => d.OrderId == order.OrderId).ToList();
                foreach (var item in details)
                {
                    var product = _ctx.Product.Find(item.ProductId);

                    _list.Add(new ShowOrderViewModel()
                    {
                        Count = item.Count,
                        
                        OrderDetailId = item.OrderDetailID,
                        Price = item.Price,
                        Sum = item.Count * item.Price,
                        Title = product.Title
                    });

                }
            }


            return View(order);
            }

            [Authorize]
            public IActionResult RemoveCart(int detailId)
            {

                var orderDetail = _ctx.orderdetails.Find(detailId);
                _ctx.Remove(orderDetail);
                _ctx.SaveChanges();

                return RedirectToAction("ShowOrder");
            }

        
        public IActionResult Payment()
        {
            var order = _ctx.Order.FirstOrDefault(o => !o.IsFinaly);
            if (order == null)
            {
                return NotFound();
            }

            string merchantId = "000000140212149";
            string terminalId = "24000615";
            string merchantKey = "kLheA+FS7MLoLlLVESE3v3/FP07uLaRw";

            string signDataBeforeEncode = $"{terminalId};{order.OrderId};{order.Sum}";


            var byteData = Encoding.UTF8.GetBytes(signDataBeforeEncode);

            var algorithm = SymmetricAlgorithm.Create("TripleDes");
            algorithm.Mode = CipherMode.ECB;
            algorithm.Padding = PaddingMode.PKCS7;

            var encryptor = algorithm.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);
            string signData = Convert.ToBase64String(encryptor.TransformFinalBlock(byteData, 0, byteData.Length));

            var data = new
            {
                MerchantId = merchantId,
                TerminalId = terminalId,
                Amount = order.Sum,
                OrderId = order.OrderId,
                ProductId=order.productId,
                UserName=order.UserName,
                LocalDateTime = DateTime.Now,
                ReturnUrl = "https://localhost:44370/Home/CallBackk",
                SignData = signData
            };


            var res = CallApi<PaymentViewModels>("https://sadad.shaparak.ir/api/v0/Request/PaymentRequest", data).Result;
            if (res.ResCode == 0)
            {
                return Redirect($"https://sadad.shaparak.ir/Purchase/Index?token={res.Token}");
            }
            else
            {
                return View("PaymentError", res);
            }
            //return Content("");
        }

        public async Task<T> CallApi<T>(string apiUrl, object value) where T : new()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var w = client.PostAsync(apiUrl, content);
                w.Wait();

                HttpResponseMessage response = w.Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return JsonConvert.DeserializeObject<T>(result.Result);
                }

                return new T();
            }
        }
    }
}