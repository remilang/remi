namespace Cruorin
{
    public class Label
    {
        private string name_;
        private int index_;

        public string Name 
        {
            get { return name_; }
        }

        public int Index 
        {
            get { return index_; }
            set { index_ = value; }
        }

        public Label(string name) 
        {
            name_ = name;
        }
    }
}
