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
namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private BL.UserBL userBL = new BL.UserBL();
        //private ET.User userET = new ET.User();
        
        // GET: Login
        public ActionResult Index()
        {
            return View(userBL.List());
        }
       [HttpPost] 
       public ActionResult Index(ET.User model)
       {
            //var nombre = model.nombre;
            //Console.WriteLine(nombre);
            
            //if (ModelState.IsValid)
            //{

            //    try
            //    {
            //        string connectionstring = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            //        SqlConnection c = new SqlConnection();

            //        c.ConnectionString = connectionstring;

               
            //        SqlCommand cm = new SqlCommand("SELECT * FROM usuario WHERE nombre = @nombre AND password = @password", c);
            //        cm.CommandType = CommandType.Text;
            //        cm.Parameters.AddWithValue("@nombre", model.nombre);
            //        cm.Parameters.AddWithValue("@password", model.password);
            //        c.Open();
            //        SqlDataReader query = cm.ExecuteReader();
            //        c.Close();
            //        var rol = query.GetInt32(5);
               
            //        if (query != null)
            //            {
            //                if(rol == 1)
            //                {
            //                    Session["Admin"] = query;
            //                    return RedirectToAction("Index", "Admin");

            //                }else if (rol == 2)
            //                {
            //                    Session["Student"] = query;
            //                    return RedirectToAction("Index", "Payment");
            //                }
            //            }
            //            return View();
            //    }
            //    catch(Exception ex)
            //    {
            //        ViewBag.Error = ex.Message;
            //        return View();
            //    }
            //}
                return View();
        }
    }
}