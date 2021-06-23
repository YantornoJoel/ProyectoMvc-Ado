using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ET;


namespace CapaDb
{
    public class Connection
    {
        private SqlConnection connection = new SqlConnection();
        private void Open()
        {
            string cs = ConfigurationManager.ConnectionStrings["enlace"].ConnectionString;
            connection.ConnectionString = cs;
            connection.Open();
        }
        //private SqlCommand NewSqlCommand(string procedure)
        //{
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = procedure;
        //    command.CommandType = CommandType.Text;
        //    return command;
        //}

        private SqlCommand NewSqlCommand(string procedure, List<SqlParameter> Lparam = null)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;

            if (Lparam != null && Lparam.Count > 0)
            {
                command.Parameters.AddRange(Lparam.ToArray());
            }
            return command;
        }

        private void Close()
        {
            connection.Close();
        }
        public List<User> List()
        {
             List<User> users = new List<User>();
            DataTable table = new DataTable();
            //string cs = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            //connection.ConnectionString = cs;
            //connection.Open();
            var query = new SqlCommand("select * from usuario", connection);
            query.CommandType = CommandType.Text;
            //DataSet ds = new DataSet();
            //SqlDataAdapter adapter = new SqlDataAdapter(query);

            //adapter.Fill(table);
            //var dr = table.Rows[0];

            Open();
            SqlDataReader r = query.ExecuteReader();
            Console.WriteLine(r);
            while (r.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt32(r["id"]),
                    nombre = r["nombre"].ToString(),
                    email = r["email"].ToString(),
                    password = r["password"].ToString(),
                    idRol = Convert.ToInt32(r["IdRol"]),
                };

                users.Add(user);

            }
            r.Close();
            return users;

        }
        public User Container()
        {
            //ET.User user = new ET.User();
            
            Open();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            adapter.SelectCommand = NewSqlCommand("SELECT * FROM usuario");
            adapter.Fill(table);
            DataRow row = table.Rows[0];
            return new User()
            {
                Id = Convert.ToInt32(row["id"]),
                nombre = row["nombre"].ToString(),
                email = row["email"].ToString(),
                password = row["password"].ToString(),
                idRol = Convert.ToInt32(row["idRol"])

            };
            

            

            


        }

        public SqlDataReader ExecuteRead(string procedure, List<SqlParameter> parameters)
        {

            SqlCommand command = NewSqlCommand(procedure, parameters);
            Open();
            SqlDataReader reader = command.ExecuteReader();

            return reader;


        }

        public void Insert(User user)
        {
            Open();

            SqlCommand cm = new SqlCommand("sp_insertar_user", connection);
            cm.CommandType = CommandType.StoredProcedure;

            cm.Parameters.Add("@nom", SqlDbType.VarChar);
            cm.Parameters.Add("@email", SqlDbType.VarChar);
            cm.Parameters.Add("@pass", SqlDbType.VarChar);
            cm.Parameters.Add("@fecha", SqlDbType.DateTime);
            cm.Parameters.Add("@idrol", SqlDbType.Int);

            cm.Parameters["@nom"].Value = user.nombre;
            cm.Parameters["@email"].Value = user.email;
            cm.Parameters["@pass"].Value = user.password;
            cm.Parameters["@idrol"].Value = user.idRol;

            //var exect = cm.ExecuteNonQuery();
            cm.ExecuteNonQuery();

            Close();
            
        }
        // Crea el comando a ejecutar de sql = query de sql.
        private SqlCommand NewSqlCommandRead(string procedure, List<SqlParameter> Lparam = null)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = procedure;
            command.CommandType = CommandType.Text;
            //if(reader != null)
            //{
            //    reader = command.ExecuteReader();
            //}

            if (Lparam != null && Lparam.Count > 0)
            {
                command.Parameters.AddRange(Lparam.ToArray());
            }
            return command;
        }

        // Crea un dataTable (tabla virtual que queda en memoria)
        public DataTable Read(string procedure, List<SqlParameter> parameters = null)
        {
            Open();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = NewSqlCommandRead(procedure, parameters);
            adapter.Fill(table);

            Close();
            return table;
        }

        // crea un nuevo parametro sql
        public SqlParameter NewSqlParameterInt(string nameParam, int value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = nameParam;
            param.Value = value;
            param.DbType = DbType.Int32;

            return param;


        }

        public SqlCommand ExecuteQuery(string nameProcedure, List<SqlParameter> parameters)
        {
            SqlCommand command = NewSqlCommandRead(nameProcedure, parameters);
            command.ExecuteNonQuery();
            return command;
        }

        public SqlParameter NewSqlParameterString(string nameParam, string value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = nameParam;
            param.Value = value;
            param.DbType = DbType.String;

            return param;


        }
    }
}
