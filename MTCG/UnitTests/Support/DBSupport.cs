using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Npgsql;

namespace UnitTests.Support
{
    public class DBSupport
    {
        private static DBSupport instance;
        private readonly DBConnection conn;

        private DBSupport()
        {
            conn = DBConnection.GetDBConnection();
        }
        public static DBSupport GetDBSupport()
        {
            if(instance == null)
            {
                instance = new DBSupport();
            }
            return instance;
        }

        public void ResetDB()
        {
            ResetCollection();
            ResetPackages();
            ResetCards();
            ResetUsers();
        }
        private void ResetCollection()
        {
            using var cmd = new NpgsqlCommand("DELETE FROM collection WHERE username = 'testuser'", conn.StartCon());
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            conn.EndCon();
        }
        public void ResetCards()
        {
            using var cmd = new NpgsqlCommand("DELETE FROM cards WHERE name = 'testcard'", conn.StartCon());
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            conn.EndCon();
        }

        public void ResetUsers()
        {
            using var cmd = new NpgsqlCommand("DELETE FROM users WHERE username = 'testuser'", conn.StartCon());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            conn.EndCon();
        }
        public void ResetPackages()
        {
            using var cmd = new NpgsqlCommand("DELETE FROM packages WHERE card1 = 'testcard'", conn.StartCon());
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            conn.EndCon();
        }

    }
}
