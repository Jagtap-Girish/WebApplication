using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PPMMvc.Models;
using Repo.Concrete;
using Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PPMMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmpoyeeRepository _employeeRepository;
        private readonly IConfiguration Configuration;
        public AccountController(IEmpoyeeRepository employeeRopsitory,IConfiguration configuration)
        {
            _employeeRepository = employeeRopsitory;
            Configuration = configuration;
        }
        [Authorize(Roles ="User,Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult Details(int id)
        {
            
            var emp = _employeeRepository.Get(id);
            ViewBag.Employee = emp;
            return View("Employee");
           
        }
        [HttpPost]
        public IActionResult Login(Login ad)
        {
            if (!string.IsNullOrEmpty(ad.UserName) && string.IsNullOrEmpty(ad.Password))
            {
                return RedirectToAction("Login");
            
            }

            ClaimsIdentity identity = null;
            bool IsAuthenticated = false;
            var role="";
            //if (userName=="admin" && password=="admin") {
                List<Employee> employees;
                EmpoyeeRepository employeeRepository = new EmpoyeeRepository(Configuration);
                employees = (List<Employee>)employeeRepository.GetAll();
                var emp = employees.Single(s => s.Email == ad.UserName);


                if (emp.RoleId == 2)
                {
                role = "Admin";
                    identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name,ad.UserName),
                new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                IsAuthenticated = true;
                }


            if (emp.RoleId == 3)
            {
                role = "Manager";
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name,ad.UserName),
                new Claim(ClaimTypes.Role,"Manager")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                IsAuthenticated = true;
            }


            if (emp.RoleId == 4)
            {
                role = "Employee";
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name,ad.UserName),
                new Claim(ClaimTypes.Role,"Employee")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                IsAuthenticated = true;
            }
            // }
            //if (userName == "admin" && password == "user")
            //{

            //    identity = new ClaimsIdentity(new[] {
            //    new Claim(ClaimTypes.Name,userName),
            //    new Claim(ClaimTypes.Role,"User")
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);
            //    IsAuthenticated = true;
            //}


            if (role == "Admin") {
                return RedirectToAction("Create", "Employee");
            } else if (role == "Manager") {
                return RedirectToAction("Index", "Project");
            }
            else if (role == "Employee")
            {
                return RedirectToAction("Details", Details(emp.Id));
            }
            return View();
        }
    }
}
