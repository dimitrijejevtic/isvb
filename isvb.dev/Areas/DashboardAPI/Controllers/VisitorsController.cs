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

namespace isvb.dev.Areas.DashboardAPI.Controllers
{
    [APIAuthorize(Roles = "Administrator, Owner")]
    public class VisitorsController : ApiController
    {
        private EFModelContainer db = new EFModelContainer();

        // GET: api/Visitors
        public IQueryable<Visitor> GetVisitors()
        {
            return db.Visitors;
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