using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPMMvc.Models;
using Repo.Interfaces;
using Repo.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PPMMvc.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmpoyeeRepository _employeeRepository;
        private readonly IConfiguration Configuration;

        public EmployeeController(IEmpoyeeRepository employeeRopsitory, IConfiguration configuration)
        {
            _employeeRepository = employeeRopsitory;
            Configuration = configuration;

        }
        // GET: EmployeeController
        
        public ActionResult Index()
        {
            if (sessionCheck())
            {

                return RedirectToAction("Login", "Login");
            }
            else
            {
                var employeeList = _employeeRepository.GetAll();
                return View(employeeList);
            }
        }

        // GET: EmployeeController/Details/5
       // [Route("Employee/Details/{Id}")]
        public ActionResult Details(int id)
        {
            if (sessionCheck())
            {

                return RedirectToAction("Login", "Login");
            }
            else
            {
                var emp = _employeeRepository.Get(id);
                return View(emp);
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            if (sessionCheck())
            {

                return RedirectToAction("Login", "Login");
            }
            else
            {
                IEnumerable<Role> roles;
                RoleRepository roleRepository = new RoleRepository(Configuration);
                roles = roleRepository.GetAll();
                ViewData["roles"] = new SelectList(roles, "RoleId", "RoleName");
                return View("Create");
            }
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            var employees= _employeeRepository.GetAll();
            try
            {
                _employeeRepository.Add(emp);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = "You can not add employees with same name";
                return View("Index",employees);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (sessionCheck())
            {

                return RedirectToAction("Login", "Login");
            }
            else
            {
                IEnumerable<Role> roles;
                RoleRepository roleRepository = new RoleRepository(Configuration);
                roles = roleRepository.GetAll();
                ViewData["roles"] = new SelectList(roles, "RoleId", "RoleName");
                var emp = _employeeRepository.Get(id);

                return View(emp);
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                 _employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            if (sessionCheck())
            {

                return RedirectToAction("Login", "Login");
            }
            else
            {
                var employee = _employeeRepository.Get(id);
                return View(employee);
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee emp)
        {
            int id = emp.Id;
            try
            {
                 _employeeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public bool sessionCheck()
        {
            if (HttpContext.Session.GetString("username") == null)
            {

                return true;
            }
            else
            {
                return false;
            }
            throw new NotSupportedException();
        }

    }
}
