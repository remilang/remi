namespace Cruorin.Runtime
{
    using System.Threading;

    public class Executor
    {
        public ExecuteContext CreateContext(CompileContext script)
        {
            return new ExecuteContext(script);
        }

        public void Execute(ExecuteContext context) 
        {
            var thread = new Thread(
                new ParameterizedThreadStart(ExecuteRoutine));
            thread.Start(context);
        }

        private void ExecuteRoutine(object data) 
        {
            var context = (ExecuteContext)data;
            ExecuteContext.CurrentContext = context;
            var commands = context.Script.Commands;
            var command = commands.Count > 0 ?
                commands[0] : null;
            var pointer = 0;
            while (command != null) {
                pointer = command.Execute();
                command = commands.Count > pointer ?
                    commands[pointer] : null;
            }
        }
    }
}
