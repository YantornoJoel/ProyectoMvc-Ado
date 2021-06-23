//using DAL;
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
        //list recive un usuario del userET
        public List<User> List()
        {
            //Se crea un nuevo DataTAble que recive un dataTable con los datos requeridos(query) de la capaDB
            DataTable table = acces.Read("Select * from usuario", null);
            //Se crea un nuevo objeto de list<userET>(userL)
            List<User> userL = new List<User>();
            //Se crea un dataRow(row) que itera en filas de la tabla creada
            foreach (DataRow row in table.Rows)
            {
                //se instancia un nuevo objeto de userET (user)
                User user = new User()
                {
                    Id = Convert.ToInt32(row["id"]),
                    nombre = row["nombre"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    idRol = Convert.ToInt32(row["idRol"])
                };
                //Se agregan los datos del objeto al userL
                userL.Add(user);
            }
            //Devuelve userL(este userL coincide con el tipo requerido por el metodo "List<>/ IEnumerable")
            return userL;
        }
        //public bool Login(string nombre , string password)
        //{

        //    List<SqlParameter> parameter = new List<SqlParameter>();
        //    parameter.Add(acces.NewSqlParameterString("@name", nombre));
        //    parameter.Add(acces.NewSqlParameterString("@pass", password));

        //    SqlDataReader read = acces.LogIn("sp_Login", parameter);
        //    if (read.HasRows)
        //    {
        //        while (read.Read())
        //        {
        //            UserET user = new UserET();

        //            //user.id = read.GetInt32(0);
        //            user.nombre = read.GetString(0);
        //            //user.email = read.GetString(2);
        //            user.password = read.GetString(1);
        //            //user.idRol = read.GetInt32(4);

        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //DataTable table = acces.Read("sp_Login", parameter);
        ////if(table.Rows.Count > 0)
        ////{
        ////    if(table.Rows[0][1].ToString() == "Admin")
        ////    {
        ////        HttpContext.Current.Response.Redirect("AdminForm.aspx");

        ////    }else if (table.Rows[0][1].ToString() == "Student")
        ////    {
        ////        HttpContext.Current.Response.Redirect("StudentForm.aspx");
        ////    }
        ////}


        //}
        //private ET.UserET Model(string nombre, string password)
        //{
        //    ET.UserET user = new ET.UserET();

        //    user.nombre = nombre;
        //    user.password = password;

        //    return user;

        //}

        //7 public List<UserET>  listOne() 
        //{
        //DataTable dtblusuario = new DataTable();

        //{

        //SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM usuario", sqlCon);
        //sqlDa.Fill(dtblusuario);
        //}
        //return ;

        //    DataTable table = acces.Read("SELECT * FROM usuario",null);
        //    var view = table.Rows[0];
        //    List<UserET> user = new List<UserET>();
        //    UserET users = new UserET();
        //    users.id = Convert.ToInt32(view["id"]);
        //    users.nombre = view["nombre"].ToString();
        //    users.password = view["password"].ToString();
        //    users.email = view["email"].ToString();
        //    users.idRol = Convert.ToInt32(view["idRol"]);
        //    user.Add(users);


        //    return user;
        //}

        public bool Delete(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(acces.NewSqlParameterInt("@id", id));
            DataTable table = acces.Read("DELETE FROM usuario WHERE id = @id", parameters);
            Console.WriteLine(table);
            Console.WriteLine(parameters);
            return true;
        }
       

    }
}
