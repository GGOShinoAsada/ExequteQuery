using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExequteQuery.Models;

namespace ExequteQuery.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        static Context context = new Context();
        public ActionResult Index()
        {

            return View(context.GetAllProducts());
            
        }

    }
}