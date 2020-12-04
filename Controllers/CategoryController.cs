using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExequteQuery.Models;

namespace ExequteQuery.Controllers
{
    public class CategoryController : Controller
    {
        private Context dbcontext = new Context();
        // GET: Properties
        public ActionResult Index()
        {
            
            var data = dbcontext.GetAllCategories();
            return View(data);
        }

        // GET: Properties/Details/5
        public ActionResult Details(string id)
        {
            var category = dbcontext.GetCategoryById(id);

            return View("Details",category);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                // TODO: Add insert logic here

                dbcontext.InsertCategory(collection);
                return RedirectToAction("Index", dbcontext.GetAllCategories());
            }
            catch
            {
                return View();
            }
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(string id)
        {
            var category = dbcontext.GetCategoryById(id);
            return View("Edit",category);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Category collection)
        {
            try
            {

                dbcontext.UpdateProduct(id,collection);
                return RedirectToAction("Index", dbcontext.GetAllCategories());
            
            }
            catch
            {
                return View();
            }
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(string id)
        {
            var category = dbcontext.GetCategoryById(id);
            return View("Delete", category);
        }

        // POST: Properties/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Category collection)
        {
            try
            {
                // TODO: Add delete logic here
                dbcontext.RemoveCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
