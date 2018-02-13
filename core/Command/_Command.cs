namespace Cruorin
{
    using Cruorin.Runtime;

    public abstract class Command
    {
        /// <summary>
        /// get pointer of this command
        /// </summary>
        public int Pointer
        {
            get
            {
                var context = ExecuteContext.CurrentContext;
                var script = context.Script;
                return script.Commands.IndexOf(this);
            }
        }

        /// <summary>
        /// execute command and return next pointer
        /// </summary>
        public virtual int Execute()
        {
            return Pointer + 1;
        }
    }
}