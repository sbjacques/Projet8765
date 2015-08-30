using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using System.IO;

namespace Form115.Areas.Admin.Controllers
{
    [Authorize (Roles="Admin")]
    public class HotelsController : Controller
    {

        private Form115Entities db = new Form115Entities();

        // GET: Admin/Hotels
        public ActionResult Index()
        {
            var hotels = db.Hotels.Include(h => h.Villes);
            return View(hotels.OrderBy(h=>h.IdHotel).ToList());
        }

        // GET: Admin/Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // GET: Admin/Hotels/Create
        public ActionResult Create()
        {
            ViewBag.IdVille = new SelectList(db.Villes.OrderBy(h =>h.name), "idVille", "name");
            return View();
        }

        // POST: Admin/Hotels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHotel,IdVille,Categorie,Description,Photo,Nom")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                
                db.Hotels.Add(hotels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdVille = new SelectList(db.Villes, "idVille", "name", hotels.IdVille);
            return View(hotels);
        }

        // GET: Admin/Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdVille = new SelectList(db.Villes, "idVille", "name", hotels.IdVille);
            return View(hotels);
        }

        // POST: Admin/Hotels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHotel,IdVille,Categorie,Description,Photo,Nom")] Hotels hotels)
        {

            if (ModelState.IsValid)
            {
                db.Entry(hotels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdVille = new SelectList(db.Villes, "idVille", "name", hotels.IdVille);
            return View(hotels);
        }

        // GET: Admin/Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Admin/Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotels hotels = db.Hotels.Find(id);
            db.Hotels.Remove(hotels);
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

        [HttpPost]
        public ActionResult PhotoHotel(HttpPostedFileBase postedFile)
        {
            if (postedFile == null || postedFile.ContentLength <= 0)
            {
                return RedirectToAction("Index");
            }

            var fileName = Path.GetFileName(postedFile.FileName);

            if (fileName == null)
            {
                return RedirectToAction("");
            }

            var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
            postedFile.SaveAs(path);
            return RedirectToAction("Index", "Hotel");
        }
    }
}
