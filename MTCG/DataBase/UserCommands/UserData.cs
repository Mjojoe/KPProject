using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Npgsql;

namespace DataBase.UserCommands
{
    public class UserData
    {
        readonly DBConnection connection;
        private static UserData instance;
        private UserData()
        {
            connection = DBConnection.GetDBConnection();
        }

        public static UserData GetCheckUserData()
        {
            if (instance == null)
            {
                instance = new UserData();
            }
            return instance;
        }

        public int GetCoins(string username)
        {
            using var cmd = new NpgsqlCommand("SELECT coins FROM users WHERE username =@u;", connection.StartCon());
            cmd.Parameters.AddWithValue("u", username);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            int awnser = 0;
            while (reader.Read())
            {
                awnser = reader.GetInt32(0);
            }
            connection.EndCon();
            return awnser;   
        }

        public bool HasCoins(string username, int value)
        {
            if(GetCoins(username) >= value) 
            { 
                return true; 
            }
            return false;
        }

        public string SpendCoins(string username, int value)
        {  
            if(HasCoins(username, value))
            {
                using var cmd = new NpgsqlCommand("UPDATE users SET coins =@v WHERE username =@u", connection.StartCon());
                cmd.Parameters.AddWithValue("v", GetCoins(username)-value);
                cmd.Parameters.AddWithValue("u", username);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                connection.EndCon();
                return "Coins Spent";
            }
            return "Not enough Coins";

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
