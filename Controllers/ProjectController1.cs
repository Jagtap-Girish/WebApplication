using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPMMvc.Models;
using Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPMMvc.Controllers
{
    public class ProjectController1 : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController1(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // GET: ProjectController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProjectController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController1/Edit/5
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

        // GET: ProjectController1/Delete/5
        public ActionResult Delete(int id)
        {
            Project p=_projectRepository.Get(id);
            return View(p);
        }

        // POST: ProjectController1/Delete/5
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
