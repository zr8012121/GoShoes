using NewGoShoes.Models;
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


        //登陆页面
        public ActionResult login()
        {
            return View();
        }

        //注册页面
        public ActionResult Register() {

            return View();
        }


        //登陆判断用户
        [HttpPost]
        public JsonResult loginIsOk(string name, string pwd) {
            GoShoesDBEntities db = new GoShoesDBEntities();
            var s = db.T_user.Where(c => c.userName == name).FirstOrDefault();
            var obj = new {
                msg="登陆成功",
                code=200
            };

            if (s == null) {
                obj = new {
                    msg="用户不存在",
                    code=201
                };
                return Json(obj);
            }

            if (s.userPassword != pwd) {
                obj = new
                {
                    msg = "密码错误",
                    code = 202
                };
                return Json(obj);
            }
            return Json(obj);
        }

    }
}