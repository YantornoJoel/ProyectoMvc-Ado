using ET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BL
{
    public class UserBL
    {
        private RequestDb.ProcedureReq petition = new RequestDb.ProcedureReq();

        public List<User> List()
        {
            return petition.List();
        }
        public bool Login(string nombre, string password)
        {
            return petition.Login(nombre, password);
        }
        public bool Delete(int id)
        {
            return petition.Delete(id);
        }
        public ET.User Find(int id)
        {
            return petition.Find(id);
        }
        public bool Modify(ET.User model)
        {
            return petition.Modify(model);
        }
        public ET.User Model(string name, string password)
        {
            return petition.Model(name, password);
        }
    }
}
