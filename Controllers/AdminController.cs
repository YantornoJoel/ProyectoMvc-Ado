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



        //GET: Admin
        [HttpPost]
        public ActionResult Index(string selectupdate, string nomupdate, string emailupdate, string passupdate, DateTime fechaupdate, int idrolupdate)
        {
            try
            {


                //SqlConnection c = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = NSLP; Integrated Security = True");

                //string connectionstring = ConfigurationManager.ConnectionStrings["MiSistemaEntities"].ConnectionString;

                ////SqlConnection c = new SqlConnection();

                //c.ConnectionString = connectionstring;

                //using (Models.MiSistemaEntities u = new Models.MiSistemaEntities());

                //SqlCommand cm = new SqlCommand("sp_select_update", c);
                //cm.CommandType = CommandType.StoredProcedure;

                //cm.Parameters.Add("@name", SqlDbType.VarChar);


                ////cm.Parameters["@name"].Value = selectupdate;

                //c.Open();

                //cm.ExecuteNonQuery();
                ////mensajes al usuario de confirmacion

                //c.Close();

                return View();


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }

}