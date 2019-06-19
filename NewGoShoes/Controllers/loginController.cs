using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult login()
        {
            return View();
        }

        public ActionResult Register() {

            return View();
        }

    }
}