namespace Cruorin
{
    public class Symbol
    {
        private string name_;
        private Value value_;

        public string Name
        {
            get { return name_; }
        }

        public Value Value 
        {
            get { return value_; }
            set { value_ = value; }
        }

        public Symbol(string name)
        {
            name_ = name;
        }
    }
}
