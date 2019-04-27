using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace school
{
    public static class help_methods
    {
        public static string conn_string = ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
        public static string escape_char(string input)
        {
            try
            {
                return input.Replace("'", "''");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool is_numeric_float(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static bool is_numeric_int(string s)
        {
            int output;
            return Int32.TryParse(s, out output);
        }
    }
}