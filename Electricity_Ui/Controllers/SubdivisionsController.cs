using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectricityProject.DataLayer.DbLayer;

namespace Electricity_Ui.Controllers
{
    [Authorize(Roles = "admin")]

    public class SubdivisionsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Subdivisions
        public ActionResult Index()
        {
            return View(db.Subdivisions.ToList());
        }

        // GET: Subdivisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }

        // GET: Subdivisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subdivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                db.Subdivisions.Add(subdivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subdivision);
        }

        // GET: Subdivisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }

        // POST: Subdivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subdivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subdivision);
        }

        // GET: Subdivisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }

        // POST: Subdivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subdivision subdivision = db.Subdivisions.Find(id);
            db.Subdivisions.Remove(subdivision);
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
