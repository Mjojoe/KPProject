using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CardCommands
{
    public class Cards
    {
        DBConnection connection;
        static Cards instance;
        private Cards()
        {
            connection = DBConnection.GetDBConnection();
        }

        public static Cards GetDBCards()
        {
            if(instance == null)
            {
                instance = new Cards();
            }
            return instance;
        }

        public string GetType(string name)
        {
            if (name.Contains("Spell")) return "spell";
            else return "monster";
        }
        public string GetElement(string name)
        {
            if (name.Contains("Water")) return "water";
            else if (name.Contains("Fire")) return "fire";
            else return "normal";
        }
        public string GetClan(string name)
        {
            if (name.Contains("Knight")) return "knight";
            else if (name.Contains("Dragon")) return "dragon";
            else if (name.Contains("Elf")) return "elf";
            else if (name.Contains("Kraken")) return "kraken";
            else if (name.Contains("Ork")) return "ork";
            else if (name.Contains("Wizard")) return "wizard";
            else if (name.Contains("Spell")) return "spell";
            else return "goblin";
        }
        public string SelectCard(string cid)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM cards WHERE cid=@id;", connection.StartCon());
            cmd.Parameters.AddWithValue("id", cid);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == cid)
                {
                    connection.EndCon();
                    return "Card Exists";
                }
            }
            connection.EndCon();
            return null;
            
        }
        private bool CardCollected(string cid, string username)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM collection WHERE card=@id AND username =@u;", connection.StartCon());
            cmd.Parameters.AddWithValue("id", cid);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == username && reader.GetString(2) == cid)
                {
                    connection.EndCon();
                    return true;
                }
            }
            connection.EndCon();
            return false;
        }
        public string AddCardToCollection(string cid, string username)
        {
            if (!CardCollected(cid, username))
            {
                using var cmd = new NpgsqlCommand("INSERT INTO collection(username, card) VALUES (@n, @c)", connection.StartCon());
                
                    cmd.Parameters.AddWithValue("n", username);
                    cmd.Parameters.AddWithValue("c", cid);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                
                connection.EndCon();
                return "Card Added to Collection.";
            }
            else
            {
                return "Card Already Owned!";
            }
        }
        public string AddCard(string cid, string name, float power)
        {
            if(SelectCard(cid) == null)
            {
                using var cmd = new NpgsqlCommand("INSERT INTO cards(cid, name, power, type, element, clan) VALUES(@id, @n, @p, @t, @e, @c)", connection.StartCon());
                string type = GetType(name);
                string element = GetElement(name);
                string clan = GetClan(name);
                
                cmd.Parameters.AddWithValue("id", cid);
                cmd.Parameters.AddWithValue("n", name);
                cmd.Parameters.AddWithValue("p", power);
                cmd.Parameters.AddWithValue("t", type);
                cmd.Parameters.AddWithValue("e", element);
                cmd.Parameters.AddWithValue("c", clan);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                connection.EndCon();
                return cid + " Saved in DB\n";
            }
            return "Card Already Exists!\n";
        }
    }
}
