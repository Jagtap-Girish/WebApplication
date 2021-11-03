using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPMMvc.Models;
using Repo.Interfaces;
namespace PPMMvc.Controllers
{
    public class ProjectController : Controller
    {
        
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // GET: ProjectController
        public ActionResult Index()
        {
           var projects= _projectRepository.GetAll();
           return View(projects);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            var project = _projectRepository.Get(id);
            return View(project);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            try
            {
                _projectRepository.Add(project);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var projectDetails =_projectRepository.Get(id);
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
            Project p = _projectRepository.Get(id);
            return View(p);
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
