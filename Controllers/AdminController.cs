using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.FilterAuth;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AuthorizeUserRol(roles:"admin")]
    public class AdminController : Controller
    {
        private usuario user;
        // GET: Admin
        public ActionResult Index()
        {
            user =(usuario)HttpContext.Session["User"];
            var rol = user.rol;
            ViewBag.userrol = rol;
            

            return View();
        }
    }
}