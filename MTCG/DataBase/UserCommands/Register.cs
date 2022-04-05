using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UserCommands
{
    public class Register
    {
        DBConnection conn;
        CheckUserData checkUserData;

        public Register()
        {
            conn = DBConnection.GetDBConnection();
            checkUserData = CheckUserData.GetCheckUserData();
        }

        public string RegisterUser(string username, string password)
        {
            if(checkUserData.SelectUserByUSername(username) == null)
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO users(username, pw, coins, admin, won, lost) VALUES (@n, @p, @c, @a, @w, @l)", conn.StartCon()))
                {

                    cmd.Parameters.AddWithValue("n", username);
                    cmd.Parameters.AddWithValue("p", password);
                    cmd.Parameters.AddWithValue("c", 20);
                    cmd.Parameters.AddWithValue("a", false);
                    cmd.Parameters.AddWithValue("w", 0);
                    cmd.Parameters.AddWithValue("l", 0);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                conn.EndCon();
                return "Register Successful!";
            }
            else
            {
                return "User already Exists";
            }
        }
    }
}
