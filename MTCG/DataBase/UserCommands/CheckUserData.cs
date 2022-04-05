using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Npgsql;

namespace DataBase.UserCommands
{
    public class CheckUserData
    {
        readonly DBConnection connection;
        private static CheckUserData instance;
        private CheckUserData()
        {
            connection = DBConnection.GetDBConnection();
        }

        public static CheckUserData GetCheckUserData()
        {
            if (instance == null)
            {
                instance = new CheckUserData();
            }
            return instance;
        }

        public string SelectUserByUSername(string username)
        {
            using var cmd = new NpgsqlCommand("SELECT username FROM users WHERE username=@n;", connection.StartCon());
            cmd.Parameters.AddWithValue("n", username);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == username)
                {
                    connection.EndCon();
                    return "User Exists";
                }
            }
            connection.EndCon();
            return null;
        }

        public string CheckPassword(string username, string password)
        {
            using (var cmd = new NpgsqlCommand("SELECT pw FROM users WHERE username=@n;", connection.StartCon()))
            {
                cmd.Parameters.AddWithValue("n", username);

                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())

                    while (reader.Read())
                    {

                        if (reader.GetString(0) == password)
                        {
                            connection.EndCon();
                            return "Correct Password submitted";
                        }
                    }
            }
            connection.EndCon();
            return null;
        }
    }
}
