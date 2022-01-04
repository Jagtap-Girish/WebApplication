using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PPMMvc.Models;
using Repo.Concrete;
using Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace PPMMvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeeToProjectController : Controller
    {
        private IEmployeeToProject _employeeToProjectRopsitory;

        private readonly IConfiguration Configuration;

        public EmployeeToProjectController(IEmployeeToProject employeeToProjectRopsitory, IConfiguration configuration)
        {
            _employeeToProjectRopsitory = employeeToProjectRopsitory;
            Configuration = configuration;

        }


        // GET: EmployeeToProjectController
        public ActionResult Index()
        {
           
                var employeeList = _employeeToProjectRopsitory.GetAll();
            return View(employeeList);
            
        }

        // GET: EmployeeToProjectController/Details/5
        public ActionResult Details(int id)
        {
            
                var emp = _employeeToProjectRopsitory.Get(id);
            return View(emp);
             
        }

        // GET: EmployeeToProjectController/Create
        public ActionResult Create()
        {
            
                IEnumerable<Project> projects;
            ProjectRepository projectRepository = new ProjectRepository(Configuration);
            projects = projectRepository.GetAll();
            ViewData["projects"] = new SelectList(projects, "ProjectId", "ProjectName");
            IEnumerable<Employee> employees;
            EmpoyeeRepository empoyeeRepository = new EmpoyeeRepository(Configuration);
            employees = empoyeeRepository.GetAll();
            ViewData["employees"] = new SelectList(employees, "FirstName", "FirstName");
            return View("Create");
        
        }

        // POST: EmployeeToProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeToProject etp)
        {
            try
            {
                _employeeToProjectRopsitory.Add(etp);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return View(e);
            }
        }

        // GET: EmployeeToProjectController/Edit/5
        public ActionResult Edit(int id)
        {
          
                return View();
        
        }

        // POST: EmployeeToProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeToProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            
                var employee = _employeeToProjectRopsitory.Get(id);
                return View(employee);
            
        }

        // POST: EmployeeToProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeToProject employee)
        {
            try
            {
                _employeeToProjectRopsitory.Delete(id);
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
            else {
                return false;
            }
            throw new NotSupportedException();
        }


    }
}
