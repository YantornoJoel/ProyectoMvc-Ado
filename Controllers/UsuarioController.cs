using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        string connectionString = @"Data Source = DESKTOP-HC3RFIP\SQLEXPRESS; Initial Catalog = Roy; Integrated Security = true";

        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblusuario = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM usuario", sqlCon);
                sqlDa.Fill(dtblusuario);
            }
                return View(dtblusuario);
        }

      

        [HttpGet]
        
        public ActionResult Create()
        {
            return View(new Models.usuario());
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Models.usuario modelUsuario)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO usuario VALUES(@nombre,@email,@password,@fecha,@idRol)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@nombre",modelUsuario.nombre);
                sqlCmd.Parameters.AddWithValue("@email", modelUsuario.email);
                sqlCmd.Parameters.AddWithValue("@password", modelUsuario.password);
                sqlCmd.Parameters.AddWithValue("@fecha", modelUsuario.fecha);
                sqlCmd.Parameters.AddWithValue("@idRol", modelUsuario.idRol);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Models.usuario modelUsuario = new Models.usuario();
            DataTable dbtlusuario = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM usuario WHERE id = @id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query,sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id",id);
                sqlDa.Fill(dbtlusuario);
            }
            if (dbtlusuario.Rows.Count == 1) 
            {
                modelUsuario.id = Convert.ToInt32(dbtlusuario.Rows[0][0].ToString());
                modelUsuario.nombre = dbtlusuario.Rows[0][1].ToString();
                modelUsuario.email = dbtlusuario.Rows[0][2].ToString();
                modelUsuario.password = dbtlusuario.Rows[0][3].ToString();
                modelUsuario.fecha = Convert.ToDateTime(dbtlusuario.Rows[0][4].ToString());
                modelUsuario.idRol = Convert.ToInt32(dbtlusuario.Rows[0][5].ToString());
                return View(modelUsuario);
            }
            else
                return View("Index");
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.usuario modelUsuario)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE usuario SET nombre = @nombre, email = @email, password = @password, fecha = @fecha, idRol = @idRol WHERE id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", modelUsuario.id);
                sqlCmd.Parameters.AddWithValue("@nombre", modelUsuario.nombre);
                sqlCmd.Parameters.AddWithValue("@email", modelUsuario.email);
                sqlCmd.Parameters.AddWithValue("@password", modelUsuario.password);
                sqlCmd.Parameters.AddWithValue("@fecha", modelUsuario.fecha);
                sqlCmd.Parameters.AddWithValue("@idRol", modelUsuario.idRol);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM usuario WHERE id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

    }
}
