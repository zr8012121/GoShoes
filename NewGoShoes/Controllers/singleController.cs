using NewGoShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class singleController : Controller
    {
        // GET: single
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult single()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCar(string shoesName,int shoesPrice, string shoesImg, int shoesNum) {

            var obj = new
            {
                msg = "添加购物车失败",
                code = 201
            };
            var user = HttpContext.Cache["c_User"] as T_user;
            var uid = user.userId;

            GoShoesDBEntities db = new GoShoesDBEntities();
            //用鞋名  查出鞋id
            var shoesId = db.T_shoes.Where(c => c.shoesName == shoesName).FirstOrDefault().shoesId;

            //看看购物车是否存在这鞋子
            var s = db.T_buyCar.Where(c => c.shoesId == shoesId).FirstOrDefault();
            if (s != null) {
                //如果有这个鞋子 那么久是加鞋数量
                s.carNum += shoesNum;
                s.shoesPrices += shoesPrice;
                int rs = db.SaveChanges();

                if (rs > 0) {
                    obj = new
                    {
                        msg = "添加购物成功",
                        code = 201
                    };
                   
                }//rs
                return Json(obj);
            }



            //如果没有这个鞋子
            T_buyCar car = new T_buyCar();
            car.carNum = shoesNum;
            car.shoesImg = shoesImg;
            car.shoesId = shoesId;
            car.shoesPrices = shoesPrice;
            car.userId = uid;

            db.T_buyCar.Add(car);

            int rs1 = db.SaveChanges();

            if (rs1 > 0)
            {
                obj = new
                {
                    msg = "添加购物车成功",
                    code = 200
                };

            }//rs

            return Json(obj);

        }
       


    }
}