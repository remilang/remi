namespace Cruorin
{
    public enum ValueType 
    {
        Boolean,
        Integer,
        Real,
        String
    }

    public class Value
    {
        private object data_;
        private ValueType type_;

        public object Data
        {
            get { return data_; }
            set 
            {
                data_ = value;
                UpdateType();
            }
        }

        public ValueType Type 
        {
            get { return type_; }
        }

        private void UpdateType()
        {
            var type = data_.GetType();
            if (type == typeof(bool)) {
                type_ = ValueType.Boolean;
            } else if (type == typeof(int)) {
                type_ = ValueType.Integer;
            } else if (type == typeof(float)) {
                type_ = ValueType.Real;
            } else if (type == typeof(string)) {
                type_ = ValueType.String;
            }
        }
    }
}
