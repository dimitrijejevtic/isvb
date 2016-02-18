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
using isvb.dev.Models;

namespace isvb.dev.Controllers
{
    [APIAuthorize(Roles = "Administrator, Owner, Customer")]
    public class CartsController : Controller
    {

        private EFModelContainer db = new EFModelContainer();

        // GET: Carts
        public ActionResult MyCart()
        {
            var user = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
            var myCart = user.Cart;
            var items = myCart.CartItems;
            return View(items);
            
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
            var tempCartItem = user.Cart.CartItems.FirstOrDefault(x => x.Product.ProductId == id);
            if (tempCartItem == null)
            {
                tempCartItem = new CartItem { Product = product, Quantity = quant };
            }
            else
            {
                tempCartItem.Quantity += quant;
            }            
            user.Cart.CartItems.Add(tempCartItem);
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
