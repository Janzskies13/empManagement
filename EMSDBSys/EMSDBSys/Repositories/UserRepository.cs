using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSDBSys.AppData;

namespace EMSDBSys.Repositories
{
    public class UserRepository
    {
        private EmpManagementEntities db;

        public UserRepository()
        { 
            db = new EmpManagementEntities();
        }

        public UserAccount GetUserByUsername(String username)
        {
            using (db = new EmpManagementEntities())
            {
                return db.UserAccount.Where(m => m.userName == username).FirstOrDefault();
            }
        }
    }
}
