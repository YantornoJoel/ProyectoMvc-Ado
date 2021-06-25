using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.FilterAuth;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BL;
using WebApplication1.FilterSession;

namespace WebApplication1.Controllers
{
    [AuthorizeUserRol(roles: "admin")]
    public class AdminController : Controller
    {
        private readonly BL.UserBL userBL = new BL.UserBL();
        
        public ActionResult Index()
        {
            
            var model = userBL.List();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var validate = userBL.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Modify(int id)
        {
            var model = userBL.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(ET.User model)
        {

            var validate = userBL.Modify(model);

            return RedirectToAction("Index", "Admin");
        }
    }

}