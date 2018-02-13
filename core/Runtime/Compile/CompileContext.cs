namespace Cruorin.Runtime
{
    using System.Collections.Generic;

    public class CompileContext
    {
        private object input_ = null;
        private object output_ = null;
        private string error_ = null;
        private List<Command> commands_
            = new List<Command>();

        public object Input 
        {
            get { return input_; }
            set { input_ = value; }
        }

        public object Output 
        {
            get { return output_; }
            set { output_ = value; }
        }

        public string Error 
        {
            get { return error_; }
            set { error_ = value; }
        }

        public IList<Command> Commands
        {
            get { return commands_; }
        }

        internal CompileContext() 
        {
        }
    }
}
