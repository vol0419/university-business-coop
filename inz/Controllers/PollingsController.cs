using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using inz.Models;
using inz.DAL;
using PagedList;
using System.Web;

namespace inz.Controllers
{
    public class PollingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pollings
        public ActionResult Index()
        {
            return View(db.Pollings.ToList());
        }

        // GET: Pollings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polling polling = db.Pollings.Find(id);
            if (polling == null)
            {
                return HttpNotFound();
            }
            return View(polling);
        }

        // GET: Pollings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pollings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,FormLink")] Polling polling)
        {
            if (ModelState.IsValid)
            {
                db.Pollings.Add(polling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polling);
        }

        // GET: Pollings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polling polling = db.Pollings.Find(id);
            if (polling == null)
            {
                return HttpNotFound();
            }
            return View(polling);
        }

        // POST: Pollings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,FormLink")] Polling polling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(polling);
        }

        // GET: Pollings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polling polling = db.Pollings.Find(id);
            if (polling == null)
            {
                return HttpNotFound();
            }
            return View(polling);
        }

        // POST: Pollings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Polling polling = db.Pollings.Find(id);
            db.Pollings.Remove(polling);
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
