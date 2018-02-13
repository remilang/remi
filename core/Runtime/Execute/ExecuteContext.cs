namespace Cruorin.Runtime
{
    using System;
    using System.Collections.Generic;

    public class ExecuteContext
    {
        [ThreadStatic] 
        private static ExecuteContext current_context_ = null; 

        public static ExecuteContext CurrentContext
        {
            get { return current_context_; }
            internal set { current_context_ = value; }
        }

        private CompileContext script_ = new CompileContext();
        private List<Symbol> symbols_ = new List<Symbol>();
        private List<Label> labels_ = new List<Label>();
        private Stack<int> call_stack_ = new Stack<int>();

        public CompileContext Script
        {
            get { return script_; }
        }

        public IList<Symbol> Symbols 
        {
            get { return symbols_; }
        }

        public IList<Label> Labels 
        {
            get { return labels_; }
        }

        public Stack<int> CallStack
        {
            get { return call_stack_; }
        }

        internal ExecuteContext(CompileContext script) 
        {
            script_ = script;
        }
    }
}
