using isvb.dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using isvb.dev.ViewModels;
using System.Net;

namespace isvb.dev.Controllers
{
    [Authorize(Roles ="Administrator, Owner")]
    public class DashboardController : Controller
    {
        private EFModelContainer myContext = new EFModelContainer();
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var dump = db.Users.ToList();
            var dump2 = myContext.Users.ToList();
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (ApplicationUser user in dump)
            {
                //index of Name will be identical when the database is cleared and repopulated
                var matchingUser = dump2.FirstOrDefault(x => x.Email == user.Email);
                string name="";
                if (matchingUser != null)
                    name = matchingUser.Name;
                users.Add(new UserViewModel { Id = user.Id, Email = user.Email, Name = name,UserName=user.UserName,EmailConfirmed=user.EmailConfirmed,PhoneNumber=user.PhoneNumber, PhoneNumberConfirmed=user.PhoneNumberConfirmed,LockoutEndDateUtc=user.LockoutEndDateUtc,AccessFailedCount=user.AccessFailedCount });
            }
            return View(users);
        }

        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            var myUser = myContext.Users.FirstOrDefault(x => x.Email == user.Email);
            string name = "";
            if (myUser!=null)
                name = myUser.Name;
            return View(new UserViewModel { Id = user.Id, Email = user.Email, Name =name, UserName = user.UserName, EmailConfirmed = user.EmailConfirmed, PhoneNumber = user.PhoneNumber, PhoneNumberConfirmed = user.PhoneNumberConfirmed, LockoutEndDateUtc = user.LockoutEndDateUtc, AccessFailedCount = user.AccessFailedCount });
        }

        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            //firstordefault
            var myUser = myContext.Users.FirstOrDefault(x=>x.Email==user.Email);
            string name = "";
            if (myUser!=null)
                name = myUser.Name;
            return View(new UserViewModel { Id = user.Id, Email = user.Email, Name = name, UserName = user.UserName, EmailConfirmed = user.EmailConfirmed, PhoneNumber = user.PhoneNumber, PhoneNumberConfirmed = user.PhoneNumberConfirmed, LockoutEndDateUtc = user.LockoutEndDateUtc, AccessFailedCount = user.AccessFailedCount });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Email, Name, UserName, EmailConfirmed, PhoneNumber, PhoneConfirmed, LockoutEndDateUtc, AccessFailedCount")] UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = db.Users.Find(userVM.Id);
                user.Email = userVM.Email;
                user.UserName = userVM.UserName;
                user.EmailConfirmed = userVM.EmailConfirmed;
                user.PhoneNumber = userVM.PhoneNumber;
                user.PhoneNumberConfirmed = userVM.PhoneNumberConfirmed;
                user.LockoutEndDateUtc = userVM.LockoutEndDateUtc;
                user.AccessFailedCount = userVM.AccessFailedCount;
                var user2 = myContext.Users.Find(user.Email);
                user2.Name = userVM.Name;
                user2.Email = userVM.Email;
                db.Entry(user).State = EntityState.Modified;
                myContext.Entry(user2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userVM);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                myContext.Dispose();
            }
            base.Dispose(disposing);

        }

    }
}