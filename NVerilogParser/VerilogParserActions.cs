using CFGToolkit.AST;
using CFGToolkit.AST.Providers;
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
    public static partial class ParseExt
    {
        public static void After(this IParser<CharToken, SyntaxNode> parser, Action<AfterArgs<CharToken>> action)
        {
            if (parser is EventParser<CharToken, SyntaxNode> e)
            {
                if (!VerilogParserActions.AfterActions.ContainsKey(parser))
                {
                    VerilogParserActions.AfterActions[parser] = new List<Action<AfterArgs<CharToken>>>();
                }
                VerilogParserActions.AfterActions[parser].Add(action);
            }
        }

        public static void Before(this IParser<CharToken, SyntaxNode> parser, Action<BeforeArgs<CharToken>> action)
        {
            if (parser is EventParser<CharToken, SyntaxNode> e)
            {
                if (!VerilogParserActions.BeforeActions.ContainsKey(parser))
                {
                    VerilogParserActions.BeforeActions[parser] = new List<Action<BeforeArgs<CharToken>>>();
                }
                VerilogParserActions.BeforeActions[parser].Add(action);
            }
        }
    }

    public class VerilogParserActions
    {
        private const int DefaultLookDownDepth = 3;
        private const int DefaultLookUpDepth = 9;
        private const int ShallowLookUpDepth = 9;


        public static Dictionary<IParser<CharToken>, List<Action<AfterArgs<CharToken>>>> AfterActions = new Dictionary<IParser<CharToken>, List<Action<AfterArgs<CharToken>>>>();

        public static Dictionary<IParser<CharToken>, List<Action<BeforeArgs<CharToken>>>> BeforeActions = new Dictionary<IParser<CharToken>, List<Action<BeforeArgs<CharToken>>>>();

        static VerilogParserActions()
        {
            CreateScopes();
        }

        private static void CreateScopes()
        {
            var keywordsArray = VerilogKeywords.Values.ToArray();

            // Modules
            Parsers.module_declaration.Value.Before(CreateScope(ScopeType.Module));
            Parsers.module_identifier.Value.After((args) => EnforeAndCollect(ScopeType.Module, args, nameof(Parsers.module_declaration), nameof(Parsers.module_identifier)));
            Parsers.module_declaration.Value.After(CloseScope());

            // Disciplines
            Parsers.discipline_declaration.Value.Before(CreateScope(ScopeType.Discipline));
            Parsers.discipline_identifier.Value.After((args) => EnforeAndCollect(ScopeType.Discipline, args, nameof(Parsers.discipline_declaration), nameof(Parsers.discipline_identifier)));
            Parsers.discipline_declaration.Value.After(CloseScope());

            // Natures
            Parsers.nature_declaration.Value.Before(CreateScope(ScopeType.Nature));
            Parsers.nature_identifier.Value.After((args) => EnforeAndCollect(ScopeType.Nature, args, nameof(Parsers.nature_declaration), nameof(Parsers.nature_identifier)));
            Parsers.nature_declaration.Value.After(CloseScope());
            Parsers.nature_attribute.Value.After(Collect<SyntaxNode>("nature_attribute_access",
              (obj, scope) => obj
              .GetValue<SyntaxNode>()
              .GetNodes("nature_attribute", DefaultLookDownDepth)
              .Where(n => n.GetNodes("nature_attribute_identifier", DefaultLookDownDepth).First().Text() == "access")
              .Select(attr => attr.GetNodes("nature_attribute_expression", DefaultLookDownDepth).First().Text())));



            // Functions
            Parsers.function_declaration.Value.Before(CreateScope(ScopeType.Function));
            Parsers.function_identifier.Value.After((args) => EnforeAndCollect(ScopeType.Function, args, nameof(Parsers.function_declaration), nameof(Parsers.function_identifier)));
            Parsers.function_declaration.Value.After(CloseScope());

            // Functions
            Parsers.analog_function_declaration.Value.Before(CreateScope(ScopeType.Function));
            Parsers.analog_function_identifier.Value.After((args) => EnforeAndCollect(ScopeType.Function, args, nameof(Parsers.analog_function_declaration), nameof(Parsers.function_identifier)));
            Parsers.analog_function_declaration.Value.After(CloseScope());


            // Blocks
           
            Parsers.seq_block.Value.Before(CreateScope(ScopeType.Block));
            Parsers.seq_block.Value.After(CloseScope());

            Parsers.analog_function_seq_block.Value.Before(CreateScope(ScopeType.Block));
            Parsers.analog_function_seq_block.Value.After(CloseScope());

            Parsers.analog_event_seq_block.Value.Before(CreateScope(ScopeType.Block));
            Parsers.analog_event_seq_block.Value.After(CloseScope());

            Parsers.analog_seq_block.Value.Before(CreateScope(ScopeType.Block));
            Parsers.analog_seq_block.Value.After(CloseScope());

            Parsers.par_block.Value.Before(CreateScope(ScopeType.Block));
            Parsers.par_block.Value.After(CloseScope());

            Parsers.block_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                    bool hasParent = (args.ParserCallStack.HasParser("seq_block", DefaultLookUpDepth)
                    || args.ParserCallStack.HasParser("analog_function_seq_block", DefaultLookUpDepth)
                    || args.ParserCallStack.HasParser("analog_event_seq_block", DefaultLookUpDepth)
                    || args.ParserCallStack.HasParser("par_block", DefaultLookUpDepth)
                    || args.ParserCallStack.HasParser("analog_seq_block", DefaultLookUpDepth));

                    if (hasParent)
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.Block, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "block_identifier", args.Input.Position);
                    }
                    else
                    {
                        if (!state.VerilogSymbolTable.HasDefinition("block_identifier", name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });

            // Declarations

            Parsers.paramset_declaration.Value.Before(CreateScope(ScopeType.ParamsetDeclaration));
            Parsers.paramset_identifier.Value.After((args) => EnforeAndCollect(ScopeType.ParamsetDeclaration, args, nameof(Parsers.paramset_declaration), nameof(Parsers.paramset_identifier)));
            Parsers.paramset_declaration.Value.After(CloseScope());

            Parsers.task_declaration.Value.Before(CreateScope(ScopeType.TaskDeclaration));
            Parsers.task_identifier.Value.After((args) => EnforeAndCollect(ScopeType.TaskDeclaration, args, nameof(Parsers.task_declaration), nameof(Parsers.task_identifier)));
            Parsers.task_declaration.Value.After(CloseScope());


            Parsers.inout_declaration.Value.Before(CreateScope(ScopeType.InputOutputPortDeclaration));
            Parsers.inout_declaration.Value.After(CloseScope());

            Parsers.input_declaration.Value.Before(CreateScope(ScopeType.InputPortDeclaration));
            Parsers.input_declaration.Value.After(CloseScope());

            Parsers.output_declaration.Value.Before(CreateScope(ScopeType.OutputPortDeclaration));
            Parsers.output_declaration.Value.After(CloseScope());

            Parsers.port_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                    if (args.ParserCallStack.HasParser("list_of_port_identifiers", DefaultLookUpDepth))
                    {
                        state.VerilogSymbolTable.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        state.VerilogSymbolTable.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("port", ShallowLookUpDepth))
                    {
                        state.VerilogSymbolTable.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        state.VerilogSymbolTable.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("input_declaration", ShallowLookUpDepth))
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.InputPortDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        state.VerilogSymbolTable.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("output_declaration", ShallowLookUpDepth))
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.OutputPortDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        state.VerilogSymbolTable.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("inout_declaration", ShallowLookUpDepth))
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.InputOutputPortDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        state.VerilogSymbolTable.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else
                    {
                        if (!state.VerilogSymbolTable.HasDefinition("port_identifier", name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });


            Parsers.event_declaration.Value.Before(CreateScope(ScopeType.EventDeclaration));
            Parsers.event_identifier.Value.After((args) => EnforeAndCollect(ScopeType.EventDeclaration, args, nameof(Parsers.event_declaration), "event_identifier"));
            Parsers.event_declaration.Value.After(CloseScope());

            Parsers.local_parameter_declaration.Value.Before(CreateScope(ScopeType.LocalParameterDeclaration));
            Parsers.local_parameter_declaration.Value.After(CloseScope());

            Parsers.parameter_declaration.Value.Before(CreateScope(ScopeType.ParameterDeclaration));
            Parsers.parameter_declaration.Value.After(CloseScope());
            Parsers.parameter_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                    bool hasParent = (args.ParserCallStack.HasParser("parameter_declaration", DefaultLookUpDepth)
                    || args.ParserCallStack.HasParser("local_parameter_declaration", DefaultLookUpDepth));

                    if (hasParent)
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.ParameterDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "parameter_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("module_instantiation", DefaultLookUpDepth))
                    {
                        //
                    }
                    else if (args.ParserCallStack.HasParser("aliasparam_declaration", DefaultLookUpDepth))
                    {
                        //
                    }
                    else
                    {

                        if (!state.VerilogSymbolTable.HasDefinition("parameter_identifier", name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });


            Parsers.branch_declaration.Value.Before(CreateScope(ScopeType.BranchDeclaration));
            Parsers.branch_identifier.Value.After((args) => EnforeAndCollect(ScopeType.BranchDeclaration, args, nameof(Parsers.branch_declaration), "branch_identifier", false));
            Parsers.branch_declaration.Value.After(CloseScope());

            Parsers.net_declaration.Value.Before(CreateScope(ScopeType.NetDeclaration));
            Parsers.ams_net_identifier.Value.After((args) => EnforeAndCollect(ScopeType.NetDeclaration, args, nameof(Parsers.net_declaration), "net_identifier", false));
            Parsers.net_declaration.Value.After(CloseScope());

            Parsers.udp_declaration.Value.Before(CreateScope(ScopeType.UdpDeclaration));
            Parsers.udp_identifier.Value.After((args) => EnforeAndCollect(ScopeType.UdpDeclaration, args, nameof(Parsers.net_declaration), "udp_identifier", false));
            Parsers.udp_declaration.Value.After(CloseScope());

            Parsers.reg_declaration.Value.Before(CreateScope(ScopeType.RegDeclaration));
            Parsers.reg_declaration.Value.After(CloseScope());

            Parsers.integer_declaration.Value.Before(CreateScope(ScopeType.IntegerDeclaration));
            Parsers.integer_declaration.Value.After(CloseScope());

            Parsers.time_declaration.Value.Before(CreateScope(ScopeType.TimeDeclaration));
            Parsers.time_declaration.Value.After(CloseScope());
          
            Parsers.variable_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                    if (args.ParserCallStack.HasParser("reg_declaration", DefaultLookUpDepth))
                    {
                        //state.VerilogSymbolTable.UpdateScopeName(ScopeType.RegDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("integer_declaration", DefaultLookUpDepth))
                    {
                        //state.VerilogSymbolTable.UpdateScopeName(ScopeType.IntegerDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else if (args.ParserCallStack.HasParser("time_declaration", DefaultLookUpDepth))
                    {
                        //state.VerilogSymbolTable.UpdateScopeName(ScopeType.TimeDeclaration, name);
                        state.VerilogSymbolTable.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else
                    {

                        if (!state.VerilogSymbolTable.HasDefinition("parameter_identifier", name)
                            && !state.VerilogSymbolTable.HasDefinition("variable_identifier", name)
                            && !state.VerilogSymbolTable.HasDefinition("function_identifier", name)
                            && !state.VerilogSymbolTable.HasDefinition("real_identifier", name)
                            && !state.VerilogSymbolTable.HasDefinition("genvar_identifier", name))

                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });

            Parsers.genvar_declaration.Value.Before(CreateScope(ScopeType.GenvarDeclaration));
            Parsers.genvar_declaration.Value.After(CloseScope());
            Parsers.genvar_identifier.Value.After((args) => EnforeAndCollect(new ScopeType[] { ScopeType.GenvarDeclaration}, args, new string[] { "genvar_declaration" }, "genvar_identifier", false));

            Parsers.real_declaration.Value.Before(CreateScope(ScopeType.RealDeclaration));
            Parsers.real_declaration.Value.After(CloseScope());
            Parsers.realtime_declaration.Value.Before(CreateScope(ScopeType.RealTimeDeclaration));
            Parsers.realtime_declaration.Value.After(CloseScope());
            Parsers.real_identifier.Value.After((args) => EnforeAndCollect(new ScopeType[] { ScopeType.RealDeclaration, ScopeType.RealTimeDeclaration }, args, new string[] { "real_declaration", "realtime_declaration" }, "real_identifier", false));
            Parsers.real_identifier.Value.After((args) => EnforeAndCollect(new ScopeType[] { ScopeType.RealDeclaration, ScopeType.RealTimeDeclaration }, args, new string[] { "real_declaration", "realtime_declaration" }, "variable_identifier", false));

            Parsers.aliasparam_declaration.Value.Before(CreateScope(ScopeType.AliasParam));
            Parsers.aliasparam_declaration.Value.After(CloseScope());

            // Others
            Parsers.identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            Parsers.port_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            Parsers.parameter_reference.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("parameter_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("local_parameter_identifier", value);

            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            Parsers.hierarchical_event_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("event_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("net_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("output_port", value)
                || state.VerilogSymbolTable.HasDefinition("input_port", value);
            }, new string[] { }, (obj, Scope) => obj.Text(), 0));

            Parsers.hierarchical_task_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("task_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            Parsers.escaped_identifier.Value.After((args) =>
            {
                if (args.ParserResult.WasSuccessful)
                {
                    var token = (args.ParserResult.Values[0].Value as SyntaxNode).GetFirstToken();
                    token.Value = token.Value.Substring(1);
                }
            });

            Parsers.system_parameter_identifier.Value.After(Limit<SyntaxNode>(new[] { "$mfactor", "$xposition" }, (obj, scope) => obj.Text()));

            Parsers.nature_attribute_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("nature_attribute_identifier", value)
                 || state.VerilogSymbolTable.HasDefinition("nature_attribute_access", value) && (scope.HasParser("branch_probe_function_call", DefaultLookUpDepth) || scope.HasParser("port_probe_function_call", DefaultLookUpDepth));
            }, new[] { "nature_attribute" }, (obj, scope) => obj.Text(), DefaultLookUpDepth));

            Parsers.hierarchical_function_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("function_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            Parsers.hierarchical_block_identifier.Value.After(Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasScope(ScopeType.Block, name: value);
            }, new string[] {  }, (obj, scope) => obj.Text(), 0));
        }

        private static void EnforeAndCollect(ScopeType scopeType, AfterArgs<CharToken> args, string parentName, string type, bool updateScopeName = true)
        {
            EnforeAndCollect(new ScopeType[] { scopeType }, args, new string[] { parentName }, type, updateScopeName);
        }

        private static void EnforeAndCollect(ScopeType[] scopeTypes, AfterArgs<CharToken> args, string[] parentNames, string type, bool updateScopeName = true)
        {
            var state = (VerilogParserState<CharToken>)args.GlobalState;
            if (args.ParserResult.WasSuccessful)
            {
                var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                bool found = false;
                int i = 0;
                for (; i < scopeTypes.Length; i++)
                {
                    if (args.ParserCallStack.HasParser(parentNames[i], ShallowLookUpDepth))
                    {
                        if (updateScopeName)
                        {
                            state.VerilogSymbolTable.UpdateScopeName(scopeTypes[i], name);
                        }
                        state.VerilogSymbolTable.RegisterDefinition(name, type, args.Input.Position);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (!state.VerilogSymbolTable.HasDefinition(type, name))
                    {
                        args.ParserResult.Values.Clear();
                    }
                    else
                    {
                        //state.VerilogSymbolTable.RegisterReference(name, "module_identifier", args.Input.Position);
                    }
                }

            }
        }
        private static Action<BeforeArgs<CharToken>> CreateScope(ScopeType scopeType)
        {
            return (args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(scopeType, null, args.Input.Position, null);
            };
        }

        private static Action<AfterArgs<CharToken>> CloseScope()
        {
            return (args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            };
        }

        private static void CreateContraints(string[] keywords, string[] kernel_parameters, string[] buildInFunctions)
        {
            // collect
            //Parsers.specparam_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("specparam_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("specparam_identifier", DefaultLookDownDepth).Select(node => node.Text())));

            // Enforce
            //Parsers.specparam_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "specparam_identifier" }, new[] { "specparam_declaration" }, (obj, scope) => obj.Text(), DefaultLookUpDepth));
        }

        public static Action<AfterArgs<CharToken>> Limit<TResult>(string[] allowed, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory)
        {
            return (args) =>
            {
                var obj = args.ParserResult;

                if (obj.WasSuccessful)
                {
                    List<IUnionResultValue<CharToken>> newItems = null;

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, args.ParserCallStack)?.Trim();

                        if (value != null)
                        {
                            if (allowed.Contains(value))
                            {
                                if (newItems == null)
                                {
                                    newItems = new List<IUnionResultValue<CharToken>>();
                                }
                                newItems.Add(item);
                            }
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
                    List<IUnionResultValue<CharToken>> newItems = null;

                    foreach (var item in obj.Values)
                    {
                        var value = factory(item, callStack)?.Trim();
                        if (validator(value, state, callStack))
                        {
                            if (newItems == null)
                            {
                                newItems = new List<IUnionResultValue<CharToken>>();
                            }
                            newItems.Add(item);
                        }
                    }

                    obj.Values = newItems;
                }
            };
        }

        public static Action<AfterArgs<CharToken>> Collect<TResult>(string dataSetName, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory)
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
    }
}