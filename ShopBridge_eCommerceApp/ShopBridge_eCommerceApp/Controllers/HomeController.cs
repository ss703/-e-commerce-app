using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge_eCommerceApp.Models;

namespace ShopBridge_eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        ThinkBridgeEntities db1 = new ThinkBridgeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(ProductAdminLogin tb1)
        {
           
            var check = db1.ProductAdminLogins.Where(x => x.Name.Equals(tb1.Name) && x.Password.Equals(tb1.Password)).FirstOrDefault();
            if (check != null)
            {
                Session["Username"] = tb1.Name.ToString();
                Session["Password"] = tb1.Password.ToString();
                ViewBag.name = Session["Username"];

                return RedirectToAction("index");
            }
            else
            {
                Response.Write("Invalid Name or password!!!");
            }

            return View();

        }
    }
}