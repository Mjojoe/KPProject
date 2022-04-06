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
    }
}
