using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Parsers;
using CFGToolkit.ParserCombinator.State;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public class VerilogParserActionTypes
    {
        public static Action<AfterArgs<CharToken>> Not<TResult>(string[] forbidden, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, callStack)?.Trim();

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

        public static Action<AfterArgs<CharToken>> Not<TResult>(Func<VerilogParserState<CharToken>, IInputStream<CharToken>, IParserCallStack<CharToken>, string, bool> forbidden, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, callStack)?.Trim();

                        if (value != null)
                        {
                            if (!forbidden((VerilogParserState<CharToken>)args.GlobalState, args.Input, callStack, value))
                            {
                                newItems.Add(item);
                            }
                        }
                    }
                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Limit<TResult>(string[] allowed, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;

                if (obj.WasSuccessful)
                {
                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, args.ParserCallStack)?.Trim();

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

        public static Action<AfterArgs<CharToken>> Enforce<TResult>(string[] dataSetName, string[] parents, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory, int depth)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    if (parents.Any(p => callStack.HasParser(p, depth)))
                    {
                        return;
                    }

                    var newItems = new List<IUnionResultValue<CharToken>>();

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, callStack)?.Trim();

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

        public static Action<AfterArgs<CharToken>> Enforce<TResult>(Func<string, VerilogParserState<CharToken>, IParserCallStack<CharToken>, bool> validator, string[] parents, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory, int depth)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    if (parents.Any(p => callStack.HasParser(p, depth)))
                    {
                        return;
                    }
                    var newItems = new List<IUnionResultValue<CharToken>>();
                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, callStack)?.Trim();
                        if (validator(value, state, callStack))
                        {
                            newItems.Add(item);
                        }
                    }

                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Collect<TResult>(string destination, string dataSetName, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, callStack);

                        foreach (var value in values)
                        {
                            state.VerilogSymbolTable.RegisterDefinition(value, dataSetName, res.Position);
                        }
                    }
                }
            };
        }


        public static Action<AfterArgs<CharToken>> Collect<TResult>(string[] destinations, string dataSetName, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, callStack);

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

        public static Action<AfterArgs<CharToken>> Collect<TResult>(string destination, string dataSetName, string parent, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory, int depth)
        {
            return (args) =>
            {
                var obj = args.ParserResult;
                var globalState = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    if (parent != null && !callStack.HasParser(parent, depth))
                    {
                        return;
                    }

                    foreach (var res in obj.Values)
                    {
                        var values = factory(res, callStack);
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
