namespace Cruorin.Runtime
{
    using System.Linq;

    public class Operator
    {
        private static string[] names_ = new string[] { 
            "+", "-", "*", "/", "%", "[", "]", "(", ")", "," 
        };
        private static int[] orders_ = new int[] { 
            2, 2, 4, 4, 5, 0, 0, 0, 0, 1 
        };

        public static bool IsMatch(string text) 
        {
            return names_.Contains(text);
        }

        public static bool IsPair(string text)
        {
            return text == "()" || text == "[]";
        }

        public static bool IsPrior(string a, string b)
        {
            int a_index = -1;
            int b_index = -1;
            for (int i = 0; i < names_.Length; i++) {
                if (names_[i] == a)
                    a_index = orders_[i];
                if (names_[i] == b)
                    b_index = orders_[i];
            }
            return a_index > b_index;
        }

        public Operator()
        {
        }
    }
}
