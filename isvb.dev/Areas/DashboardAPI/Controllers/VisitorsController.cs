using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using isvb.dev;
using isvb.dev.Models;
using isvb.dev.ViewModels;

namespace isvb.dev.Areas.DashboardAPI.Controllers
{
    [APIAuthorize(Roles = "Administrator, Owner")]
    public class VisitorsController : ApiController
    {
        private EFModelContainer db = new EFModelContainer();

        // GET: api/Visitors
        public IQueryable<Visitor> GetVisitors()
        {
            VisitorsCountViewModel count;
            var visitors = db.Visitors.ToList();
            List<VisitorsCountViewModel> counts = new List<VisitorsCountViewModel>();

            foreach (var visitor in visitors)
            {
                count = new VisitorsCountViewModel();
                count.Date = DateTime.Parse(visitor.Time);
                if ((DateTime.Now - count.Date).TotalDays > 7) break;
                if (counts.Contains(count)) break; //necu ovo, samo datum da proverava da li postoji u listi vec
                int pom = 0;
                foreach (var v in visitors)
                {
                    if (DateTime.Parse(v.Time) == count.Date) pom++;
                }
                count.Count = pom;
                counts.Add(count);
            }
            return db.Visitors; //catalogs but nece
        }
        [HttpGet]
        [Route("DashboardAPI/CountVisitors")]
        public IHttpActionResult GetTotalVisitors()
        {
            return Ok(db.Visitors.Count());
        }
        // GET: api/Visitors/5
        [ResponseType(typeof(Visitor))]
        public IHttpActionResult GetVisitor(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return NotFound();
            }

            return Ok(visitor);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitorExists(int id)
        {
            return db.Visitors.Count(e => e.VisitorId == id) > 0;
        }
    }
}