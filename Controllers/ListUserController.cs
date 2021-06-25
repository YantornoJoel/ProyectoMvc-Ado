using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;
using WebApplication1.database_access;
using System.Data.SqlClient;



namespace WebApplication1.Controllers
{
    public class ListUserController : Controller
    {
        // GET: ListUser
        db dbmostrar = new db();
        public ActionResult Show_data()
        {
            DataSet d = dbmostrar.Show_data();
            ViewBag.emp = d.Tables[0];
            return View();
        }

        [HttpGet]
        public ActionResult Show_user_by_id(int id)
        {
            DataSet a = dbmostrar.Show_user_by_id(id);

            //DataSet d = dbmostrar.Show_data(nom);
            ViewBag.emp = a.Tables[0];
            return View();



            //f["id"] = a.Tables[0].Rows[0][0].ToString();
            //f["nombre"] = a.Tables[0].Rows[0][0].ToString();
            //f["email"] = a.Tables[0].Rows[0][0].ToString();
            //f["password"] = a.Tables[0].Rows[0][0].ToString();
            //f["fecha"] = a.Tables[0].Rows[0][0].ToString();
            //f["idRol"] = a.Tables[0].Rows[0][0].ToString();



            //ViewBag.emp = a.Tables[0];
            
        }

        //public ActionResult Add_user()
        //{



        //    return View();
        //}
        [HttpPost]
        public ActionResult Add_user(FormCollection fc)
        {

            Usuario usua = new Usuario();
            //usua.id = int.Parse(fc["ID"]);
            usua.nombre = fc["nombre"];
            usua.email = fc["email"];
            usua.password = fc["Password"];
            usua.fecha = DateTime.Parse(fc["fecha"]);
            usua.idRol =  int.Parse(fc["idRol"]);
            dbmostrar.Add_user(usua);
            TempData["msg"] = "Usuario dado de alta con exito";

            return View();
        }
        //public ActionResult Update_user(int id)
        //{
        //    DataSet ds = dbmostrar.Show_user(id);
        //    ViewBag.emp = ds.Tables[2];
        //    return View();

        //}

        [HttpPost]

        public ActionResult Show_user_by_id(int id, string nom, string email, string pass, DateTime fecha, int idRol)
        {
            {
               try
                {

                    SqlConnection c = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = NSLP; Integrated Security = True");

                    //string connectionstring = ConfigurationManager.ConnectionStrings["MiSistemaEntities"].ConnectionString;
                    //SqlConnection  c = new SqlConnection();
                    //c.ConnectionString = connectionstring;
                    //using (Models.MiSistemaEntities u = new Models.MiSistemaEntities());

                    SqlCommand com = new SqlCommand("sp_update_user", c);
                    com.CommandType = CommandType.StoredProcedure;
                    //revisar si anda con el id
                    com.Parameters.AddWithValue("@id", id);
                    com.Parameters.AddWithValue("@nom", nom);
                    com.Parameters.AddWithValue("@email", email);
                    com.Parameters.AddWithValue("@pass", pass);
                    com.Parameters.AddWithValue("@fecha", fecha);
                    com.Parameters.AddWithValue("@idRol", idRol);
                    c.Open();
                    com.ExecuteNonQuery();
                    c.Close();






                    //SqlCommand cm = new SqlCommand("sp_insertar_user", c);
                    //cm.CommandType = CommandType.StoredProcedure;

                    //cm.Parameters.Add("@nom", SqlDbType.VarChar);
                    //cm.Parameters.Add("@email", SqlDbType.VarChar);
                    //cm.Parameters.Add("@pass", SqlDbType.VarChar);
                    //cm.Parameters.Add("@fecha", SqlDbType.DateTime);
                    //cm.Parameters.Add("@idrol", SqlDbType.Int);

                    //cm.Parameters["@nom"].Value = nom;
                    //cm.Parameters["@email"].Value = email;
                    //// cm.Parameters["@pass"].Value = pass;

                    //cm.Parameters["@pass"].Value = database_access.Encrypt.GetSHA256(pass.ToString());
                    //cm.Parameters["@fecha"].Value = fecha;
                    //cm.Parameters["@idrol"].Value = idrol;

                    //c.Open();

                    //cm.ExecuteNonQuery();
                    ////mensajes al usuario de confirmacion

                    //c.Close();

                    return RedirectToAction("Show_data");


                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

            

             
            
            //usua.fecha =  DateTime.Parse(fc[(Convert.ToString("fecha"))]);
            // usua.idRol = int.Parse(fc["idRol"]);
            //dbmostrar.Update_user(usua);
            //TempData["msg"] = "Actualizacion con exito";
            //return RedirectToAction("Show_data");




            

        








        //public ActionResult Update_user(int id, FormCollection fc)
        //{


        //    Usuario usua = new Usuario();

        //    //int.Parse(fc["ID"]);

        //    usua.id = id;
        //    usua.nombre = fc["nom"];
        //    usua.email = fc["email"];
        //    usua.password = fc["pass"];
        //   //usua.fecha =  DateTime.Parse(fc[(Convert.ToString("fecha"))]);
        //   // usua.idRol = int.Parse(fc["idRol"]);
        //    dbmostrar.Update_user(usua);
        //    TempData["msg"] = "Actualizacion con exito";
        //    return RedirectToAction("Show_data");
        //}

        public ActionResult Delete_user(int id)
        {

            dbmostrar.Delete_user(id);
            TempData["msg"] = "Borrado con exito";
            return RedirectToAction("Show_data");
        }


       
    }
}
