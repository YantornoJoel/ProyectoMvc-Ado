using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ET;
using BL;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly BL.UserBL userBL = new BL.UserBL();
        //private readonly ET.User userET = new ET.User();

        // GET: Login
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            ET.User model = new ET.User();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(ET.User model)

        {

            var validate = userBL.Login(model.nombre, model.password);
            if (validate == false)
            {

                return RedirectToAction("Index", new { message = "Usuario y/o contraseña incorrectos" });

            }
            else
            {

                var userModel = userBL.Model(model.nombre, model.password);
                if (userModel.idRol == 1)
                {
                    Session["Admin"] = userModel;
                    return RedirectToAction("Index", "Admin");

                }
                else if (userModel.idRol == 2)
                {
                    Session["Student"] = userModel;
                    return RedirectToAction("Index", "Payment");

                }

                return View();


            }


            //if (ModelState.IsValid)
            //{

            //    try
            //    {
            //        string connectionstring = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            //        SqlConnection c = new SqlConnection();

            //        c.ConnectionString = connectionstring;


            //        c.Open();
            //        SqlCommand cm = new SqlCommand("SELECT * FROM usuario WHERE nombre = @nombre AND password = @password", c);
            //        cm.CommandType = CommandType.Text;
            //        cm.Parameters.AddWithValue("@nombre", model.nombre);
            //        cm.Parameters.AddWithValue("@password", model.password);
            //        cm.ExecuteNonQuery();
            //        SqlDataReader query = cm.ExecuteReader();
            //        query.Read();
            //        var rol = query.GetInt32(4);
            //        Console.WriteLine(rol);


            //        if (query != null)
            //        {
            //            if (rol == 1)
            //            {
            //                Session["Admin"] = model;
            //                return RedirectToAction("Index", "Admin");

            //            }
            //            else if (rol == 2)
            //            {
            //                Session["Student"] = model;
            //                return RedirectToAction("Index", "Payment");
            //            }
            //        }
            //        return View();
            //    }
            //    catch (Exception ex)
            //    {
            //        ViewBag.Error = ex.Message;
            //        return View();
            //    }
            //}
        }
    }
}