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
    public class AddressPlans2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Store/AddressPlans
        public ActionResult Index()
        {
            var addressPlans = db.AddressPlans.Include(a => a.Street).Include(a => a.Subdivision);
            return View(addressPlans.ToList());
            // var model = db.AddressPlans.GetAll();
            // return View(model);
        }

        // GET: Store/AddressPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressPlan addressPlan = db.AddressPlans.Find(id);
            if (addressPlan == null)
            {
                return HttpNotFound();
            }
            return View(addressPlan);
        }

        // GET: Store/AddressPlans/Create
        public ActionResult Create()
        {
            ViewBag.StreetId = new SelectList(db.Streets, "StreetId", "StreetName");
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName");
            return View();
        }

        // POST: Store/AddressPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressPlanId,SubdivisionId,CompanyServiceId,StreetId,House,Latitude,Longitude,IsAccounting,CodePostal,remarks")] AddressPlan addressPlan)
        {
            if (ModelState.IsValid)
            {
                db.AddressPlans.Add(addressPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StreetId = new SelectList(db.Streets, "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
            return View(addressPlan);
        }

        // GET: Store/AddressPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressPlan addressPlan = db.AddressPlans.Find(id);
            if (addressPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.StreetId = new SelectList(db.Streets, "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
            return View(addressPlan);
        }

        // POST: Store/AddressPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressPlanId,SubdivisionId,CompanyServiceId,StreetId,House,Latitude,Longitude,IsAccounting,CodePostal,remarks")] AddressPlan addressPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StreetId = new SelectList(db.Streets, "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
            return View(addressPlan);
        }

        // GET: Store/AddressPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressPlan addressPlan = db.AddressPlans.Find(id);
            if (addressPlan == null)
            {
                return HttpNotFound();
            }
            return View(addressPlan);
        }

        // POST: Store/AddressPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressPlan addressPlan = db.AddressPlans.Find(id);
            db.AddressPlans.Remove(addressPlan);
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
