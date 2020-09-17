using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.SqlContext;

namespace WebApplication3.DAL
{
    public class UserDAL
    {
        DapperHelper _db = new DapperHelper();

        public Users GetUsersByLogin(string userName, string passWord)
        {
            string sql = "SELECT * FROM USERS where UserName = @userName And Password = @passWord";
            var _user = _db.QueryFirst<Users>(sql, new { userName, passWord });
            if (userName == null)
            {
                return default;
            }
            return _user;
        }
    }
}
