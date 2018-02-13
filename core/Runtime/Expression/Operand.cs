using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cruorin.Runtime
{
    public class Operand
    {
        private static Regex regex_identifier_
            = new Regex(@"^[a-zA-Z_]+[a-zA-Z0-9_]*$");
        private static Regex regex_number_literal_
            = new Regex(@"^\d+(\.\d+){0,1}$");
        private static Regex regex_text_literal_
            = new Regex(@"^\"".*\""$");

        public static bool IsIdentifier(string text) 
        {
            return regex_identifier_.IsMatch(text);
        }

        public static bool IsLiteral(string text) 
        {
            return 
                regex_number_literal_.IsMatch(text) || 
                regex_text_literal_.IsMatch(text);
        }

        public static bool IsNumberLiteral(string text) 
        {
            return regex_number_literal_.IsMatch(text);
        }

        public static bool IsTextLiteral(string text) 
        {
            return regex_text_literal_.IsMatch(text);
        }
    }
}
