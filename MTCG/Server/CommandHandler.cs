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
            if (data[0].Contains("changeDeck"))
            {
                //extract username from token
                //extract data an transform to Json
                //if failed should trigger show deck
                //send to Db

            }
            else if (data[0].Contains("users"))
            {
                //extract username from token
                //check if username is the same as in the link
                //if yes extract data
                //send to db
            }
            return "not yet implemented";
        }
        //GET requests
        public string GetMethod(string[] data)
        {
            if (data[0].Contains("stats"))
            {
                //CommandHandlerDb dbHandler = new CommandHandlerDb();

                if (data[8].Contains("Basic"))
                {
                    string authToken = CutUserToken(data[8]);
                    //dbHandler.TransmitCommand(null, data[0], authToken);
                    return "not yet implemented";
                }
                else
                {
                    return "You need to be logged in";
                }
            }
            else if (data[0].Contains("showCards"))
            {
                //check if token is there
                //starte db suche
            }
            else if (data[0].Contains("showDeck"))
            {
                //get username from token
                //go to db

            }
            else if (data[0].Contains("changeDeck"))
            {
                //get username from token
                //send to db

            }
            else if (data[0].Contains("users"))
            {
                //extract username from token
                //check if username is the same as in the link
                //no data so nothing changes
                //send to db

            }
            //this have a special command
            else if (data[0].Contains("monsterBattle"))
            {
                //check if token is there
                //surch an enemy
                //start the game
            }
            else if (data[0].Contains("spellBattle"))
            {
                //check if token is there
                //surch an enemy
                //start the game
            }
            return "not yet implemented";
        }
    }
}

