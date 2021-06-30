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
        public ActionResult AddUser()
        {
            ET.User model = new ET.User();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(ET.User model)
        {
            var validate = userBL.Add(model.nombre, model.password, model.email, model.fecha, model.idRol);
            return View();
        }
        public ActionResult Delete(int id)
        {

            userBL.Delete(id);
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

            userBL.Modify(model);

            return RedirectToAction("Index", "Admin");
        }
    }

}