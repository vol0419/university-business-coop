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
    public class ScientistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scientists
        [Authorize(Roles = "Admin")]
      
    
 
        public ActionResult Index()
        {
            return View(db.Scientists.ToList());
        }

        // GET: Scientists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scientist scientist = db.Scientists.Find(id);
            if (scientist == null)
            {
                return HttpNotFound();
            }
            return View(scientist);
        }

        // GET: Scientists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scientists/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Title,Department,Mail,Phone,City,ImgName, UserID")] Scientist scientist, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {
                UpdateModel(scientist);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    scientist.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/") + scientist.ImgName);


                }

                db.Scientists.Add(scientist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scientist);
        }

        // GET: Scientists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scientist scientist = db.Scientists.Find(id);
            if (scientist == null)
            {
                return HttpNotFound();
            }
            return View(scientist);
        }

        // POST: Scientists/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Title,Department,Mail,Phone,City,ImgName")] Scientist scientist, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {

                UpdateModel(scientist);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    scientist.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/") + scientist.ImgName);


                }

                db.Entry(scientist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scientist);
        }

        // GET: Scientists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scientist scientist = db.Scientists.Find(id);
            if (scientist == null)
            {
                return HttpNotFound();
            }
            return View(scientist);
        }

        // POST: Scientists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scientist scientist = db.Scientists.Find(id);
            db.Scientists.Remove(scientist);
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
