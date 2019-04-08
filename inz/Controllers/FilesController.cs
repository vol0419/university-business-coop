using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inz.Models;

namespace inz.Controllers
{
    public class FilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Files
        [Authorize(Roles = "Admin, Agent")]

        public ActionResult Index()
        {
            return View(db.Files.ToList());
        }

        // GET: Files/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inz.Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            string virtualFilePath = "~/App_Data/uploads/"+file.Path.ToString();
            return File(virtualFilePath, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(virtualFilePath));
            //return View(file);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Path,ProjectID ")] inz.Models.File file, HttpPostedFileBase UserFile, string projID)
        {
            if (ModelState.IsValid)
            {

                if (UserFile != null && UserFile.ContentLength > 0)
                {
                    //file.ProjectID = Int32.Parse(Request.Params["ProjectID"]);
                    file.ProjectID = Int32.Parse(projID);
                    // extract only the filename
                    var fileName = Path.GetFileName(UserFile.FileName);

                    var temp = db.Files
                            .Where(x => x.Path == fileName)
                            .Select(x => x.Path)
                            .FirstOrDefault();

                    int count = 0;
                    while( temp != null )
                    {
                        Random rand = new Random();
                        int num = rand.Next(1, 99);
                        fileName = num.ToString() + "-" + fileName;

                        temp = db.Files
                            .Where(x => x.Path == fileName)
                            .Select(x => x.Path)
                            .FirstOrDefault();
                        count++;
                        if(count >= 100)
                        {
                            return RedirectToAction("Index");
                        }
                    }

                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    UserFile.SaveAs(path);

                    file.Date = DateTime.Now;
                    file.Path = fileName;
                    
                    db.Files.Add(file);
                    db.SaveChanges();
                }
                // redirect back to the index action to show the form once again
                return RedirectToAction("../Projects/Details/" + file.ProjectID);
            }

            return RedirectToAction("../Projects/Details/" + file.ProjectID);
        }

        // GET: Files/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inz.Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Path")] inz.Models.File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(file);
        }

        // GET: Files/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inz.Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inz.Models.File file = db.Files.Find(id);
            db.Files.Remove(file);
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
