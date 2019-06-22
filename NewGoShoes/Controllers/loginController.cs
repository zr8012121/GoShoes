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
        public ActionResult Register()
        {

            return View();
        }


        //登陆判断用户
        [HttpPost]
        public JsonResult loginIsOk(string name, string pwd)
        {
            GoShoesDBEntities db = new GoShoesDBEntities();
            var s = db.T_user.Where(c => c.userName == name).FirstOrDefault();

            var obj = new
            {
                msg = "登陆成功",
                code = 200,

            };

            if (s == null)
            {
                obj = new
                {
                    msg = "用户不存在",
                    code = 201
                };
                return Json(obj);
            }

            if (s.userPassword != pwd)
            {
                obj = new
                {
                    msg = "密码错误",
                    code = 202
                };
                return Json(obj);
            }


            if (s.userClose == 1)
            {
                obj = new
                {
                    msg = "用户被封禁",
                    code = 203
                };
                return Json(obj);
            }

            if (s.userPowerId == 1)
            {
                obj = new
                {
                    msg = "管理员登陆",
                    code = 204
                };
                return Json(obj);
            }


            HttpContext.Cache["c_User"] = s;

            return Json(obj);
        }


        //注册用户
        [HttpPost]
        public JsonResult userRegister(string name, string pwd, string rePwd)
        {
            //var s = new
            //{
            //    userName = name,
            //    userPassword = pwd,
            //    userPowerId = 2,
            //    userClose = 0
            //};

            var obj = new
            {
                msg = "注册失败",
                code = 201
            };

            if (string.IsNullOrEmpty(name))
            {
                obj = new
                {
                    msg = "用户名不能为空",
                    code = 203
                };
                return Json(obj);
            }
            if (string.IsNullOrEmpty(pwd))
            {
                obj = new
                {
                    msg = "密码不能为空",
                    code = 204
                };
                return Json(obj);
            }


            if (string.IsNullOrEmpty(rePwd))
            {
                obj = new
                {
                    msg = "再次输入密码不能为空",
                    code = 205
                };
                return Json(obj);
            }
            if (pwd != rePwd)
            {
                obj = new
                {
                    msg = "两次输入密码不一样",
                    code = 206
                };
                return Json(obj);
            }
            GoShoesDBEntities db = new GoShoesDBEntities();
            var abc = db.T_user.Where(c => c.userName == name).FirstOrDefault();
            if (abc != null)
            {
                obj = new
                {
                    msg = "注册失败，用户存在",
                    code = 202
                };
                return Json(obj);
            }
            T_user s = new T_user();
            s.userName = name;
            s.userPassword = pwd;
            s.userPowerId = 2;
            s.userClose = 0;
            db.T_user.Add(s);
            int rs = db.SaveChanges();

            if (rs > 0) obj = new { msg = "注册成功", code = 200 };

             var ss = db.T_user.Where(c => c.userName == s.userName).FirstOrDefault();

            HttpContext.Cache["c_User"] = s;

            return Json(obj);
        }

    }
}