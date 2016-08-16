using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AddressPlanController(IGenericRepository<AddressPlan> adrPlan)
        {
            this.adrPlan = adrPlan;
        }
        //GET: Store/Auto/TableEdit/AddressPlan
        public ActionResult TableEdit(string TableName = "AddressPlan")
        {
            var model = adrPlan.GetAll();
            return View(model);
        }

    }
}