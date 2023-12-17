using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSDBSys.AppData;
using EMSDBSys.Utils;

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
        public List<vw_AllUsers> AllUserTable()
        {
            using (db = new EmpManagementEntities())
            { 
                return db.vw_AllUsers.ToList();
            }
        }
        public ErrorCode InsertUserUsingStoredProf(String uFN, String uLN, String uA, String uE, String uP, String uN, String uPass, int rId, int cBy, ref String szResponse)
        {
            using (db = new EmpManagementEntities())
            {
                try
                {
                    db.sp_InsterUser(uFN, uLN, uA, uE, uP, uN, uPass, rId, cBy);
                    szResponse = "Added";
                    return ErrorCode.Success;
                }
                catch (Exception ex)
                {
                    szResponse = ex.Message;
                    return ErrorCode.Error;
                }
            }
        }
        public ErrorCode UpdateUserUsingStoredProf(int uId, String uFN, String uLN, String uA, String uE, String uP, String uN, String uPass, int rId, int cBy, ref String szResponse)
        {
            using (db = new EmpManagementEntities())
            {
                try
                {
                    db.sp_UpdateUser(uId, uFN, uLN, uA, uE, uP, uN, uPass, rId, cBy);
                    szResponse = "Updated";
                    return ErrorCode.Success;
                }
                catch (Exception ex)
                {
                    szResponse = ex.Message;
                    return ErrorCode.Error;
                }
            }
        }
        public ErrorCode DeleteUserUsingStoredProf(int uId, ref String szResponse)
        {
            using (db = new EmpManagementEntities())
            {
                try
                {
                    db.sp_DeleteUser(uId);
                    szResponse = "Deleted";
                    return ErrorCode.Success;
                }
                catch (Exception ex)
                {
                    szResponse = ex.Message;
                    return ErrorCode.Error;
                }
            }
        }
    }
}
