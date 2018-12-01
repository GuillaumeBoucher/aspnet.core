using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminLTEController : Controller
    {
        // GET: AdminLTE
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminLTE/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminLTE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLTE/Create
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

        // GET: AdminLTE/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminLTE/Edit/5
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

        // GET: AdminLTE/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminLTE/Delete/5
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