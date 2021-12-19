using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public class SymbolTable
    {
        private Dictionary<string, List<SymbolEntry>> _entries = new Dictionary<string, List<SymbolEntry>>();
        private List<Scope> _scopes = new List<Scope>();

        public void PushScope(ScopeType type, string name, int start, int? stop)
        {
            var lastScope = _scopes.LastOrDefault();
            var scope = new Scope { Type = type, Name = name, StartPosition = start };

            if (lastScope != null && lastScope.EndPosition == null)
            {
                scope.Parent = lastScope;
                lastScope.Children.Add(scope);
            }
            _scopes.Add(scope);
        }

        public void CleanScope()
        {
            var lastScope = _scopes.LastOrDefault();
            if (lastScope != null && lastScope.Symbols.Count == 0 && lastScope.Name == null)
            {
                _scopes.Remove(lastScope);
            }
        }

        public void FinishScope(int stop)
        {
            _scopes.Last().EndPosition = stop;
        }

        public void UpdateScopeName(ScopeType type, string name)
        {
            var last = _scopes.Last(s => s.Type == type);
            last.Name = name;
        }

        public bool HasScope(ScopeType type, string name)
        {
            return _scopes.Any(scope => scope.Type == type && scope.Name == name);
        }

        public void RegisterDefinition(string name, string type, int position)
        {
            Register(name, type, position, SymbolEntryUseType.Definition);
        }

        public void Register(string name, string type, int position, SymbolEntryUseType useType)
        {
            if (!_entries.ContainsKey(name))
            {
                _entries[name] = new List<SymbolEntry>();
            }
            var currentScope = _scopes.LastOrDefault();

            var symbol = new SymbolEntry
            {
                UseType = useType,
                Type = type,
                Name = name,
                Position = position,
                Scope = currentScope
            };

            _entries[name].Add(symbol);

            if (currentScope != null)
            {
                currentScope.Symbols.Add(symbol);
            }
        }

        public bool HasDefinition(string type, string name)
        {
            return _entries.ContainsKey(name)
                && _entries[name].Any(e => e.UseType == SymbolEntryUseType.Definition && e.Type == type);
        }
    }

    public enum SymbolEntryUseType
    {
        Definition,
        Reference
    }

    public class SymbolEntry
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public SymbolEntryUseType UseType { get; set; }

        public int Position { get; set; }

        public Scope Scope { get; set; }
    }

    public class Scope
    {
        public int StartPosition { get; set; }

        public int? EndPosition { get; set; }

        public string Name { get; set; }

        public ScopeType Type { get; set; }

        public List<SymbolEntry> Symbols { get; set; } = new List<SymbolEntry>();

        public Scope Parent { get; set; }

        public List<Scope> Children { get; set; } = new List<Scope>();

    }

    public enum ScopeType
    {
        Module,
        Function,
        Block
    }
}
