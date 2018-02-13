namespace Cruorin.Runtime
{
    internal class SemanticPhase : ICompilePhase
    {
        public void Process(CompileContext context)
        {
            var parts = context.Input as object[];
            var verb = parts[0] as string;
            if (verb == "move") {
                var expr_from = new Expression((string[])parts[1]);
                var expr_to = new Expression((string[])parts[3]);
                context.Output = new MoveCommand(expr_from, expr_to);
            } else if (verb == "mark") {
                var expr_label = new Expression((string[])parts[1]);
                context.Output = new MarkCommand(expr_label);
            } else if (verb == "jump") {
                var expr_label = new Expression((string[])parts[1]);
                context.Output = new JumpCommand(expr_label);
            } else if (verb == "back") {
                context.Output = new BackCommand();
            }
        }
    }
}
