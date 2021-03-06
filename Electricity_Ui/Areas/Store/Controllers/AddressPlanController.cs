﻿using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Electricity_Ui.Areas.Store.Controllers
{
    public class AddressPlanController : Controller
    {
        // GET: Store/AdressPlan
        public ActionResult Index()
        {
            return View();
        }
        IGenericRepository<AddressPlan> adrPlan;
         IGenericRepository<Street> street;
         IGenericRepository<Subdivision> subdivision;

        public AddressPlanController(
            IGenericRepository<AddressPlan> adrPlan, 
            IGenericRepository<Street> street, 
            IGenericRepository<Subdivision> subdivision)
        {
            this.street = street;
            this.subdivision = subdivision;
            this.adrPlan = adrPlan;
        }
        //GET: Store/Auto/TableEdit/AddressPlan
        public ActionResult IndexTable(string TableName = "AddressPlan")
        {
            var model = adrPlan.GetAll();
            return View(model);
        }

        // GET: Store/AddressPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var addressPlan = adrPlan.Get((int)id);
            if (addressPlan == null)
            {
                return HttpNotFound();
            }
            return View(addressPlan);
        }
        // GET: Store/AddressPlans/Create
        public ActionResult Create()
        {
            //  var addressPlan = adrPlan.GetAll();
            // var street = new IGenericRepository<Street>;
             ViewBag.StreetId = new SelectList(street.GetAll(), "StreetId", "StreetName");
            ViewBag.SubdivisionId = new SelectList(subdivision.GetAll(), "SubdivisionId", "SubdivisionName");
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
                adrPlan.AddOrUpdate(addressPlan);
                // adrPlan.SaveChanges();
                return RedirectToAction("IndexTable");
            }

            ViewBag.StreetId = new SelectList(street.GetAll(), "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(subdivision.GetAll(), "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
            return View(addressPlan);
        }


        // GET: Store/AddressPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressPlan addressPlan = adrPlan.Get((int)id);
            if (addressPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.StreetId = new SelectList(street.GetAll(), "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(subdivision.GetAll(), "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
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
                // addressPlan.Entry(addressPlan).State = EntityState.Modified;
                adrPlan.AddOrUpdate(addressPlan);
                return RedirectToAction("IndexTable");
            }
            ViewBag.StreetId = new SelectList(street.GetAll(), "StreetId", "StreetName", addressPlan.StreetId);
            ViewBag.SubdivisionId = new SelectList(subdivision.GetAll(), "SubdivisionId", "SubdivisionName", addressPlan.SubdivisionId);
            return View(addressPlan);
        }

        // GET: Store/AddressPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AddressPlan addressPlan = adrPlan.Get((int)id);
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
            AddressPlan addressPlan = adrPlan.Get((int)id);
            adrPlan.Delete(addressPlan);
            return RedirectToAction("IndexTable");
        }
    }
}