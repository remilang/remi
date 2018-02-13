namespace Cruorin
{
    using Cruorin.Runtime;
    using System.Linq;

    public class MoveCommand : Command
    {
        private Expression expr_from_;
        private Expression expr_to_;

        public MoveCommand(Expression from, Expression to) 
        {
            expr_from_ = from;
            expr_to_ = to;
        }

        public override int Execute()
        {
            var context = ExecuteContext.CurrentContext;
            var value = expr_from_.Evaluate();
            var name = expr_to_.Reflect();
            var symbol = context.Symbols.FirstOrDefault(
                e => e.Name == name);
            if (symbol == null) {
                symbol = new Symbol(name);
                context.Symbols.Add(symbol);
            }
            symbol.Value = value;
            return base.Execute();
        }
    }
}
