using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class aboutController : Controller
    {
        // GET: about
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
    }
}