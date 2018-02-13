using System.IO;
using System.Xml.Linq;

namespace Cruorin.Command
{
    public class CopyFile : Command
    {
        private string _PathSource;
        private string _PathTarget;

        public override void Prepare(XElement xml)
        {
            _PathSource = xml.Element("source").Value;
            _PathTarget = xml.Element("target").Value;
        }

        public override bool Execute()
        {
            var macro = Script.Macro;
            var logger = Script.Logger;
            string source = macro.Restore(_PathSource);
            string target = macro.Restore(_PathTarget);
            if (!File.Exists(source))
            {
                logger.WriteLog(string.Format("文件{0}不存在", source));
                return false;
            }
            else
            {
                File.Copy(source, target, true);
                logger.WriteLog(string.Format("复制文件{0}", source));
                return true;
            }
        }

        public override bool Rollback()
        {
            return false;
        }
    }
}
