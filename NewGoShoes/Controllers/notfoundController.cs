using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class notfoundController : Controller
    {
        // GET: notfound
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult notfound()
        {
            return View();
        }
    }
}