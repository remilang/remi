namespace Cruorin.Runtime
{
    using System;

    internal class LexicalPhase : ICompilePhase
    {
        public void Process(CompileContext context)
        {
            var input = context.Input as string;
            var lexical_analyzer = new LexicalAnalyzer();
            try {
                lexical_analyzer.Scan(input);
            } catch (Exception ex) {
                context.Error = ex.Message;
            }
            context.Output = lexical_analyzer.ToArray();
        }
    }
}
