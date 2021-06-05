using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.FilterAuth;



namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //MENU ADMIN
        //RECIBE EL NUMERO DE OPERACION Y MUESTRA DISTINTOS MENUS
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeUser(idOperacion: 1002)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AuthorizeUser(idOperacion: 1003)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}