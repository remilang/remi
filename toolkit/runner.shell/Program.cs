using Cruorin;
using Cruorin.Runtime;
using System;

namespace Cruorin
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiler = new Compiler();
            var compile_context = compiler.CreateContext();
            /*
            var line = @"move a >= [(c * 3.2 - 98 / d2) + l](a,b,c) to [""abc""]";
            var command = compiler.Compile(compile_context, line);
            line = @"move a>=[(c*3.2-98/d2)+l](a, b, c) to [""abc""]";
            command = compiler.Compile(compile_context, line);
            Console.ReadKey();
            //*/
            
            compiler.Load(compile_context, args[0]);
            var executor = new Executor();
            var execute_context = executor.CreateContext(compile_context);
            executor.Execute(execute_context);
        }
    }
}
