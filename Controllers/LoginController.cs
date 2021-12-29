using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPMMvc.Models;
using Repo.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace PPMMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepo _loginRepository;
        private readonly IConfiguration Configuration;
        public LoginController(LoginRepo loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            Configuration = configuration;
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login([Bind] Login ad)
        {
            int res = _loginRepository.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Section";
                CookieOptions cookie = new CookieOptions();
                HttpContext.Session.SetString("username", ad.Id.ToString());
                Response.Cookies.Append("User","Abc");
                               return RedirectToAction("Index", "Employee");
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
               
                return View("Login", ad);
            }
           
        }

       
    }
}
