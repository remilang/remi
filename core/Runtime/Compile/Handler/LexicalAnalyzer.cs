namespace Cruorin.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class LexicalAnalyzer
    {
        public const int MaxLineLength = 1024;

        private List<string> tokens_ 
            = new List<string>();
        private StringBuilder buffer_ 
            = new StringBuilder();
        private bool on_quote_ = false;
        private bool on_escape_ = false;
        private bool on_operand_ = false;
        private bool on_pair_operator_ = false;

        private void MergeToken()
        {
            if (buffer_.Length > 0) {
                tokens_.Add(buffer_.ToString());
                buffer_.Clear();
            }
        }

        private bool IsOperandChar(char c)
        {
            return
                (c >= 'a' && c <= 'z') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= '0' && c <= '9') ||
                (c == '.' || c == '_');
        }

        private bool IsPairOperatorChar(char c) 
        {
            return
                c == '[' || c == ']' ||
                c == '(' || c == ')';
        }

        /// <summary>
        /// false to move on, true to continue
        /// </summary>
        private bool TryEscape(char c) 
        {
            if (on_escape_) {
                on_escape_ = false;
                //todo: translate standard char
                buffer_.Append(c); //skip one char
                return true;
            }
            if (c == '\\') {
                on_escape_ = true; //on escape
                return true;
            }
            return false;
        }

        /// <summary>
        /// false to move on, true to continue
        /// </summary>
        private bool TryQuote(char c)
        {
            if (c == '"') {
                if (!on_quote_)
                    MergeToken();
                on_quote_ = !on_quote_; //flip quote
                buffer_.Append(c);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 0 - null, 1 to continue, 2 to break
        /// </summary>
        private int TryNotQuote(char c)
        {
            if (!on_quote_) {
                if (c == ';')
                    return 2; //skip comment
                else if (c == ' ') {
                    MergeToken();
                    return 1;
                }
                if (IsOperandChar(c)) {
                    if (!on_operand_)
                        MergeToken(); //before on operand
                    on_operand_ = true;
                } else {
                    if (on_operand_)
                        MergeToken();
                    if (on_pair_operator_) {
                        MergeToken();
                        on_pair_operator_ = false;
                    }
                    if (IsPairOperatorChar(c)) {
                        MergeToken();
                        on_pair_operator_ = true;
                    }
                    on_operand_ = false;
                }
            }
            buffer_.Append(c);
            return 0;
        }

        public void Scan(string text)
        {
            if (text.Length > MaxLineLength)
                throw new Exception("line is too long");
            foreach (var c in text) {
                if (TryEscape(c)) {
                    continue;
                }
                if (TryQuote(c)) {
                    continue;
                }
                var flag = TryNotQuote(c);
                if (flag == 1)
                    continue;
                if (flag == 2)
                    break;
            }
            MergeToken();
        }

        public string[] ToArray()
        {
            if (tokens_.Count > 0)
                return tokens_.ToArray();
            return null;
        }
    }
}
