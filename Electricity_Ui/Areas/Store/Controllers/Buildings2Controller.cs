using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectricityProject.DataLayer.DbLayer;
using Electricity_Ui.Models;

namespace Electricity_Ui.Areas.Store.Controllers
{
    public class Buildings2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Store/Buildings
        public ActionResult Index()
        {
            var buildings = db.Buildings.Include(b => b.AddressPlan).Include(b => b.TypeBuilding);
            return View(buildings.ToList());
        }

        // GET: Store/Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: Store/Buildings/Create
        public ActionResult Create()
        {
            ViewBag.AddressPlanId = new SelectList(db.AddressPlans, "AddressPlanId", "House");
            ViewBag.TypeBuildingId = new SelectList(db.TypeBuildings, "TypeBuildingId", "TypeBuildingName");
            return View();
        }

        // POST: Store/Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingId,AddressPlanId,TypeBuildingId,YearConstruction,CountFloors,SerialBuilding,MaterialsWall,MaterialsWallString,IsAccounting,IsPlumbing,IsSewerage,IsHeating,IsHotWater,IsGas,Balanse,Iznos")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressPlanId = new SelectList(db.AddressPlans, "AddressPlanId", "House", building.AddressPlanId);
            ViewBag.TypeBuildingId = new SelectList(db.TypeBuildings, "TypeBuildingId", "TypeBuildingName", building.TypeBuildingId);
            return View(building);
        }

        // GET: Store/Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressPlanId = new SelectList(db.AddressPlans, "AddressPlanId", "House", building.AddressPlanId);
            ViewBag.TypeBuildingId = new SelectList(db.TypeBuildings, "TypeBuildingId", "TypeBuildingName", building.TypeBuildingId);
            return View(building);
        }

        // POST: Store/Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingId,AddressPlanId,TypeBuildingId,YearConstruction,CountFloors,SerialBuilding,MaterialsWall,MaterialsWallString,IsAccounting,IsPlumbing,IsSewerage,IsHeating,IsHotWater,IsGas,Balanse,Iznos")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressPlanId = new SelectList(db.AddressPlans, "AddressPlanId", "House", building.AddressPlanId);
            ViewBag.TypeBuildingId = new SelectList(db.TypeBuildings, "TypeBuildingId", "TypeBuildingName", building.TypeBuildingId);
            return View(building);
        }

        // GET: Store/Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Store/Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
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
