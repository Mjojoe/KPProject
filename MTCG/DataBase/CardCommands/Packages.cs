using DataBase.UserCommands;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CardCommands
{
    public class Packages
    {
        DBConnection connection;
        static readonly int value = 5;
        static Packages instance;
        private Packages()
        {
            connection = DBConnection.GetDBConnection();
        }

        public static Packages GetDBPackages()
        {
            if(instance == null) 
            { 
                instance = new Packages(); 
            }
            return instance;
        }

        private bool PackageAvailable()
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM packages WHERE bought = false", connection.StartCon());
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetBoolean(6) == false)
                {
                    connection.EndCon();
                    return true;
                }
            }
            connection.EndCon();
            return false;
        }

        public string AddPackage(string cid1, string cid2, string cid3, string cid4, string cid5)
        {
            using var cmd = new NpgsqlCommand("INSERT INTO packages(card1, card2, card3, card4, card5) VALUES(@1, @2, @3, @4, @5)", connection.StartCon());
            
                cmd.Parameters.AddWithValue("1", cid1);
                cmd.Parameters.AddWithValue("2", cid2);
                cmd.Parameters.AddWithValue("3", cid3);
                cmd.Parameters.AddWithValue("4", cid4);
                cmd.Parameters.AddWithValue("5", cid5);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            
            connection.EndCon();
            return "Package Added!";
        }
        private void MarkAsBought(int id)
        {
            using var cmd = new NpgsqlCommand("UPDATE packages SET bought=true WHERE id=@id", connection.StartCon());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connection.EndCon();
        }

        public string BuyPackage(string username)
        {
            if (PackageAvailable())
            {
                Cards card = Cards.GetDBCards();
                UserData user = UserData.GetCheckUserData();
                if (user.HasCoins(username, value))
                {
                    using var cmd = new NpgsqlCommand("SELECT * FROM packages WHERE bought = false LIMIT 1", connection.StartCon());
                    using var reader = cmd.ExecuteReader();
                    int count = 1;
                    int pid= 0;
                    
                    while (reader.Read() && count < 6)
                    {
                        if (count == 1)
                        {
                            pid = reader.GetInt32(0);
                        }
                        card.AddCardToCollection(reader.GetString(count), username);
                        
                        count++;
                    }
                    connection.EndCon();
                    MarkAsBought(pid);
                }
                return user.SpendCoins(username, value);
            }
            return "No Packages available";
        }
    }
}
