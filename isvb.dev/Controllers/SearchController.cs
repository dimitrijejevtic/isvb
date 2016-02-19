using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isvb.dev.Controllers
{
    public class SearchController : Controller
    {
        private EFModelContainer db = new EFModelContainer();
        // GET: Search
        public ActionResult Index(string text)
        {
            var products = db.Products.ToList();
            List<Product> resultP = new List<Product>();
            foreach (Product p in products) {
                if (p.Name.IndexOf(text) != -1) {
                    resultP.Add(p);
                }                                                 
            }
            return View(resultP);
        }
    }
}