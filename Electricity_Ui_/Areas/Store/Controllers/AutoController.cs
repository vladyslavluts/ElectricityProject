using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Authorize]
    public class AutoController : Controller
    {
        // GET: Store/Auto
        public ActionResult Index()
        {
            return View();
        }
    }
}