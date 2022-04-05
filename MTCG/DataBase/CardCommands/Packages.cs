using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CardCommands
{
    internal class Packages
    {
        DBConnection connection;
        public Packages()
        {
            connection = DBConnection.GetDBConnection();
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
    }
}
