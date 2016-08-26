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
    public class TypeBuildingsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: TypeBuildings
        public ActionResult Index()
        {
            return View(db.TypeBuildings.ToList());
        }

        // GET: TypeBuildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBuilding typeBuilding = db.TypeBuildings.Find(id);
            if (typeBuilding == null)
            {
                return HttpNotFound();
            }
            return View(typeBuilding);
        }

        // GET: TypeBuildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeBuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeBuildingId,TypeBuildingName")] TypeBuilding typeBuilding)
        {
            if (ModelState.IsValid)
            {
                db.TypeBuildings.Add(typeBuilding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeBuilding);
        }

        // GET: TypeBuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBuilding typeBuilding = db.TypeBuildings.Find(id);
            if (typeBuilding == null)
            {
                return HttpNotFound();
            }
            return View(typeBuilding);
        }

        // POST: TypeBuildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeBuildingId,TypeBuildingName")] TypeBuilding typeBuilding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeBuilding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeBuilding);
        }

        // GET: TypeBuildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBuilding typeBuilding = db.TypeBuildings.Find(id);
            if (typeBuilding == null)
            {
                return HttpNotFound();
            }
            return View(typeBuilding);
        }

        // POST: TypeBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeBuilding typeBuilding = db.TypeBuildings.Find(id);
            db.TypeBuildings.Remove(typeBuilding);
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
