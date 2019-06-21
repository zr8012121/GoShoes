using NewGoShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class userManageController : Controller
    {
        // GET: userManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult userManage()
        {
            return View();
        }


        //获取所有用户数据
        public JsonResult GetList() {
            GoShoesDBEntities db = new GoShoesDBEntities();
            var ss = db.T_user.ToList().Select(c => new {
                uid=c.userId,
                uname=c.userName,
                upwd=c.userPassword,
                uclose=c.userClose,
                upower=c.T_userType.userPowerName
            });


            return Json(ss, JsonRequestBehavior.AllowGet);
        }


        //用户封禁
        [HttpPost]
        public JsonResult Ban(int uid) {
            GoShoesDBEntities db = new GoShoesDBEntities();

            var s = db.T_user.Where(c => c.userId == uid).FirstOrDefault();

            if (s.userClose == 1) {

                s.userClose = 0;
                var obj2 = new { msg = "解封失败", code = 203 };
                
                int rs2 = db.SaveChanges();

                

                if (rs2 > 0)
                {
                    obj2 = new { msg = "解封成功", code = 204 };
                }

                return Json(obj2);

            }
            

            s.userClose = 1;

            
            int rs = db.SaveChanges();

            var obj = new {msg="封禁失败",code=201 };

            if (rs > 0) {
                 obj = new { msg = "封禁成功", code = 200 };
            }

            return Json(obj);
        }


    }
}