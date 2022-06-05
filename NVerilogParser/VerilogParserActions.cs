using CFGToolkit.AST;
using CFGToolkit.AST.Providers;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public class VerilogParserActions
    {
        private const int DefaultLookDownDepth = 3;
        private const int DefaultLookUpDepth = 16;

        private static object SyncRoot = new object();

        public static void Init()
        {
            lock (SyncRoot)
            {
                CreateActions();
            }
        }

        public static void After(IParser<CharToken, SyntaxNode> parser, Action<AfterParseArgs<CharToken>> action)
        {
            parser.EnableEvents();
            parser.AfterParse.Add(action);
        }

        public static void Before(IParser<CharToken, SyntaxNode> parser, Action<BeforeParseArgs<CharToken>> action)
        {
            parser.EnableEvents();
            parser.BeforeParse.Add(action);
        }

        private static void CreateActions()
        {
            var keywordsArray = VerilogKeywords.Values;

            // Modules
            Before(Parsers.module_declaration.Value, CreateScope(VerilogScopeType.Module));
            After(Parsers.module_declaration.Value, CloseScope());
            After(Parsers.module_identifier.Value, Enforce(VerilogScopeType.Module, nameof(Parsers.module_identifier), registerToParent: true));

            Before(Parsers.module_instantiation.Value, CreateScope(VerilogScopeType.ModuleInstantiation));
            After(Parsers.module_instantiation.Value, CloseScope());

            // Disciplines
            Before(Parsers.discipline_declaration.Value, CreateScope(VerilogScopeType.Discipline));
            After(Parsers.discipline_declaration.Value, CloseScope());
            After(Parsers.discipline_identifier.Value, Enforce(VerilogScopeType.Discipline, nameof(Parsers.discipline_identifier), registerToParent: true));

            // Natures
            Before(Parsers.nature_declaration.Value, CreateScope(VerilogScopeType.Nature));
            After(Parsers.nature_declaration.Value, CloseScope());
            After(Parsers.nature_identifier.Value, Enforce(VerilogScopeType.Nature, nameof(Parsers.nature_identifier), registerToParent: true));


            After(Parsers.nature_attribute.Value, CollectToRoot<SyntaxNode>("nature_attribute_access",
              (obj, scope) => obj
              .GetValue<SyntaxNode>()
              .GetNodes("nature_attribute", DefaultLookDownDepth)
              .Where(n => n.GetNodes("nature_attribute_identifier", DefaultLookDownDepth).First().Text() == "access")
              .Select(attr => attr.GetNodes("nature_attribute_expression", DefaultLookDownDepth).First().Text())));



            // Functions
            Before(Parsers.function_declaration.Value, CreateScope(VerilogScopeType.Function));
            After(Parsers.function_declaration.Value, CloseScope());
            After(Parsers.function_identifier.Value, Enforce(VerilogScopeType.Function, nameof(Parsers.function_identifier), registerToParent: true));

            // Functions
            Before(Parsers.analog_function_declaration.Value, CreateScope(VerilogScopeType.Function));
            After(Parsers.analog_function_declaration.Value, CloseScope());
            After(Parsers.analog_function_identifier.Value, Enforce(VerilogScopeType.Function, nameof(Parsers.function_identifier), registerToParent: true));

            // Blocks

            Before(Parsers.seq_block.Value, CreateScope(VerilogScopeType.Block));
            After(Parsers.seq_block.Value, CloseScope());

            Before(Parsers.analog_function_seq_block.Value, CreateScope(VerilogScopeType.Block));
            After(Parsers.analog_function_seq_block.Value, CloseScope());

            Before(Parsers.analog_event_seq_block.Value, CreateScope(VerilogScopeType.Block));
            After(Parsers.analog_event_seq_block.Value, CloseScope());

            Before(Parsers.analog_seq_block.Value, CreateScope(VerilogScopeType.Block));
            After(Parsers.analog_seq_block.Value, CloseScope());

            Before(Parsers.par_block.Value, CreateScope(VerilogScopeType.Block));
            After(Parsers.par_block.Value, CloseScope());

            After(Parsers.block_identifier.Value, Enforce(VerilogScopeType.Block, nameof(Parsers.block_identifier)));
            // Declarations

            Before(Parsers.paramset_declaration.Value, CreateScope(VerilogScopeType.ParamsetDeclaration));
            After(Parsers.paramset_declaration.Value, CloseScope());
            After(Parsers.paramset_identifier.Value, Enforce(VerilogScopeType.ParamsetDeclaration, nameof(Parsers.paramset_identifier)));

            Before(Parsers.task_declaration.Value, CreateScope(VerilogScopeType.TaskDeclaration));
            After(Parsers.task_declaration.Value, CloseScope());
            After(Parsers.task_identifier.Value, Enforce(VerilogScopeType.TaskDeclaration, nameof(Parsers.task_identifier)));


            Before(Parsers.inout_declaration.Value, CreateScope(VerilogScopeType.InputOutputPortDeclaration));
            After(Parsers.inout_declaration.Value, CloseScope());

            Before(Parsers.input_declaration.Value, CreateScope(VerilogScopeType.InputPortDeclaration));
            After(Parsers.input_declaration.Value, CloseScope());

            Before(Parsers.output_declaration.Value, CreateScope(VerilogScopeType.OutputPortDeclaration));
            After(Parsers.output_declaration.Value, CloseScope());

            After(Parsers.port_identifier.Value, (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (scope.Type == VerilogScopeType.InputOutputPortDeclaration || scope.Type == VerilogScopeType.InputPortDeclaration || scope.Type == VerilogScopeType.OutputPortDeclaration)
                    {
                        scope.Parent.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        scope.Parent.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (scope.Type == VerilogScopeType.Function || scope.Type == VerilogScopeType.TaskDeclaration)
                    {
                        scope.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        scope.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (scope.Type == VerilogScopeType.Module)
                    {
                        scope.RegisterDefinition(name, "port_identifier", args.Input.Position);
                        scope.RegisterDefinition(name, "net_identifier", args.Input.Position);
                    }
                    else if (scope.Type == VerilogScopeType.ModuleInstantiation)
                    {
                        scope.RegisterDefinition(name, "port_identifier", args.Input.Position);
                    }
                    else
                    {
                        if (!scope.HasDefinition("port_identifier", name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });


            Before(Parsers.event_declaration.Value, CreateScope(VerilogScopeType.EventDeclaration));
            After(Parsers.event_declaration.Value, CloseScope());
            After(Parsers.event_identifier.Value, Enforce(VerilogScopeType.EventDeclaration, nameof(Parsers.event_identifier)));


            Before(Parsers.local_parameter_declaration.Value, CreateScope(VerilogScopeType.LocalParameterDeclaration));
            After(Parsers.local_parameter_declaration.Value, CloseScope());

            Before(Parsers.parameter_declaration.Value, CreateScope(VerilogScopeType.ParameterDeclaration));
            After(Parsers.parameter_declaration.Value, CloseScope());

            After(Parsers.specparam_identifier.Value, (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (!scope.HasDefinition("parameter_identifier", name))
                    {
                        args.ParserResult.Values.Clear();
                    }
                }
            });


            After(Parsers.parameter_identifier.Value, (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (scope.Type == VerilogScopeType.ParameterDeclaration || scope.Type == VerilogScopeType.LocalParameterDeclaration || scope.Type == VerilogScopeType.AliasParam)
                    {
                        if (scope.Parent != null)
                        {
                            scope.Parent.RegisterDefinition(name, "parameter_identifier", args.Input.Position);
                        }
                        else
                        {
                            state.SymbolTable.Root.RegisterDefinition(name, "parameter_identifier", args.Input.Position);
                        }

                    }
                    else if (scope.Type == VerilogScopeType.ModuleInstantiation)
                    {
                        //
                    }
                    else
                    {
                        if (!scope.HasDefinition("parameter_identifier", name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });


            Before(Parsers.branch_declaration.Value, CreateScope(VerilogScopeType.BranchDeclaration));
            After(Parsers.branch_declaration.Value, CloseScope());
            After(Parsers.branch_identifier.Value, Enforce(VerilogScopeType.BranchDeclaration, nameof(Parsers.branch_identifier)));

            Before(Parsers.net_declaration.Value, CreateScope(VerilogScopeType.NetDeclaration));
            After(Parsers.net_declaration.Value, CloseScope());

            //After(Parsers.net_identifier.Value, Enforce(VerilogScopeType.NetDeclaration, Parsers.net_identifier), registerToParent: true));
            //After(Parsers.ams_net_identifier.Value, Enforce(VerilogScopeType.NetDeclaration, Parsers.net_identifier), registerToParent: true));


            Before(Parsers.udp_declaration.Value, CreateScope(VerilogScopeType.UdpDeclaration));
            After(Parsers.udp_declaration.Value, CloseScope());
            After(Parsers.udp_identifier.Value, Enforce(VerilogScopeType.UdpDeclaration, nameof(Parsers.udp_identifier), registerToParent: true));

            Before(Parsers.reg_declaration.Value, CreateScope(VerilogScopeType.RegDeclaration));
            After(Parsers.reg_declaration.Value, CloseScope());

            Before(Parsers.integer_declaration.Value, CreateScope(VerilogScopeType.IntegerDeclaration));
            After(Parsers.integer_declaration.Value, CloseScope());

            Before(Parsers.time_declaration.Value, CreateScope(VerilogScopeType.TimeDeclaration));
            After(Parsers.time_declaration.Value, CloseScope());

            After(Parsers.variable_identifier.Value, (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (scope.Type == VerilogScopeType.RealDeclaration
                        || scope.Type == VerilogScopeType.IntegerDeclaration
                        || scope.Type == VerilogScopeType.TimeDeclaration
                        || scope.Type == VerilogScopeType.RegDeclaration)
                    {
                        scope.Parent.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else
                    {
                        if (!scope.HasDefinition(new[] { "parameter_identifier", "variable_identifier", "function_identifier", "real_identifier", "genvar_identifier" }, name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });

            Before(Parsers.genvar_declaration.Value, CreateScope(VerilogScopeType.GenvarDeclaration));
            After(Parsers.genvar_declaration.Value, CloseScope());
            After(Parsers.genvar_identifier.Value, Enforce(VerilogScopeType.GenvarDeclaration, nameof(Parsers.genvar_identifier), registerToParent: true));
            
            Before(Parsers.real_declaration.Value, CreateScope(VerilogScopeType.RealDeclaration));
            After(Parsers.real_declaration.Value, CloseScope());

            Before(Parsers.realtime_declaration.Value, CreateScope(VerilogScopeType.RealTimeDeclaration));
            After(Parsers.realtime_declaration.Value, CloseScope());

            After(Parsers.real_identifier.Value, (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (scope.Type == VerilogScopeType.RealDeclaration)
                    {
                        scope.Parent.RegisterDefinition(name, "real_identifier", args.Input.Position);
                        scope.Parent.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else if (scope.Type == VerilogScopeType.RealTimeDeclaration)
                    {
                        scope.Parent.RegisterDefinition(name, "realtime_identifier", args.Input.Position);
                        scope.Parent.RegisterDefinition(name, "variable_identifier", args.Input.Position);
                    }
                    else
                    {
                        if (!scope.HasDefinition(new[] { "real_identifier" }, name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            });

            Before(Parsers.aliasparam_declaration.Value, CreateScope(VerilogScopeType.AliasParam));
            After(Parsers.aliasparam_declaration.Value, CloseScope());

            // Others
            After(Parsers.identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(Parsers.port_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(Parsers.parameter_reference.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                var symbolScope = state.SymbolTable.GetCurrentScope(callStack);
                return symbolScope.HasDefinition(new[] { "parameter_identifier", "local_parameter_identifier" }, value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(Parsers.hierarchical_event_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                var scope = state.SymbolTable.GetCurrentScope(callStack);
                return scope.HasDefinition(new[] { "event_identifier", "net_identifier", "output_port", "input_port" }, value);

            }, new string[] { }, (obj, Scope) => obj.Text(), 0));

            After(Parsers.hierarchical_task_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("task_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(Parsers.escaped_identifier.Value, (args) =>
            {
                if (args.ParserResult.WasSuccessful)
                {
                    var token = (args.ParserResult.Values[0].Value as SyntaxNode).GetFirstToken();
                    token.Value = token.Value.Substring(1);
                }
            });

            After(Parsers.system_parameter_identifier.Value, Limit<SyntaxNode>(new[] { "$mfactor", "$xposition" }, (obj, scope) => obj.Text()));
            After(Parsers.nature_attribute_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                if (value == "abstol")
                {
                    return true;
                }

                var symbolScope = state.SymbolTable.GetCurrentScope(callStack);

                return symbolScope.HasDefinition("nature_attribute_identifier", value)
                 || symbolScope.HasDefinition("nature_attribute_access", value) && (callStack.IsPresent("branch_probe_function_call", DefaultLookUpDepth) || callStack.IsPresent("port_probe_function_call", DefaultLookUpDepth));
            }, new[] { "nature_attribute" }, (obj, scope) => obj.Text(), DefaultLookUpDepth));
            

            After(Parsers.hierarchical_function_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("function_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(Parsers.hierarchical_block_identifier.Value, Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("block_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));
        }

        private static Action<AfterParseArgs<CharToken>> Enforce(string scopeType, string definitionType, bool registerToParent = false)
        {
            return (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    var scope = state.SymbolTable.GetCurrentScope(args.ParserCallStack);

                    if (scope.Type == scopeType)
                    {
                        var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();
                        scope.Name = name;

                        if (registerToParent)
                        {
                            scope = scope.Parent ?? state.SymbolTable.Root;
                        }
                        scope.RegisterDefinition(name, definitionType, args.Input.Position);
                    }
                    else
                    {
                        var name = (args.ParserResult.Values[0].Value as SyntaxNode).Text().Trim();

                        if (!scope.HasDefinition(definitionType, name))
                        {
                            args.ParserResult.Values.Clear();
                        }
                    }
                }
            };
        }

        private static Action<BeforeParseArgs<CharToken>> CreateScope(string scopeType)
        {
            return (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                state.SymbolTable.OpenScope(args.ParserCallStack, scopeType, args.Input.Position);
            };
        }

        private static Action<AfterParseArgs<CharToken>> CloseScope()
        {
            return (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
                var state = (VerilogParserState<CharToken>)args.GlobalState;

                if (args.ParserResult.WasSuccessful)
                {
                    state.SymbolTable.GetCurrentScope(args.ParserCallStack).Close(args.Input.Position);
                }
                else
                {
                    state.SymbolTable.RemoveScope(args.ParserCallStack);
                }
            };
        }

        public static Action<AfterParseArgs<CharToken>> Limit<TResult>(string[] allowed, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory)
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

        public static Action<AfterParseArgs<CharToken>> Enforce<TResult>(Func<string, VerilogParserState<CharToken>, IParserCallStack<CharToken>, bool> validator, string[] parents, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, string> factory, int depth)
        {
            return (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }

                var obj = args.ParserResult;
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                var callStack = args.ParserCallStack;

                if (obj.WasSuccessful)
                {
                    if (parents.Any(p => callStack.IsPresent(p, depth)))
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

        public static Action<AfterParseArgs<CharToken>> CollectToRoot<TResult>(string dataSetName, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory)
        {
            return (args) =>
            {
                if (args.GlobalState is not VerilogParserState<CharToken>)
                {
                    return;
                }
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
                            state.SymbolTable.Root.RegisterDefinition(value, dataSetName, res.Position);
                        }
                    }
                }
            };
        }
    }
}