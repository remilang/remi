namespace Cruorin
{
    using Cruorin.Runtime;

    public class BackCommand : Command
    {
        public BackCommand()
        {
        }

        public override int Execute()
        {
            var context = ExecuteContext.CurrentContext;
            if (context.CallStack.Count > 0)
                return context.CallStack.Pop();
            //todo: warning
            return base.Execute();
        }
    }
}
