using System;
using System.Xml.Linq;

namespace Cruorin.Command
{
    public class Unknown : Command
    {
        private string _What = null;

        public override void Prepare(XElement xml)
        {
            _What = xml.Attribute("what").Value;
        }

        public override bool Execute()
        {
            return false;
        }

        public override bool Rollback()
        {
            return true;
        }
    }
}
