namespace Cruorin.Runtime
{
    using System.Linq;

    public class Expression
    {
        private string[] tokens_ = null;

        public string[] Tokens 
        {
            get { return tokens_; } 
        }

        public int Length 
        {
            get { return tokens_.Length; }
        }

        public Expression(string[] tokens) 
        {
            tokens_ = tokens;
        }

        /// <summary>
        /// optimize & reduce expression
        /// </summary>
        public Expression Reduce() 
        {
            return null;
        }

        public Value Evaluate()
        {
            return null;
        }

        public Value Evaluate(int from, int to)
        {
            return null;
        }

        public string Reflect()
        {
            if (Length == 1) {
                return tokens_[0];
            } else if (Length > 1) {
                var value = Evaluate(0, Length - 1);
                if (value != null &&
                    value.Type == ValueType.String) {
                    return (string)value.Data;
                }
            }
            return null;
        }
    }
}
