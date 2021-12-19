using CFGToolkit.AST;
using CFGToolkit.AST.Providers;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Parsers;
using CFGToolkit.ParserCombinator.Values;
using CFGToolkit.Parsers.VerilogAMS;
using NVerilogParser.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public static class IUnionResultValueExtensions
    {
        public static string Text(this IUnionResultValue<VerilogToken> value)
        {
            if (value.EmptyMatch)
            {
                return string.Empty;
            }

            return string.Join(string.Empty, value.Reminder.Source.Skip(value.Position).Take(value.ConsumedTokens).Select(token => token.Lexem).ToArray());
        }
    }

    public static partial class ParseExt
    {
        public static void After(this IParser<VerilogToken, SyntaxNode> parser, Action<AfterArgs<VerilogToken>> action)
        {
            if (parser is EventParser<VerilogToken, SyntaxNode> e)
            {
                if (!VerilogTokenParserActions.AfterActions.ContainsKey(parser))
                {
                    VerilogTokenParserActions.AfterActions[parser] = new List<Action<AfterArgs<VerilogToken>>>();
                }
                VerilogTokenParserActions.AfterActions[parser].Add(action);
            }
        }

        public static void Before(this IParser<VerilogToken, SyntaxNode> parser, Action<BeforeArgs<VerilogToken>> action)
        {
            if (parser is EventParser<VerilogToken, SyntaxNode> e)
            {
                if (!VerilogTokenParserActions.BeforeActions.ContainsKey(parser))
                {
                    VerilogTokenParserActions.BeforeActions[parser] = new List<Action<BeforeArgs<VerilogToken>>>();
                }
                VerilogTokenParserActions.BeforeActions[parser].Add(action);
            }
        }
    }

    public class VerilogTokenParserActions
    {
        private const int DefaultLookupDepth = 6;

        public static Dictionary<IParser<VerilogToken>, List<Action<AfterArgs<VerilogToken>>>> AfterActions = new Dictionary<IParser<VerilogToken>, List<Action<AfterArgs<VerilogToken>>>>();

        public static Dictionary<IParser<VerilogToken>, List<Action<BeforeArgs<VerilogToken>>>> BeforeActions = new Dictionary<IParser<VerilogToken>, List<Action<BeforeArgs<VerilogToken>>>>();

        static VerilogTokenParserActions()
        {
            string[] kernel_parameters = { "$vt" };

            string[] buildInFunctions = { "exp", "ln", "abs", "sqrt", "analysis", "$mfactor" };

            CreateContraints(VerilogKeywords.Values, kernel_parameters, buildInFunctions);

            CreateScopes();

        }

        private static void CreateScopes()
        {
            // Modules
            TokenParsers.module_declaration.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Module, null, args.Input.Position, null);
            });

            TokenParsers.module_identifier.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful && args.ParserCallStack.HasParser("module_declaration", 10))
                {
                    var txt = args.ParserResult.Values[0].Text();

                    if (!string.IsNullOrEmpty(txt))
                    {
                        state.VerilogSymbolTable.UpdateScopeName(ScopeType.Module, txt);
                    }
                }
            });

            TokenParsers.module_declaration.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });

            /*
            // DISCIPLINE
            TokenParsers.discipline_declaration.Value.Before((args) =>
            {
                var state = (VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Discipline, null, args.Input.Position, null);
            });

            TokenParsers.discipline_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful && args.ParserCallStack.HasParser("discipline_declaration", 10))
                {
                    state.VerilogSymbolTable.UpdateScopeName(ScopeType.Discipline, args.ParserResult.Values[0].Text());
                }
            });

            TokenParsers.discipline_declaration.Value.After((args) =>
            {
                var state = (VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });*/

            // Functions
            TokenParsers.function_declaration.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Function, null, args.Input.Position, null);
            });

            TokenParsers.function_identifier.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful && args.ParserCallStack.HasParser("function_declaration", 10))
                {
                    state.VerilogSymbolTable.UpdateScopeName(ScopeType.Function, args.ParserResult.Values[0].Text());
                }
            });

            TokenParsers.function_declaration.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });

            // Blocks
            TokenParsers.block_identifier.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful
                    && (args.ParserCallStack.HasParser("seq_block", 10)
                    || args.ParserCallStack.HasParser("analog_function_seq_block", 10)
                    || args.ParserCallStack.HasParser("analog_event_seq_block", 10)
                    || args.ParserCallStack.HasParser("par_block", 10)
                    || args.ParserCallStack.HasParser("analog_seq_block", 10)))
                {
                    state.VerilogSymbolTable.UpdateScopeName(ScopeType.Block, args.ParserResult.Values[0].Text());
                }
            });

            // seq_block
            TokenParsers.seq_block.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            TokenParsers.seq_block.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });
            // analog_function_seq_block
            TokenParsers.analog_function_seq_block.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            TokenParsers.analog_function_seq_block.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });

            // analog_event_seq_block
            TokenParsers.analog_event_seq_block.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            TokenParsers.analog_event_seq_block.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });
            // analog_seq_block
            TokenParsers.analog_seq_block.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            TokenParsers.analog_seq_block.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });
            // analog_seq_block
            TokenParsers.par_block.Value.Before((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            TokenParsers.par_block.Value.After((args) =>
            {
                var state =(VerilogParserState<VerilogToken>)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });
        }

        private static void CreateContraints(string[] keywords, string[] kernel_parameters, string[] buildInFunctions)
        {
            var forbidden = new List<string>();
            forbidden.AddRange(keywords);
            forbidden.AddRange(buildInFunctions);

            TokenParsers.seq_block.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("seq_block", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("block_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.task_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "task_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("task_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.nature_attribute.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("source_text", "nature_attribute_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("nature_attribute_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.nature_attribute.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("source_text", "nature_attribute_access",
                (obj, scope) => obj
                .GetValue<SyntaxNode>()
                .GetNodes("nature_attribute", DefaultLookupDepth)
                .Where(n => n.GetNodes("nature_attribute_identifier", DefaultLookupDepth).First().Text() == "access")
                .Select(attr => attr.GetNodes("nature_attribute_expression", DefaultLookupDepth).First().Text())));


            TokenParsers.discipline_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("source_text", "discipline_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("discipline_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.module_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("source_text", "module_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("module_identifier", DefaultLookupDepth).Select(node => node.Text())));


            TokenParsers.paramset_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("source_text", "paramset_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("paramset_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.udp_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "udp_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("udp_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.input_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "input_port", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.output_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "output_port", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.input_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.output_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.net_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("ams_net_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.net_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("hierarchical_net_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.genvar_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "genvar_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("genvar_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.parameter_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "paramset_declaration", "module_declaration" }, "parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.specparam_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "module_declaration" }, "specparam_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("specparam_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.aliasparam_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "source_text" }, "parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.local_parameter_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>(new string[] { "module_declaration" }, "local_parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.reg_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "reg_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));

            TokenParsers.analog_seq_block.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));
            TokenParsers.analog_event_seq_block.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));
            TokenParsers.analog_function_seq_block.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));

            TokenParsers.function_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "function_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text())));
            TokenParsers.analog_function_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "analog_function_identifier", (obj, scope) =>
            {
                var tmp = obj.GetValue<SyntaxNode>().GetNodes("analog_function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text()).ToList();

                return tmp;
            }));
            TokenParsers.analog_function_identifier.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "analog_function_identifier", "analog_function_declaration", (obj, scope) =>
            {
                var cmp = obj.GetValue<SyntaxNode>().GetNodes("analog_function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text()).ToList();

                return cmp;
            }, depth: 3));
            TokenParsers.branch_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "branch_identifier", (obj, scope) =>
            {
                return obj.GetValue<SyntaxNode>().GetNodes("branch_identifier", DefaultLookupDepth).Select(node => node.Text());
            }));

            TokenParsers.variable_type.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "variable_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.real_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "real_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("real_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.integer_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "integer_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.event_declaration.Value.After(VerilogParserTokenActionTypes.Collect<SyntaxNode>("module_declaration", "event_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("event_identifier", DefaultLookupDepth).Select(node => node.Text())));
            TokenParsers.specparam_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "specparam_identifier" }, new[] { "specparam_declaration" }, (obj, scope) => obj.Text()));

            TokenParsers.paramset_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "paramset_identifier" }, new[] { "paramset_declaration" }, (obj, scope) => obj.Text()));
            TokenParsers.paramset_identifier.Value.After(VerilogParserTokenActionTypes.Not<SyntaxNode>((state, input, scope, value) =>
            {
                return state.VerilogSymbolTable.HasDefinition("module_identifier", value);
            }, (obj, scope) => obj.Text()));


            TokenParsers.module_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "module_identifier" }, new[] { "module_declaration", "module_instantiation" }, (obj, scope) => obj.Text(), 5));
            TokenParsers.module_identifier.Value.After(VerilogParserTokenActionTypes.Not<SyntaxNode>((state, input, scope, value) =>
            {
                return state.VerilogSymbolTable.HasDefinition("paramset_identifier", value);
            }, (obj, scope) => obj.Text()));


            TokenParsers.udp_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "udp_identifier" }, new[] { "udp_declaration" }, (obj, scope) => obj.Text(), 5));
            TokenParsers.net_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("net_identifier", value);

            }, new[] { "list_of_net_identifiers", "list_of_net_decl_assignments" }, (obj, scope) => obj.Text(), DefaultLookupDepth));
            TokenParsers.genvar_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "genvar_identifier" }, new[] { "genvar_declaration" }, (obj, scope) => obj.Text()));
            TokenParsers.discipline_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "discipline_identifier" }, new[] { "discipline_declaration" }, (obj, scope) => obj.Text()));


            TokenParsers.function_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("function_identifier", value);
            }, new[] { "function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.hierarchical_function_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("function_identifier", value);
            }, new[] { "function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.analog_function_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("analog_function_identifier", value) && !buildInFunctions.Contains(value);
            }, new[] { "analog_function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.parameter_reference.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {

                return state.VerilogSymbolTable.HasDefinition("parameter_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("local_parameter_identifier", value);


            }, new string[] { }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.parameter_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>(new[] { "parameter_identifier", "local_parameter_identifier" }, new[] { "local_parameter_declaration", "aliasparam_declaration", "param_assignment", "parameter_declaration", "list_of_parameter_assignments" }, (obj, scope) => obj.Text()));
            TokenParsers.system_parameter_identifier.Value.After(VerilogParserTokenActionTypes.Limit<SyntaxNode>(new[] { "$mfactor", "$xposition" }, (obj, scope) => obj.Text()));


            TokenParsers.block_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasScope(ScopeType.Block, name: value);
            }, new[] { "seq_block", "analog_seq_block" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.hierarchical_block_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasScope(ScopeType.Block, name: value);
            }, new[] { "seq_block", "analog_seq_block" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.task_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("task_identifier", value);
            }, new[] { "task_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.hierarchical_task_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("task_identifier", value);
            }, new[] { "task_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));


            TokenParsers.identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return !forbidden.Contains(value);
            }, new[] { "attr_name" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.variable_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return
                kernel_parameters.Contains(value)
                || state.VerilogSymbolTable.HasDefinition("genvar_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("reg_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("variable_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("integer_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("analog_function_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("real_identifier", value);
                //|| scope.HasData("local_parameter_identifier", value);
            }, new[] { "variable_type" }, (obj, Scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.nature_attribute_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("nature_attribute_identifier", value)
                 || state.VerilogSymbolTable.HasDefinition("nature_attribute_access", value) && (scope.HasParser("branch_probe_function_call", DefaultLookupDepth) || scope.HasParser("port_probe_function_call", DefaultLookupDepth));
            }, new[] { "nature_attribute" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.port_identifier.Value.After(VerilogParserTokenActionTypes.Not<SyntaxNode>(keywords, (obj, scope) => obj.Text()));

            TokenParsers.hierarchical_event_identifier.Value.After(VerilogParserTokenActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("hierarchical_event_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("net_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("output_port", value)
                || state.VerilogSymbolTable.HasDefinition("input_port", value);
            }, new[] { "event_declaration" }, (obj, Scope) => obj.Text(), DefaultLookupDepth));

            TokenParsers.binary_operator_6.Value.After((args) =>
            {
                if (args.Input.Position < args.Input.Source.Count - 1 && args.Input.Source[args.Input.Position + 1].Lexem == "&")
                {
                    args.ParserResult.Values.Clear();
                }
            });
        }
    }
}