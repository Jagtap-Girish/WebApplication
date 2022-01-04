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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        
        public ActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            return View("Login");
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([Bind] Login ad,string returnUrl)
        {
            int res = _loginRepository.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Section";

                HttpContext.Session.SetString("username", ad.UserName);
                List<Employee> employees;
                EmpoyeeRepository employeeRepository = new EmpoyeeRepository(Configuration);
                employees = (List<Employee>)employeeRepository.GetAll();
                var emp = employees.Single(s => s.Email == ad.UserName);
                if (emp.RoleId == 2)
                {
                    return RedirectToAction("Index", "Employee");
                }
               
            }
            //return View("Login", ad);
            // return RedirectToAction("Index","Project");
            var claims = new List<Claim>();
            claims.Add(new Claim("username",ad.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,ad.UserName));
            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
           await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("Project/Index");
        }
    }
}
