namespace Cruorin.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SyntaxPhase : ICompilePhase
    {
        public void Process(CompileContext context)
        {
            var tokens = context.Input as string[];
            object[] parts = null;
            var verb = tokens[0].ToLower();
            if (verb == "move") {
                parts = Merge(tokens, "move", "to");
                if (parts.Length != 4)
                    throw new Exception("command syntax error");
                Reduce(parts, 1, 3);
            } else if (verb == "drop") {
                parts = Merge(tokens, "drop");
                Reduce(parts, 1);
            } else if (verb == "mark") {
                parts = Merge(tokens, "mark");
                Reduce(parts, 1);
            } else if (verb == "jump") {
                parts = Merge(tokens, "jump", "on");
                Reduce(parts, 1, 3);
            }
            //todo: support more command
            context.Output = parts;
        }

        private object[] Merge(
            string[] tokens, params string[] keys)
        {
            var parts = new List<object>();
            var buffer = new List<string>();
            foreach (var token in tokens) {
                if (keys.Contains(token)) {
                    if (buffer.Count > 0) {
                        parts.Add(buffer.ToArray());
                        buffer.Clear();
                    }
                    parts.Add(token);
                    continue;
                }
                buffer.Add(token);
            }
            if (buffer.Count > 0)
                parts.Add(buffer.ToArray());
            return parts.ToArray();
        }

        private void Reduce(object[] parts, params int[] keys)
        {
            foreach (var key in keys) {
                parts[key] = Reduce((string[])parts[key]);
            }
        }

        private string[] Reduce(string[] tokens)
        {
            var stack_temp = new Stack<string>();
            var stack_rpn = new Stack<string>();

            for (int i = 0; i < tokens.Length; i++) {
                var token = tokens[i];
                if (Operand.IsLiteral(token) ||
                    Operand.IsIdentifier(token)) {
                    stack_rpn.Push(token);
                } else {
                    if (token == "(" || token == "[") {
                        var last_token = i - 1 < 0 ?
                            null : tokens[i - 1];
                        if (token == "[" ||
                            last_token == "]" ||
                            !Operator.IsMatch(last_token)) {
                            stack_temp.Push("#"); //keep pair
                        }
                        stack_temp.Push(token);
                    } else if (token == ")" || token == "]") {
                        var left_token = (token == ")" ? "(" : "[");
                        while (stack_temp.Peek() != left_token) {
                            stack_rpn.Push(stack_temp.Pop());
                            if (stack_temp.Count == 0) {
                                //todo: throw
                                return null;
                            }
                        }
                        stack_temp.Pop(); //pop left part
                        if (stack_temp.Count > 0 &&
                            stack_temp.Peek() == "#") {
                            stack_temp.Pop();
                            stack_rpn.Push(left_token + token);
                        }
                    } else if (token == ",") {
                        continue;
                    } else {
                        while (stack_temp.Count > 0 &&
                            !Operator.IsPrior(token, stack_temp.Peek())) {
                            stack_rpn.Push(stack_temp.Pop());
                        }
                        stack_temp.Push(token);
                    }
                }
            }
            while (stack_temp.Count > 0) {
                stack_rpn.Push(stack_temp.Pop());
            }
            var rpns = new List<string>();
            while (stack_rpn.Count > 0) {
                rpns.Add(stack_rpn.Pop());
            }
            rpns.Reverse();
            return rpns.ToArray();
        }
    }
}