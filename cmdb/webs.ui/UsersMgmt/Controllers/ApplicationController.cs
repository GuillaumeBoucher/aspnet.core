using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersMgmt.Controllers
{
    public class ApplicationController : Controller
    {

        [Route("Application/load")]
        [HttpGet]
        [HttpPost]
        public ActionResult Load()
        {
            var jsonResult = new { Id = "1", Nom = "Scott", Prenom = "adn" };
            return Json(jsonResult);
        }
        
        // GET: Application
        public ActionResult Index()
        {


            return View();
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Application/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}