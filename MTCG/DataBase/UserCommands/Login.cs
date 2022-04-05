using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UserCommands
{
    public class Login
    {
        CheckUserData checkUserData;
        public Login()
        {
            checkUserData = CheckUserData.GetCheckUserData();
        }
        public string LoginByUsername(string username, string password)
        {
            if (checkUserData.SelectUserByUSername(username) != null)
            {
                if (checkUserData.CheckPassword(username, password) != null)
                {
                    return "User Login Successful!";
                }
                else return "Wrong Password";
            }
            else return "User does not Exist";
        }
    }
}
