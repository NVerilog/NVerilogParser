using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public class VerilogParserActionTypes
    {
        public static Action<AfterArgs<CharToken>> Not<TResult>(string[] forbidden, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var scope = args.ParserState;

                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, scope)?.Trim();

                        if (value != null)
                        {
                            if (!forbidden.Contains(value))
                            {
                                newItems.Add(item);
                            }
                        }
                    }
                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Not<TResult>(Func<VerilogParserState, IInput<CharToken>, IParserState<CharToken>, string, bool> forbidden, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var scope = args.ParserState;
                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, scope)?.Trim();

                        if (value != null)
                        {
                            if (!forbidden((VerilogParserState)args.GlobalState, args.Input, scope, value))
                            {
                                newItems.Add(item);
                            }
                        }
                    }
                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Limit<TResult>(string[] allowed, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;

                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, args.ParserState)?.Trim();

                        if (value != null)
                        {
                            if (allowed.Contains(value))
                            {
                                newItems.Add(item);
                            }
                        }
                    }
                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Enforce<TResult>(string[] dataSetName, string[] parents, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, string> factory, int depth = int.MaxValue)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState)args.GlobalState;
                var scope = args.ParserState;

                if (obj.WasSuccessful)
                {
                    if (parents.Any(p => scope.HasParser(p, depth)))
                    {
                        return;
                    }

                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, args.ParserState)?.Trim();

                        bool remove = true;
                        for (var i = 0; i < dataSetName.Length; i++)
                        {
                            if (state.VerilogSymbolTable.HasDefinition(dataSetName[i], value))
                            {
                                remove = false;
                                break;
                            }
                        }

                        if (!remove)
                        {
                            newItems.Add(item);
                        }
                    }

                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Enforce<TResult>(Func<string, VerilogParserState, IParserState<CharToken>, bool> validator, string[] parents, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, string> factory, int depth)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState)args.GlobalState;
                var scope = args.ParserState;

                if (obj.WasSuccessful)
                {
                    if (parents.Any(p => scope.HasParser(p, depth)))
                    {
                        return;
                    }
                    var newItems = new List<IUnionResultValue<CharToken>>();
                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, scope)?.Trim();
                        if (validator(value, state, scope))
                        {
                            newItems.Add(item);
                        }
                    }

                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Collect<TResult>(string destination, string dataSetName, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, IEnumerable<string>> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState)args.GlobalState;
                var scope = args.ParserState;

                if (obj.WasSuccessful)
                {
                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, scope);

                        foreach (var value in values)
                        {
                            state.VerilogSymbolTable.RegisterDefinition(value, dataSetName, res.Position);
                        }
                    }
                }
            };
        }


        public static Action<AfterArgs<CharToken>> Collect<TResult>(string[] destinations, string dataSetName, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, IEnumerable<string>> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState)args.GlobalState;
                var scope = args.ParserState;

                if (obj.WasSuccessful)
                {
                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, scope);

                        foreach (var value in values)
                        {
                            for (var i = 0; i < destinations.Length; i++)
                            {
                                state.VerilogSymbolTable.RegisterDefinition(value, dataSetName, res.Position);
                            }
                        }
                    }
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Collect<TResult>(string destination, string dataSetName, string parent, Func<IUnionResultValue<CharToken>, IParserState<CharToken>, IEnumerable<string>> factory, int depth = int.MaxValue)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var globalState = (VerilogParserState)args.GlobalState;
                var parserState = args.ParserState;

                if (obj.WasSuccessful)
                {
                    if (parent != null && !parserState.HasParser(parent, depth))
                    {
                        return;
                    }

                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, parserState);
                        foreach (var value in values)
                        {
                            globalState.VerilogSymbolTable.RegisterDefinition(value, dataSetName, res.Position);
                        }
                    }
                }
            };
        }
    }
}
