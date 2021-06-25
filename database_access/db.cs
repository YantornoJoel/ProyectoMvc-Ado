using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WebApplication1.database_access;
//using WebApplication1.Models;


namespace WebApplication1.database_access
{

    
    

    public class db
    {

        

        


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["enlace"].ConnectionString);

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["enlace"].ConnectionString);
        public void Add_user(Usuario usu)
        {
            SqlCommand com = new SqlCommand("sp_insertar_user", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@nom",usu.nombre);
            com.Parameters.AddWithValue("@email",usu.email);
            com.Parameters.AddWithValue("@pass",usu.password);
            com.Parameters.AddWithValue("@fecha",usu.fecha);
            com.Parameters.AddWithValue("@idrol",usu.idRol);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            

        }
        //public void Update_user(Usuario data_user)
        //{
        //    SqlCommand com = new SqlCommand("sp_update_user", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    //revisar si anda con el id
        //    com.Parameters.AddWithValue("@id", data_user.nombre);
        //    com.Parameters.AddWithValue("@nom", data_user.nombre);
        //    com.Parameters.AddWithValue("@email", data_user.email);
        //    com.Parameters.AddWithValue("@pass", data_user.password);
        //    com.Parameters.AddWithValue("@fecha", data_user.fecha);
        //    com.Parameters.AddWithValue("@idRol", data_user.idRol);
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();

        //}
        //trae usuarios por nombre:

        //prueba si pasa los datos
        public DataSet Show_user_by_id(int id)

        {


            SqlCommand com = new SqlCommand("sp_traer_datos_por_id", con);
           com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet data_user = new DataSet();
            da.Fill(data_user);
            return data_user;

            //DataTable a = new DataTable();
        }


        public DataSet Show_data()
        {
            SqlCommand com = new SqlCommand("sp_traer_usuarios", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;







        }
        public void Delete_user(int id)
        {
            SqlCommand com = new SqlCommand("sp_delete_user",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


        }


    }
}