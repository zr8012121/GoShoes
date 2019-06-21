using NewGoShoes.Content;
using NewGoShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGoShoes.Controllers
{
    public class buyCarController : Controller
    {
        // GET: buyCar
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult cart()
        {
            return View();
        }
        public ActionResult foot()
        {
            return View();
        }

        public ActionResult head()
        {
            return View();
        }


        //头部
        public ActionResult goShoesHead()
        {
            return View();
        }

        //foot
        public ActionResult goShoesFoot()
        {
            return View();
        }



        //获取购物车数据
        public JsonResult GetBuyCar()
        {
            GoShoesDBEntities db = new GoShoesDBEntities();

            var ss = db.T_buyCar.ToList().Select(c => new
            {
                shoesId = c.shoesId,
                carNum = c.carNum,
                shoesImg = c.shoesImg,
                shoesPrices = c.shoesPrices,
                carSelfId = c.carSelfId
            });

            List<carNode> all = new List<carNode>();
            //取出所有购物车的鞋
            foreach (var item in ss)
            {
                //获取鞋名
                var name = db.T_shoes.Where(c => c.shoesId == item.shoesId).FirstOrDefault().shoesName;
                //获取鞋介绍
                var js = db.T_shoes.Where(c => c.shoesId == item.shoesId).FirstOrDefault().shoesInfo;
                carNode one = new carNode();
                one.count = item.carNum;
                one.img = item.shoesImg;
                one.jieshao = js;
                one.price = Convert.ToInt32(item.shoesPrices);
                one.sum = one.price * one.count;
                one.static1 = "可购买";
                all.Add(one);
            }


            return Json(all, JsonRequestBehavior.AllowGet);
        }


        //提交订单去结账
        public JsonResult endAll() {
            var c_user = HttpContext.Cache["c_User"] as T_user;
            var uid = c_user.userId;

            GoShoesDBEntities db = new GoShoesDBEntities();

          var ss=  db.T_buyCar.Where(c => c.userId == uid).ToList();

            foreach (var item in ss)
            {
                db.T_buyCar.Remove(item);
            }

            int rs = db.SaveChanges();
            var obj = new {
                msg= "提交失败",
                code=201
            };

            if (rs > 0) {
                obj = new {
                    msg="提交成功",
                    code=201
                };
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //测试返回购物车数据
        public JsonResult getlist()
        {
            List<carNode> all = new List<carNode>();
            carNode a = new carNode();
            a.img = "images/cart/item1.jpg";
            a.jieshao = "欢乐空间量贩式KTV：欢唱套餐2选1，国家法定节假日需到店另付20元，可升级";
            a.static1 = "可购买";
            a.price = 39;
            a.sum = 39;
            a.static1 = "可购买";
            all.Add(a);

            return Json(all, JsonRequestBehavior.AllowGet);
        }


    }
}