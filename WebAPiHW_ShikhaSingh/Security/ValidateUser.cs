using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPiHW_ShikhaSingh.Security
{
    public class ValidateUser
    {
        public static bool Login(string username, string password)
        {
            using(tempdbEntities dbContext=new tempdbEntities())
            {
                return dbContext.Users.Any(user => user.Username.Equals(username) && user.Password.Equals(password));
            }
        }
    }
}