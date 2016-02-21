using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isvb.dev.Controllers
{
    public class HomeController : Controller
    {
        private EFModelContainer db = new EFModelContainer();
        public ActionResult Index()
        {
            var posts = db.Posts.Take(5).ToList();
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}