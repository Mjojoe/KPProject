using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataBase;

namespace Server
{
    internal class CommandHandler
    {
        public CommandHandler() { }
        //Extracts the Token(if given) from the received Data
        private string CutUserToken(string data)
        {
            string seperator = "Basic ";
            string[] token = data.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return token[0];
        }
        //POST requests
        public string PostMethod(string[] data)
        {
            if (data[0].Contains("login") || data[0].Contains("register") || data[0].Contains("addPackage") || data[0].Contains("buyPackage"))
            {
                InputConverter inputConverter = InputConverter.GetInputConverter();
                DBCommands dBCommands = new ();
                string authToken = "";
                

                if (data[0].Contains("addPackage") || data[0].Contains("buyPackage"))
                {
                    //For buy- and add-Package you need a Token
                    if (data[10].Contains("Basic"))
                    {
                        authToken = CutUserToken(data[10]);
                    }
                    else
                    {
                        return "You need to be logged in";
                    }
                }
                return dBCommands.ForwardCommand(data, data[0], authToken);
            }
            else
            {
                return "Unknown Command";
            }
        }
        //PUT requests
        public string PutMethod(string[] data)
        {
            return "not yet implemented";
        }
        //GET requests
        public string GetMethod(string[] data)
        {
            DBCommands dBCommands = new();
            
            if (data[0].Contains("stats"))
            {
                return "You need to be logged in";
                //get username
                //show wins, losses, calculated ELO
            }
            else if (data[0].Contains("cards"))
            {
                if(data.Length > 8) 
                {
                    if (data[8].Contains("Basic"))
                    {
                        string authToken = CutUserToken(data[8]);
                        return dBCommands.ForwardCommand(data, data[0], authToken);
                    }
                    return "Not Authorized";
                }
                else return "Not logged in";
                //check if token is there
                //starte db suche
            }
            else if (data[0].Contains("showDeck"))
            {
                return "not yet implemented";
                //get username from token
                //show collection
            }
            
            return "not yet implemented";
        }
    }
}

