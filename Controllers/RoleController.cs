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
   
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        // GET: RoleController
        public ActionResult Index()
        {
            var roleRepository = _roleRepository.GetAll();
            return View("List",roleRepository);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
           var role= _roleRepository.Get(id);
            return View(role);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            var roles = _roleRepository.GetAll();
            try
            {
                _roleRepository.Add(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "You can not add role with same name";
                return View("List", roles);
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            var roleDetails = _roleRepository.Get(id);
            return View(roleDetails);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            try
            {
                 _roleRepository.Update(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteRole = _roleRepository.Get(id);
            return View(deleteRole);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
              _roleRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
