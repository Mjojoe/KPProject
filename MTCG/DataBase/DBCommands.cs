using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DataBase.UserCommands;
using DataBase.CardCommands;

namespace DataBase
{
    public class DBCommands
    {

        public DBCommands() { }

        public string ExtractFromJson(JObject jsonData, string toExtract)
        {
            string command = jsonData[toExtract].ToString();
            return command;
        }
        public static string CutToken(string authtoken)
        {
            string[] seperator = { "-" };
            string[] splitstring = authtoken.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return splitstring[0];
        }

        public string ForwardCommand(JObject jsonData, string command, string authToken)
        {
            if (command.Contains("login"))
            {
                string username = ExtractFromJson(jsonData, "Username");
                string password = ExtractFromJson(jsonData, "Password");

                Login login = new();
                return login.LoginByUsername(username, password);
            }
            else if (command.Contains("register"))
            {
                string username = ExtractFromJson(jsonData, "Username");
                string password = ExtractFromJson(jsonData, "Password");

                Register register = new();
                return register.RegisterUser(username, password);

            }
            else if (command.Contains("addPackage"))
            {
                if (CutToken(authToken) == "admin")
                {
                    Packages packages = new();
                    Cards cards = new();
                    string returnstring = "";
                    string cid1 = ExtractFromJson(jsonData, "Id1");
                    string cid2 = ExtractFromJson(jsonData, "Id2");
                    string cid3 = ExtractFromJson(jsonData, "Id3");
                    string cid4 = ExtractFromJson(jsonData, "Id4");
                    string cid5 = ExtractFromJson(jsonData, "Id5");
                    for(int i = 1; i < 5; i++)
                    {
                        string cid = ExtractFromJson(jsonData, "Id" + i);
                        string name = ExtractFromJson(jsonData, "Name" + i);
                        int power = Int32.Parse(ExtractFromJson(jsonData, "Damage" + i));
                        
                        returnstring = returnstring + cards.AddCard(cid, name, power);
                    }

                    returnstring = returnstring + packages.AddPackage(cid1, cid2, cid3, cid4, cid5);
                    return returnstring;
                }
                return "Must be Admin to create Packages!";
            }
            else if (command.Contains("buyPackage"))
            {
                return "not yet implemented";
            }
            else 
            {
                return "Invalid Command";
            }
        }
    }
}
