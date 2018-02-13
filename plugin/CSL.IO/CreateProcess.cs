using System.Xml.Linq;

namespace Cruorin.Command
{
    public class CreateProcess : Command
    {
        public override void Prepare(XElement xml)
        {
        }

        public override bool Execute()
        {
            return true;
        }

        public override bool Rollback()
        {
            return true;
        }
    }
}
