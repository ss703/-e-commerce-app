using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
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
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

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
              //  ViewBag.name = Session["Username"];

                return RedirectToAction("Create", "ProductDetails");
            }
            else
            {
                Response.Write("Invalid Name or password!!!");
            }

            return View();

        }
        
        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }



    }
}


       
    