using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RequestDb
{
    public class ProcedureReq
    {
        private CapaDb.Connection acces = new CapaDb.Connection();
        private Security.Sec_Encrypt enc = new Security.Sec_Encrypt();

        

        public List<ET.User> List()
        {
            DataTable table = acces.Read("Select * from usuario", null);
            List<ET.User> userL = new List<ET.User>();
            foreach (DataRow row in table.Rows)
            {
                ET.User user = new ET.User()
                {
                    id = Convert.ToInt32(row["id"]),
                    nombre = row["nombre"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    idRol = Convert.ToInt32(row["idRol"])
                };

                userL.Add(user);
            }
            foreach (var rol in userL)
            {
                List<SqlParameter> parameter = new List<SqlParameter>();
                parameter.Add(acces.NewSqlParameterInt("@id", rol.idRol));
                var query = acces.ExecuteReadT("Select * from  rol Where id = @id", parameter);
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        rol.Rol.id = Convert.ToInt32(query["id"]);
                        rol.Rol.nombre = query["nombre"].ToString();
                    }
                }
            }
            return userL;
        }
        public ET.User Find(int id)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterInt("@id", id));

            DataTable table = acces.Read("Select * from usuario where id = @id", parameter);
            ET.User user = new ET.User();

            foreach (DataRow row in table.Rows)
            {

                user.id = Convert.ToInt32(row["id"]);
                user.nombre = row["nombre"].ToString();
                user.email = row["email"].ToString();
                user.password = row["password"].ToString();
                user.idRol = Convert.ToInt32(row["idRol"]);

            }
            return user;
        }
        public bool Delete(int id)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterInt("@id", id));

            DataTable table = acces.Read("Delete from usuario where id = @id", parameter);

            return true;
           



        }

        public bool Modify(ET.User model)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterString("@nombre", model.nombre));
            parameter.Add(acces.NewSqlParameterString("@email", model.email));
            parameter.Add(acces.NewSqlParameterInt("@id", model.id));

            DataTable table = acces.Read("Update usuario Set nombre = @nombre, email = @email where id =  @id", parameter);

            return true;
        }

        public bool Add(string name, string password, string email, DateTime date, int idRol)
        {
            string epass = Security.Sec_Encrypt.GetSHA256(password);
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(acces.NewSqlParameterString("@nom", name));
            parameters.Add(acces.NewSqlParameterString("@email", email));
            parameters.Add(acces.NewSqlParameterString("@pass", epass));
            parameters.Add(acces.NewSqlParameterDate("@fecha", date));
            parameters.Add(acces.NewSqlParameterInt("@idrol", idRol));

            DataTable table = acces.ReadSp("sp_insertar_user", parameters);

            return true;
        }


        public bool Login(string nombre, string password)
        {

            string epass2 = Security.Sec_Encrypt.GetSHA256(password);

            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterString("@name", nombre));
            parameter.Add(acces.NewSqlParameterString("@pass", epass2));



            SqlDataReader read = acces.ExecuteRead("sp_Login", parameter);
             if (read.HasRows)
            {
                while (read.Read())
                {

                    string epass = Security.Sec_Encrypt.GetSHA256(read.GetString(3));
                    ET.User user = new ET.User();

              
                    user.id = Convert.ToInt32(read[0]);
                    user.nombre = read.GetString(1);
                    user.email = read.GetString(2);
                    //user.password = read.GetString(3);

                    user.password = epass;
                    user.idRol = read.GetInt32(4);
                    user.fecha = read.GetDateTime(5);

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public ET.User Model(string nombre, string password)
        {
            string epass2 = Security.Sec_Encrypt.GetSHA256(password);
            ET.User user = new ET.User();
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterString("@name", nombre));
            parameter.Add(acces.NewSqlParameterString("@pass", epass2));

            

            SqlDataReader read = acces.ExecuteRead("sp_Login", parameter);

            
                

            if (read.HasRows)
            {
                while (read.Read())
                {
                    string epass = Security.Sec_Encrypt.GetSHA256(read.GetString(3));

                    


                    user.id = Convert.ToInt32(read[0]);
                    user.nombre = read.GetString(1);
                    user.email = read.GetString(2);

                    //user.password = read.GetString(3);

                    user.password = epass;
                    user.idRol = read.GetInt32(4);
                    user.fecha = read.GetDateTime(5);

                }

            }
            List<SqlParameter> parameter2 = new List<SqlParameter>();
            parameter2.Add(acces.NewSqlParameterInt("@id", user.idRol));
            var query = acces.ExecuteReadT("Select * from  rol Where id = @id", parameter2);
            if (query.HasRows)
            {
                while (query.Read())
                {
                    user.Rol.id = Convert.ToInt32(query["id"]);
                    user.Rol.nombre = query["nombre"].ToString();
                }
            }
            return user;

        }
        //DataTable table = acces.Read("sp_Login", parameter);
        //if(table.Rows.Count > 0)
        //{
        //    if(table.Rows[0][1].ToString() == "Admin")
        //    {
        //        HttpContext.Current.Response.Redirect("AdminForm.aspx");

        //    }else if (table.Rows[0][1].ToString() == "Student")
        //    {
        //        HttpContext.Current.Response.Redirect("StudentForm.aspx");
        //    }
        //}



        //private ET.UserET Model(string nombre, string password)
        //{
        //    ET.UserET user = new ET.UserET();

        //    user.nombre = nombre;
        //    user.password = password;

        //    return user;

        //}

    }
}
