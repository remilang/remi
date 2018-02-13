namespace Cruorin
{
    using Cruorin.Runtime;
    using System.Linq;

    public class JumpCommand : Command
    {
        private Expression expr_label_ = null;

        public JumpCommand(Expression label)
        {
            expr_label_ = label;
        }

        public override int Execute()
        {
            var context = ExecuteContext.CurrentContext;
            var name = expr_label_.Reflect();
            var label = context.Labels.FirstOrDefault(
                e => e.Name == name);
            //todo: if label == null
            context.CallStack.Push(Pointer);
            return label.Index;
        }
    }
}
