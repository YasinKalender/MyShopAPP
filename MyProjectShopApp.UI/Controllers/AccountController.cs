using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.UI.Identity;
using MyProjectShopApp.UI.Models.Identity;

namespace MyProjectShopApp.UI.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICardService _cardService;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICardService  cardService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;

        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = userModel.UserName;
                user.FullName = userModel.FullName;
                user.Email = userModel.Mail;

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Lütfen değelerinizi kontrol ediniz");

            return View(userModel);
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.url= ReturnUrl;

            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel,string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Mail veya şifre yanlış");
                return View(loginModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password,false,false);

            if (result.Succeeded)
            {
                _cardService.CardObject(user.Id);
                ViewBag.url = ReturnUrl;
                return Redirect(string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl);
              

            }
           

            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");


            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");



        }

        public IActionResult AccessDeniedPath()
        {


            return View();
        }






    }
}