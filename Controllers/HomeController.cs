using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MohamadShop.Data;
using MohamadShop.Models;
using MohamadShop.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MohamadShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Eshopecontex _contex;
        SignInManager<IdentityUser> SignInManager;
        public HomeController(ILogger<HomeController> logger, Eshopecontex contex)
        {
            _logger = logger;
            _contex = contex;
        }

        public IActionResult Index()
        {

            var product = _contex.Product.ToList();

            var slider = _contex.Sliders.Skip(1).Take(3).ToList();
    

            var Index = new Indexx()
            {
             
                Products = product,
                Sliders = slider
            };


            return View(Index);
        }




        public async Task<IActionResult> Search(string searchString)
        {
            var movies = from m in _contex.Product
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }









        [HttpPost]
        public IActionResult CallBackk (CallbackRequestPayment result)
        {
            var order = _contex.Order.FirstOrDefault(o => o.OrderId == result.OrderId);
            if (order == null)
            {
                return NotFound();
            }

            string merchantId = "000000140212149";
            string terminalId = "24000615";
            string merchantKey = "kLheA+FS7MLoLlLVESE3v3/FP07uLaRw";

            var byteData = Encoding.UTF8.GetBytes(result.Token);

            var algorithm = SymmetricAlgorithm.Create("TripleDes");
            algorithm.Mode = CipherMode.ECB;
            algorithm.Padding = PaddingMode.PKCS7;

            var encryptor = algorithm.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);
            string signData = Convert.ToBase64String(encryptor.TransformFinalBlock(byteData, 0, byteData.Length));

            var data = new
            {
                Token = result.Token,
                SignData = signData
            };

            var verifyRes = CallApi<VerifyResultData>("https://sadad.shaparak.ir/api/v0/Advice/Verify", data).Result;
            if (verifyRes.ResCode == 0)
            {
                order.IsFinaly = true;

                _contex.Order.Update(order);
                _contex.SaveChanges();

                return View("SuccessPaymentView", verifyRes);
            }
            else
            {
                return View("ErrorPaymentView", verifyRes);
            }

            return View();

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






        [Authorize]
        public IActionResult Detail(int id)
        {


            var product = _contex.Product
                 //.Include(p => p.item)
                 .SingleOrDefault(p => p.ProductId == id);



            // .Select(ca => ca.category).ToList();

            if (product == null)
            {
                return NotFound();
            }


            var Name = product.Title;

            var File = _contex.Filesses.Where(D => D.productName == Name).ToList();

            var Categoress = _contex.Product.Where(A => A.ProductId == id).SelectMany(s => s.CategoryToproducts)
              .Select(ca => ca.Category).ToList();






            var Orrder = _contex.Order.Single(d => d.UserName == User.Identity.Name);



            var Orrderdetaill = _contex.orderdetails.Single(d => d.ProductId == id && d.Order.OrderId == d.OrderId);
            var pro = new AddDetailView()
            {

                product = product,
                categories = Categoress,
                Filess = File,
                OrderDetail = Orrderdetaill,
                order = Orrder
            };
            return View(pro);



        }




        public IActionResult AboutMe()
        {
            return View();


        }

        public IActionResult Callme()
        {
            return View();


        }
       

     



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
