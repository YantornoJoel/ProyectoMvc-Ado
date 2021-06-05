﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string user, string password)
        {

            try
            {
                using (Models.MiSistemaEntities db = new Models.MiSistemaEntities())
                {
                    var queryUser = (from u in db.usuario
                                     where u.nombre == user && u.password == password
                                     select u).FirstOrDefault();
                    if (queryUser == null)
                    {

                        // FormsAuthentication.SetAuthCookie(queryUser.nombre, true);
                        //return RedirectToAction("Index", "Admin");
                        ViewBag.Error = "Usuario o contraseña invalida";

                        return View();
                    }

                    Session["User"] = queryUser;

                }

                return RedirectToAction("Index", "Admin");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }


        }
    }
}