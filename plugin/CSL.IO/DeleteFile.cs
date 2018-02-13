using System.IO;
using System.Xml.Linq;

namespace Cruorin.Command
{
    public class DeleteFile : Command
    {
        private string _Path = null;

        public override void Prepare(XElement xml)
        {
            _Path = xml.Element("path").Value;
        }

        public override bool Execute()
        {
            if (File.Exists(_Path))
                File.Delete(_Path);
            return true;
        }

        public override bool Rollback()
        {
            return false;
        }
    }
}
