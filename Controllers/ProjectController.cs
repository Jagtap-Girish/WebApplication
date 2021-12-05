using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPMMvc.Models;
using Repo.Concrete;
using Repo.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace PPMMvc.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IConfiguration Configuration;
        public ProjectController(IProjectRepository projectRepository, IConfiguration configuration)
        {
            _projectRepository = projectRepository;
            Configuration = configuration;
        }
        // GET: ProjectController
        public ActionResult Index()
        {
            var projects = _projectRepository.GetAll();

            return View(projects);

        }




        // GET: ProjectController/Details/5


        public ActionResult Details(int id)
        {


            EmployeeToProjectRepository employeeToProjectRepository = new EmployeeToProjectRepository(Configuration);
            IList<EmployeeToProject> Employee = (IList<EmployeeToProject>)employeeToProjectRepository.GetAll();
            IList<EmployeeToProject> Emp = new List<EmployeeToProject>();
            if (Employee.Count > 0)
            {
                foreach (var emp in Employee)
                {
                    if (emp.ProjectId == id)
                    {
                        Emp.Add(emp);
                    }
                }
            }
            return View("List", Emp);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            IEnumerable<Employee> employees;
            EmpoyeeRepository employeeRepository = new EmpoyeeRepository(Configuration);
            employees = employeeRepository.GetAll();
            ViewBag.EmployeeId = new MultiSelectList(employees, "Id", "FirstName");
            return View("Create");

        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            try
            {
                _projectRepository.Add(project);
                // ViewBag.EmployeeId = new SelectList((System.Collections.IEnumerable)Index(), "ProjectId", "text");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Employee> employees;
            EmpoyeeRepository employeeRepository = new EmpoyeeRepository(Configuration);
            employees = employeeRepository.GetAll();
            ViewData["employees"] = new MultiSelectList(employees, "Id", "FirstName");
            var projectDetails = _projectRepository.Get(id);
            return View(projectDetails);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
                _projectRepository.Update(project);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController1/Delete/5
        public ActionResult Delete(int id)
        {
            bool flag = true;
            Project p = _projectRepository.Get(id);
            var projects = _projectRepository.GetAll();
            EmployeeToProjectRepository employeeToProjectRepository = new EmployeeToProjectRepository(Configuration);
            IList<EmployeeToProject> Employee = (IList<EmployeeToProject>)employeeToProjectRepository.GetAll();
            IList<EmployeeToProject> Emp = new List<EmployeeToProject>();
            if (Employee.Count > 0)
            {
                foreach (var emp in Employee)
                {
                    if (emp.ProjectId == id)
                    {
                        ViewBag.Message = "This project is mapped to employees please unmap employees to delete";
                        flag = false;
                        break;
                    }

                }
                if (!flag)
                {
                    return View("Index", projects);
                }
                else
                {
                    return View(p);
                }

            }

            else
            {
                return View(p);
            }

        }


        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _projectRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
