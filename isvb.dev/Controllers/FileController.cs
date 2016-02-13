using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isvb.dev.Controllers
{
    public class FileController : Controller
    {
        private EFModelContainer db = new EFModelContainer();
        // GET: Image
        public ActionResult Index(int id)
        {
            var retrievedFile = db.Files.Find(id);
            return File(retrievedFile.Content, retrievedFile.ContentType);
        }
    }
}