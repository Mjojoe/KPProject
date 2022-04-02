using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class InputConverter
    {
        private static InputConverter instance = null;
        readonly string[] seperator = { ": ", "\n" };
        private InputConverter() { }

        public static InputConverter GetInputConverter()
        {
            if (instance == null)
            {
                instance = new InputConverter();
            }
            return instance;
        }

        public string[] ExtractData(string message)
        {
            string[] sub = message.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return sub;
        }

        //Convert give data into Json Object
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
