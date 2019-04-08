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
    public class OffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var Offers = db.Offers.Include(u => u.Categories);
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
                Offers = Offers.Where(u => u.Title.Contains(searchString)
                                       || u.Author.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    Offers = Offers.OrderByDescending(u => u.Title);
                    break;
                case "name_asc":
                    Offers = Offers.OrderBy(u => u.Title);
                    break;
                case "surename_desc":
                    Offers = Offers.OrderByDescending(u => u.Author);
                    break;
                default:
                    Offers = Offers.OrderBy(u => u.Author);
                    break;
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(Offers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ImgName,Date,Author")] Offer offer, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {




                UpdateModel(offer);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    offer.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/") + offer.ImgName);


                }



                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ImgName,Date,Author")] Offer offer, HttpPostedFileBase imgname)
        {
            if (ModelState.IsValid)
            {

                UpdateModel(offer);
                if (imgname != null && imgname.ContentLength > 0)
                {
                    offer.ImgName = imgname.FileName;
                    imgname.SaveAs(HttpContext.Server.MapPath("~/Images/") + offer.ImgName);


                }

                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offer);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
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
