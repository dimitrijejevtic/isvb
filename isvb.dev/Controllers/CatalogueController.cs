using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using isvb.dev;
using isvb.dev.ViewModels;
using isvb.dev.ViewModels.Enums;

namespace isvb.dev.Controllers
{
    
    public class CatalogueController : Controller
    {
        private EFModelContainer db = new EFModelContainer();

        // GET: Catalogue
        [AllowAnonymous]
        public ActionResult Index()
        {
            CatalogViewModel catalog;
            var products = db.Products.ToList();
            List<CatalogViewModel> catalogs = new List<CatalogViewModel>();
            foreach (var product in products)
            {
                
                catalog = new CatalogViewModel();
                catalog.File = db.Files.SingleOrDefault(x => x.ProductId == product.ProductId);
                catalog.Price = product.Price;
                catalog.Name = product.Name;
                catalog.ProductId = product.ProductId;
                catalog.LatName = product.LatName;
                catalogs.Add(catalog);
            }
            return View(catalogs);
        }

        // GET: Catalogue/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Include(x=>x.Files).SingleOrDefault(x=>x.ProductId==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [Authorize(Roles ="Administrator, Owner")]
        // GET: Catalogue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Owner")]
        public ActionResult Create([Bind(Include = "ProductId,Name,LatName,Price")] Product product, HttpPostedFileBase upload)
        {
            try {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var img = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType,
                            FileType =(int) ViewModels.Enums.FileType.Cover
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            img.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        product.Files = new List<File> { img };
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                ModelState.AddModelError("", "Unable  to save changes.");
            }
                return View(product);
            
        }

        // GET: Catalogue/Edit/5
        [Authorize(Roles = "Administrator, Owner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Catalogue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Owner")]
        public ActionResult Edit([Bind(Include = "ProductId,Name,LatName,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Catalogue/Delete/5
        [Authorize(Roles = "Administrator, Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Catalogue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Owner")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
