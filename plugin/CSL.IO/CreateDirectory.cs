using System.IO;
using System.Xml.Linq;

namespace Cruorin.Command
{
    public class CreateDirectory : Command
    {
        private string _Name = null;
        private string _Target = null;

        public override void Prepare(XElement xml)
        {
            _Name = xml.Element("name").Value;
            _Target = xml.Element("target").Value;
        }

        public override bool Execute()
        {
            string path = Path.Combine(_Target, _Name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return true;
        }

        public override bool Rollback()
        {
            return false;
        }
    }
}