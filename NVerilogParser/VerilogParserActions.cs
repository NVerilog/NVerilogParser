using CFGToolkit.AST;
using CFGToolkit.AST.Providers;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Parsers;
using CFGToolkit.ParserCombinator.State;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public class VerilogParserActions
    {
        private const int DefaultLookDownDepth = 3;
        private const int DefaultLookUpDepth = 16;

        public static ConcurrentDictionary<string, ConcurrentBag<AfterParseAction<CharToken>>> AfterActions = new ConcurrentDictionary<string, ConcurrentBag<AfterParseAction<CharToken>>>();

        public static ConcurrentDictionary<string, ConcurrentBag<BeforeParseAction<CharToken>>> BeforeActions = new ConcurrentDictionary<string, ConcurrentBag<BeforeParseAction<CharToken>>>();

        static VerilogParserActions()
        {
            lock (AfterActions)
            {
                CreateActions();
            }
        }

        public static void After(string name, Action<AfterArgs<CharToken>> action)
        {
            if (!AfterActions.ContainsKey(name))
            {
                AfterActions[name] = new ConcurrentBag<AfterParseAction<CharToken>>();
            }
            AfterActions[name].Add(new AfterParseAction<CharToken>() { Index = AfterActions[name].Count, Action = action });
        }

        public static void Before(string name, Action<BeforeArgs<CharToken>> action)
        {
            if (!BeforeActions.ContainsKey(name))
            {
                BeforeActions[name] = new ConcurrentBag<BeforeParseAction<CharToken>>();
            }
            BeforeActions[name].Add(new BeforeParseAction<CharToken>() { Index = BeforeActions[name].Count, Action = action });
        }

        private static void CreateActions()
        {
            var keywordsArray = VerilogKeywords.Values;

            // Modules
            Before(nameof(Parsers.module_declaration), CreateScope(VerilogScopeType.Module));
            After(nameof(Parsers.module_declaration), CloseScope());
            After(nameof(Parsers.module_identifier), Enforce(VerilogScopeType.Module, nameof(Parsers.module_identifier), registerToParent: true));

            Before(nameof(Parsers.module_instantiation), CreateScope(VerilogScopeType.ModuleInstantiation));
            After(nameof(Parsers.module_instantiation), CloseScope());

            // Disciplines
            Before(nameof(Parsers.discipline_declaration), CreateScope(VerilogScopeType.Discipline));
            After(nameof(Parsers.discipline_declaration), CloseScope());
            After(nameof(Parsers.discipline_identifier), Enforce(VerilogScopeType.Discipline, nameof(Parsers.discipline_identifier), registerToParent: true));

            // Natures
            Before(nameof(Parsers.nature_declaration), CreateScope(VerilogScopeType.Nature));
            After(nameof(Parsers.nature_declaration), CloseScope());
            After(nameof(Parsers.nature_identifier), Enforce(VerilogScopeType.Nature, nameof(Parsers.nature_identifier), registerToParent: true));


            After(nameof(Parsers.nature_attribute), CollectToRoot<SyntaxNode>("nature_attribute_access",
              (obj, scope) => obj
              .GetValue<SyntaxNode>()
              .GetNodes("nature_attribute", DefaultLookDownDepth)
              .Where(n => n.GetNodes("nature_attribute_identifier", DefaultLookDownDepth).First().Text() == "access")
              .Select(attr => attr.GetNodes("nature_attribute_expression", DefaultLookDownDepth).First().Text())));



            // Functions
            Before(nameof(Parsers.function_declaration), CreateScope(VerilogScopeType.Function));
            After(nameof(Parsers.function_declaration), CloseScope());
            After(nameof(Parsers.function_identifier), Enforce(VerilogScopeType.Function, nameof(Parsers.function_identifier), registerToParent: true));

            // Functions
            Before(nameof(Parsers.analog_function_declaration), CreateScope(VerilogScopeType.Function));
            After(nameof(Parsers.analog_function_declaration), CloseScope());
            After(nameof(Parsers.analog_function_identifier), Enforce(VerilogScopeType.Function, nameof(Parsers.function_identifier), registerToParent: true));

            // Blocks

            Before(nameof(Parsers.seq_block), CreateScope(VerilogScopeType.Block));
            After(nameof(Parsers.seq_block), CloseScope());

            Before(nameof(Parsers.analog_function_seq_block), CreateScope(VerilogScopeType.Block));
            After(nameof(Parsers.analog_function_seq_block), CloseScope());

            Before(nameof(Parsers.analog_event_seq_block), CreateScope(VerilogScopeType.Block));
            After(nameof(Parsers.analog_event_seq_block), CloseScope());

            Before(nameof(Parsers.analog_seq_block), CreateScope(VerilogScopeType.Block));
            After(nameof(Parsers.analog_seq_block), CloseScope());

            Before(nameof(Parsers.par_block), CreateScope(VerilogScopeType.Block));
            After(nameof(Parsers.par_block), CloseScope());

            After(nameof(Parsers.block_identifier), Enforce(VerilogScopeType.Block, nameof(Parsers.block_identifier)));
            // Declarations

            Before(nameof(Parsers.paramset_declaration), CreateScope(VerilogScopeType.ParamsetDeclaration));
            After(nameof(Parsers.paramset_declaration), CloseScope());
            After(nameof(Parsers.paramset_identifier), Enforce(VerilogScopeType.ParamsetDeclaration, nameof(Parsers.paramset_identifier)));

            Before(nameof(Parsers.task_declaration), CreateScope(VerilogScopeType.TaskDeclaration));
            After(nameof(Parsers.task_declaration), CloseScope());
            After(nameof(Parsers.task_identifier), Enforce(VerilogScopeType.TaskDeclaration, nameof(Parsers.task_identifier)));


            Before(nameof(Parsers.inout_declaration), CreateScope(VerilogScopeType.InputOutputPortDeclaration));
            After(nameof(Parsers.inout_declaration), CloseScope());

            Before(nameof(Parsers.input_declaration), CreateScope(VerilogScopeType.InputPortDeclaration));
            After(nameof(Parsers.input_declaration), CloseScope());

            Before(nameof(Parsers.output_declaration), CreateScope(VerilogScopeType.OutputPortDeclaration));
            After(nameof(Parsers.output_declaration), CloseScope());

            After(nameof(Parsers.port_identifier), (args) =>
            {
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


            Before(nameof(Parsers.event_declaration), CreateScope(VerilogScopeType.EventDeclaration));
            After(nameof(Parsers.event_declaration), CloseScope());
            After(nameof(Parsers.event_identifier), Enforce(VerilogScopeType.EventDeclaration, nameof(Parsers.event_identifier)));


            Before(nameof(Parsers.local_parameter_declaration), CreateScope(VerilogScopeType.LocalParameterDeclaration));
            After(nameof(Parsers.local_parameter_declaration), CloseScope());

            Before(nameof(Parsers.parameter_declaration), CreateScope(VerilogScopeType.ParameterDeclaration));
            After(nameof(Parsers.parameter_declaration), CloseScope());

            After(nameof(Parsers.specparam_identifier), (args) =>
            {
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


            After(nameof(Parsers.parameter_identifier), (args) =>
            {
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


            Before(nameof(Parsers.branch_declaration), CreateScope(VerilogScopeType.BranchDeclaration));
            After(nameof(Parsers.branch_declaration), CloseScope());
            After(nameof(Parsers.branch_identifier), Enforce(VerilogScopeType.BranchDeclaration, nameof(Parsers.branch_identifier)));

            Before(nameof(Parsers.net_declaration), CreateScope(VerilogScopeType.NetDeclaration));
            After(nameof(Parsers.net_declaration), CloseScope());

            //After(nameof(Parsers.net_identifier), Enforce(VerilogScopeType.NetDeclaration, nameof(Parsers.net_identifier), registerToParent: true));
            //After(nameof(Parsers.ams_net_identifier), Enforce(VerilogScopeType.NetDeclaration, nameof(Parsers.net_identifier), registerToParent: true));


            Before(nameof(Parsers.udp_declaration), CreateScope(VerilogScopeType.UdpDeclaration));
            After(nameof(Parsers.udp_declaration), CloseScope());
            After(nameof(Parsers.udp_identifier), Enforce(VerilogScopeType.UdpDeclaration, nameof(Parsers.udp_identifier), registerToParent: true));

            Before(nameof(Parsers.reg_declaration), CreateScope(VerilogScopeType.RegDeclaration));
            After(nameof(Parsers.reg_declaration), CloseScope());

            Before(nameof(Parsers.integer_declaration), CreateScope(VerilogScopeType.IntegerDeclaration));
            After(nameof(Parsers.integer_declaration), CloseScope());

            Before(nameof(Parsers.time_declaration), CreateScope(VerilogScopeType.TimeDeclaration));
            After(nameof(Parsers.time_declaration), CloseScope());

            After(nameof(Parsers.variable_identifier), (args) =>
            {
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

            Before(nameof(Parsers.genvar_declaration), CreateScope(VerilogScopeType.GenvarDeclaration));
            After(nameof(Parsers.genvar_declaration), CloseScope());
            After(nameof(Parsers.genvar_identifier), Enforce(VerilogScopeType.GenvarDeclaration, nameof(Parsers.genvar_identifier), registerToParent: true));
            
            Before(nameof(Parsers.real_declaration), CreateScope(VerilogScopeType.RealDeclaration));
            After(nameof(Parsers.real_declaration), CloseScope());

            Before(nameof(Parsers.realtime_declaration), CreateScope(VerilogScopeType.RealTimeDeclaration));
            After(nameof(Parsers.realtime_declaration), CloseScope());

            After(nameof(Parsers.real_identifier), (args) =>
            {
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

            Before(nameof(Parsers.aliasparam_declaration), CreateScope(VerilogScopeType.AliasParam));
            After(nameof(Parsers.aliasparam_declaration), CloseScope());

            // Others
            After(nameof(Parsers.identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(nameof(Parsers.port_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return !keywordsArray.Contains(value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(nameof(Parsers.parameter_reference), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                var symbolScope = state.SymbolTable.GetCurrentScope(callStack);
                return symbolScope.HasDefinition(new[] { "parameter_identifier", "local_parameter_identifier" }, value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(nameof(Parsers.hierarchical_event_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                var scope = state.SymbolTable.GetCurrentScope(callStack);
                return scope.HasDefinition(new[] { "event_identifier", "net_identifier", "output_port", "input_port" }, value);

            }, new string[] { }, (obj, Scope) => obj.Text(), 0));

            After(nameof(Parsers.hierarchical_task_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("task_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(nameof(Parsers.escaped_identifier), (args) =>
            {
                if (args.ParserResult.WasSuccessful)
                {
                    var token = (args.ParserResult.Values[0].Value as SyntaxNode).GetFirstToken();
                    token.Value = token.Value.Substring(1);
                }
            });

            After(nameof(Parsers.system_parameter_identifier), Limit<SyntaxNode>(new[] { "$mfactor", "$xposition" }, (obj, scope) => obj.Text()));
            After(nameof(Parsers.nature_attribute_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                if (value == "abstol")
                {
                    return true;
                }

                var symbolScope = state.SymbolTable.GetCurrentScope(callStack);

                return symbolScope.HasDefinition("nature_attribute_identifier", value)
                 || symbolScope.HasDefinition("nature_attribute_access", value) && (callStack.IsPresent("branch_probe_function_call", DefaultLookUpDepth) || callStack.IsPresent("port_probe_function_call", DefaultLookUpDepth));
            }, new[] { "nature_attribute" }, (obj, scope) => obj.Text(), DefaultLookUpDepth));

            After(nameof(Parsers.hierarchical_function_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("function_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));

            After(nameof(Parsers.hierarchical_block_identifier), Enforce<SyntaxNode>((value, state, callStack) =>
            {
                return state.SymbolTable.GetCurrentScope(callStack).HasDefinition("block_identifier", value);
            }, new string[] { }, (obj, scope) => obj.Text(), 0));
        }

        private static Action<AfterArgs<CharToken>> Enforce(string scopeType, string definitionType, bool registerToParent = false)
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

        private static Action<BeforeArgs<CharToken>> CreateScope(string scopeType)
        {
            return (args) =>
            {
                var state = (VerilogParserState<CharToken>)args.GlobalState;
                state.SymbolTable.OpenScope(args.ParserCallStack, scopeType, args.Input.Position);
            };
        }

        private static Action<AfterArgs<CharToken>> CloseScope()
        {
            return (args) =>
            {
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

        public static Action<AfterArgs<CharToken>> CollectToRoot<TResult>(string dataSetName, Func<IUnionResultValue<CharToken>, IParserCallStack<CharToken>, IEnumerable<string>> factory)
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