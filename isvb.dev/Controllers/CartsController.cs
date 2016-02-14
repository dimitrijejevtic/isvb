using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using isvb.dev;
using System.Threading.Tasks;

namespace isvb.dev.Controllers
{
    public class CartsController : Controller
    {

        private EFModelContainer db = new EFModelContainer();

        // GET: Carts
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
          
        public async Task<string> AddToCart(int? id,int quant)
        {
            //JavaScript should handle this
            if (id < 0 || id == null)
            {
                return "That product doesnt exist!";
            }
                       
            var user = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
            var product = db.Products.Find(id);
            var cartItem = new CartItem { Product = product, Quantity = quant };
            List<CartItem> items = new List<CartItem>();
            items.Add(cartItem);
            user.Cart.CartItems.Add(cartItem);
            db.SaveChanges();
            return "Product added!!";                           
        }     

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
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
