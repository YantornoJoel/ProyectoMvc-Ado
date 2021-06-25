using ET;
//using CapaDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;



namespace BL
{
    public class UserBL
    {
        private RequestDb.ProcedureReq DAL = new RequestDb.ProcedureReq();
        public void Insert(User user)
        {
            
        }
        public List<ET.User> List()
        {
            return DAL.List();
        }
        //public User Contain()
        //{
        //    return DAL.Container();
        //}

        public bool Delete(int id)
        {
            return DAL.Delete(id);
        }

        public bool Login (string nombre, string password)
        {
            return DAL.Login(nombre, password);

        }
        public ET.User Find(int id)
        {
            return DAL.Find(id);
        }
    }
}
