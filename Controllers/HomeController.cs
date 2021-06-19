using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.FilterAuth;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        private BL.UserBL userBL = new BL.UserBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //PUT- ALTA USUARIOS
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
    

            [HttpPost]
            public ActionResult Contact(ET.User user)
            {
                userBL.Insert(user);
                return View();
            }

        
    }
}