using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class shopController : Controller
    {
        // GET: shop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult shop()
        {
            return View();
        }
    }
}