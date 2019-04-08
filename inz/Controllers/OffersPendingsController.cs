using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inz.Models;

namespace inz.Controllers
{
    public class OffersPendingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "Admin, Firm, Scientist, Agent")]
        // GET: OffersPendings
        public ActionResult Index()
        {
            return View(db.OffersPendings.ToList());
        }

        // GET: OffersPendings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersPending offersPending = db.OffersPendings.Find(id);
            if (offersPending == null)
            {
                return HttpNotFound();
            }
            return View(offersPending);
        }

        // GET: OffersPendings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OffersPendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,OfferFrom,Agent,Taken,Description,OfferID,AgentID")] OffersPending offersPending)
        {
            if (ModelState.IsValid)
            {
                db.OffersPendings.Add(offersPending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offersPending);
        }

        // GET: OffersPendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersPending offersPending = db.OffersPendings.Find(id);
            if (offersPending == null)
            {
                return HttpNotFound();
            }
            return View(offersPending);
        }

        // POST: OffersPendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,OfferFrom,Agent,Taken,Description,OfferID,AgentID")] OffersPending offersPending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offersPending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offersPending);
        }

        // GET: OffersPendings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffersPending offersPending = db.OffersPendings.Find(id);
            if (offersPending == null)
            {
                return HttpNotFound();
            }
            return View(offersPending);
        }

        // POST: OffersPendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffersPending offersPending = db.OffersPendings.Find(id);
            db.OffersPendings.Remove(offersPending);
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
