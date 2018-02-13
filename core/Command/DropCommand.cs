namespace Cruorin
{
    using Cruorin.Runtime;
    using System.Linq;

    public class DropCommand : Command
    {
        private Expression expr_target_ = null;

        public DropCommand(Expression target)
        {
            expr_target_ = target;
        }

        public override int Execute()
        {
            var context = ExecuteContext.CurrentContext;
            var name = expr_target_.Reflect();
            var symbol = context.Symbols.FirstOrDefault(
                e => e.Name == name);
            if (symbol == null) {
                //todo: warning
            }
            context.Symbols.Remove(symbol);
            return base.Execute();
        }
    }
}
