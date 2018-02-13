namespace Cruorin
{
    using Cruorin.Runtime;
    using System.Linq;

    public class MarkCommand : Command
    {
        private Expression expr_target_ = null;

        public MarkCommand(Expression target)
        {
            expr_target_ = target;
        }

        public override int Execute()
        {
            var context = ExecuteContext.CurrentContext;
            var name = expr_target_.Reflect();
            var label = context.Labels.FirstOrDefault(
                e => e.Name == name);
            if (label == null) {
                label = new Label(name);
                context.Labels.Add(label);
            }
            label.Index = Pointer;
            return base.Execute();
        }
    }
}
