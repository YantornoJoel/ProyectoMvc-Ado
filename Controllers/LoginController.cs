using System;
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
                using(Models.MiSistemaEntities db = new Models.MiSistemaEntities())
                {
                    var queryUser = (from u in db.usuario
                                     where u.nombre == user && u.password == password
                                     select u).FirstOrDefault();
                    var rol = queryUser.rol.id;

                    if(queryUser != null)
                    {
                        if(rol == 1)
                        {
                            Session["Admin"] = queryUser;
                            return RedirectToAction("Index", "Admin");

                        }else if (rol == 2)
                        {
                            Session["Student"] = queryUser;
                            return RedirectToAction("Index", "Payment");
                        }
                    }

                    return View();

                   

                    //var rol = db.rol.FirstOrDefault(x => x.id != queryUser.idRol);
                    //Console.WriteLine(rol);
                }

            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }
    }
}