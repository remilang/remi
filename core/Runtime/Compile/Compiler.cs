namespace Cruorin.Runtime
{
    using System;
    using System.IO;
    using System.Text;

    public class Compiler
    {
        private ICompilePhase[] phases_ = null;

        public Compiler() 
        {
            phases_ = new ICompilePhase[3];
            phases_[0] = new LexicalPhase();
            phases_[1] = new SyntaxPhase();
            phases_[2] = new SemanticPhase();
        }

        public CompileContext CreateContext() 
        {
            return new CompileContext();
        }

        public void Load(CompileContext context, string file)
        {
            var reader = new StreamReader(file, Encoding.UTF8);
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var command = Compile(context, line);
                context.Commands.Add(command);
            }
            reader.Close();
        }

        public Command Compile(CompileContext context, string line)
        {
            context.Input = line;
            foreach (var phase in phases_) {
                phase.Process(context);
                if (context.Error != null) {
                    Console.WriteLine(context.Error);
                    return null;
                }
                if (context.Output == null)
                    return null;
                context.Input = context.Output;
            }
            return context.Output as Command;
        }
    }
}
