using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class StringConverter
    {
        public StringConverter() { }

        public static string CutToken(string authtoken)
        {
            string[] seperator = { "-" };
            string[] splitstring = authtoken.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return splitstring[0];
        }

        public static string[] GetKeys(string keys)
        {
            string[] seperator = { "+" };
            string[] splitstring = keys.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return splitstring;
        }
    }
}
