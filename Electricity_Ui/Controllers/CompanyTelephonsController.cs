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

    public class CompanyTelephonsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: CompanyTelephons
        public ActionResult Index()
        {
            return View(db.CompanyTelephons.ToList());
        }

        // GET: CompanyTelephons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTelephon companyTelephon = db.CompanyTelephons.Find(id);
            if (companyTelephon == null)
            {
                return HttpNotFound();
            }
            return View(companyTelephon);
        }

        // GET: CompanyTelephons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyTelephons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyTelephonId,CompanyId,Number,FullNumber,IsMain")] CompanyTelephon companyTelephon)
        {
            if (ModelState.IsValid)
            {
                db.CompanyTelephons.Add(companyTelephon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyTelephon);
        }

        // GET: CompanyTelephons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTelephon companyTelephon = db.CompanyTelephons.Find(id);
            if (companyTelephon == null)
            {
                return HttpNotFound();
            }
            return View(companyTelephon);
        }

        // POST: CompanyTelephons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyTelephonId,CompanyId,Number,FullNumber,IsMain")] CompanyTelephon companyTelephon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyTelephon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyTelephon);
        }

        // GET: CompanyTelephons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTelephon companyTelephon = db.CompanyTelephons.Find(id);
            if (companyTelephon == null)
            {
                return HttpNotFound();
            }
            return View(companyTelephon);
        }

        // POST: CompanyTelephons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyTelephon companyTelephon = db.CompanyTelephons.Find(id);
            db.CompanyTelephons.Remove(companyTelephon);
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
