using ET;
using CapaDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BL
{
    public class UserBL
    {
        private Connection DAL = new Connection();
        public void Insert(User user)
        {
            
        }
        public List<User> List()
        {
            return DAL.List();
        }
        public User Contain()
        {
            return DAL.Container();
        }
    }
}
