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
    public class Uph_offerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Uph_offer
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var uph_offer = db.Uph_offer.Include(u => u.Categories);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            ViewBag.SureNameSortParm = String.IsNullOrEmpty(sortOrder) ? "surename_desc" : "surename_asc";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;



            if (!String.IsNullOrEmpty(searchString))
            {
                uph_offer = uph_offer.Where(u => u.Title.Contains(searchString)
                                       || u.Author.Contains(searchString)
                                       || u.Department.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    uph_offer = uph_offer.OrderByDescending(u => u.Title);
                    break;
                case "name_asc":
                    uph_offer = uph_offer.OrderBy(u => u.Title);
                    break;
                case "surename_desc":
                    uph_offer = uph_offer.OrderByDescending(u => u.Author);
                    break;
                default:
                    uph_offer = uph_offer.OrderBy(u => u.Author);
                    break;
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(uph_offer.ToPagedList(pageNumber, pageSize));





        }

        // GET: Uph_offer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uph_offer uph_offer = db.Uph_offer.Find(id);
            if (uph_offer == null)
            {
                return HttpNotFound();
            }
            return View(uph_offer);
        }

        // GET: Uph_offer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uph_offer/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ImgName,Date,Author,Department,Aiddtional_information")] Uph_offer uph_offer, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {
                UpdateModel(uph_offer);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    uph_offer.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/")+uph_offer.ImgName);


                }


                    db.Uph_offer.Add(uph_offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uph_offer);
        }

        // GET: Uph_offer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uph_offer uph_offer = db.Uph_offer.Find(id);
            if (uph_offer == null)
            {
                return HttpNotFound();
            }
            return View(uph_offer);
        }

        // POST: Uph_offer/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ImgName,Date,Author,Department,Aiddtional_information")] Uph_offer uph_offer, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {
                UpdateModel(uph_offer);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    uph_offer.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/") + uph_offer.ImgName);


                }


                db.Entry(uph_offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uph_offer);
        }

        // GET: Uph_offer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uph_offer uph_offer = db.Uph_offer.Find(id);
            if (uph_offer == null)
            {
                return HttpNotFound();
            }
            return View(uph_offer);
        }

        // POST: Uph_offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uph_offer uph_offer = db.Uph_offer.Find(id);
            db.Uph_offer.Remove(uph_offer);
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
