using System;
using System.Xml.Linq;

namespace Cruorin.Command
{
    public class SetEnvironment : Command
    {
        private string _Name = null;
        private string _Value = null;

        public override void Prepare(XElement xml)
        {
            _Name = xml.Attribute("name").Value;
            _Value = xml.Attribute("value").Value;
        }

        public override bool Execute()
        {
            return false;
        }

        public override bool Rollback()
        {
            return false;
        }
    }
}
