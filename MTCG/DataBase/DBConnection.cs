using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DBConnection
    {
        protected static DBConnection instance = null;
        NpgsqlConnection conn = null;
        private static Mutex mute = new();
        protected DBConnection()
        { }
        public static DBConnection GetDBConnection()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }


        //establish Db connection
        public NpgsqlConnection StartCon()
        {
            mute.WaitOne();
            //Db soll threadsave sein, ich habe von problemem gehört also gehe ich nur sicher 
            var connString = "Host=127.0.0.1;Username=postgres;Password=fhSWENDataBase;Database=MTCG";

            conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        //end Db connection
        public void EndCon()
        {
            conn.Close();
            mute.ReleaseMutex();
        }
    }
}
