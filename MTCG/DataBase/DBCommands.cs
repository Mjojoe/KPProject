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

        public static string CutToken(string authtoken)
        {
            string[] seperator = { "-" };
            string[] splitstring = authtoken.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return splitstring[0];
        }

        public string ForwardCommand(string[] data, string command, string authToken)
        {
            JsonHandler jhandler = JsonHandler.GetJsonHandler(); ;
            if (command.Contains("login"))
            {
                JObject jsonData =  jhandler.ConvertToJson(data[data.Length - 1]); ;
                string username = jhandler.ExtractFromJson(jsonData, "Username");
                string password = jhandler.ExtractFromJson(jsonData, "Password");

                Login login = new();
                return login.LoginByUsername(username, password);
            }
            else if (command.Contains("register"))
            {
                JObject jsonData = jhandler.ConvertToJson(data[data.Length - 1]);
                Register register = new();

                string username = jhandler.ExtractFromJson(jsonData, "Username");
                string password = jhandler.ExtractFromJson(jsonData, "Password");

                return register.RegisterUser(username, password);

            }
            else if (command.Contains("addPackage"))
            {
                if (CutToken(authToken) == "admin")
                {
                    Packages packages = new();
                    Cards cards = new();
                    JObject jsonData = jhandler.ConvertToJson(data[data.Length - 1]); ;

                    string returnstring = "";
                    string cid1 = jhandler.ExtractFromJson(jsonData, "Id1");
                    string cid2 = jhandler.ExtractFromJson(jsonData, "Id2");
                    string cid3 = jhandler.ExtractFromJson(jsonData, "Id3");
                    string cid4 = jhandler.ExtractFromJson(jsonData, "Id4");
                    string cid5 = jhandler.ExtractFromJson(jsonData, "Id5");
                    for(int i = 1; i <= 5; i++)
                    {
                        string cid = jhandler.ExtractFromJson(jsonData, "Id" + i);
                        string name = jhandler.ExtractFromJson(jsonData, "Name" + i);
                        float power = float.Parse(jhandler.ExtractFromJson(jsonData, "Damage" + i));
                        
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
