using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;

namespace NVerilogParser
{
    public class VerilogSymbolTable<TToken> where TToken : IToken
    {
        public Scope<TToken> Root { get; }

        public VerilogSymbolTable(Scope<TToken> root)
        {
            Root = root;
        }

        public Scope<TToken> GetCurrentScope(IParserCallStack<TToken> callStack)
        {
            if (callStack.CurrentScope == null)
            {
                callStack.CurrentScope = Root;
            }

            return callStack.CurrentScope;
        }

        public Scope<TToken> GetParentScope(IParserCallStack<TToken> callStack)
        {
            var current = GetCurrentScope(callStack);
            return current.Parent ?? Root;
        }

        public void RemoveScope(IParserCallStack<TToken> callStack)
        {
            callStack.CurrentScope = callStack.CurrentScope?.Parent;
        }

        public void OpenScope(IParserCallStack<TToken> callStack, string scopeType, int position)
        {
            var currentScope = GetCurrentScope(callStack);

            currentScope.OpenChildScope(scopeType.ToString(), position, callStack);
        }
    }
}

