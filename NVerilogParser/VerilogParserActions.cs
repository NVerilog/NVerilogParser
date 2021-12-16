using CFGToolkit.AST;
using CFGToolkit.AST.Providers;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Parsers;
using CFGToolkit.ParserCombinator.Values;
using CFGToolkit.Parsers.VerilogAMS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser
{
    public static class ParseExt
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
        private const int DefaultLookupDepth = 6;

        public static Dictionary<IParser<CharToken>, List<Action<AfterArgs<CharToken>>>> AfterActions = new Dictionary<IParser<CharToken>, List<Action<AfterArgs<CharToken>>>>();

        public static Dictionary<IParser<CharToken>, List<Action<BeforeArgs<CharToken>>>> BeforeActions = new Dictionary<IParser<CharToken>, List<Action<BeforeArgs<CharToken>>>>();

        static VerilogParserActions()
        {
            string[] keywords =
            {
                "above",
                "abs",
                "absdelay",
                "absdelta",
                "abstol",
                "access",
                "acos",
                "acosh",
                "ac_stim",
                "aliasparam",
                "always",
                "analog",
                "analysis",
                "and",
                "asin",
                "asinh",
                "assert",
                "assign",
                "atan",
                "atan2",
                "atanh",
                "automatic",
                "begin",
                "branch",
                "buf",
                "bufif0",
                "bufif1",
                "case",
                "casex",
                "casez",
                "ceil",
                "cell",
                "cmos",
                "config",
                "connect",
                "connectmodule",
                "connectrules",
                "continuous",
                "cos",
                "cosh",
                "cross",
                "ddt",
                "ddt_nature",
                "ddx",
                "deassign",
                "default",
                "defparam",
                "design",
                "disable",
                "discipline",
                "discrete",
                "domain",
                "driver_update",
                "edge",
                "else",
                "end",
                "endcase",
                "endconfig",
                "endconnectrules",
                "enddiscipline",
                "endfunction",
                "endgenerate",
                "endmodule",
                "endnature",
                "endparamset",
                "endprimitive",
                "endspecify",
                "endtable",
                "endtask",
                "event",
                "exclude",
                "exp",
                "final_step",
                "flicker_noise",
                "floor",
                "flow",
                "for",
                "force",
                "forever",
                "fork",
                "from",
                "function",
                "generate",
                "genvar",
                "ground",
                "highz0",
                "highz1",
                "hypot",
                "idt",
                "idtmod",
                "idt_nature",
                "if",
                "ifnone",
                "incdir",
                "include",
                "inf",
                "initial",
                "initial_step",
                "inout",
                "input",
                "instance",
                "integer",
                "join",
                "laplace_nd",
                "laplace_np",
                "laplace_zd",
                "laplace_zp",
                "large",
                "last_crossing",
                "liblist",
                "library",
                "limexp",
                "ln",
                "localparam",
                "log",
                "macromodule",
                "max",
                "medium",
                "merged",
                "min",
                "module",
                "nand",
                "nature",
                "negedge",
                "net_resolution",
                "nmos",
                "noise_table",
                "noise_table_log",
                "nor",
                "noshowcancelled",
                "not",
                "notif0",
                "notif1",
                "or",
                "output",
                "parameter",
                "paramset",
                "pmos",
                "posedge",
                "potential",
                "pow",
                "primitive",
                "pull0",
                "pull1",
                "pulldown",
                "pullup",
                "pulsestyle_onevent",
                "pulsestyle_ondetect",
                "rcmos",
                "real",
                "realtime",
                "reg",
                "release",
                "repeat",
                "resolveto",
                "rnmos",
                "rpmos",
                "rtran",
                "rtranif0",
                "rtranif1",
                "scalared",
                "sin",
                "sinh",
                "showcancelled",
                "signed",
                "slew",
                "small",
                "specify",
                "specparam",
                "split",
                "sqrt",
                "string",
                "strong0",
                "strong1",
                "supply0",
                "supply1",
                "table",
                "tan",
                "tanh",
                "task",
                "time",
                "timer",
                "tran",
                "tranif0",
                "tranif1",
                "transition",
                "tri",
                "tri0",
                "tri1",
                "triand",
                "trior",
                "trireg",
                "units",
                "unsigned",
                "use",
                "uwire",
                "vectored",
                "wait",
                "wand",
                "weak0",
                "weak1",
                "while",
                "white_noise",
                "wire",
                "wor",
                "wreal",
                "xnor",
                "xor",
                "zi_nd",
                "zi_np",
                "zi_zd",
                "zi_zp"
            };

            string[] kernel_parameters = { "$vt" };

            string[] buildInFunctions = { "exp", "ln", "abs", "sqrt", "analysis", "$mfactor" };

            CreateContraints(keywords, kernel_parameters, buildInFunctions);

            CreateScopes();

        }

        private static void CreateScopes()
        {
            // Modules
            Parsers.module_declaration.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Module, null, args.Input.Position, null);
            });

            Parsers.module_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                if (args.ParserResult.WasSuccessful && args.ParserCallStack.HasParser("module_declaration", 10))
                {
                    state.VerilogSymbolTable.UpdateScopeName(ScopeType.Module, args.ParserResult.Values[0].Text());
                }
            });

            Parsers.module_declaration.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                if (args.ParserResult.WasSuccessful)
                {
                    state.VerilogSymbolTable.FinishScope(args.ParserResult.Values[0].Position + args.ParserResult.Values[0].ConsumedTokens);
                }
                else
                {
                    state.VerilogSymbolTable.CleanScope();
                }
            });

            // Functions
            Parsers.function_declaration.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Function, null, args.Input.Position, null);
            });

            Parsers.function_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                if (args.ParserResult.WasSuccessful && args.ParserCallStack.HasParser("function_declaration", 10))
                {
                    state.VerilogSymbolTable.UpdateScopeName(ScopeType.Function, args.ParserResult.Values[0].Text());
                }
            });

            Parsers.function_declaration.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.block_identifier.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.seq_block.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            Parsers.seq_block.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.analog_function_seq_block.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            Parsers.analog_function_seq_block.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.analog_event_seq_block.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            Parsers.analog_event_seq_block.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.analog_seq_block.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            Parsers.analog_seq_block.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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
            Parsers.par_block.Value.Before((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
                state.VerilogSymbolTable.PushScope(ScopeType.Block, null, args.Input.Position, null);
            });
            Parsers.par_block.Value.After((args) =>
            {
                var state = (VerilogParserState)args.GlobalState;
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

            Parsers.seq_block.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("seq_block", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("block_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.task_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "task_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("task_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.nature_attribute.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("source_text", "nature_attribute_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("nature_attribute_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.nature_attribute.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("source_text", "nature_attribute_access",
                (obj, scope) => obj
                .GetValue<SyntaxNode>()
                .GetNodes("nature_attribute", DefaultLookupDepth)
                .Where(n => n.GetNodes("nature_attribute_identifier", DefaultLookupDepth).First().Text() == "access")
                .Select(attr => attr.GetNodes("nature_attribute_expression", DefaultLookupDepth).First().Text())));


            Parsers.discipline_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("source_text", "discipline_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("discipline_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.module_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("source_text", "module_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("module_identifier", DefaultLookupDepth).Select(node => node.Text())));


            Parsers.paramset_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("source_text", "paramset_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("paramset_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.udp_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "udp_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("udp_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.input_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "input_port", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.output_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "output_port", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.input_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.output_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "analog_function_declaration", "module_declaration" }, "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("port_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.net_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("ams_net_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.net_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "net_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("hierarchical_net_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.genvar_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "genvar_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("genvar_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.parameter_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "paramset_declaration", "module_declaration" }, "parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.specparam_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "module_declaration" }, "specparam_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("specparam_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.aliasparam_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "source_text" }, "parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.local_parameter_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>(new string[] { "module_declaration" }, "local_parameter_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("parameter_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.reg_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "reg_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));

            Parsers.analog_seq_block.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));
            Parsers.analog_event_seq_block.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));
            Parsers.analog_function_seq_block.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "block_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("analog_block_identifier", 5).Select(node => node.Text())));

            Parsers.function_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "function_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text())));
            Parsers.analog_function_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "analog_function_identifier", (obj, scope) =>
            {
                var tmp = obj.GetValue<SyntaxNode>().GetNodes("analog_function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text()).ToList();

                return tmp;
            }));
            Parsers.analog_function_identifier.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "analog_function_identifier", "analog_function_declaration", (obj, scope) =>
            {
                var cmp = obj.GetValue<SyntaxNode>().GetNodes("analog_function_identifier", DefaultLookupDepth).Take(1).Select(node => node.Text()).ToList();

                return cmp;
            }, depth: 3));
            Parsers.branch_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "branch_identifier", (obj, scope) =>
            {
                return obj.GetValue<SyntaxNode>().GetNodes("branch_identifier", DefaultLookupDepth).Select(node => node.Text());
            }));

            Parsers.variable_type.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "variable_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.real_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "real_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("real_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.integer_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "integer_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("variable_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.event_declaration.Value.After(VerilogParserActionTypes.Collect<SyntaxNode>("module_declaration", "event_identifier", (obj, scope) => obj.GetValue<SyntaxNode>().GetNodes("event_identifier", DefaultLookupDepth).Select(node => node.Text())));
            Parsers.specparam_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "specparam_identifier" }, new[] { "specparam_declaration" }, (obj, scope) => obj.Text()));

            Parsers.paramset_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "paramset_identifier" }, new[] { "paramset_declaration" }, (obj, scope) => obj.Text()));
            Parsers.paramset_identifier.Value.After(VerilogParserActionTypes.Not<SyntaxNode>((state, input, scope, value) =>
            {
                return state.VerilogSymbolTable.HasDefinition("module_identifier", value);
            }, (obj, scope) => obj.Text()));


            Parsers.module_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "module_identifier" }, new[] { "module_declaration", "module_instantiation" }, (obj, scope) => obj.Text(), 5));
            Parsers.module_identifier.Value.After(VerilogParserActionTypes.Not<SyntaxNode>((state, input, scope, value) =>
            {
                return state.VerilogSymbolTable.HasDefinition("paramset_identifier", value);
            }, (obj, scope) => obj.Text()));


            Parsers.udp_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "udp_identifier" }, new[] { "udp_declaration" }, (obj, scope) => obj.Text(), 5));
            Parsers.net_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("net_identifier", value);

            }, new[] { "list_of_net_identifiers", "list_of_net_decl_assignments" }, (obj, scope) => obj.Text(), DefaultLookupDepth));
            Parsers.genvar_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "genvar_identifier" }, new[] { "genvar_declaration" }, (obj, scope) => obj.Text()));
            Parsers.discipline_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "discipline_identifier" }, new[] { "discipline_declaration" }, (obj, scope) => obj.Text()));


            Parsers.function_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("function_identifier", value);
            }, new[] { "function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.hierarchical_function_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("function_identifier", value);
            }, new[] { "function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.analog_function_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("analog_function_identifier", value) && !buildInFunctions.Contains(value);
            }, new[] { "analog_function_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.parameter_reference.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {

                return state.VerilogSymbolTable.HasDefinition("parameter_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("local_parameter_identifier", value);


            }, new string[] { }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.parameter_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>(new[] { "parameter_identifier", "local_parameter_identifier" }, new[] { "local_parameter_declaration", "aliasparam_declaration", "param_assignment", "parameter_declaration", "list_of_parameter_assignments" }, (obj, scope) => obj.Text()));
            Parsers.system_parameter_identifier.Value.After(VerilogParserActionTypes.Limit<SyntaxNode>(new[] { "$mfactor", "$xposition" }, (obj, scope) => obj.Text()));


            Parsers.block_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasScope(ScopeType.Block, name: value);
            }, new[] { "seq_block", "analog_seq_block" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.hierarchical_block_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasScope(ScopeType.Block, name: value);
            }, new[] { "seq_block", "analog_seq_block" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.task_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("task_identifier", value);
            }, new[] { "task_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.hierarchical_task_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("task_identifier", value);
            }, new[] { "task_declaration" }, (obj, scope) => obj.Text(), DefaultLookupDepth));


            Parsers.identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return !forbidden.Contains(value);
            }, new[] { "attr_name" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.variable_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
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

            Parsers.nature_attribute_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("nature_attribute_identifier", value)
                 || state.VerilogSymbolTable.HasDefinition("nature_attribute_access", value) && (scope.HasParser("branch_probe_function_call", DefaultLookupDepth) || scope.HasParser("port_probe_function_call", DefaultLookupDepth));
            }, new[] { "nature_attribute" }, (obj, scope) => obj.Text(), DefaultLookupDepth));

            Parsers.port_identifier.Value.After(VerilogParserActionTypes.Not<SyntaxNode>(keywords, (obj, scope) => obj.Text()));

            Parsers.hierarchical_event_identifier.Value.After(VerilogParserActionTypes.Enforce<SyntaxNode>((value, state, scope) =>
            {
                return state.VerilogSymbolTable.HasDefinition("hierarchical_event_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("net_identifier", value)
                || state.VerilogSymbolTable.HasDefinition("output_port", value)
                || state.VerilogSymbolTable.HasDefinition("input_port", value);
            }, new[] { "event_declaration" }, (obj, Scope) => obj.Text(), DefaultLookupDepth));

            Parsers.binary_operator_6.Value.After((args) =>
            {
                if (args.Input.Position < args.Input.Source.Count - 1 && args.Input.Source[args.Input.Position + 1].Value == '&')
                {
                    args.ParserResult.Values.Clear();
                }
            });
        }
    }
}