using NewGoShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            //var user = HttpContext.Cache["c_User"] as T_user;
            //var uid = user.userId;

            return View();
        }
    }
}