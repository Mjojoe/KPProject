using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class JsonHandler
    {
        static JsonHandler instance;

        private JsonHandler() { }

        public static JsonHandler GetJsonHandler()
        {
            if(instance == null)
            {
                instance = new JsonHandler();
            }
            return instance;
        }

        public string ExtractFromJson(JObject jsonData, string toExtract)
        {
            string command = "{}";
            if (jsonData != null) command = jsonData[toExtract].ToString();
            return command;
        }

        //Converts given data string into JSONObject
        public JObject ConvertToJson(string data)
        {
            try
            {
                JObject jsonString = JObject.Parse(data);
                return jsonString;
            }
            catch
            {
                Console.WriteLine("Invalid Input. Not a Json Format");
                return null;
            }
        }
    }
}
