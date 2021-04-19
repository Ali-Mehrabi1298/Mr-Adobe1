using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MohamadShop.Models;
using MohamadShop.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MohamadShop.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Account(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,

                };

                //var emailConfirmationToken =
                //await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var emailMessage =
                //    Url.Action("ConfirmEmail", "Account",
                //        new { username = user.UserName, token = emailConfirmationToken },
                //        Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Email confirmation", emailMessage);



                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {


                    return View("SuccessRegister");

                    //return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);

        }
















        [HttpGet]
        public async Task<IActionResult> Login(/*string returnUrl = null*/)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new LoginViewModel()
            {
                //ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            //ViewData["returnUrl"] = returnUrl;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model ,string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["returnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

           
            

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }

                if (model.ExternalLogins == null)
                {

                    ModelState.AddModelError("", "رمزعبور یا نام کاربری اشتباه است");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است";
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");


        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
                new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new IdentityUser()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, externalLoginInfo);
                await _signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            ViewBag.ErrorTitle = "لطفا با بخش پشتیبانی تماس بگیرید";
            ViewBag.ErrorMessage = $"دریافت کرد {externalLoginInfo.LoginProvider} نمیتوان اطلاعاتی از";
            return View();

        }
    }
}


//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Register(RegisterViewModel register)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(register);
//            }

//            if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
//            {
//                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
//                return View(register);
//            }

//            Users user = new Users()
//            {
//                Email = register.Email.ToLower(),
//                Password = register.Password,
//                IsAdmin = false,
//                RegisterDate = DateTime.Now
//            };

//            _userRepository.AddUser(user);

//            return View("SuccessRegister", register);
//        }

//#endregion

//        #region Login

//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Login(LoginViewModel login)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(login);
//            }

//            var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
//            if (user == null)
//            {
//                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
//                return View(login);
//            }

//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
//                new Claim(ClaimTypes.Name, user.Email),
//               // new Claim("CodeMeli", user.Email),

//            };
//            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//            var principal = new ClaimsPrincipal(identity);

//            var properties = new AuthenticationProperties
//            {
//                IsPersistent = login.RememberMe
//            };

//            HttpContext.SignInAsync(principal, properties);

//            return Redirect("/");
//        }

//        #endregion

//        public IActionResult Logout()
//        {
//            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return Redirect("/Account/Login");
//        }

//    }


//}
