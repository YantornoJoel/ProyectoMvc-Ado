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
    [AuthorizeUserRol(roles:"Admin")]
    public class AdminController : Controller
    {
       
        // GET: Admin
        public ActionResult Index() { 
        

            return View();
        }

        public ActionResult Usuarios()
        {


            return View();
        }
    }
}