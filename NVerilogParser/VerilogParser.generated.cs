using CFGToolkit.AST;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Values;
using CFGToolkit.ParserCombinator.Parsers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NVerilogParser
{
    public partial class Parsers
    {
        public static Lazy<IParser<CharToken, SyntaxNode>> source_text =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("source_text", (args) => CreateSyntaxNode(true, true, nameof(source_text), args), new Lazy<IParser<CharToken>>(() => description.Value.Many(greedy: true))).Token().Tag("index", "0").Tag("nodeTokenize").Tag("nt", NonTerminals.source_text));

        public static Lazy<IParser<CharToken, SyntaxNode>> description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("description", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("description#0", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => module_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("description#1", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => udp_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("description#2", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => config_declaration.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("description#3", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => paramset_declaration.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("description#4", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => nature_declaration.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("description#5", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => discipline_declaration.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("description#6", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => connectrules_declaration.Value)).Tag("index", "6")).Tag("xor").Tag("nt", NonTerminals.description));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_declaration", (args) => CreateSyntaxNode(false, true, nameof(module_declaration), args), new Lazy<IParser<CharToken>>(() => module_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => module_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.module_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_keyword =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_keyword", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_keyword#0", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_0.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_keyword#1", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_1.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_keyword#2", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_2.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "module").Tag("First:1", "macromodule").Tag("First:2", "connectmodule").Tag("nt", NonTerminals.module_keyword));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_port_list", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_port_list), args), new Lazy<IParser<CharToken>>(() => _keyword_3.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_parameter_port_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.module_parameter_port_list_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_ports", (args) => CreateSyntaxNode(false, true, nameof(list_of_ports), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => port.Value), new Lazy<IParser<CharToken>>(() => list_of_ports_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.list_of_ports));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_ports_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_ports_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => port.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_ports_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations), args), new Lazy<IParser<CharToken>>(() => list_of_port_declarations_prefix.Value), new Lazy<IParser<CharToken>>(() => list_of_port_declarations_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.list_of_port_declarations));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => port_declaration.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_port_declarations_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> port =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("port#0", (args) => CreateSyntaxNode(false, true, nameof(port), args), new Lazy<IParser<CharToken>>(() => port_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("port#1", (args) => CreateSyntaxNode(false, true, nameof(port), args), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => port_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.port));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_expression", (args) => CreateSyntaxNode(false, true, nameof(port_expression), args), new Lazy<IParser<CharToken>>(() => port_reference.Value), new Lazy<IParser<CharToken>>(() => port_expression_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.port_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_expression_many", (args) => CreateSyntaxNode(false, true, nameof(port_expression_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => port_reference.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.port_expression_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_reference", (args) => CreateSyntaxNode(false, true, nameof(port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => port_reference_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.port_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_reference_optional", (args) => CreateSyntaxNode(false, true, nameof(port_reference_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.port_reference_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_declaration", (args) => CreateSyntaxNode(false, true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => port_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => port_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.port_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_item#0", (args) => CreateSyntaxNode(false, true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => port_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_item#1", (args) => CreateSyntaxNode(false, true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.module_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item_prefix.Value), new Lazy<IParser<CharToken>>(() => module_or_generate_item_rest.Value)).Tag("index", "0").Tag("xor").Tag("parallel").Tag("parallel_first").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.module_or_generate_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_or_generate_item_declaration", first: false, parallelMode: XOrParallelMode.Ordered, Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => net_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => reg_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => real_declaration.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => time_declaration.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#5", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => realtime_declaration.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#6", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => event_declaration.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#7", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => genvar_declaration.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#8", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => task_declaration.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#9", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => function_declaration.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#10", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => branch_declaration.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#11", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_function_declaration.Value)).Tag("index", "11")).Tag("xor").Tag("parallel").Tag("nt", NonTerminals.module_or_generate_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_port_module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("non_port_module_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#0", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#1", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => generate_region.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#2", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => specify_block.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#3", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#4", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#5", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.non_port_module_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_override", (args) => CreateSyntaxNode(false, true, nameof(parameter_override), args), new Lazy<IParser<CharToken>>(() => _keyword_11.Value), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.parameter_override));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("config_declaration", (args) => CreateSyntaxNode(false, true, nameof(config_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_12.Value), new Lazy<IParser<CharToken>>(() => config_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => design_statement.Value), new Lazy<IParser<CharToken>>(() => config_rule_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_13.Value)).Tag("index", "0").Tag("nt", NonTerminals.config_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement", (args) => CreateSyntaxNode(false, true, nameof(design_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_14.Value), new Lazy<IParser<CharToken>>(() => design_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.design_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement_many", (args) => CreateSyntaxNode(false, true, nameof(design_statement_many), args), new Lazy<IParser<CharToken>>(() => design_statement_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.design_statement_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement_optional", (args) => CreateSyntaxNode(false, true, nameof(design_statement_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.design_statement_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_rule_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("config_rule_statement", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#0", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => default_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#1", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#2", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value), new Lazy<IParser<CharToken>>(() => use_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#3", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#4", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value), new Lazy<IParser<CharToken>>(() => use_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "4")).Tag("xor").Tag("nt", NonTerminals.config_rule_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> default_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("default_clause", (args) => CreateSyntaxNode(false, true, nameof(default_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_15.Value)).Tag("index", "0").Tag("nt", NonTerminals.default_clause));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_clause", (args) => CreateSyntaxNode(false, true, nameof(inst_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_16.Value), new Lazy<IParser<CharToken>>(() => inst_name.Value)).Tag("index", "0").Tag("nt", NonTerminals.inst_clause));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_name", (args) => CreateSyntaxNode(false, true, nameof(inst_name), args), new Lazy<IParser<CharToken>>(() => topmodule_identifier.Value), new Lazy<IParser<CharToken>>(() => inst_name_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.inst_name));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_name_many", (args) => CreateSyntaxNode(false, true, nameof(inst_name_many), args), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => instance_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.inst_name_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_clause", (args) => CreateSyntaxNode(false, true, nameof(cell_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_17.Value), new Lazy<IParser<CharToken>>(() => cell_clause_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.cell_clause));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_clause_optional", (args) => CreateSyntaxNode(false, true, nameof(cell_clause_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("nt", NonTerminals.cell_clause_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> liblist_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("liblist_clause", (args) => CreateSyntaxNode(false, true, nameof(liblist_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_18.Value), new Lazy<IParser<CharToken>>(() => library_identifier.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.liblist_clause));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_clause", (args) => CreateSyntaxNode(false, true, nameof(use_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_19.Value), new Lazy<IParser<CharToken>>(() => use_clause_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value), new Lazy<IParser<CharToken>>(() => use_config.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.use_clause));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_clause_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_clause_optional", (args) => CreateSyntaxNode(false, true, nameof(use_clause_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("nt", NonTerminals.use_clause_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_config =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_config", (args) => CreateSyntaxNode(false, true, nameof(use_config), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => _keyword_12.Value)).Tag("index", "0").Tag("nt", NonTerminals.use_config));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_21.Value), new Lazy<IParser<CharToken>>(() => nature_identifier.Value), new Lazy<IParser<CharToken>>(() => nature_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => nature_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => nature_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_22.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => parent_nature.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> parent_nature =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parent_nature", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("parent_nature#0", (args) => CreateSyntaxNode(false, true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("parent_nature#1", (args) => CreateSyntaxNode(false, true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.parent_nature));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_item", (args) => CreateSyntaxNode(false, true, nameof(nature_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => nature_attribute_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_attribute));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_declaration", (args) => CreateSyntaxNode(false, true, nameof(discipline_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_24.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => discipline_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => discipline_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_25.Value)).Tag("index", "0").Tag("nt", NonTerminals.discipline_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(discipline_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.discipline_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discipline_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("discipline_item#0", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_binding.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_item#1", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => discipline_domain_binding.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_item#2", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute_override.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.discipline_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_binding", (args) => CreateSyntaxNode(false, true, nameof(nature_binding), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => nature_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_binding));

        public static Lazy<IParser<CharToken, SyntaxNode>> potential_or_flow =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("potential_or_flow", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("potential_or_flow#0", (args) => CreateSyntaxNode(false, true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => _keyword_26.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("potential_or_flow#1", (args) => CreateSyntaxNode(false, true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => _keyword_27.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "potential").Tag("First:1", "flow").Tag("nt", NonTerminals.potential_or_flow));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_domain_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_domain_binding", (args) => CreateSyntaxNode(false, true, nameof(discipline_domain_binding), args), new Lazy<IParser<CharToken>>(() => _keyword_28.Value), new Lazy<IParser<CharToken>>(() => discrete_or_continuous.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.discipline_domain_binding));

        public static Lazy<IParser<CharToken, SyntaxNode>> discrete_or_continuous =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discrete_or_continuous", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#0", (args) => CreateSyntaxNode(false, true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => _keyword_29.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#1", (args) => CreateSyntaxNode(false, true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => _keyword_30.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "discrete").Tag("First:1", "continuous").Tag("nt", NonTerminals.discrete_or_continuous));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_override", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_override), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => nature_attribute.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_attribute_override));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectrules_declaration", (args) => CreateSyntaxNode(false, true, nameof(connectrules_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_31.Value), new Lazy<IParser<CharToken>>(() => connectrules_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => connectrules_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_32.Value)).Tag("index", "0").Tag("nt", NonTerminals.connectrules_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connectrules_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("connectrules_item#0", (args) => CreateSyntaxNode(false, true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_insertion.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("connectrules_item#1", (args) => CreateSyntaxNode(false, true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_resolution.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.connectrules_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_insertion =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_insertion", (args) => CreateSyntaxNode(false, true, nameof(connect_insertion), args), new Lazy<IParser<CharToken>>(() => _keyword_33.Value), new Lazy<IParser<CharToken>>(() => connectmodule_identifier.Value), new Lazy<IParser<CharToken>>(() => connect_mode.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => connect_port_overrides.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.connect_insertion));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_mode =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connect_mode", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("connect_mode#0", (args) => CreateSyntaxNode(false, true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => _keyword_34.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("connect_mode#1", (args) => CreateSyntaxNode(false, true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => _keyword_35.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "merged").Tag("First:1", "split").Tag("nt", NonTerminals.connect_mode));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_port_overrides =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connect_port_overrides", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#0", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#1", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_36.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_37.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#2", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_37.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_36.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#3", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_38.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_38.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.connect_port_overrides));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_resolution", (args) => CreateSyntaxNode(false, true, nameof(connect_resolution), args), new Lazy<IParser<CharToken>>(() => _keyword_33.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => connect_resolution_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_39.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier_or_exclude.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.connect_resolution));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_resolution_many", (args) => CreateSyntaxNode(false, true, nameof(connect_resolution_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.connect_resolution_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier_or_exclude =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discipline_identifier_or_exclude", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#0", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#1", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => _keyword_40.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.discipline_identifier_or_exclude));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_declaration", (args) => CreateSyntaxNode(false, true, nameof(paramset_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_41.Value), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_statement.Value), new Lazy<IParser<CharToken>>(() => paramset_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_42.Value)).Tag("index", "0").Tag("nt", NonTerminals.paramset_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_item_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => real_declaration.Value)).Tag("index", "4")).Tag("xor").Tag("nt", NonTerminals.paramset_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_statement", (args) => CreateSyntaxNode(false, true, nameof(paramset_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => module_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.paramset_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_constant_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)).Tag("index", "2")).Tag("xor").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.paramset_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration), args), new Lazy<IParser<CharToken>>(() => local_parameter_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => local_parameter_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.local_parameter_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.local_parameter_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration), args), new Lazy<IParser<CharToken>>(() => parameter_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.parameter_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.parameter_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specparam_declaration", (args) => CreateSyntaxNode(false, true, nameof(specparam_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_44.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.specparam_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("parameter_type#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_46.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#2", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#3", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#4", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_49.Value)).Tag("index", "4")).Tag("xor").Tag("First").Tag("First:0", "integer").Tag("First:1", "realtime").Tag("First:2", "real").Tag("First:3", "time").Tag("First:4", "string").Tag("nt", NonTerminals.parameter_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> aliasparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("aliasparam_declaration", (args) => CreateSyntaxNode(false, true, nameof(aliasparam_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_50.Value), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.aliasparam_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_declaration", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_38.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => inout_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => inout_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0").Tag("nt", NonTerminals.inout_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("inout_declaration_optional", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_51.Value)).Tag("index", "1")).Tag("nt", NonTerminals.inout_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("nt", NonTerminals.inout_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_declaration", (args) => CreateSyntaxNode(false, true, nameof(input_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_36.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => input_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => input_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0").Tag("nt", NonTerminals.input_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("input_declaration_optional", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_51.Value)).Tag("index", "1")).Tag("nt", NonTerminals.input_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("nt", NonTerminals.input_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration", (args) => CreateSyntaxNode(false, true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => output_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => output_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.output_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_declaration_optional", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_51.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.output_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.output_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional_3", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.output_declaration_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("branch_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_52.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value), new Lazy<IParser<CharToken>>(() => branch_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => port_branch_declaration.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.branch_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.branch_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration), args), new Lazy<IParser<CharToken>>(() => port_branch_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => port_branch_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.port_branch_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_terminal", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#0", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#1", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#2", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#3", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#4", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#5", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.branch_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_declaration", (args) => CreateSyntaxNode(false, true, nameof(event_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_53.Value), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.event_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> integer_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("integer_declaration", (args) => CreateSyntaxNode(false, true, nameof(integer_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.integer_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_54.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_7.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#5", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_54.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_8.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#6", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_54.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_9.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_10.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#7", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_54.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_11.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_12.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#8", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#9", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#10", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_51.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#11", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_51.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#12", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_55.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "12")).Tag("xor").Tag("nt", NonTerminals.net_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_3", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_56.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_57.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "vectored").Tag("First:1", "scalared").Tag("nt", NonTerminals.net_declaration_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_4", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_5", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_56.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_57.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "vectored").Tag("First:1", "scalared").Tag("nt", NonTerminals.net_declaration_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_6", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_7", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_8", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_9", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_56.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_57.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "vectored").Tag("First:1", "scalared").Tag("nt", NonTerminals.net_declaration_optional_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_10", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_11", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_56.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_57.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "vectored").Tag("First:1", "scalared").Tag("nt", NonTerminals.net_declaration_optional_11));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_12", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.net_declaration_optional_12));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_declaration", (args) => CreateSyntaxNode(false, true, nameof(real_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.real_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> realtime_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("realtime_declaration", (args) => CreateSyntaxNode(false, true, nameof(realtime_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_46.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.realtime_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reg_declaration", (args) => CreateSyntaxNode(false, true, nameof(reg_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_58.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => reg_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.reg_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reg_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(reg_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("nt", NonTerminals.reg_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> time_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("time_declaration", (args) => CreateSyntaxNode(false, true, nameof(time_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.time_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_type#0", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_59.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#1", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_60.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#2", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_61.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#3", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_62.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#4", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_63.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#5", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_64.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#6", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_65.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#7", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_66.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#8", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_67.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#9", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_68.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#10", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_69.Value)).Tag("index", "10")).Tag("xor").Tag("First").Tag("First:0", "supply0").Tag("First:1", "supply1").Tag("First:2", "triand").Tag("First:3", "trior").Tag("First:4", "tri0").Tag("First:5", "tri1").Tag("First:6", "tri").Tag("First:7", "uwire").Tag("First:8", "wire").Tag("First:9", "wand").Tag("First:10", "wor").Tag("nt", NonTerminals.net_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_variable_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("output_variable_type#0", (args) => CreateSyntaxNode(false, true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("output_variable_type#1", (args) => CreateSyntaxNode(false, true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "integer").Tag("First:1", "time").Tag("nt", NonTerminals.output_variable_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_type", (args) => CreateSyntaxNode(false, true, nameof(real_type), args), new Lazy<IParser<CharToken>>(() => real_type_prefix.Value), new Lazy<IParser<CharToken>>(() => real_type_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.real_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_type_optional", (args) => CreateSyntaxNode(false, true, nameof(real_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.real_type_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_type", (args) => CreateSyntaxNode(false, true, nameof(variable_type), args), new Lazy<IParser<CharToken>>(() => variable_type_prefix.Value), new Lazy<IParser<CharToken>>(() => variable_type_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.variable_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_type_optional", (args) => CreateSyntaxNode(false, true, nameof(variable_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.variable_type_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> drive_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("drive_strength", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => drive_strength_prefix.Value), new Lazy<IParser<CharToken>>(() => drive_strength_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.drive_strength));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("strength0", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("strength0#0", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_59.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#1", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_70.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#2", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_71.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#3", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_72.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "supply0").Tag("First:1", "strong0").Tag("First:2", "pull0").Tag("First:3", "weak0").Tag("nt", NonTerminals.strength0));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("strength1", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("strength1#0", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_60.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#1", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_73.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#2", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_74.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#3", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_75.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "supply1").Tag("First:1", "strong1").Tag("First:2", "pull1").Tag("First:3", "weak1").Tag("nt", NonTerminals.strength1));

        public static Lazy<IParser<CharToken, SyntaxNode>> charge_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("charge_strength", (args) => CreateSyntaxNode(false, true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => charge_strength_prefix.Value), new Lazy<IParser<CharToken>>(() => charge_strength_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.charge_strength));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3", (args) => CreateSyntaxNode(false, false, nameof(delay3), args), new Lazy<IParser<CharToken>>(() => delay3_prefix.Value), new Lazy<IParser<CharToken>>(() => delay3_rest.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.delay3));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3_optional", (args) => CreateSyntaxNode(false, false, nameof(delay3_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_76.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay3_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nt", NonTerminals.delay3_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3_optional_2", (args) => CreateSyntaxNode(false, false, nameof(delay3_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_76.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nt", NonTerminals.delay3_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay2", (args) => CreateSyntaxNode(false, false, nameof(delay2), args), new Lazy<IParser<CharToken>>(() => delay2_prefix.Value), new Lazy<IParser<CharToken>>(() => delay2_rest.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.delay2));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay2_optional", (args) => CreateSyntaxNode(false, false, nameof(delay2_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_76.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nt", NonTerminals.delay2_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_value", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delay_value#0", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delay_value#1", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => real_number.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("delay_value#2", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.delay_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_branch_identifiers), args), new Lazy<IParser<CharToken>>(() => branch_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_branch_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_branch_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => branch_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_branch_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_defparam_assignments), args), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_defparam_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_defparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_defparam_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_event_identifiers), args), new Lazy<IParser<CharToken>>(() => event_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_event_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_event_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => event_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_event_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_decl_assignments), args), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_net_decl_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_decl_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_net_decl_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_identifiers), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_net_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_net_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_param_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_param_assignments), args), new Lazy<IParser<CharToken>>(() => param_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_param_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_param_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_param_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => param_assignment.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_param_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_port_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_port_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_real_identifiers), args), new Lazy<IParser<CharToken>>(() => real_type.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_real_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => real_type.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_real_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_specparam_assignments), args), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_specparam_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_specparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_specparam_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_variable_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => variable_type.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_variable_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_variable_port_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_variable_port_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_variable_port_identifiers_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_variable_port_identifiers_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> defparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("defparam_assignment", (args) => CreateSyntaxNode(false, true, nameof(defparam_assignment), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.defparam_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_decl_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_decl_assignment", (args) => CreateSyntaxNode(false, true, nameof(net_decl_assignment), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.net_decl_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> param_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("param_assignment", (args) => CreateSyntaxNode(false, true, nameof(param_assignment), args), new Lazy<IParser<CharToken>>(() => param_assignment_prefix.Value), new Lazy<IParser<CharToken>>(() => param_assignment_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.param_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specparam_assignment", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("specparam_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("specparam_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => pulse_control_specparam.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.specparam_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam), args), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_prefix.Value), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_rest.Value)).Tag("index", "0").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.pulse_control_specparam));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => error_limit_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.pulse_control_specparam_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional_2", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => error_limit_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.pulse_control_specparam_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> error_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("error_limit_value", (args) => CreateSyntaxNode(false, true, nameof(error_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.error_limit_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> reject_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reject_limit_value", (args) => CreateSyntaxNode(false, true, nameof(reject_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.reject_limit_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("limit_value", (args) => CreateSyntaxNode(false, true, nameof(limit_value), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.limit_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("dimension", (args) => CreateSyntaxNode(false, true, nameof(dimension), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.dimension));

        public static Lazy<IParser<CharToken, SyntaxNode>> range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("range", (args) => CreateSyntaxNode(false, true, nameof(range), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.range));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("value_range#0", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#1", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#2", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#3", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#4", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_77.Value), new Lazy<IParser<CharToken>>(() => @string.Value), new Lazy<IParser<CharToken>>(() => value_range_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#5", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => _keyword_40.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.value_range));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("value_range_many", (args) => CreateSyntaxNode(false, true, nameof(value_range_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.value_range_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("value_range_type#0", (args) => CreateSyntaxNode(false, true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => _keyword_79.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_type#1", (args) => CreateSyntaxNode(false, true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => _keyword_40.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "from").Tag("First:1", "exclude").Tag("nt", NonTerminals.value_range_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_80.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_81.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.value_range_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_declaration", (args) => CreateSyntaxNode(false, true, nameof(analog_function_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_82.Value), new Lazy<IParser<CharToken>>(() => _keyword_83.Value), new Lazy<IParser<CharToken>>(() => analog_function_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_84.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_function_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_type#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_type#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "integer").Tag("First:1", "real").Tag("nt", NonTerminals.analog_function_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_item_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => inout_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.analog_function_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration", (args) => CreateSyntaxNode(false, true, nameof(function_declaration), args), new Lazy<IParser<CharToken>>(() => function_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => function_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.function_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_85.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.function_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_85.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.function_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_item_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("function_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("function_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.function_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_port_list", (args) => CreateSyntaxNode(false, true, nameof(function_port_list), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => function_port_list_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.function_port_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(function_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.function_port_list_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_range_or_type", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#0", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => function_range_or_type_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#1", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#2", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#3", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_46.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#4", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value)).Tag("index", "4")).Tag("xor").Tag("nt", NonTerminals.function_range_or_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type_optional", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.function_range_or_type_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration", (args) => CreateSyntaxNode(false, true, nameof(task_declaration), args), new Lazy<IParser<CharToken>>(() => task_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => task_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.task_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_85.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.task_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_85.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.task_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_item_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.task_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_list", (args) => CreateSyntaxNode(false, true, nameof(task_port_list), args), new Lazy<IParser<CharToken>>(() => task_port_item.Value), new Lazy<IParser<CharToken>>(() => task_port_list_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.task_port_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(task_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => task_port_item.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.task_port_list_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_item", (args) => CreateSyntaxNode(false, true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => task_port_item_prefix.Value), new Lazy<IParser<CharToken>>(() => task_port_item_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.task_port_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration), args), new Lazy<IParser<CharToken>>(() => tf_input_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => tf_input_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.tf_input_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_58.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_input_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_input_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration), args), new Lazy<IParser<CharToken>>(() => tf_output_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => tf_output_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.tf_output_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_58.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_output_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_output_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration), args), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.tf_inout_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_58.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_inout_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.tf_inout_declaration_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_port_type", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("task_port_type#0", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#1", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_46.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#2", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#3", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "integer").Tag("First:1", "realtime").Tag("First:2", "real").Tag("First:3", "time").Tag("nt", NonTerminals.task_port_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_block_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.block_item_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_43.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.block_item_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => block_variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_block_variable_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => block_variable_type.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_block_variable_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_real_identifiers), args), new Lazy<IParser<CharToken>>(() => block_real_type.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_block_real_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => block_real_type.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_block_real_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_variable_type", (args) => CreateSyntaxNode(false, true, nameof(block_variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.block_variable_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_real_type", (args) => CreateSyntaxNode(false, true, nameof(block_real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.block_real_type));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("gate_instantiation", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#0", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => cmos_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#1", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => enable_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#2", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => mos_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_3.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#3", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_input_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_4.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#4", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_output_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_5.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#5", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_en_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_6.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#6", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_switchtype.Value), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_7.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#7", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => _keyword_86.Value), new Lazy<IParser<CharToken>>(() => pulldown_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_8.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#8", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => _keyword_87.Value), new Lazy<IParser<CharToken>>(() => pullup_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_9.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "8")).Tag("xor").Tag("nt", NonTerminals.gate_instantiation));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_2", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_3", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_4", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_5", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_6", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_6), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_7", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_7), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_8", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_8), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_9", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_9), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.gate_instantiation_many_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cmos_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(cmos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => ncontrol_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => pcontrol_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.cmos_switch_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("enable_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(enable_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.enable_gate_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("mos_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(mos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.mos_switch_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_input_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(n_input_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => n_input_gate_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.n_input_gate_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_input_gate_instance_many", (args) => CreateSyntaxNode(false, true, nameof(n_input_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.n_input_gate_instance_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_output_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(n_output_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => n_output_gate_instance_many.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.n_output_gate_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_output_gate_instance_many", (args) => CreateSyntaxNode(false, true, nameof(n_output_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value)).Tag("index", "0").Tag("lazy").Tag("nt", NonTerminals.n_output_gate_instance_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pass_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(pass_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.pass_switch_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_enable_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pass_enable_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(pass_enable_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.pass_enable_switch_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> pull_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pull_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(pull_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.pull_gate_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_gate_instance), args), new Lazy<IParser<CharToken>>(() => gate_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.name_of_gate_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulldown_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => pulldown_strength_prefix.Value), new Lazy<IParser<CharToken>>(() => pulldown_strength_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.pulldown_strength));

        public static Lazy<IParser<CharToken, SyntaxNode>> pullup_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pullup_strength", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => pullup_strength_prefix.Value), new Lazy<IParser<CharToken>>(() => pullup_strength_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.pullup_strength));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("enable_terminal", (args) => CreateSyntaxNode(false, true, nameof(enable_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.enable_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_terminal", (args) => CreateSyntaxNode(false, true, nameof(inout_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)).Tag("index", "0").Tag("nt", NonTerminals.inout_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_terminal", (args) => CreateSyntaxNode(false, true, nameof(input_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.input_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> ncontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ncontrol_terminal", (args) => CreateSyntaxNode(false, true, nameof(ncontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.ncontrol_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_terminal", (args) => CreateSyntaxNode(false, true, nameof(output_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)).Tag("index", "0").Tag("nt", NonTerminals.output_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> pcontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pcontrol_terminal", (args) => CreateSyntaxNode(false, true, nameof(pcontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.pcontrol_terminal));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("cmos_switchtype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("cmos_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_88.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("cmos_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_89.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "cmos").Tag("First:1", "rcmos").Tag("nt", NonTerminals.cmos_switchtype));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("enable_gatetype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_90.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_91.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#2", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_92.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#3", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_93.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "bufif0").Tag("First:1", "bufif1").Tag("First:2", "notif0").Tag("First:3", "notif1").Tag("nt", NonTerminals.enable_gatetype));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("mos_switchtype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_94.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_95.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#2", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_96.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#3", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_97.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "nmos").Tag("First:1", "pmos").Tag("First:2", "rnmos").Tag("First:3", "rpmos").Tag("nt", NonTerminals.mos_switchtype));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("n_input_gatetype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_98.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_99.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#2", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_100.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#3", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_101.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#4", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_102.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#5", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_103.Value)).Tag("index", "5")).Tag("xor").Tag("First").Tag("First:0", "and").Tag("First:1", "nand").Tag("First:2", "or").Tag("First:3", "nor").Tag("First:4", "xor").Tag("First:5", "xnor").Tag("nt", NonTerminals.n_input_gatetype));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("n_output_gatetype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("n_output_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_104.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("n_output_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_105.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "buf").Tag("First:1", "not").Tag("nt", NonTerminals.n_output_gatetype));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_en_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pass_en_switchtype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_106.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_107.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#2", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_108.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#3", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_109.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "tranif0").Tag("First:1", "tranif1").Tag("First:2", "rtranif1").Tag("First:3", "rtranif0").Tag("nt", NonTerminals.pass_en_switchtype));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pass_switchtype", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("pass_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_110.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pass_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_111.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "tran").Tag("First:1", "rtran").Tag("nt", NonTerminals.pass_switchtype));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instantiation", (args) => CreateSyntaxNode(false, true, nameof(module_instantiation), args), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => module_instance.Value), new Lazy<IParser<CharToken>>(() => module_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_instantiation));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(module_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => module_instance.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.module_instantiation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_value_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment), args), new Lazy<IParser<CharToken>>(() => parameter_value_assignment_prefix.Value), new Lazy<IParser<CharToken>>(() => parameter_value_assignment_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.parameter_value_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_parameter_assignments", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many_2.Value.Many(greedy: true))).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.list_of_parameter_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_parameter_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_parameter_assignments_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ordered_parameter_assignment", (args) => CreateSyntaxNode(false, true, nameof(ordered_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.ordered_parameter_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => named_parameter_assignment_prefix.Value), new Lazy<IParser<CharToken>>(() => named_parameter_assignment_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.named_parameter_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance", (args) => CreateSyntaxNode(false, true, nameof(module_instance), args), new Lazy<IParser<CharToken>>(() => name_of_module_instance.Value), new Lazy<IParser<CharToken>>(() => module_instance_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.module_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance_optional", (args) => CreateSyntaxNode(false, true, nameof(module_instance_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_instance_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_module_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_module_instance), args), new Lazy<IParser<CharToken>>(() => module_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.name_of_module_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_port_connections", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => named_port_connection.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many_2.Value.Many(greedy: true))).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.list_of_port_connections));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_port_connections_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => named_port_connection.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_port_connections_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ordered_port_connection", (args) => CreateSyntaxNode(false, true, nameof(ordered_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.ordered_port_connection));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("named_port_connection", (args) => CreateSyntaxNode(false, true, nameof(named_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.named_port_connection));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_region =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_region", (args) => CreateSyntaxNode(false, true, nameof(generate_region), args), new Lazy<IParser<CharToken>>(() => _keyword_112.Value), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_113.Value)).Tag("index", "0").Tag("nt", NonTerminals.generate_region));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_declaration", (args) => CreateSyntaxNode(false, true, nameof(genvar_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_114.Value), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.genvar_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_genvar_identifiers), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_genvar_identifiers));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_genvar_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_genvar_identifiers_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_generate_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_loop_generate_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_generate_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_loop_generate_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("loop_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(loop_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => generate_block.Value)).Tag("index", "0").Tag("nt", NonTerminals.loop_generate_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_initialization =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_initialization", (args) => CreateSyntaxNode(false, true, nameof(genvar_initialization), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.genvar_initialization));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("genvar_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("genvar_expression#0", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_primary.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression#1", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => genvar_primary.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)).Tag("index", "1")).Tag("xor").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.genvar_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_iteration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_iteration", (args) => CreateSyntaxNode(false, true, nameof(genvar_iteration), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.genvar_iteration));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_primary", (args) => CreateSyntaxNode(false, true, nameof(genvar_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)).Tag("index", "0").Tag("nt", NonTerminals.genvar_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("conditional_generate_construct", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#0", (args) => CreateSyntaxNode(false, true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => if_generate_construct.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#1", (args) => CreateSyntaxNode(false, true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => case_generate_construct.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "if").Tag("First:1", "case").Tag("nt", NonTerminals.conditional_generate_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(if_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value), new Lazy<IParser<CharToken>>(() => if_generate_construct_else.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.if_generate_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_generate_construct_else", (args) => CreateSyntaxNode(false, true, nameof(if_generate_construct_else), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value)).Tag("index", "0").Tag("greedy").Tag("nt", NonTerminals.if_generate_construct_else));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(case_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_118.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => case_generate_item.Value), new Lazy<IParser<CharToken>>(() => case_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "0").Tag("nt", NonTerminals.case_generate_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_generate_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("case_generate_item#0", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => case_generate_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("case_generate_item#1", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => _keyword_15.Value), new Lazy<IParser<CharToken>>(() => case_generate_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.case_generate_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_item_many", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.case_generate_item_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_item_optional", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.case_generate_item_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("generate_block", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("generate_block#0", (args) => CreateSyntaxNode(false, true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => _keyword_120.Value), new Lazy<IParser<CharToken>>(() => generate_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_121.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("generate_block#1", (args) => CreateSyntaxNode(false, true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.generate_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_block_optional", (args) => CreateSyntaxNode(false, true, nameof(generate_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => generate_block_identifier.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.generate_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("generate_block_or_null", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("generate_block_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => generate_block.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("generate_block_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("nt", NonTerminals.generate_block_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration), args), new Lazy<IParser<CharToken>>(() => udp_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => udp_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.udp_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_port_list", (args) => CreateSyntaxNode(false, true, nameof(udp_port_list), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value), new Lazy<IParser<CharToken>>(() => udp_port_list_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.udp_port_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(udp_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.udp_port_list_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_port_list), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.udp_declaration_port_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.udp_declaration_port_list_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_port_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_reg_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.udp_port_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration_prefix.Value), new Lazy<IParser<CharToken>>(() => udp_output_declaration_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.udp_output_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.udp_output_declaration_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_input_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_input_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_36.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_input_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_reg_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_reg_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_58.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_reg_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("udp_body", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("udp_body#0", (args) => CreateSyntaxNode(false, true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => combinational_body.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("udp_body#1", (args) => CreateSyntaxNode(false, true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => sequential_body.Value)).Tag("index", "1")).Tag("nt", NonTerminals.udp_body));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("combinational_body", (args) => CreateSyntaxNode(false, true, nameof(combinational_body), args), new Lazy<IParser<CharToken>>(() => _keyword_122.Value), new Lazy<IParser<CharToken>>(() => combinational_entry.Value), new Lazy<IParser<CharToken>>(() => combinational_entry.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_123.Value)).Tag("index", "0").Tag("nt", NonTerminals.combinational_body));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("combinational_entry", (args) => CreateSyntaxNode(false, true, nameof(combinational_entry), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => output_symbol.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.combinational_entry));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("sequential_body", (args) => CreateSyntaxNode(false, true, nameof(sequential_body), args), new Lazy<IParser<CharToken>>(() => udp_initial_statement.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_122.Value), new Lazy<IParser<CharToken>>(() => sequential_entry.Value), new Lazy<IParser<CharToken>>(() => sequential_entry.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_123.Value)).Tag("index", "0").Tag("nt", NonTerminals.sequential_body));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_initial_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_initial_statement", (args) => CreateSyntaxNode(false, true, nameof(udp_initial_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_124.Value), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => init_val.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_initial_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> init_val =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("init_val", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("init_val#0", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_125.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#1", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_126.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#2", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_127.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#3", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_128.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#4", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_129.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#5", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_130.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#6", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_131.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#7", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_132.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#8", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_133.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#9", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_134.Value)).Tag("index", "9")).Tag("xor").Tag("First").Tag("First:0", "1'b0").Tag("First:1", "1'b1").Tag("First:2", "1'bx").Tag("First:3", "1'bX").Tag("First:4", "1'B0").Tag("First:5", "1'B1").Tag("First:6", "1'Bx").Tag("First:7", "1'BX").Tag("First:8", "1").Tag("First:9", "0").Tag("nt", NonTerminals.init_val));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("sequential_entry", (args) => CreateSyntaxNode(false, true, nameof(sequential_entry), args), new Lazy<IParser<CharToken>>(() => seq_input_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => current_state.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => next_state.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.sequential_entry));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("seq_input_list", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("seq_input_list#0", (args) => CreateSyntaxNode(false, true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("seq_input_list#1", (args) => CreateSyntaxNode(false, true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => edge_input_list.Value)).Tag("index", "1")).Tag("nt", NonTerminals.seq_input_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("level_input_list", (args) => CreateSyntaxNode(false, true, nameof(level_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.level_input_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_input_list", (args) => CreateSyntaxNode(false, true, nameof(edge_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => edge_indicator.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.edge_input_list));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_indicator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("edge_indicator", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("edge_indicator#0", (args) => CreateSyntaxNode(false, true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_indicator#1", (args) => CreateSyntaxNode(false, true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => edge_symbol.Value)).Tag("index", "1")).Tag("nt", NonTerminals.edge_indicator));

        public static Lazy<IParser<CharToken, SyntaxNode>> current_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("current_state", (args) => CreateSyntaxNode(false, true, nameof(current_state), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value)).Tag("index", "0").Tag("nt", NonTerminals.current_state));

        public static Lazy<IParser<CharToken, SyntaxNode>> next_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("next_state", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("next_state#0", (args) => CreateSyntaxNode(false, true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => output_symbol.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("next_state#1", (args) => CreateSyntaxNode(false, true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => _keyword_135.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.next_state));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_symbol", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("output_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_134.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_133.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_136.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_137.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "0").Tag("First:1", "1").Tag("First:2", "x").Tag("First:3", "X").Tag("nt", NonTerminals.output_symbol));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("level_symbol", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("level_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_134.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_133.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_136.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_137.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#4", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#5", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_139.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#6", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_140.Value)).Tag("index", "6")).Tag("xor").Tag("First").Tag("First:0", "0").Tag("First:1", "1").Tag("First:2", "x").Tag("First:3", "X").Tag("First:4", "?").Tag("First:5", "b").Tag("First:6", "B").Tag("nt", NonTerminals.level_symbol));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_symbol", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_141.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_142.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_143.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_144.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#4", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_145.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#5", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_146.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#6", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_147.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#7", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_148.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#8", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_149.Value)).Tag("index", "8")).Tag("xor").Tag("First").Tag("First:0", "r").Tag("First:1", "R").Tag("First:2", "f").Tag("First:3", "F").Tag("First:4", "p").Tag("First:5", "P").Tag("First:6", "n").Tag("First:7", "N").Tag("First:8", "*").Tag("nt", NonTerminals.edge_symbol));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instantiation", (args) => CreateSyntaxNode(false, true, nameof(udp_instantiation), args), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => udp_instance.Value), new Lazy<IParser<CharToken>>(() => udp_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_instantiation));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(udp_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => udp_instance.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.udp_instantiation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance", (args) => CreateSyntaxNode(false, true, nameof(udp_instance), args), new Lazy<IParser<CharToken>>(() => name_of_udp_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => udp_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance_many", (args) => CreateSyntaxNode(false, true, nameof(udp_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.udp_instance_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_udp_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_udp_instance), args), new Lazy<IParser<CharToken>>(() => udp_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.name_of_udp_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> continuous_assign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("continuous_assign", (args) => CreateSyntaxNode(false, true, nameof(continuous_assign), args), new Lazy<IParser<CharToken>>(() => _keyword_150.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.continuous_assign));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_assignments), args), new Lazy<IParser<CharToken>>(() => net_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_net_assignments_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_net_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => net_assignment.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_net_assignments_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_assignment", (args) => CreateSyntaxNode(false, true, nameof(net_assignment), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.net_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_construct", (args) => CreateSyntaxNode(false, true, nameof(analog_construct), args), new Lazy<IParser<CharToken>>(() => analog_construct_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_construct_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_procedural_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_procedural_assignment", (args) => CreateSyntaxNode(false, true, nameof(analog_procedural_assignment), args), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_procedural_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_variable_assignment", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_assignment.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => array_analog_variable_assignment.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_variable_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.scalar_analog_variable_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue_prefix.Value), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.scalar_analog_variable_lvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.scalar_analog_variable_lvalue_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> initial_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("initial_construct", (args) => CreateSyntaxNode(false, true, nameof(initial_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_124.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0").Tag("nt", NonTerminals.initial_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> always_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("always_construct", (args) => CreateSyntaxNode(false, true, nameof(always_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_151.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0").Tag("nt", NonTerminals.always_construct));

        public static Lazy<IParser<CharToken, SyntaxNode>> blocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("blocking_assignment", (args) => CreateSyntaxNode(false, true, nameof(blocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.blocking_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> nonblocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nonblocking_assignment", (args) => CreateSyntaxNode(false, true, nameof(nonblocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_152.Value), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.nonblocking_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_continuous_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("procedural_continuous_assignments", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#0", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_150.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#1", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_153.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#2", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_154.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#3", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_154.Value), new Lazy<IParser<CharToken>>(() => net_assignment.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#4", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_155.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#5", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_155.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.procedural_continuous_assignments));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(variable_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.variable_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_120.Value), new Lazy<IParser<CharToken>>(() => analog_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_121.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_seq_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_seq_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_event_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_120.Value), new Lazy<IParser<CharToken>>(() => analog_event_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_121.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_event_seq_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_event_seq_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_function_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_120.Value), new Lazy<IParser<CharToken>>(() => analog_function_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_121.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_function_seq_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_function_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_function_seq_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("par_block", (args) => CreateSyntaxNode(false, true, nameof(par_block), args), new Lazy<IParser<CharToken>>(() => _keyword_156.Value), new Lazy<IParser<CharToken>>(() => par_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_157.Value)).Tag("index", "0").Tag("nt", NonTerminals.par_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("par_block_optional", (args) => CreateSyntaxNode(false, true, nameof(par_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => block_identifier.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.par_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("seq_block", (args) => CreateSyntaxNode(false, true, nameof(seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_120.Value), new Lazy<IParser<CharToken>>(() => seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_121.Value)).Tag("index", "0").Tag("nt", NonTerminals.seq_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => block_identifier.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.seq_block_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_statement", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => analog_statement_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_statement_rest.Value)).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_statement_or_null", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_statement_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => analog_event_statement_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_event_statement_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_event_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => analog_function_statement_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_function_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement_or_null", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_function_statement_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("statement", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => statement_prefix.Value), new Lazy<IParser<CharToken>>(() => statement_rest.Value)).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("statement_or_null", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.statement_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_statement", (args) => CreateSyntaxNode(false, true, nameof(function_statement), args), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0").Tag("nt", NonTerminals.function_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_control_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control_statement), args), new Lazy<IParser<CharToken>>(() => analog_event_control.Value), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_event_control_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_control", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control), args), new Lazy<IParser<CharToken>>(() => analog_event_control_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_event_control_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_event_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_158.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_159.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_160.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_161.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "6")).Tag("xor").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.analog_event_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_expression_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_event_expression_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_many", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_event_expression_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_many_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_event_expression_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_functions", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_163.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_164.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_165.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_166.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "cross").Tag("First:1", "above").Tag("First:2", "timer").Tag("First:3", "absdelta").Tag("nt", NonTerminals.analog_event_functions));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_5.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_6.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_7.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_8.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_9.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_10.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_11.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_8", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_12.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_9", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_13.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_10", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_11", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_11));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_12", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_12));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_13", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_event_functions_optional_13));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay_control", (args) => CreateSyntaxNode(true, false, nameof(delay_control), args), new Lazy<IParser<CharToken>>(() => delay_control_prefix.Value), new Lazy<IParser<CharToken>>(() => delay_control_rest.Value)).Token().Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nodeTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.delay_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_or_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_or_event_control", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#0", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#1", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#2", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_167.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => event_control.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.delay_or_event_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> disable_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("disable_statement", (args) => CreateSyntaxNode(false, true, nameof(disable_statement), args), new Lazy<IParser<CharToken>>(() => disable_statement_prefix.Value), new Lazy<IParser<CharToken>>(() => disable_statement_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.disable_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_control", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("event_control#0", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_168.Value), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#1", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_168.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#2", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_169.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#3", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_168.Value), new Lazy<IParser<CharToken>>(() => _keyword_170.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.event_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_trigger", (args) => CreateSyntaxNode(false, true, nameof(event_trigger), args), new Lazy<IParser<CharToken>>(() => _keyword_171.Value), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => event_trigger_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.event_trigger));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_trigger_many", (args) => CreateSyntaxNode(false, true, nameof(event_trigger_many), args), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.event_trigger_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("event_expression#0", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_158.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#1", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_159.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#2", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#3", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#4", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_172.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#5", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#6", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "6")).Tag("xor").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.event_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("procedural_timing_control", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control#0", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control#1", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.procedural_timing_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control_statement", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control_statement), args), new Lazy<IParser<CharToken>>(() => procedural_timing_control.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0").Tag("nt", NonTerminals.procedural_timing_control_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> wait_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("wait_statement", (args) => CreateSyntaxNode(false, true, nameof(wait_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_173.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0").Tag("nt", NonTerminals.wait_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_else.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_conditional_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_many", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_conditional_statement_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)).Tag("index", "0").Tag("greedy").Tag("nt", NonTerminals.analog_conditional_statement_else));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_else.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_function_conditional_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_function_conditional_statement_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)).Tag("index", "0").Tag("greedy").Tag("nt", NonTerminals.analog_function_conditional_statement_else));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("conditional_statement", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("conditional_statement#0", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => conditional_statement_else.Value.Optional(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("conditional_statement#1", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => if_else_if_statement.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.conditional_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0").Tag("greedy").Tag("nt", NonTerminals.conditional_statement_else));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => if_else_if_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => if_else_if_statement_else.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.if_else_if_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement_many", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.if_else_if_statement_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement_else", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_117.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0").Tag("greedy").Tag("nt", NonTerminals.if_else_if_statement_else));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_case_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_118.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_174.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_175.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "case").Tag("First:1", "casex").Tag("First:2", "casez").Tag("nt", NonTerminals.analog_case_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_case_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_case_item#0", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_item#1", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_15.Value), new Lazy<IParser<CharToken>>(() => analog_case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_case_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_case_item_many", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_case_item_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_case_item_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_118.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_function_case_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_case_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_15.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_function_case_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_function_case_item_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_function_case_item_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("case_statement#0", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_118.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("case_statement#1", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_175.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("case_statement#2", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_174.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_119.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "case").Tag("First:1", "casez").Tag("First:2", "casex").Tag("nt", NonTerminals.case_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("case_item#0", (args) => CreateSyntaxNode(false, true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("case_item#1", (args) => CreateSyntaxNode(false, true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_15.Value), new Lazy<IParser<CharToken>>(() => case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.case_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_item_many", (args) => CreateSyntaxNode(false, true, nameof(case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.case_item_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.case_item_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_loop_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_167.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_176.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "repeat").Tag("First:1", "while").Tag("First:2", "for").Tag("nt", NonTerminals.analog_loop_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_loop_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_167.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_176.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "repeat").Tag("First:1", "while").Tag("First:2", "for").Tag("nt", NonTerminals.analog_function_loop_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement_loop_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_177.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_167.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_176.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "forever").Tag("First:1", "repeat").Tag("First:2", "while").Tag("First:3", "for").Tag("nt", NonTerminals.analog_function_statement_loop_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("loop_statement", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_177.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_167.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_176.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#3", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_115.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => statement.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "forever").Tag("First:1", "repeat").Tag("First:2", "while").Tag("First:3", "for").Tag("nt", NonTerminals.loop_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable), args), new Lazy<IParser<CharToken>>(() => analog_system_task_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_system_task_enable));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_system_task_enable_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_system_task_enable_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value), new Lazy<IParser<CharToken>>(() => system_task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.system_task_enable));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => system_task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.system_task_enable_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.system_task_enable_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable", (args) => CreateSyntaxNode(false, true, nameof(task_enable), args), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value), new Lazy<IParser<CharToken>>(() => task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.task_enable));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.task_enable_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.task_enable_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("contribution_statement", (args) => CreateSyntaxNode(false, true, nameof(contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_178.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.contribution_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_contribution_statement", (args) => CreateSyntaxNode(false, true, nameof(indirect_contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => indirect_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_179.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.indirect_contribution_statement));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_block", (args) => CreateSyntaxNode(false, true, nameof(specify_block), args), new Lazy<IParser<CharToken>>(() => _keyword_180.Value), new Lazy<IParser<CharToken>>(() => specify_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_181.Value)).Tag("index", "0").Tag("nt", NonTerminals.specify_block));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specify_item", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("specify_item#0", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#1", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => pulsestyle_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#2", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => showcancelled_declaration.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#3", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => path_declaration.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#4", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => system_timing_check.Value)).Tag("index", "4")).Tag("xor").Tag("nt", NonTerminals.specify_item));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulsestyle_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pulsestyle_declaration", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_182.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_183.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "pulsestyle_onevent").Tag("First:1", "pulsestyle_ondetect").Tag("nt", NonTerminals.pulsestyle_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> showcancelled_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("showcancelled_declaration", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_184.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_185.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "showcancelled").Tag("First:1", "noshowcancelled").Tag("nt", NonTerminals.showcancelled_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("path_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("path_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => state_dependent_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.path_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("simple_path_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("simple_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("simple_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.simple_path_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parallel_path_description", (args) => CreateSyntaxNode(false, true, nameof(parallel_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_186.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.parallel_path_description));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("full_path_description", (args) => CreateSyntaxNode(false, true, nameof(full_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_187.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.full_path_description));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_inputs", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_inputs), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => list_of_path_inputs_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_188.Value)).Tag("index", "0").Tag("nt", NonTerminals.list_of_path_inputs));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_inputs_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_inputs_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_path_inputs_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_outputs", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_outputs), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.list_of_path_outputs));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_outputs_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_outputs_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.list_of_path_outputs_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor", (args) => CreateSyntaxNode(false, true, nameof(specify_input_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => input_identifier.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.specify_input_terminal_descriptor));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor_optional", (args) => CreateSyntaxNode(false, true, nameof(specify_input_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.specify_input_terminal_descriptor_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor", (args) => CreateSyntaxNode(false, true, nameof(specify_output_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => output_identifier.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.specify_output_terminal_descriptor));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor_optional", (args) => CreateSyntaxNode(false, true, nameof(specify_output_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.specify_output_terminal_descriptor_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("input_identifier", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("input_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("input_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.input_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_identifier", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("output_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("output_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.output_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("path_delay_value", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("path_delay_value#0", (args) => CreateSyntaxNode(false, true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("path_delay_value#1", (args) => CreateSyntaxNode(false, true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.path_delay_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_delay_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_path_delay_expressions", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t_path_delay_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#2", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tz_path_delay_expression.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#3", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#4", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t0x_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tx1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => t1x_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tx0_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => txz_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => tzx_path_delay_expression.Value)).Tag("index", "4")).Tag("xor").Tag("nt", NonTerminals.list_of_path_delay_expressions));

        public static Lazy<IParser<CharToken, SyntaxNode>> t_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> trise_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("trise_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(trise_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.trise_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tfall_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tfall_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tfall_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tfall_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tz_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t01_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t01_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t01_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t01_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t10_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t10_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t10_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t10_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t0z_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t0z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t0z_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz1_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tz1_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t1z_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t1z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t1z_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz0_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tz0_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t0x_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t0x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t0x_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tx1_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tx1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tx1_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t1x_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t1x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.t1x_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tx0_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tx0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tx0_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> txz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("txz_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(txz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.txz_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> tzx_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tzx_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tzx_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.tzx_path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(path_delay_expression), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.path_delay_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_sensitive_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_sensitive_path_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_edge_sensitive_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_edge_sensitive_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.edge_sensitive_path_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parallel_edge_sensitive_path_description", (args) => CreateSyntaxNode(false, true, nameof(parallel_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_186.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => data_source_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.parallel_edge_sensitive_path_description));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("full_edge_sensitive_path_description", (args) => CreateSyntaxNode(false, true, nameof(full_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_187.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => data_source_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.full_edge_sensitive_path_description));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_source_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("data_source_expression", (args) => CreateSyntaxNode(false, true, nameof(data_source_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.data_source_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_identifier", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("edge_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_158.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_159.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "posedge").Tag("First:1", "negedge").Tag("nt", NonTerminals.edge_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> state_dependent_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("state_dependent_path_declaration", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_116.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_189.Value), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.state_dependent_path_declaration));

        public static Lazy<IParser<CharToken, SyntaxNode>> polarity_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("polarity_operator", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("polarity_operator#0", (args) => CreateSyntaxNode(false, true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_190.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("polarity_operator#1", (args) => CreateSyntaxNode(false, true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_135.Value)).Tag("index", "1")).Tag("First").Tag("First:0", "+").Tag("First:1", "-").Tag("nt", NonTerminals.polarity_operator));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("system_timing_check", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#0", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setup_timing_check.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#1", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => hold_timing_check.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#2", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setuphold_timing_check.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#3", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recovery_timing_check.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#4", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => removal_timing_check.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#5", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recrem_timing_check.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#6", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => skew_timing_check.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#7", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => timeskew_timing_check.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#8", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => fullskew_timing_check.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#9", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => period_timing_check.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#10", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => width_timing_check.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#11", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => nochange_timing_check.Value)).Tag("index", "11")).Tag("xor").Tag("First").Tag("First:0", "$setup").Tag("First:1", "$hold").Tag("First:2", "$setuphold").Tag("First:3", "$recovery").Tag("First:4", "$removal").Tag("First:5", "$recrem").Tag("First:6", "$skew").Tag("First:7", "$timeskew").Tag("First:8", "$fullskew").Tag("First:9", "$period").Tag("First:10", "$width").Tag("First:11", "$nochange").Tag("nt", NonTerminals.system_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setup_timing_check", (args) => CreateSyntaxNode(false, true, nameof(setup_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_191.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => setup_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.setup_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setup_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(setup_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setup_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hold_timing_check", (args) => CreateSyntaxNode(false, true, nameof(hold_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_192.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => hold_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.hold_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hold_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(hold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.hold_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_193.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_3.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_4.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_4", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_5.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_5", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.setuphold_timing_check_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recovery_timing_check", (args) => CreateSyntaxNode(false, true, nameof(recovery_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_194.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => recovery_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.recovery_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recovery_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(recovery_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recovery_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("removal_timing_check", (args) => CreateSyntaxNode(false, true, nameof(removal_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_195.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => removal_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.removal_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("removal_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(removal_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.removal_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_196.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_3.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_4.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_4", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_5.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_5", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.recrem_timing_check_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("skew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(skew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_197.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => skew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.skew_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("skew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(skew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.skew_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_198.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.timeskew_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.timeskew_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_3.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.timeskew_timing_check_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.timeskew_timing_check_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_199.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.fullskew_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.fullskew_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_3.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.fullskew_timing_check_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.fullskew_timing_check_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("period_timing_check", (args) => CreateSyntaxNode(false, true, nameof(period_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_200.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => period_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.period_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("period_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(period_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.period_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_201.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => width_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.width_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => threshold.Value), new Lazy<IParser<CharToken>>(() => width_timing_check_optional_2.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.width_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.width_timing_check_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nochange_timing_check", (args) => CreateSyntaxNode(false, true, nameof(nochange_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_202.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => start_edge_offset.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => end_edge_offset.Value), new Lazy<IParser<CharToken>>(() => nochange_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.nochange_timing_check));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nochange_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(nochange_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.nochange_timing_check_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> checktime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("checktime_condition", (args) => CreateSyntaxNode(false, true, nameof(checktime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.checktime_condition));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_reference_event", (args) => CreateSyntaxNode(false, true, nameof(controlled_reference_event), args), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event.Value)).Tag("index", "0").Tag("nt", NonTerminals.controlled_reference_event));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("data_event", (args) => CreateSyntaxNode(false, true, nameof(data_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value)).Tag("index", "0").Tag("nt", NonTerminals.data_event));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_data =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delayed_data", (args) => CreateSyntaxNode(false, true, nameof(delayed_data), args), new Lazy<IParser<CharToken>>(() => delayed_data_prefix.Value), new Lazy<IParser<CharToken>>(() => delayed_data_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.delayed_data));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delayed_reference", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference), args), new Lazy<IParser<CharToken>>(() => delayed_reference_prefix.Value), new Lazy<IParser<CharToken>>(() => delayed_reference_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.delayed_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> end_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("end_edge_offset", (args) => CreateSyntaxNode(false, true, nameof(end_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.end_edge_offset));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_based_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_based_flag", (args) => CreateSyntaxNode(false, true, nameof(event_based_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.event_based_flag));

        public static Lazy<IParser<CharToken, SyntaxNode>> notifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("notifier", (args) => CreateSyntaxNode(false, true, nameof(notifier), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.notifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reference_event", (args) => CreateSyntaxNode(false, true, nameof(reference_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value)).Tag("index", "0").Tag("nt", NonTerminals.reference_event));

        public static Lazy<IParser<CharToken, SyntaxNode>> remain_active_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("remain_active_flag", (args) => CreateSyntaxNode(false, true, nameof(remain_active_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.remain_active_flag));

        public static Lazy<IParser<CharToken, SyntaxNode>> stamptime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("stamptime_condition", (args) => CreateSyntaxNode(false, true, nameof(stamptime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.stamptime_condition));

        public static Lazy<IParser<CharToken, SyntaxNode>> start_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("start_edge_offset", (args) => CreateSyntaxNode(false, true, nameof(start_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.start_edge_offset));

        public static Lazy<IParser<CharToken, SyntaxNode>> threshold =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("threshold", (args) => CreateSyntaxNode(false, true, nameof(threshold), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.threshold));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_limit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_limit", (args) => CreateSyntaxNode(false, true, nameof(timing_check_limit), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.timing_check_limit));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_event", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => timing_check_event_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.timing_check_event));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_optional", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_203.Value), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value)).Tag("index", "0").Tag("nt", NonTerminals.timing_check_event_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event", (args) => CreateSyntaxNode(false, true, nameof(controlled_timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.controlled_timing_check_event));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event_optional", (args) => CreateSyntaxNode(false, true, nameof(controlled_timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_203.Value), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value)).Tag("index", "0").Tag("nt", NonTerminals.controlled_timing_check_event_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("timing_check_event_control", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#0", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_158.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#1", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_159.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#2", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => edge_control_specifier.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "posedge").Tag("First:1", "negedge").Tag("First:2", "edge").Tag("nt", NonTerminals.timing_check_event_control));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specify_terminal_descriptor", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#0", (args) => CreateSyntaxNode(false, true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#1", (args) => CreateSyntaxNode(false, true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.specify_terminal_descriptor));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier), args), new Lazy<IParser<CharToken>>(() => _keyword_204.Value), new Lazy<IParser<CharToken>>(() => edge_control_specifier_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.edge_control_specifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier_optional", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier_optional), args), new Lazy<IParser<CharToken>>(() => edge_descriptor.Value), new Lazy<IParser<CharToken>>(() => edge_control_specifier_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.edge_control_specifier_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier_many", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => edge_descriptor.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.edge_control_specifier_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_descriptor", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#0", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => _keyword_205.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#1", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => _keyword_206.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#2", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => z_or_x.Value), new Lazy<IParser<CharToken>>(() => zero_or_one.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#3", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => zero_or_one.Value), new Lazy<IParser<CharToken>>(() => z_or_x.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.edge_descriptor));

        public static Lazy<IParser<CharToken, SyntaxNode>> zero_or_one =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("zero_or_one", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("zero_or_one#0", (args) => CreateSyntaxNode(false, true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => _keyword_134.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("zero_or_one#1", (args) => CreateSyntaxNode(false, true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => _keyword_133.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "0").Tag("First:1", "1").Tag("nt", NonTerminals.zero_or_one));

        public static Lazy<IParser<CharToken, SyntaxNode>> z_or_x =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("z_or_x", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("z_or_x#0", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_136.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#1", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_137.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#2", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_207.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#3", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_208.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "x").Tag("First:1", "X").Tag("First:2", "z").Tag("First:3", "Z").Tag("nt", NonTerminals.z_or_x));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("timing_check_condition", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("timing_check_condition#0", (args) => CreateSyntaxNode(false, true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_condition#1", (args) => CreateSyntaxNode(false, true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.timing_check_condition));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_timing_check_condition", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_209.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_179.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#2", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_210.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#3", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_211.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#4", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => _keyword_212.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#5", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.scalar_timing_check_condition));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_constant =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_constant", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_125.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_126.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#2", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_129.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#3", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_130.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#4", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_213.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#5", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_214.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#6", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_215.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#7", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_216.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#8", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_133.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#9", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_134.Value)).Tag("index", "9")).Tag("xor").Tag("First").Tag("First:0", "1'b0").Tag("First:1", "1'b1").Tag("First:2", "1'B0").Tag("First:3", "1'B1").Tag("First:4", "'b0").Tag("First:5", "'b1").Tag("First:6", "'B0").Tag("First:7", "'B1").Tag("First:8", "1").Tag("First:9", "0").Tag("nt", NonTerminals.scalar_constant));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_concatenation", (args) => CreateSyntaxNode(false, true, nameof(analog_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(analog_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_concatenation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(analog_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_multiple_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_filter_function_arg", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#0", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#1", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => constant_optional_arrayinit.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.analog_filter_function_arg));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("concatenation", (args) => CreateSyntaxNode(false, true, nameof(concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.concatenation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_concatenation", (args) => CreateSyntaxNode(false, true, nameof(constant_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(constant_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_concatenation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(constant_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_multiple_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_concatenation", (args) => CreateSyntaxNode(false, true, nameof(module_path_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_path_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(module_path_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.module_path_concatenation_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(module_path_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_path_multiple_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.multiple_concatenation));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern), args), new Lazy<IParser<CharToken>>(() => assignment_pattern_prefix.Value), new Lazy<IParser<CharToken>>(() => assignment_pattern_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.assignment_pattern));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_many", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.assignment_pattern_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_many_2", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.assignment_pattern_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern), args), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_prefix.Value), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.constant_assignment_pattern));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_assignment_pattern_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many_2", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_assignment_pattern_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_arrayinit", (args) => CreateSyntaxNode(false, true, nameof(constant_arrayinit), args), new Lazy<IParser<CharToken>>(() => _keyword_77.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_arrayinit));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_arrayinit_many", (args) => CreateSyntaxNode(false, true, nameof(constant_arrayinit_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_arrayinit_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_optional_arrayinit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_optional_arrayinit", (args) => CreateSyntaxNode(false, true, nameof(constant_optional_arrayinit), args), new Lazy<IParser<CharToken>>(() => _keyword_77.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_optional_arrayinit_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_optional_arrayinit));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_optional_arrayinit_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_optional_arrayinit_many", (args) => CreateSyntaxNode(false, true, nameof(constant_optional_arrayinit_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_optional_arrayinit_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call), args), new Lazy<IParser<CharToken>>(() => analog_system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_system_function_call_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_system_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_system_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_system_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_built_in_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_built_in_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_built_in_function_name", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#0", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_218.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#1", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_219.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#2", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_220.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#3", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_221.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#4", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_222.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#5", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_223.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#6", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_224.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#7", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_225.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#8", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_226.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#9", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_227.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#10", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_228.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#11", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_229.Value)).Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#12", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_230.Value)).Tag("index", "12"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#13", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_231.Value)).Tag("index", "13"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#14", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_232.Value)).Tag("index", "14"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#15", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_233.Value)).Tag("index", "15"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#16", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_234.Value)).Tag("index", "16"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#17", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_235.Value)).Tag("index", "17"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#18", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_236.Value)).Tag("index", "18"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#19", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_237.Value)).Tag("index", "19"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#20", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_238.Value)).Tag("index", "20"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#21", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_239.Value)).Tag("index", "21"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#22", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_240.Value)).Tag("index", "22"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#23", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_241.Value)).Tag("index", "23")).Tag("xor").Tag("First").Tag("First:0", "ln").Tag("First:1", "log").Tag("First:2", "exp").Tag("First:3", "sqrt").Tag("First:4", "min").Tag("First:5", "max").Tag("First:6", "abs").Tag("First:7", "pow").Tag("First:8", "floor").Tag("First:9", "ceil").Tag("First:10", "tanh").Tag("First:11", "asinh").Tag("First:12", "acosh").Tag("First:13", "atan2").Tag("First:14", "atanh").Tag("First:15", "hypot").Tag("First:16", "sinh").Tag("First:17", "sin").Tag("First:18", "cosh").Tag("First:19", "cos").Tag("First:20", "tan").Tag("First:21", "asin").Tag("First:22", "acos").Tag("First:23", "atan").Tag("nt", NonTerminals.analog_built_in_function_name));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_function_call", (args) => CreateSyntaxNode(false, true, nameof(analysis_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_242.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.analysis_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_filter_function_call", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#0", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_243.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#1", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_244.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_245.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#3", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_246.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#4", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_247.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#5", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_248.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#6", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_249.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#7", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_250.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_7.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#8", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_251.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#9", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => laplace_filter_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_8.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#10", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => zi_filter_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_9.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "10")).Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_10.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_11.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_12.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_13.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_8", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_9", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_14.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_10", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_15.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_11", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_16.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_11));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_12", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_17.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_12));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_13", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_13));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_14", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_14), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_14));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_15", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_15), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_15));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_16", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_16), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_18.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_16));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_17 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_17", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_17), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_19.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_17));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_18 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_18", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_18), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_18));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_19 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_19", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_19), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_filter_function_call_optional_19));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_small_signal_function_call", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#0", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_252.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#1", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_253.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#2", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_254.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#3", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_255.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#4", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_256.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "4")).Tag("xor").Tag("First").Tag("First:0", "ac_stim").Tag("First:1", "white_noise").Tag("First:2", "flicker_noise").Tag("First:3", "noise_table").Tag("First:4", "noise_table_log").Tag("nt", NonTerminals.analog_small_signal_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_162.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_6.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_7.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.analog_small_signal_function_call_optional_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("noise_table_input_arg", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#0", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg_optional.Value.Optional(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#1", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#2", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#3", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.noise_table_input_arg));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg_optional", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg_optional), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.noise_table_input_arg_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> laplace_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("laplace_filter_name", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#0", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_257.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#1", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_258.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#2", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_259.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#3", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_260.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "laplace_zd").Tag("First:1", "laplace_zp").Tag("First:2", "laplace_np").Tag("First:3", "laplace_nd").Tag("nt", NonTerminals.laplace_filter_name));

        public static Lazy<IParser<CharToken, SyntaxNode>> zi_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("zi_filter_name", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#0", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_261.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#1", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_262.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#2", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_263.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#3", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_264.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "zi_zp").Tag("First:1", "zi_zd").Tag("First:2", "zi_np").Tag("First:3", "zi_nd").Tag("nt", NonTerminals.zi_filter_name));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_function =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_access_function", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#0", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#1", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => _keyword_26.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#2", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => _keyword_27.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.nature_access_function));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call_prefix.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.branch_probe_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.branch_probe_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_probe_function_call", (args) => CreateSyntaxNode(false, true, nameof(port_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_265.Value), new Lazy<IParser<CharToken>>(() => analog_port_reference.Value), new Lazy<IParser<CharToken>>(() => _keyword_266.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.port_probe_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_analog_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_analog_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_analog_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_function_call), args), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_system_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_system_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_system_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_analog_built_in_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_analog_built_in_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_call", (args) => CreateSyntaxNode(false, true, nameof(function_call), args), new Lazy<IParser<CharToken>>(() => hierarchical_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_call_many", (args) => CreateSyntaxNode(false, true, nameof(function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call", (args) => CreateSyntaxNode(false, true, nameof(system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => system_function_call_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.system_function_call));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0").Tag("nt", NonTerminals.system_function_call_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.system_function_call_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_conditional_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression", (args) => CreateSyntaxNode(false, true, nameof(analog_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression_10.Value), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value)).Tag("index", "0").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.analog_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_10", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_10), args), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value), new Lazy<IParser<CharToken>>(() => analog_expression_10_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_10_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_9", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_9), args), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression_9_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_9_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_8", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_8), args), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value), new Lazy<IParser<CharToken>>(() => analog_expression_8_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_8_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_7", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_7), args), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression_7_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_7_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_6", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_6), args), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value), new Lazy<IParser<CharToken>>(() => analog_expression_6_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_6_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_5", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_5), args), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression_5_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_5_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_4", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_4), args), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value), new Lazy<IParser<CharToken>>(() => analog_expression_4_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_4_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_3", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_3), args), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value), new Lazy<IParser<CharToken>>(() => analog_expression_3_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_3_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_2", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_2), args), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value), new Lazy<IParser<CharToken>>(() => analog_expression_2_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_2_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_1), args), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value), new Lazy<IParser<CharToken>>(() => analog_expression_1_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_1));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_1_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_0), args), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value), new Lazy<IParser<CharToken>>(() => analog_expression_0_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_0));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_expression_0_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_expression_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => analog_primary.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_primary.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#2", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.analog_expression_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> abstol_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("abstol_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("abstol_expression#0", (args) => CreateSyntaxNode(false, true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("abstol_expression#1", (args) => CreateSyntaxNode(false, true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.abstol_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_range_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.analog_range_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_or_null", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_or_null), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analog_expression_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("base_expression", (args) => CreateSyntaxNode(false, true, nameof(base_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.base_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(conditional_expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => expression3.Value)).Tag("index", "0").Tag("nt", NonTerminals.conditional_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_base_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_base_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_base_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_or_null", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_or_null), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_or_null));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression_10.Value), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value)).Tag("index", "0").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.constant_conditional_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_10", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_10), args), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value), new Lazy<IParser<CharToken>>(() => constant_expression_10_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_10_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_9", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_9), args), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression_9_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_9_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_8", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_8), args), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value), new Lazy<IParser<CharToken>>(() => constant_expression_8_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_8_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_7", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_7), args), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_7_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_7_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_6", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_6), args), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value), new Lazy<IParser<CharToken>>(() => constant_expression_6_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_6_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_5", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_5), args), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression_5_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_5_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_4", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_4), args), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value), new Lazy<IParser<CharToken>>(() => constant_expression_4_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_4_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_3", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_3), args), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value), new Lazy<IParser<CharToken>>(() => constant_expression_3_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_3_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_2", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_2), args), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value), new Lazy<IParser<CharToken>>(() => constant_expression_2_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_2_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_1), args), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value), new Lazy<IParser<CharToken>>(() => constant_expression_1_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_1));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_1_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_0), args), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value), new Lazy<IParser<CharToken>>(() => constant_expression_0_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.constant_expression_0));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.constant_expression_0_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_expression_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("constant_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.constant_expression_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value)).Tag("index", "0").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.analysis_or_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_conditional_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_10), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_10_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_9), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_9_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_8), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_8_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_7), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_7_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_6), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_6_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_5), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_5_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_4), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_4_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_3), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_3_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_2), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_2_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_1), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_1));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_1_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_0), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.analysis_or_constant_expression_0));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analysis_or_constant_expression_0_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analysis_or_constant_expression_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#2", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.analysis_or_constant_expression_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression_prefix.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.constant_mintypmax_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_range_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_267.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_268.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#3", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.constant_range_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("dimension_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(dimension_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.dimension_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("expression", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("expression#0", (args) => CreateSyntaxNode(false, true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("expression#1", (args) => CreateSyntaxNode(false, true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => expression3.Value)).Tag("index", "1")).Tag("nt", NonTerminals.expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_10", (args) => CreateSyntaxNode(false, true, nameof(expression_10), args), new Lazy<IParser<CharToken>>(() => expression_9.Value), new Lazy<IParser<CharToken>>(() => expression_10_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_9.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_10_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_9", (args) => CreateSyntaxNode(false, true, nameof(expression_9), args), new Lazy<IParser<CharToken>>(() => expression_8.Value), new Lazy<IParser<CharToken>>(() => expression_9_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_8.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_9_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_8", (args) => CreateSyntaxNode(false, true, nameof(expression_8), args), new Lazy<IParser<CharToken>>(() => expression_7.Value), new Lazy<IParser<CharToken>>(() => expression_8_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_7.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_8_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_7", (args) => CreateSyntaxNode(false, true, nameof(expression_7), args), new Lazy<IParser<CharToken>>(() => expression_6.Value), new Lazy<IParser<CharToken>>(() => expression_7_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_6.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_7_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_6", (args) => CreateSyntaxNode(false, true, nameof(expression_6), args), new Lazy<IParser<CharToken>>(() => expression_5.Value), new Lazy<IParser<CharToken>>(() => expression_6_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_5.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_6_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_5", (args) => CreateSyntaxNode(false, true, nameof(expression_5), args), new Lazy<IParser<CharToken>>(() => expression_4.Value), new Lazy<IParser<CharToken>>(() => expression_5_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_4.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_5_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_4", (args) => CreateSyntaxNode(false, true, nameof(expression_4), args), new Lazy<IParser<CharToken>>(() => expression_3.Value), new Lazy<IParser<CharToken>>(() => expression_4_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_3.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_4_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_3", (args) => CreateSyntaxNode(false, true, nameof(expression_3), args), new Lazy<IParser<CharToken>>(() => expression_2.Value), new Lazy<IParser<CharToken>>(() => expression_3_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_2.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_3_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_2", (args) => CreateSyntaxNode(false, true, nameof(expression_2), args), new Lazy<IParser<CharToken>>(() => expression_1.Value), new Lazy<IParser<CharToken>>(() => expression_2_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_1.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_2_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_1", (args) => CreateSyntaxNode(false, true, nameof(expression_1), args), new Lazy<IParser<CharToken>>(() => expression_0.Value), new Lazy<IParser<CharToken>>(() => expression_1_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_1));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_0.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_1_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_0", (args) => CreateSyntaxNode(false, true, nameof(expression_0), args), new Lazy<IParser<CharToken>>(() => expression_primary.Value), new Lazy<IParser<CharToken>>(() => expression_0_many.Value.Many(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.expression_0));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_primary.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.expression_0_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("expression_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => primary.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => primary.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.expression_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression1", (args) => CreateSyntaxNode(false, true, nameof(expression1), args), new Lazy<IParser<CharToken>>(() => expression_10.Value), new Lazy<IParser<CharToken>>(() => expression1_prim.Value)).Tag("index", "0").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.expression1));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression2", (args) => CreateSyntaxNode(false, true, nameof(expression2), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.expression2));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression3", (args) => CreateSyntaxNode(false, true, nameof(expression3), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.expression3));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("indirect_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#0", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#1", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#2", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_243.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#3", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_243.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#4", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_245.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#5", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_245.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#6", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_246.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#7", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_246.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "7")).Tag("xor").Tag("nt", NonTerminals.indirect_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_2", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_3", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_7.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_4", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_8.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_5", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_9.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_6", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_10.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_7", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_11.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_8", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_12.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_9", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_13.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_10", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_14.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_11", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_11));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_12", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_12));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_13", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_15.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_13));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_14", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_14), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_16.Value.Optional(greedy: true))).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_14));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_15", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_15), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_15));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_16", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_16), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.indirect_expression_optional_16));

        public static Lazy<IParser<CharToken, SyntaxNode>> lsb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("lsb_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(lsb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.lsb_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression_prefix.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.mintypmax_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(module_path_conditional_expression), args), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_path_conditional_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_path_expression#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "1")).Tag("xor").Tag("reductor:left_recursion", "true").Tag("nt", NonTerminals.module_path_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_mintypmax_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#2", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#3", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.module_path_mintypmax_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> msb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("msb_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(msb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.msb_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_attribute_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#0", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#1", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.nature_attribute_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("range_expression", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_267.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_268.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#3", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.range_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(width_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.width_constant_expression));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_primary#0", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#1", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value)).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#2", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_multiple_concatenation.Value)).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#3", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#4", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_system_function_call.Value)).Token().Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#5", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value)).Token().Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#6", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_filter_function_call.Value)).Token().Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#7", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call.Value)).Token().Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#8", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value)).Token().Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#9", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)).Token().Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#10", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)).Token().Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#11", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => variable_reference.Value)).Token().Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#12", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => net_reference.Value)).Token().Tag("index", "12"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#13", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)).Token().Tag("index", "13"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#14", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => parameter_reference.Value)).Token().Tag("index", "14"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#15", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)).Token().Tag("index", "15"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#16", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Token().Tag("index", "16")).Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.analog_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("constant_primary#0", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#1", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => constant_primary_optional.Value.Optional(greedy: true))).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#2", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value), new Lazy<IParser<CharToken>>(() => constant_primary_optional_2.Value.Optional(greedy: true))).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#3", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#4", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_multiple_concatenation.Value)).Token().Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#5", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_function_call.Value)).Token().Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#6", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_system_function_call.Value)).Token().Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#7", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call.Value)).Token().Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#8", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Token().Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#9", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value)).Token().Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#10", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value)).Token().Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#11", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)).Token().Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#12", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_function_call.Value)).Token().Tag("index", "12"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#13", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)).Token().Tag("index", "13")).Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.constant_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_primary_optional", (args) => CreateSyntaxNode(true, true, nameof(constant_primary_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.constant_primary_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_primary_optional_2", (args) => CreateSyntaxNode(true, true, nameof(constant_primary_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.constant_primary_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("module_path_primary", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#0", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#1", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#2", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value)).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#3", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_multiple_concatenation.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#4", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value)).Token().Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#5", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value)).Token().Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#6", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => module_path_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Token().Tag("index", "6")).Tag("nodeTokenize").Tag("nt", NonTerminals.module_path_primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("primary", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("primary#0", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#1", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => concatenation.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#2", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => multiple_concatenation.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#3", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#4", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#5", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#6", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => @string.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#7", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#8", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#9", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#10", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#11", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value)).Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("primary#12", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => primary_h.Value)).Tag("index", "12")).Tag("xor").Tag("nt", NonTerminals.primary));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("primary_h", (args) => CreateSyntaxNode(false, true, nameof(primary_h), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value), new Lazy<IParser<CharToken>>(() => primary_h_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.primary_h));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("primary_h_optional", (args) => CreateSyntaxNode(false, true, nameof(primary_h_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("nt", NonTerminals.primary_h_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue_prefix.Value), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.analog_variable_lvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.analog_variable_lvalue_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_269.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0").Tag("nt", NonTerminals.array_analog_variable_assignment));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("array_analog_variable_rvalue", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#0", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_270.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#1", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_270.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#2", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => assignment_pattern.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.array_analog_variable_rvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue_many", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.array_analog_variable_rvalue_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_lvalue", (args) => CreateSyntaxNode(false, true, nameof(branch_lvalue), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)).Tag("index", "0").Tag("nt", NonTerminals.branch_lvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_lvalue", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => net_lvalue_optional.Value.Optional(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value), new Lazy<IParser<CharToken>>(() => net_lvalue_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.net_lvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_lvalue_optional", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => constant_expression_lazy.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.net_lvalue_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.net_lvalue_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_lazy", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_lazy), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("lazy").Tag("nt", NonTerminals.constant_expression_lazy));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_lvalue", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_variable_identifier.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue_optional.Value.Optional(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.variable_lvalue));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue_optional", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.variable_lvalue_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.variable_lvalue_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> lazy_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("lazy_expressions", (args) => CreateSyntaxNode(false, true, nameof(lazy_expressions), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("lazy").Tag("nt", NonTerminals.lazy_expressions));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("unary_operator", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("unary_operator#0", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_190.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#1", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_135.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#2", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_271.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#3", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_272.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#4", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_273.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#5", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_274.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#6", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_212.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#7", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_275.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#8", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_276.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#9", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_277.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#10", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_278.Value)).Tag("index", "10")).Tag("xor").Tag("First").Tag("First:0", "+").Tag("First:1", "-").Tag("First:2", "!").Tag("First:3", "~^").Tag("First:4", "^~").Tag("First:5", "~&").Tag("First:6", "~").Tag("First:7", "&").Tag("First:8", "|").Tag("First:9", "~|").Tag("First:10", "^").Tag("nt", NonTerminals.unary_operator));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#4", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#5", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#6", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#7", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#8", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#9", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#10", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value)).Tag("index", "10")).Tag("xor").Tag("nt", NonTerminals.binary_operator));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_0), args), new Lazy<IParser<CharToken>>(() => _keyword_279.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.binary_operator_0));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_1", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_1#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_1), args), new Lazy<IParser<CharToken>>(() => _keyword_149.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_1#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_1), args), new Lazy<IParser<CharToken>>(() => _keyword_280.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_1#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_1), args), new Lazy<IParser<CharToken>>(() => _keyword_281.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "*").Tag("First:1", "/").Tag("First:2", "%").Tag("nt", NonTerminals.binary_operator_1));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_2", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_2#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => _keyword_190.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_2#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => _keyword_135.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "+").Tag("First:1", "-").Tag("nt", NonTerminals.binary_operator_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_3", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_282.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_283.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_284.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_285.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "<<<").Tag("First:1", ">>>").Tag("First:2", "<<").Tag("First:3", ">>").Tag("nt", NonTerminals.binary_operator_3));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_4", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_152.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_286.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_265.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_266.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "<=").Tag("First:1", ">=").Tag("First:2", "<").Tag("First:3", ">").Tag("nt", NonTerminals.binary_operator_4));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_5", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_209.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_210.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_179.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_211.Value)).Tag("index", "3")).Tag("xor").Tag("First").Tag("First:0", "===").Tag("First:1", "!==").Tag("First:2", "==").Tag("First:3", "!=").Tag("nt", NonTerminals.binary_operator_5));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_6", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_6), args), new Lazy<IParser<CharToken>>(() => _keyword_275.Value)).Tag("index", "0").Tag("nt", NonTerminals.binary_operator_6));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_7", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_273.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_272.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_278.Value)).Tag("index", "2")).Tag("xor").Tag("First").Tag("First:0", "^~").Tag("First:1", "~^").Tag("First:2", "^").Tag("nt", NonTerminals.binary_operator_7));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_8", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_8), args), new Lazy<IParser<CharToken>>(() => _keyword_276.Value)).Tag("index", "0").Tag("nt", NonTerminals.binary_operator_8));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_9", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_9), args), new Lazy<IParser<CharToken>>(() => _keyword_287.Value)).Tag("index", "0").Tag("nt", NonTerminals.binary_operator_9));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_10", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_10), args), new Lazy<IParser<CharToken>>(() => _keyword_288.Value)).Tag("index", "0").Tag("nt", NonTerminals.binary_operator_10));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("unary_module_path_operator", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#0", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_271.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#1", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_212.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#2", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_275.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#3", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_274.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#4", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_276.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#5", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_277.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#6", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_272.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#7", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_273.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#8", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_278.Value)).Tag("index", "8")).Tag("xor").Tag("First").Tag("First:0", "!").Tag("First:1", "~").Tag("First:2", "&").Tag("First:3", "~&").Tag("First:4", "|").Tag("First:5", "~|").Tag("First:6", "~^").Tag("First:7", "^~").Tag("First:8", "^").Tag("nt", NonTerminals.unary_module_path_operator));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_module_path_operator", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#0", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_179.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#1", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_211.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#2", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_287.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#3", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_288.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#4", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_275.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#5", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_276.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#6", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_273.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#7", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_272.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#8", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_278.Value)).Tag("index", "8")).Tag("xor").Tag("First").Tag("First:0", "==").Tag("First:1", "!=").Tag("First:2", "&&").Tag("First:3", "||").Tag("First:4", "&").Tag("First:5", "|").Tag("First:6", "^~").Tag("First:7", "~^").Tag("First:8", "^").Tag("nt", NonTerminals.binary_module_path_operator));

        public static Lazy<IParser<CharToken, SyntaxNode>> number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("number", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("number#0", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => binary_number.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("number#1", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => hex_number.Value)).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("number#2", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => octal_number.Value)).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("number#3", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => real_number.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("number#4", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => decimal_number.Value)).Token().Tag("index", "4")).Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.number));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number", (args) => CreateSyntaxNode(false, false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => real_number_prefix.Value), new Lazy<IParser<CharToken>>(() => real_number_rest.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.real_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number_optional", (args) => CreateSyntaxNode(false, false, nameof(real_number_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_289.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nt", NonTerminals.real_number_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number_optional_2", (args) => CreateSyntaxNode(false, false, nameof(real_number_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_289.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nt", NonTerminals.real_number_optional_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> exp =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("exp", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("exp#0", (args) => CreateSyntaxNode(false, false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => _keyword_290.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("exp#1", (args) => CreateSyntaxNode(false, false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => _keyword_291.Value)).Tag("index", "1")).Tag("xor").Tag("!tokenTokenize").Tag("First").Tag("First:0", "e").Tag("First:1", "E").Tag("nt", NonTerminals.exp));

        public static Lazy<IParser<CharToken, SyntaxNode>> scale_factor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scale_factor", (args) => CreateSyntaxNode(false, false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => _keyword_292.Value)).Tag("index", "0").Tag("xor").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.scale_factor));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("decimal_number", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("decimal_number#0", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#1", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => _keyword_293.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many.Value.Many(greedy: true))).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#2", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => _keyword_294.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many_2.Value.Many(greedy: true))).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#3", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.decimal_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_number_many", (args) => CreateSyntaxNode(false, true, nameof(decimal_number_many), args), new Lazy<IParser<CharToken>>(() => _keyword_295.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.decimal_number_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_number_many_2", (args) => CreateSyntaxNode(false, true, nameof(decimal_number_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_295.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.decimal_number_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_number", (args) => CreateSyntaxNode(false, true, nameof(binary_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => binary_base.Value), new Lazy<IParser<CharToken>>(() => binary_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.binary_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_number", (args) => CreateSyntaxNode(false, true, nameof(octal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => octal_base.Value), new Lazy<IParser<CharToken>>(() => octal_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.octal_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_number", (args) => CreateSyntaxNode(false, true, nameof(hex_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => hex_base.Value), new Lazy<IParser<CharToken>>(() => hex_value.Value)).Tag("index", "0").Tag("nt", NonTerminals.hex_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> sign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("sign", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("sign#0", (args) => CreateSyntaxNode(false, true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => _keyword_190.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("sign#1", (args) => CreateSyntaxNode(false, true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => _keyword_135.Value)).Tag("index", "1")).Tag("xor").Tag("First").Tag("First:0", "+").Tag("First:1", "-").Tag("nt", NonTerminals.sign));

        public static Lazy<IParser<CharToken, SyntaxNode>> size =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("size", (args) => CreateSyntaxNode(false, false, nameof(size), args), new Lazy<IParser<CharToken>>(() => _keyword_296.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.size));

        public static Lazy<IParser<CharToken, SyntaxNode>> unsigned_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("unsigned_number", (args) => CreateSyntaxNode(false, false, nameof(unsigned_number), args), new Lazy<IParser<CharToken>>(() => _keyword_297.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.unsigned_number));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_value", (args) => CreateSyntaxNode(false, false, nameof(binary_value), args), new Lazy<IParser<CharToken>>(() => _keyword_298.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.binary_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_value", (args) => CreateSyntaxNode(false, false, nameof(octal_value), args), new Lazy<IParser<CharToken>>(() => _keyword_299.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.octal_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_value", (args) => CreateSyntaxNode(false, false, nameof(hex_value), args), new Lazy<IParser<CharToken>>(() => _keyword_300.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.hex_value));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_base", (args) => CreateSyntaxNode(false, false, nameof(decimal_base), args), new Lazy<IParser<CharToken>>(() => _keyword_301.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.decimal_base));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_base", (args) => CreateSyntaxNode(false, false, nameof(binary_base), args), new Lazy<IParser<CharToken>>(() => _keyword_302.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.binary_base));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_base", (args) => CreateSyntaxNode(false, false, nameof(octal_base), args), new Lazy<IParser<CharToken>>(() => _keyword_303.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.octal_base));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_base", (args) => CreateSyntaxNode(false, false, nameof(hex_base), args), new Lazy<IParser<CharToken>>(() => _keyword_304.Value)).Tag("index", "0").Tag("pattern").Tag("!tokenTokenize").Tag("nt", NonTerminals.hex_base));

        public static Lazy<IParser<CharToken, SyntaxNode>> @string =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("@string", (args) => CreateSyntaxNode(false, true, nameof(@string), args), new Lazy<IParser<CharToken>>(() => _keyword_305.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.@string));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_reference", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_attribute_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_port_reference", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#0", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#1", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#2", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#3", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.analog_port_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_net_reference", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#0", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#1", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#2", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#3", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#4", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#5", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.analog_net_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_reference", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("branch_reference#0", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_reference#1", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_reference#2", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference.Value)).Tag("index", "2")).Tag("xor").Tag("nt", NonTerminals.branch_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference_prefix.Value), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.hierarchical_unnamed_branch_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value)).Tag("index", "0").Tag("xor").Tag("nt", NonTerminals.hierarchical_unnamed_branch_reference_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_reference", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference), args), new Lazy<IParser<CharToken>>(() => parameter_reference_prefix.Value), new Lazy<IParser<CharToken>>(() => parameter_reference_rest.Value)).Tag("index", "0").Tag("xor").Tag("reductor:left_factoring", "true").Tag("nt", NonTerminals.parameter_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_reference", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("variable_reference#0", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value), new Lazy<IParser<CharToken>>(() => variable_reference_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#1", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value), new Lazy<IParser<CharToken>>(() => variable_reference_many_2.Value.Many(greedy: true))).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#2", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#3", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.variable_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_reference_many", (args) => CreateSyntaxNode(false, true, nameof(variable_reference_many), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.variable_reference_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_reference_many_2", (args) => CreateSyntaxNode(false, true, nameof(variable_reference_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("xor").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.variable_reference_many_2));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_reference", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("net_reference#0", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#1", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#2", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#3", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value)).Tag("index", "3")).Tag("xor").Tag("nt", NonTerminals.net_reference));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attribute_instance", (args) => CreateSyntaxNode(false, true, nameof(attribute_instance), args), new Lazy<IParser<CharToken>>(() => _keyword_306.Value), new Lazy<IParser<CharToken>>(() => attr_spec.Value), new Lazy<IParser<CharToken>>(() => attribute_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_307.Value)).Tag("index", "0").Tag("nt", NonTerminals.attribute_instance));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attribute_instance_many", (args) => CreateSyntaxNode(false, true, nameof(attribute_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => attr_spec.Value)).Tag("index", "0").Tag("reductor:many_single", "true").Tag("nt", NonTerminals.attribute_instance_many));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_spec", (args) => CreateSyntaxNode(false, true, nameof(attr_spec), args), new Lazy<IParser<CharToken>>(() => attr_name.Value), new Lazy<IParser<CharToken>>(() => attr_spec_optional.Value.Optional(greedy: true))).Tag("index", "0").Tag("nt", NonTerminals.attr_spec));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_spec_optional", (args) => CreateSyntaxNode(false, true, nameof(attr_spec_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("nt", NonTerminals.attr_spec_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_name", (args) => CreateSyntaxNode(false, true, nameof(attr_name), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.attr_name));

        public static Lazy<IParser<CharToken, SyntaxNode>> ams_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("ams_net_identifier", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("ams_net_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("ams_net_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value)).Tag("index", "1")).Tag("xor").Tag("nt", NonTerminals.ams_net_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_block_identifier), args), new Lazy<IParser<CharToken>>(() => block_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_block_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_function_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_identifier), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_system_task_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_identifier), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.analog_system_function_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_identifier", (args) => CreateSyntaxNode(false, true, nameof(analysis_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.analysis_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_identifier", (args) => CreateSyntaxNode(false, true, nameof(block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.block_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_identifier", (args) => CreateSyntaxNode(false, true, nameof(branch_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.branch_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_identifier", (args) => CreateSyntaxNode(false, true, nameof(cell_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.cell_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("config_identifier", (args) => CreateSyntaxNode(false, true, nameof(config_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.config_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectmodule_identifier", (args) => CreateSyntaxNode(false, true, nameof(connectmodule_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.connectmodule_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectrules_identifier", (args) => CreateSyntaxNode(false, true, nameof(connectrules_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.connectrules_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.discipline_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> escaped_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("escaped_identifier", (args) => CreateSyntaxNode(false, true, nameof(escaped_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_308.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.escaped_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_identifier", (args) => CreateSyntaxNode(false, true, nameof(event_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.event_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_identifier", (args) => CreateSyntaxNode(false, true, nameof(function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.function_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(gate_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.gate_instance_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(generate_block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.generate_block_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_identifier", (args) => CreateSyntaxNode(false, true, nameof(genvar_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.genvar_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_block_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_block_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_branch_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_branch_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_branch_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_event_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_event_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_event_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_function_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_function_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_309.Value), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_identifier_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_lazy), args), new Lazy<IParser<CharToken>>(() => identifier.Value), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("lazy").Tag("nt", NonTerminals.hierarchical_identifier_lazy));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_lazy_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0").Tag("lazy").Tag("nt", NonTerminals.hierarchical_identifier_lazy_optional));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_inst_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_inst_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_inst_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_inst_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_net_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_net_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_parameter_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_port_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_port_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_variable_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_variable_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_task_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.hierarchical_task_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("identifier", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("identifier#0", (args) => CreateSyntaxNode(true, true, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => simple_identifier.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("identifier#1", (args) => CreateSyntaxNode(true, true, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => escaped_identifier.Value)).Token().Tag("index", "1")).Tag("xor").Tag("nodeTokenize").Tag("nt", NonTerminals.identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(inout_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.inout_port_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(input_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.input_port_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.instance_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> library_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("library_identifier", (args) => CreateSyntaxNode(false, true, nameof(library_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.library_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_instance_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("module_or_paramset_identifier", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value)).Tag("index", "1")).Tag("nt", NonTerminals.module_or_paramset_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_output_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_output_variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_output_variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_output_variable_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.module_parameter_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_identifier", (args) => CreateSyntaxNode(false, true, nameof(nature_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_access_identifier", (args) => CreateSyntaxNode(false, true, nameof(nature_access_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.nature_access_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_attribute_identifier", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_310.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_311.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#2", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_312.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#3", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_313.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#4", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_314.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#5", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "5")).Tag("xor").Tag("nt", NonTerminals.nature_attribute_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_identifier", (args) => CreateSyntaxNode(false, true, nameof(net_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.net_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(output_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.output_port_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.parameter_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_identifier", (args) => CreateSyntaxNode(false, true, nameof(paramset_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.paramset_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_identifier", (args) => CreateSyntaxNode(false, true, nameof(port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.port_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_identifier", (args) => CreateSyntaxNode(false, true, nameof(real_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.real_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("simple_identifier", (args) => CreateSyntaxNode(false, true, nameof(simple_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_315.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.simple_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specparam_identifier", (args) => CreateSyntaxNode(false, true, nameof(specparam_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.specparam_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_function_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_316.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.system_function_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_316.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.system_parameter_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_task_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_316.Value)).Tag("index", "0").Tag("pattern").Tag("nt", NonTerminals.system_task_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_identifier", (args) => CreateSyntaxNode(false, true, nameof(task_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.task_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> terminal_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("terminal_identifier", (args) => CreateSyntaxNode(false, true, nameof(terminal_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.terminal_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> text_macro_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("text_macro_identifier", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_317.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#2", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_318.Value)).Tag("index", "2")).Tag("nt", NonTerminals.text_macro_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> topmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("topmodule_identifier", (args) => CreateSyntaxNode(false, true, nameof(topmodule_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.topmodule_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_identifier", (args) => CreateSyntaxNode(false, true, nameof(udp_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(udp_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.udp_instance_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Tag("index", "0").Tag("nt", NonTerminals.variable_identifier));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_expression_prim", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_100.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "analog_event_expression").Tag("nt", NonTerminals.analog_event_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("analog_expression_prim", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("analog_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("reductor_owner", "analog_expression").Tag("nt", NonTerminals.analog_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("analysis_or_constant_expression_prim", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("reductor_owner", "analysis_or_constant_expression").Tag("nt", NonTerminals.analysis_or_constant_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("constant_expression_prim", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("reductor_owner", "constant_expression").Tag("nt", NonTerminals.constant_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_expression_prim", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_100.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "event_expression").Tag("nt", NonTerminals.event_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("expression1_prim", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("expression1_prim#0", (args) => CreateSyntaxNode(false, true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => expression3.Value), new Lazy<IParser<CharToken>>(() => expression1_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("expression1_prim#1", (args) => CreateSyntaxNode(false, true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("reductor_owner", "expression1").Tag("nt", NonTerminals.expression1_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("genvar_expression_prim", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "genvar_expression").Tag("nt", NonTerminals.genvar_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_expression_prim", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "module_path_expression").Tag("nt", NonTerminals.module_path_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_constant_expression_prim", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_138.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "paramset_constant_expression").Tag("nt", NonTerminals.paramset_constant_expression_prim));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_item_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_block_item_declaration").Tag("nt", NonTerminals.analog_block_item_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_item_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_block_item_declaration_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration_rest#2", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => real_declaration.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "analog_block_item_declaration").Tag("First").Tag("First:0", "parameter").Tag("First:1", "integer").Tag("First:2", "real").Tag("nt", NonTerminals.analog_block_item_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_construct_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_construct_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_construct_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_82.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_construct").Tag("nt", NonTerminals.analog_construct_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_construct_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_construct_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_construct_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_construct_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_124.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_construct_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_construct_rest), args), new Lazy<IParser<CharToken>>(() => analog_statement.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "analog_construct").Tag("nt", NonTerminals.analog_construct_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_control_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_168.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_event_control").Tag("nt", NonTerminals.analog_event_control_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_control_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_event_control_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control_rest), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_control_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "analog_event_control").Tag("nt", NonTerminals.analog_event_control_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_statement_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_event_statement").Tag("nt", NonTerminals.analog_event_statement_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_statement_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_statement_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_event_seq_block.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => disable_statement.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#7", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => event_trigger.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement_rest#8", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "8")).Tag("xor").Tag("reductor_owner", "analog_event_statement").Tag("nt", NonTerminals.analog_event_statement_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_function_statement").Tag("nt", NonTerminals.analog_function_statement_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_function_case_statement.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_function_loop_statement.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_function_seq_block.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#4", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_rest#5", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value)).Tag("index", "5")).Tag("xor").Tag("reductor_owner", "analog_function_statement").Tag("nt", NonTerminals.analog_function_statement_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_statement_prefix", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("reductor_owner", "analog_statement").Tag("nt", NonTerminals.analog_statement_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_statement_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#0", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_loop_generate_statement.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#1", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value)).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#2", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value)).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#3", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#4", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)).Token().Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#5", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_seq_block.Value)).Token().Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#6", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value)).Token().Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#7", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => contribution_statement.Value)).Token().Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#8", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => indirect_contribution_statement.Value)).Token().Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_rest#9", (args) => CreateSyntaxNode(true, true, nameof(analog_statement_rest), args), new Lazy<IParser<CharToken>>(() => analog_event_control_statement.Value)).Token().Tag("index", "9")).Tag("xor").Tag("nodeTokenize").Tag("reductor_owner", "analog_statement").Tag("nt", NonTerminals.analog_statement_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_prefix", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue_prefix), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "analog_variable_lvalue").Tag("nt", NonTerminals.analog_variable_lvalue_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_variable_lvalue_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_rest#0", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_rest#1", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "analog_variable_lvalue").Tag("nt", NonTerminals.analog_variable_lvalue_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_prefix", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_77.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "assignment_pattern").Tag("nt", NonTerminals.assignment_pattern_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("assignment_pattern_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_rest#0", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_rest), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => assignment_pattern_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_rest#1", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_rest), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => assignment_pattern_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "assignment_pattern").Tag("nt", NonTerminals.assignment_pattern_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "block_item_declaration").Tag("nt", NonTerminals.block_item_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("block_item_declaration_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_58.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => block_item_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_45.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#2", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_48.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#3", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_47.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#4", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_46.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#5", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => event_declaration.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#6", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_rest#7", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_rest), args), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "7")).Tag("xor").Tag("reductor_owner", "block_item_declaration").Tag("First").Tag("First:0", "reg").Tag("First:1", "integer").Tag("First:2", "time").Tag("First:3", "real").Tag("First:4", "realtime").Tag("First:5", "event").Tag("First:6", "localparam").Tag("First:7", "parameter").Tag("nt", NonTerminals.block_item_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_prefix", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call_prefix), args), new Lazy<IParser<CharToken>>(() => nature_access_function.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "branch_probe_function_call").Tag("nt", NonTerminals.branch_probe_function_call_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_probe_function_call_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_rest#0", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_reference.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_rest#1", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "branch_probe_function_call").Tag("nt", NonTerminals.branch_probe_function_call_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> charge_strength_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("charge_strength_prefix", (args) => CreateSyntaxNode(false, true, nameof(charge_strength_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "charge_strength").Tag("nt", NonTerminals.charge_strength_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> charge_strength_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("charge_strength_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("charge_strength_rest#0", (args) => CreateSyntaxNode(false, true, nameof(charge_strength_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_319.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("charge_strength_rest#1", (args) => CreateSyntaxNode(false, true, nameof(charge_strength_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_320.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("charge_strength_rest#2", (args) => CreateSyntaxNode(false, true, nameof(charge_strength_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_321.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "charge_strength").Tag("First").Tag("First:0", "small").Tag("First:1", "medium").Tag("First:2", "large").Tag("nt", NonTerminals.charge_strength_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_prefix", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_77.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "constant_assignment_pattern").Tag("nt", NonTerminals.constant_assignment_pattern_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_assignment_pattern_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_rest#0", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_rest), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_rest#1", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_rest), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_217.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_78.Value), new Lazy<IParser<CharToken>>(() => _keyword_78.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "constant_assignment_pattern").Tag("nt", NonTerminals.constant_assignment_pattern_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_mintypmax_expression_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression_prefix", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression_prefix), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "constant_mintypmax_expression").Tag("nt", NonTerminals.constant_mintypmax_expression_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_mintypmax_expression_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_mintypmax_expression_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression_rest#0", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression_rest#1", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "constant_mintypmax_expression").Tag("nt", NonTerminals.constant_mintypmax_expression_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_control_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay_control_prefix", (args) => CreateSyntaxNode(true, false, nameof(delay_control_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_322.Value)).Token().Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("nodeTokenize").Tag("reductor_owner", "delay_control").Tag("nt", NonTerminals.delay_control_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_control_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_control_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delay_control_rest#0", (args) => CreateSyntaxNode(true, false, nameof(delay_control_rest), args), new Lazy<IParser<CharToken>>(() => delay_value.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delay_control_rest#1", (args) => CreateSyntaxNode(true, false, nameof(delay_control_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_323.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_324.Value)).Token().Tag("index", "1")).Tag("xor").Tag("!tokenTokenize").Tag("nodeTokenize").Tag("reductor_owner", "delay_control").Tag("nt", NonTerminals.delay_control_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay2_prefix", (args) => CreateSyntaxNode(false, false, nameof(delay2_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_322.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "delay2").Tag("nt", NonTerminals.delay2_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay2_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delay2_rest#0", (args) => CreateSyntaxNode(false, false, nameof(delay2_rest), args), new Lazy<IParser<CharToken>>(() => delay_value.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delay2_rest#1", (args) => CreateSyntaxNode(false, false, nameof(delay2_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_323.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay2_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_324.Value)).Tag("index", "1")).Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "delay2").Tag("nt", NonTerminals.delay2_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3_prefix", (args) => CreateSyntaxNode(false, false, nameof(delay3_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_322.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "delay3").Tag("nt", NonTerminals.delay3_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay3_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delay3_rest#0", (args) => CreateSyntaxNode(false, false, nameof(delay3_rest), args), new Lazy<IParser<CharToken>>(() => delay_value.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delay3_rest#1", (args) => CreateSyntaxNode(false, false, nameof(delay3_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_323.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay3_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_324.Value)).Tag("index", "1")).Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "delay3").Tag("nt", NonTerminals.delay3_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_data_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delayed_data_prefix", (args) => CreateSyntaxNode(false, true, nameof(delayed_data_prefix), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "delayed_data").Tag("nt", NonTerminals.delayed_data_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_data_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delayed_data_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delayed_data_rest#0", (args) => CreateSyntaxNode(false, true, nameof(delayed_data_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delayed_data_rest#1", (args) => CreateSyntaxNode(false, true, nameof(delayed_data_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "delayed_data").Tag("nt", NonTerminals.delayed_data_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_reference_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delayed_reference_prefix", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference_prefix), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "delayed_reference").Tag("nt", NonTerminals.delayed_reference_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_reference_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delayed_reference_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("delayed_reference_rest#0", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("delayed_reference_rest#1", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "delayed_reference").Tag("nt", NonTerminals.delayed_reference_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> disable_statement_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("disable_statement_prefix", (args) => CreateSyntaxNode(false, true, nameof(disable_statement_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_325.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "disable_statement").Tag("nt", NonTerminals.disable_statement_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> disable_statement_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("disable_statement_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("disable_statement_rest#0", (args) => CreateSyntaxNode(false, true, nameof(disable_statement_rest), args), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("disable_statement_rest#1", (args) => CreateSyntaxNode(false, true, nameof(disable_statement_rest), args), new Lazy<IParser<CharToken>>(() => hierarchical_block_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "disable_statement").Tag("nt", NonTerminals.disable_statement_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> drive_strength_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("drive_strength_prefix", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "drive_strength").Tag("nt", NonTerminals.drive_strength_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> drive_strength_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("drive_strength_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#0", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#1", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#2", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_326.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#3", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => _keyword_327.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#4", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_327.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength_rest#5", (args) => CreateSyntaxNode(false, true, nameof(drive_strength_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_326.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "5")).Tag("xor").Tag("reductor_owner", "drive_strength").Tag("nt", NonTerminals.drive_strength_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_83.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "function_declaration").Tag("nt", NonTerminals.function_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("function_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_rest), args), new Lazy<IParser<CharToken>>(() => function_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_84.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("function_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_rest), args), new Lazy<IParser<CharToken>>(() => function_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => function_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_84.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "function_declaration").Tag("nt", NonTerminals.function_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_prefix", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_prefix), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "hierarchical_unnamed_branch_reference").Tag("nt", NonTerminals.hierarchical_unnamed_branch_reference_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("hierarchical_unnamed_branch_reference_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_rest#0", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_328.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_rest#1", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_328.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_265.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_266.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_rest#2", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_328.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_265.Value), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_266.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "hierarchical_unnamed_branch_reference").Tag("nt", NonTerminals.hierarchical_unnamed_branch_reference_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_prefix", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "list_of_port_declarations").Tag("nt", NonTerminals.list_of_port_declarations_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_port_declarations_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_rest#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations_rest), args), new Lazy<IParser<CharToken>>(() => port_declaration.Value), new Lazy<IParser<CharToken>>(() => list_of_port_declarations_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_rest#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "list_of_port_declarations").Tag("nt", NonTerminals.list_of_port_declarations_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_329.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "local_parameter_declaration").Tag("nt", NonTerminals.local_parameter_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("local_parameter_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration_rest), args), new Lazy<IParser<CharToken>>(() => local_parameter_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration_rest), args), new Lazy<IParser<CharToken>>(() => parameter_type.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "local_parameter_declaration").Tag("nt", NonTerminals.local_parameter_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> mintypmax_expression_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression_prefix", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression_prefix), args), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "mintypmax_expression").Tag("nt", NonTerminals.mintypmax_expression_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> mintypmax_expression_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("mintypmax_expression_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression_rest#0", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_20.Value), new Lazy<IParser<CharToken>>(() => expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression_rest#1", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "mintypmax_expression").Tag("nt", NonTerminals.mintypmax_expression_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(module_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "module_declaration").Tag("nt", NonTerminals.module_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("module_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(module_declaration_rest), args), new Lazy<IParser<CharToken>>(() => module_keyword.Value), new Lazy<IParser<CharToken>>(() => module_identifier.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_ports.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => module_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_330.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(module_declaration_rest), args), new Lazy<IParser<CharToken>>(() => module_keyword.Value), new Lazy<IParser<CharToken>>(() => module_identifier.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_declarations.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_330.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "module_declaration").Tag("nt", NonTerminals.module_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_prefix", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("parallel").Tag("parallel_first").Tag("reductor_owner", "module_or_generate_item").Tag("nt", NonTerminals.module_or_generate_item_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_or_generate_item_rest", first: false, parallelMode: XOrParallelMode.First, Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#2", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => parameter_override.Value)).Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#3", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => continuous_assign.Value)).Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#4", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => gate_instantiation.Value)).Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#5", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => udp_instantiation.Value)).Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#6", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => module_instantiation.Value)).Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#7", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => initial_construct.Value)).Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#8", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => always_construct.Value)).Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#9", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => loop_generate_construct.Value)).Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#10", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => conditional_generate_construct.Value)).Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_rest#11", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_rest), args), new Lazy<IParser<CharToken>>(() => analog_construct.Value)).Tag("index", "11")).Tag("xor").Tag("parallel").Tag("parallel_first").Tag("reductor_owner", "module_or_generate_item").Tag("nt", NonTerminals.module_or_generate_item_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_parameter_assignment_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment_prefix", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_7.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "named_parameter_assignment").Tag("nt", NonTerminals.named_parameter_assignment_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_parameter_assignment_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("named_parameter_assignment_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment_rest#0", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment_rest), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment_rest#1", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment_rest), args), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "named_parameter_assignment").Tag("nt", NonTerminals.named_parameter_assignment_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_37.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "output_declaration").Tag("nt", NonTerminals.output_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("output_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => output_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => output_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_58.Value), new Lazy<IParser<CharToken>>(() => output_declaration_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration_rest#2", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => output_variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "output_declaration").Tag("nt", NonTerminals.output_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> param_assignment_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("param_assignment_prefix", (args) => CreateSyntaxNode(false, true, nameof(param_assignment_prefix), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "param_assignment").Tag("nt", NonTerminals.param_assignment_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> param_assignment_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("param_assignment_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("param_assignment_rest#0", (args) => CreateSyntaxNode(false, true, nameof(param_assignment_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("param_assignment_rest#1", (args) => CreateSyntaxNode(false, true, nameof(param_assignment_rest), args), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "param_assignment").Tag("First").Tag("First:0", "=").Tag("First:1", "[").Tag("nt", NonTerminals.param_assignment_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_331.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "parameter_declaration").Tag("nt", NonTerminals.parameter_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration_rest), args), new Lazy<IParser<CharToken>>(() => parameter_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration_rest), args), new Lazy<IParser<CharToken>>(() => parameter_type.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "parameter_declaration").Tag("nt", NonTerminals.parameter_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_reference_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_reference_prefix", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference_prefix), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "parameter_reference").Tag("nt", NonTerminals.parameter_reference_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_reference_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_reference_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("parameter_reference_rest#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_reference_rest#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "parameter_reference").Tag("nt", NonTerminals.parameter_reference_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_value_assignment_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment_prefix", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_3.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "parameter_value_assignment").Tag("nt", NonTerminals.parameter_value_assignment_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_value_assignment_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_value_assignment_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment_rest#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment_rest#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "parameter_value_assignment").Tag("nt", NonTerminals.parameter_value_assignment_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_branch_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_52.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "port_branch_declaration").Tag("nt", NonTerminals.port_branch_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_branch_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port_branch_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_265.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_266.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => _keyword_265.Value), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_266.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "port_branch_declaration").Tag("nt", NonTerminals.port_branch_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(port_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "port_declaration").Tag("nt", NonTerminals.port_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port_declaration_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("port_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(port_declaration_rest), args), new Lazy<IParser<CharToken>>(() => inout_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("port_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(port_declaration_rest), args), new Lazy<IParser<CharToken>>(() => input_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("port_declaration_rest#2", (args) => CreateSyntaxNode(false, true, nameof(port_declaration_rest), args), new Lazy<IParser<CharToken>>(() => output_declaration.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "port_declaration").Tag("First").Tag("First:0", "inout").Tag("First:1", "input").Tag("First:2", "output").Tag("nt", NonTerminals.port_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulldown_strength_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength_prefix", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "pulldown_strength").Tag("nt", NonTerminals.pulldown_strength_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulldown_strength_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pulldown_strength_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength_rest#0", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength_rest#1", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength_rest#2", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "pulldown_strength").Tag("nt", NonTerminals.pulldown_strength_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> pullup_strength_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pullup_strength_prefix", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_4.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "pullup_strength").Tag("nt", NonTerminals.pullup_strength_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> pullup_strength_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pullup_strength_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("pullup_strength_rest#0", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pullup_strength_rest#1", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_6.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("pullup_strength_rest#2", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength_rest), args), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "pullup_strength").Tag("nt", NonTerminals.pullup_strength_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_prefix", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_332.Value)).Tag("index", "0").Tag("reductor_owner", "pulse_control_specparam").Tag("nt", NonTerminals.pulse_control_specparam_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("pulse_control_specparam_rest", parallel: false, Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_rest#0", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_rest#1", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_rest), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_333.Value), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value)).Tag("index", "1")).Tag("reductor_owner", "pulse_control_specparam").Tag("nt", NonTerminals.pulse_control_specparam_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number_prefix", (args) => CreateSyntaxNode(false, false, nameof(real_number_prefix), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0").Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "real_number").Tag("nt", NonTerminals.real_number_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("real_number_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("real_number_rest#0", (args) => CreateSyntaxNode(false, false, nameof(real_number_rest), args), new Lazy<IParser<CharToken>>(() => real_number_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => exp.Value), new Lazy<IParser<CharToken>>(() => sign.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("real_number_rest#1", (args) => CreateSyntaxNode(false, false, nameof(real_number_rest), args), new Lazy<IParser<CharToken>>(() => real_number_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => scale_factor.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("real_number_rest#2", (args) => CreateSyntaxNode(false, false, nameof(real_number_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_289.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Tag("index", "2")).Tag("xor").Tag("!tokenTokenize").Tag("reductor_owner", "real_number").Tag("nt", NonTerminals.real_number_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_type_prefix", (args) => CreateSyntaxNode(false, true, nameof(real_type_prefix), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "real_type").Tag("nt", NonTerminals.real_type_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("real_type_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("real_type_rest#0", (args) => CreateSyntaxNode(false, true, nameof(real_type_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("real_type_rest#1", (args) => CreateSyntaxNode(false, true, nameof(real_type_rest), args), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => real_type_optional.Value.Optional(greedy: true))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "real_type").Tag("nt", NonTerminals.real_type_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_prefix", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue_prefix), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "scalar_analog_variable_lvalue").Tag("nt", NonTerminals.scalar_analog_variable_lvalue_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_analog_variable_lvalue_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_rest#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_9.Value), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue_many.Value.Many(greedy: true))).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_rest#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue_rest), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "scalar_analog_variable_lvalue").Tag("nt", NonTerminals.scalar_analog_variable_lvalue_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("statement_prefix", (args) => CreateSyntaxNode(true, true, nameof(statement_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Token().Tag("index", "0").Tag("xor").Tag("nodeTokenize").Tag("reductor_owner", "statement").Tag("nt", NonTerminals.statement_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("statement_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("statement_rest#0", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => blocking_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Token().Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#1", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => case_statement.Value)).Token().Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#2", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => conditional_statement.Value)).Token().Tag("index", "2"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#3", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => disable_statement.Value)).Token().Tag("index", "3"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#4", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => event_trigger.Value)).Token().Tag("index", "4"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#5", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => loop_statement.Value)).Token().Tag("index", "5"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#6", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => nonblocking_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Token().Tag("index", "6"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#7", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => par_block.Value)).Token().Tag("index", "7"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#8", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => procedural_continuous_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value)).Token().Tag("index", "8"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#9", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => procedural_timing_control_statement.Value)).Token().Tag("index", "9"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#10", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => seq_block.Value)).Token().Tag("index", "10"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#11", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => system_task_enable.Value)).Token().Tag("index", "11"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#12", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => task_enable.Value)).Token().Tag("index", "12"),
           Parser.Sequence<CharToken, SyntaxNode>("statement_rest#13", (args) => CreateSyntaxNode(true, true, nameof(statement_rest), args), new Lazy<IParser<CharToken>>(() => wait_statement.Value)).Token().Tag("index", "13")).Tag("xor").Tag("nodeTokenize").Tag("reductor_owner", "statement").Tag("nt", NonTerminals.statement_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_334.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "task_declaration").Tag("nt", NonTerminals.task_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("task_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_rest), args), new Lazy<IParser<CharToken>>(() => task_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => task_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => _keyword_335.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("task_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_rest), args), new Lazy<IParser<CharToken>>(() => task_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => task_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => _keyword_335.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "task_declaration").Tag("nt", NonTerminals.task_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_item_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_item_prefix", (args) => CreateSyntaxNode(false, true, nameof(task_port_item_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "task_port_item").Tag("nt", NonTerminals.task_port_item_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_item_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_port_item_rest", first: true, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("task_port_item_rest#0", (args) => CreateSyntaxNode(false, true, nameof(task_port_item_rest), args), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_item_rest#1", (args) => CreateSyntaxNode(false, true, nameof(task_port_item_rest), args), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value)).Tag("index", "1"),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_item_rest#2", (args) => CreateSyntaxNode(false, true, nameof(task_port_item_rest), args), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value)).Tag("index", "2")).Tag("xor").Tag("reductor_owner", "task_port_item").Tag("First").Tag("First:0", "input").Tag("First:1", "output").Tag("First:2", "inout").Tag("nt", NonTerminals.task_port_item_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_38.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "tf_inout_declaration").Tag("nt", NonTerminals.tf_inout_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_inout_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_rest), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_rest), args), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "tf_inout_declaration").Tag("nt", NonTerminals.tf_inout_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_36.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "tf_input_declaration").Tag("nt", NonTerminals.tf_input_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_input_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_rest), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_rest), args), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "tf_input_declaration").Tag("nt", NonTerminals.tf_input_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => _keyword_37.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "tf_output_declaration").Tag("nt", NonTerminals.tf_output_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_output_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "tf_output_declaration").Tag("nt", NonTerminals.tf_output_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "udp_declaration").Tag("nt", NonTerminals.udp_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_336.Value), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => udp_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => udp_body.Value), new Lazy<IParser<CharToken>>(() => _keyword_337.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_336.Value), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_4.Value), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_5.Value), new Lazy<IParser<CharToken>>(() => _keyword_10.Value), new Lazy<IParser<CharToken>>(() => udp_body.Value), new Lazy<IParser<CharToken>>(() => _keyword_337.Value)).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "udp_declaration").Tag("nt", NonTerminals.udp_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration_prefix", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration_prefix), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true))).Tag("index", "0").Tag("xor").Tag("reductor_owner", "udp_output_declaration").Tag("nt", NonTerminals.udp_output_declaration_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_output_declaration_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration_rest#0", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_37.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration_rest#1", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_37.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_58.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => udp_output_declaration_optional.Value.Optional(greedy: true))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "udp_output_declaration").Tag("nt", NonTerminals.udp_output_declaration_rest));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type_prefix =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_type_prefix", (args) => CreateSyntaxNode(false, true, nameof(variable_type_prefix), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)).Tag("index", "0").Tag("xor").Tag("reductor_owner", "variable_type").Tag("nt", NonTerminals.variable_type_prefix));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type_rest =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_type_rest", first: false, parallelMode: XOrParallelMode.None, Parser.Sequence<CharToken, SyntaxNode>("variable_type_rest#0", (args) => CreateSyntaxNode(false, true, nameof(variable_type_rest), args), new Lazy<IParser<CharToken>>(() => _keyword_23.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)).Tag("index", "0"),
           Parser.Sequence<CharToken, SyntaxNode>("variable_type_rest#1", (args) => CreateSyntaxNode(false, true, nameof(variable_type_rest), args), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => variable_type_optional.Value.Optional(greedy: true))).Tag("index", "1")).Tag("xor").Tag("reductor_owner", "variable_type").Tag("nt", NonTerminals.variable_type_rest));

        public static Lazy<IParser<CharToken, string>> _keyword_0 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("module", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_1 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("macromodule", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_2 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connectmodule", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_11 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("defparam", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_12 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("config", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_13 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endconfig", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_14 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("design", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_15 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("default", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_16 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("instance", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_17 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cell", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_18 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("liblist", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_19 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("use", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_21 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nature", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_22 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endnature", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_24 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("discipline", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_25 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("enddiscipline", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_26 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("potential", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_27 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("flow", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_28 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("domain", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_29 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("discrete", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_30 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("continuous", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_31 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connectrules", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_32 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endconnectrules", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_33 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connect", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_34 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("merged", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_35 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("split", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_36 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("input", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_37 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("output", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_38 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("inout", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_39 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("resolveto", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_40 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("exclude", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_41 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("paramset", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_42 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endparamset", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_43 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("signed", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_44 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("specparam", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_45 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("integer", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_46 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("realtime", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_47 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("real", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_48 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("time", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_49 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("string", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_50 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("aliasparam", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_51 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wreal", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_52 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("branch", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_53 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("event", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_54 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("trireg", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_55 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ground", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_56 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("vectored", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_57 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("scalared", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_58 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("reg", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_59 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("supply0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_60 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("supply1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_61 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("triand", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_62 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("trior", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_63 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_64 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_65 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_66 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("uwire", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_67 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wire", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_68 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wand", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_69 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_70 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("strong0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_71 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pull0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_72 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("weak0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_73 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("strong1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_74 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pull1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_75 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("weak1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_77 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'{", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_79 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("from", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_80 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("-inf", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_81 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("inf", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_82 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("analog", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_83 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("function", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_84 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endfunction", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_85 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("automatic", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_86 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulldown", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_87 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pullup", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_88 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_89 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rcmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_90 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("bufif0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_91 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("bufif1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_92 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("notif0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_93 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("notif1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_94 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_95 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_96 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rnmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_97 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rpmos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_98 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("and", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_99 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nand", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_100 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("or", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_101 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_102 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("xor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_103 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("xnor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_104 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("buf", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_105 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("not", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_106 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tranif0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_107 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tranif1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_108 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtranif1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_109 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtranif0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_110 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tran", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_111 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtran", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_112 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("generate", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_113 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endgenerate", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_114 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("genvar", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_115 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("for", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_116 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("if", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_117 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("else", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_118 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("case", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_119 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endcase", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_120 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("begin", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_121 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("end", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_122 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("table", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_123 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endtable", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_124 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("initial", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_125 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'b0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_126 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'b1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_127 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'bx", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_128 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'bX", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_129 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'B0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_130 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'B1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_131 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'Bx", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_132 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'BX", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_150 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("assign", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_151 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("always", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_152 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<=", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_153 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("deassign", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_154 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("force", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_155 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("release", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_156 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("fork", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_157 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("join", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_158 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("posedge", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_159 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("negedge", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_160 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("initial_step", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_161 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("final_step", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_162 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("\"", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_163 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cross", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_164 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("above", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_165 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("timer", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_166 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("absdelta", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_167 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("repeat", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_169 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("@*", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_170 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("(*)", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_171 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("->", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_172 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("driver_update", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_173 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wait", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_174 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("casex", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_175 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("casez", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_176 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("while", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_177 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("forever", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_178 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<+", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_179 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("==", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_180 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("specify", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_181 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endspecify", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_182 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulsestyle_onevent", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_183 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulsestyle_ondetect", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_184 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("showcancelled", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_185 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noshowcancelled", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_186 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("=>", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_187 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("*>", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_188 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("\\", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_189 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ifnone", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_191 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$setup", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_192 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$hold", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_193 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$setuphold", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_194 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$recovery", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_195 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$removal", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_196 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$recrem", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_197 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$skew", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_198 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$timeskew", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_199 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$fullskew", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_200 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$period", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_201 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$width", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_202 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$nochange", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_203 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("&&&", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_204 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("edge", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_205 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("01", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_206 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("10", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_209 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("===", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_210 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("!==", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_211 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("!=", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_213 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'b0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_214 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'b1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_215 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'B0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_216 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'B1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_218 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ln", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_219 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("log", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_220 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("exp", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_221 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sqrt", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_222 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("min", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_223 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("max", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_224 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("abs", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_225 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pow", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_226 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("floor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_227 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ceil", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_228 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tanh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_229 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("asinh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_230 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("acosh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_231 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atan2", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_232 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atanh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_233 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("hypot", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_234 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sinh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_235 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sin", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_236 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cosh", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_237 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_238 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tan", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_239 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("asin", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_240 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("acos", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_241 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atan", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_242 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("analysis", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_243 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddt", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_244 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddx", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_245 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idt", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_246 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idtmod", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_247 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("absdelay", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_248 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("transition", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_249 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("slew", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_250 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("last_crossing", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_251 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("limexp", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_252 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ac_stim", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_253 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("white_noise", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_254 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("flicker_noise", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_255 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noise_table", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_256 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noise_table_log", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_257 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_zd", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_258 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_zp", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_259 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_np", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_260 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_nd", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_261 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_zp", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_262 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_zd", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_263 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_np", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_264 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_nd", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_267 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("+:", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_268 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("-:", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_269 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("array_analog_variable_lvalue", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_270 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("array_variable_identifier", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_272 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~^", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_273 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("^~", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_274 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~&", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_277 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~|", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_279 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("**", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_282 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<<<", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_283 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">>>", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_284 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<<", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_285 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">>", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_286 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">=", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_287 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("&&", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_288 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("||", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_293 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("x_digit", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_294 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("z_digit", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_306 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("(*", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_307 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("*)", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_309 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$root", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_310 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("abstol", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_311 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("access", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_312 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddt_nature", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_313 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idt_nature", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_314 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("units", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_317 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("__VAMS_ENABLE__", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_318 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("__VAMS_COMPACT_MODELING__", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_319 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("small", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_320 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("medium", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_321 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("large", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_325 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("disable", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_326 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("highz1", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_327 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("highz0", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_328 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(".branch", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_329 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("localparam", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_330 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endmodule", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_331 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("parameter", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_332 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("PATHPULSE$", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_333 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$specify_output_terminal_descriptor", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_334 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("task", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_335 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endtask", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_336 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("primitive", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_337 =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endprimitive", true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_3 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('#', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_4 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('(', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_5 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(')', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_6 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(',', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_7 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('.', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_8 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('[', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_9 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(']', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_10 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(';', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_20 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(':', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_23 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('=', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_76 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(',', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_78 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('}', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_133 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('1', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_134 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('0', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_135 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('-', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_136 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('x', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_137 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('X', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_138 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('?', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_139 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('b', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_140 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('B', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_141 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('r', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_142 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('R', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_143 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('f', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_144 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('F', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_145 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('p', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_146 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('P', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_147 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('n', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_148 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('N', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_149 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('*', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_168 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('@', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_190 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('+', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_207 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('z', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_208 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('Z', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_212 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('~', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_217 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('{', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_265 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('<', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_266 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('>', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_271 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('!', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_275 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('&', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_276 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('|', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_278 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('^', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_280 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('/', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_281 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('%', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_289 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('.', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_290 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('e', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_291 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('E', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_295 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('_', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_322 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('#', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_323 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('(', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, char>> _keyword_324 =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(')', true).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_292 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[TGMKkmunpfa]", false).Cached(292).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_296 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[1-9][1-9_]*", false).Cached(296).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_297 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[0-9][0-9_]*", false).Cached(297).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_298 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX01zZ\\?][_xX01zZ\\?]*", false).Cached(298).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_299 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX0-7zZ\\?][xX0-7zZ\\?_]*", false).Cached(299).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_300 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX0-9a-fA-FzZ\\?][xX0-9a-fA-FzZ\\?_]*", false).Cached(300).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_301 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[dD]?", false).Cached(301).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_302 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[bB]?", false).Cached(302).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_303 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[oO]?", false).Cached(303).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_304 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[hH]?", false).Cached(304).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_305 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\"((?:\\\\.|[^\\\"])*)\"", true).Cached(305).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_308 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\\\\[^ ]+", true).Cached(308).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_315 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[a-zA-Z_][a-zA-Z0-9_\\$]*", true).Cached(315).Tag("keyword"));

        public static Lazy<IParser<CharToken, string>> _keyword_316 =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\\$[a-zA-Z0-9_$][a-zA-Z0-9_\\$]*", true).Cached(316).Tag("keyword"));

        public static int MaxCached = 338;



        public class NonTerminals
        {
            public const string source_text = "source_text";
            public const string description = "description";
            public const string module_declaration = "module_declaration";
            public const string module_keyword = "module_keyword";
            public const string module_parameter_port_list = "module_parameter_port_list";
            public const string module_parameter_port_list_many = "module_parameter_port_list_many";
            public const string list_of_ports = "list_of_ports";
            public const string list_of_ports_many = "list_of_ports_many";
            public const string list_of_port_declarations = "list_of_port_declarations";
            public const string list_of_port_declarations_many = "list_of_port_declarations_many";
            public const string port = "port";
            public const string port_expression = "port_expression";
            public const string port_expression_many = "port_expression_many";
            public const string port_reference = "port_reference";
            public const string port_reference_optional = "port_reference_optional";
            public const string port_declaration = "port_declaration";
            public const string module_item = "module_item";
            public const string module_or_generate_item = "module_or_generate_item";
            public const string module_or_generate_item_declaration = "module_or_generate_item_declaration";
            public const string non_port_module_item = "non_port_module_item";
            public const string parameter_override = "parameter_override";
            public const string config_declaration = "config_declaration";
            public const string design_statement = "design_statement";
            public const string design_statement_many = "design_statement_many";
            public const string design_statement_optional = "design_statement_optional";
            public const string config_rule_statement = "config_rule_statement";
            public const string default_clause = "default_clause";
            public const string inst_clause = "inst_clause";
            public const string inst_name = "inst_name";
            public const string inst_name_many = "inst_name_many";
            public const string cell_clause = "cell_clause";
            public const string cell_clause_optional = "cell_clause_optional";
            public const string liblist_clause = "liblist_clause";
            public const string use_clause = "use_clause";
            public const string use_clause_optional = "use_clause_optional";
            public const string use_config = "use_config";
            public const string nature_declaration = "nature_declaration";
            public const string nature_declaration_optional = "nature_declaration_optional";
            public const string nature_declaration_optional_2 = "nature_declaration_optional_2";
            public const string parent_nature = "parent_nature";
            public const string nature_item = "nature_item";
            public const string nature_attribute = "nature_attribute";
            public const string discipline_declaration = "discipline_declaration";
            public const string discipline_declaration_optional = "discipline_declaration_optional";
            public const string discipline_item = "discipline_item";
            public const string nature_binding = "nature_binding";
            public const string potential_or_flow = "potential_or_flow";
            public const string discipline_domain_binding = "discipline_domain_binding";
            public const string discrete_or_continuous = "discrete_or_continuous";
            public const string nature_attribute_override = "nature_attribute_override";
            public const string connectrules_declaration = "connectrules_declaration";
            public const string connectrules_item = "connectrules_item";
            public const string connect_insertion = "connect_insertion";
            public const string connect_mode = "connect_mode";
            public const string connect_port_overrides = "connect_port_overrides";
            public const string connect_resolution = "connect_resolution";
            public const string connect_resolution_many = "connect_resolution_many";
            public const string discipline_identifier_or_exclude = "discipline_identifier_or_exclude";
            public const string paramset_declaration = "paramset_declaration";
            public const string paramset_item_declaration = "paramset_item_declaration";
            public const string paramset_statement = "paramset_statement";
            public const string paramset_constant_expression = "paramset_constant_expression";
            public const string local_parameter_declaration = "local_parameter_declaration";
            public const string local_parameter_declaration_optional = "local_parameter_declaration_optional";
            public const string parameter_declaration = "parameter_declaration";
            public const string parameter_declaration_optional = "parameter_declaration_optional";
            public const string specparam_declaration = "specparam_declaration";
            public const string parameter_type = "parameter_type";
            public const string aliasparam_declaration = "aliasparam_declaration";
            public const string inout_declaration = "inout_declaration";
            public const string inout_declaration_optional = "inout_declaration_optional";
            public const string inout_declaration_optional_2 = "inout_declaration_optional_2";
            public const string input_declaration = "input_declaration";
            public const string input_declaration_optional = "input_declaration_optional";
            public const string input_declaration_optional_2 = "input_declaration_optional_2";
            public const string output_declaration = "output_declaration";
            public const string output_declaration_optional = "output_declaration_optional";
            public const string output_declaration_optional_2 = "output_declaration_optional_2";
            public const string output_declaration_optional_3 = "output_declaration_optional_3";
            public const string branch_declaration = "branch_declaration";
            public const string branch_declaration_optional = "branch_declaration_optional";
            public const string port_branch_declaration = "port_branch_declaration";
            public const string branch_terminal = "branch_terminal";
            public const string event_declaration = "event_declaration";
            public const string integer_declaration = "integer_declaration";
            public const string net_declaration = "net_declaration";
            public const string net_declaration_optional = "net_declaration_optional";
            public const string net_declaration_optional_2 = "net_declaration_optional_2";
            public const string net_declaration_optional_3 = "net_declaration_optional_3";
            public const string net_declaration_optional_4 = "net_declaration_optional_4";
            public const string net_declaration_optional_5 = "net_declaration_optional_5";
            public const string net_declaration_optional_6 = "net_declaration_optional_6";
            public const string net_declaration_optional_7 = "net_declaration_optional_7";
            public const string net_declaration_optional_8 = "net_declaration_optional_8";
            public const string net_declaration_optional_9 = "net_declaration_optional_9";
            public const string net_declaration_optional_10 = "net_declaration_optional_10";
            public const string net_declaration_optional_11 = "net_declaration_optional_11";
            public const string net_declaration_optional_12 = "net_declaration_optional_12";
            public const string real_declaration = "real_declaration";
            public const string realtime_declaration = "realtime_declaration";
            public const string reg_declaration = "reg_declaration";
            public const string reg_declaration_optional = "reg_declaration_optional";
            public const string time_declaration = "time_declaration";
            public const string net_type = "net_type";
            public const string output_variable_type = "output_variable_type";
            public const string real_type = "real_type";
            public const string real_type_optional = "real_type_optional";
            public const string variable_type = "variable_type";
            public const string variable_type_optional = "variable_type_optional";
            public const string drive_strength = "drive_strength";
            public const string strength0 = "strength0";
            public const string strength1 = "strength1";
            public const string charge_strength = "charge_strength";
            public const string delay3 = "delay3";
            public const string delay3_optional = "delay3_optional";
            public const string delay3_optional_2 = "delay3_optional_2";
            public const string delay2 = "delay2";
            public const string delay2_optional = "delay2_optional";
            public const string delay_value = "delay_value";
            public const string list_of_branch_identifiers = "list_of_branch_identifiers";
            public const string list_of_branch_identifiers_many = "list_of_branch_identifiers_many";
            public const string list_of_defparam_assignments = "list_of_defparam_assignments";
            public const string list_of_defparam_assignments_many = "list_of_defparam_assignments_many";
            public const string list_of_event_identifiers = "list_of_event_identifiers";
            public const string list_of_event_identifiers_many = "list_of_event_identifiers_many";
            public const string list_of_net_decl_assignments = "list_of_net_decl_assignments";
            public const string list_of_net_decl_assignments_many = "list_of_net_decl_assignments_many";
            public const string list_of_net_identifiers = "list_of_net_identifiers";
            public const string list_of_net_identifiers_many = "list_of_net_identifiers_many";
            public const string list_of_param_assignments = "list_of_param_assignments";
            public const string list_of_param_assignments_many = "list_of_param_assignments_many";
            public const string list_of_port_identifiers = "list_of_port_identifiers";
            public const string list_of_port_identifiers_many = "list_of_port_identifiers_many";
            public const string list_of_real_identifiers = "list_of_real_identifiers";
            public const string list_of_real_identifiers_many = "list_of_real_identifiers_many";
            public const string list_of_specparam_assignments = "list_of_specparam_assignments";
            public const string list_of_specparam_assignments_many = "list_of_specparam_assignments_many";
            public const string list_of_variable_identifiers = "list_of_variable_identifiers";
            public const string list_of_variable_identifiers_many = "list_of_variable_identifiers_many";
            public const string list_of_variable_port_identifiers = "list_of_variable_port_identifiers";
            public const string list_of_variable_port_identifiers_many = "list_of_variable_port_identifiers_many";
            public const string list_of_variable_port_identifiers_optional = "list_of_variable_port_identifiers_optional";
            public const string list_of_variable_port_identifiers_optional_2 = "list_of_variable_port_identifiers_optional_2";
            public const string defparam_assignment = "defparam_assignment";
            public const string net_decl_assignment = "net_decl_assignment";
            public const string param_assignment = "param_assignment";
            public const string specparam_assignment = "specparam_assignment";
            public const string pulse_control_specparam = "pulse_control_specparam";
            public const string pulse_control_specparam_optional = "pulse_control_specparam_optional";
            public const string pulse_control_specparam_optional_2 = "pulse_control_specparam_optional_2";
            public const string error_limit_value = "error_limit_value";
            public const string reject_limit_value = "reject_limit_value";
            public const string limit_value = "limit_value";
            public const string dimension = "dimension";
            public const string range = "range";
            public const string value_range = "value_range";
            public const string value_range_many = "value_range_many";
            public const string value_range_type = "value_range_type";
            public const string value_range_expression = "value_range_expression";
            public const string analog_function_declaration = "analog_function_declaration";
            public const string analog_function_type = "analog_function_type";
            public const string analog_function_item_declaration = "analog_function_item_declaration";
            public const string function_declaration = "function_declaration";
            public const string function_declaration_optional = "function_declaration_optional";
            public const string function_declaration_optional_2 = "function_declaration_optional_2";
            public const string function_item_declaration = "function_item_declaration";
            public const string function_port_list = "function_port_list";
            public const string function_port_list_many = "function_port_list_many";
            public const string function_range_or_type = "function_range_or_type";
            public const string function_range_or_type_optional = "function_range_or_type_optional";
            public const string task_declaration = "task_declaration";
            public const string task_declaration_optional = "task_declaration_optional";
            public const string task_declaration_optional_2 = "task_declaration_optional_2";
            public const string task_item_declaration = "task_item_declaration";
            public const string task_port_list = "task_port_list";
            public const string task_port_list_many = "task_port_list_many";
            public const string task_port_item = "task_port_item";
            public const string tf_input_declaration = "tf_input_declaration";
            public const string tf_input_declaration_optional = "tf_input_declaration_optional";
            public const string tf_input_declaration_optional_2 = "tf_input_declaration_optional_2";
            public const string tf_output_declaration = "tf_output_declaration";
            public const string tf_output_declaration_optional = "tf_output_declaration_optional";
            public const string tf_output_declaration_optional_2 = "tf_output_declaration_optional_2";
            public const string tf_inout_declaration = "tf_inout_declaration";
            public const string tf_inout_declaration_optional = "tf_inout_declaration_optional";
            public const string tf_inout_declaration_optional_2 = "tf_inout_declaration_optional_2";
            public const string task_port_type = "task_port_type";
            public const string analog_block_item_declaration = "analog_block_item_declaration";
            public const string block_item_declaration = "block_item_declaration";
            public const string block_item_declaration_optional = "block_item_declaration_optional";
            public const string list_of_block_variable_identifiers = "list_of_block_variable_identifiers";
            public const string list_of_block_variable_identifiers_many = "list_of_block_variable_identifiers_many";
            public const string list_of_block_real_identifiers = "list_of_block_real_identifiers";
            public const string list_of_block_real_identifiers_many = "list_of_block_real_identifiers_many";
            public const string block_variable_type = "block_variable_type";
            public const string block_real_type = "block_real_type";
            public const string gate_instantiation = "gate_instantiation";
            public const string gate_instantiation_many = "gate_instantiation_many";
            public const string gate_instantiation_many_2 = "gate_instantiation_many_2";
            public const string gate_instantiation_many_3 = "gate_instantiation_many_3";
            public const string gate_instantiation_many_4 = "gate_instantiation_many_4";
            public const string gate_instantiation_many_5 = "gate_instantiation_many_5";
            public const string gate_instantiation_many_6 = "gate_instantiation_many_6";
            public const string gate_instantiation_many_7 = "gate_instantiation_many_7";
            public const string gate_instantiation_many_8 = "gate_instantiation_many_8";
            public const string gate_instantiation_many_9 = "gate_instantiation_many_9";
            public const string cmos_switch_instance = "cmos_switch_instance";
            public const string enable_gate_instance = "enable_gate_instance";
            public const string mos_switch_instance = "mos_switch_instance";
            public const string n_input_gate_instance = "n_input_gate_instance";
            public const string n_input_gate_instance_many = "n_input_gate_instance_many";
            public const string n_output_gate_instance = "n_output_gate_instance";
            public const string n_output_gate_instance_many = "n_output_gate_instance_many";
            public const string pass_switch_instance = "pass_switch_instance";
            public const string pass_enable_switch_instance = "pass_enable_switch_instance";
            public const string pull_gate_instance = "pull_gate_instance";
            public const string name_of_gate_instance = "name_of_gate_instance";
            public const string pulldown_strength = "pulldown_strength";
            public const string pullup_strength = "pullup_strength";
            public const string enable_terminal = "enable_terminal";
            public const string inout_terminal = "inout_terminal";
            public const string input_terminal = "input_terminal";
            public const string ncontrol_terminal = "ncontrol_terminal";
            public const string output_terminal = "output_terminal";
            public const string pcontrol_terminal = "pcontrol_terminal";
            public const string cmos_switchtype = "cmos_switchtype";
            public const string enable_gatetype = "enable_gatetype";
            public const string mos_switchtype = "mos_switchtype";
            public const string n_input_gatetype = "n_input_gatetype";
            public const string n_output_gatetype = "n_output_gatetype";
            public const string pass_en_switchtype = "pass_en_switchtype";
            public const string pass_switchtype = "pass_switchtype";
            public const string module_instantiation = "module_instantiation";
            public const string module_instantiation_many = "module_instantiation_many";
            public const string parameter_value_assignment = "parameter_value_assignment";
            public const string list_of_parameter_assignments = "list_of_parameter_assignments";
            public const string list_of_parameter_assignments_many = "list_of_parameter_assignments_many";
            public const string list_of_parameter_assignments_many_2 = "list_of_parameter_assignments_many_2";
            public const string ordered_parameter_assignment = "ordered_parameter_assignment";
            public const string named_parameter_assignment = "named_parameter_assignment";
            public const string module_instance = "module_instance";
            public const string module_instance_optional = "module_instance_optional";
            public const string name_of_module_instance = "name_of_module_instance";
            public const string list_of_port_connections = "list_of_port_connections";
            public const string list_of_port_connections_many = "list_of_port_connections_many";
            public const string list_of_port_connections_many_2 = "list_of_port_connections_many_2";
            public const string ordered_port_connection = "ordered_port_connection";
            public const string named_port_connection = "named_port_connection";
            public const string generate_region = "generate_region";
            public const string genvar_declaration = "genvar_declaration";
            public const string list_of_genvar_identifiers = "list_of_genvar_identifiers";
            public const string list_of_genvar_identifiers_many = "list_of_genvar_identifiers_many";
            public const string analog_loop_generate_statement = "analog_loop_generate_statement";
            public const string loop_generate_construct = "loop_generate_construct";
            public const string genvar_initialization = "genvar_initialization";
            public const string genvar_expression = "genvar_expression";
            public const string genvar_iteration = "genvar_iteration";
            public const string genvar_primary = "genvar_primary";
            public const string conditional_generate_construct = "conditional_generate_construct";
            public const string if_generate_construct = "if_generate_construct";
            public const string if_generate_construct_else = "if_generate_construct_else";
            public const string case_generate_construct = "case_generate_construct";
            public const string case_generate_item = "case_generate_item";
            public const string case_generate_item_many = "case_generate_item_many";
            public const string case_generate_item_optional = "case_generate_item_optional";
            public const string generate_block = "generate_block";
            public const string generate_block_optional = "generate_block_optional";
            public const string generate_block_or_null = "generate_block_or_null";
            public const string udp_declaration = "udp_declaration";
            public const string udp_port_list = "udp_port_list";
            public const string udp_port_list_many = "udp_port_list_many";
            public const string udp_declaration_port_list = "udp_declaration_port_list";
            public const string udp_declaration_port_list_many = "udp_declaration_port_list_many";
            public const string udp_port_declaration = "udp_port_declaration";
            public const string udp_output_declaration = "udp_output_declaration";
            public const string udp_output_declaration_optional = "udp_output_declaration_optional";
            public const string udp_input_declaration = "udp_input_declaration";
            public const string udp_reg_declaration = "udp_reg_declaration";
            public const string udp_body = "udp_body";
            public const string combinational_body = "combinational_body";
            public const string combinational_entry = "combinational_entry";
            public const string sequential_body = "sequential_body";
            public const string udp_initial_statement = "udp_initial_statement";
            public const string init_val = "init_val";
            public const string sequential_entry = "sequential_entry";
            public const string seq_input_list = "seq_input_list";
            public const string level_input_list = "level_input_list";
            public const string edge_input_list = "edge_input_list";
            public const string edge_indicator = "edge_indicator";
            public const string current_state = "current_state";
            public const string next_state = "next_state";
            public const string output_symbol = "output_symbol";
            public const string level_symbol = "level_symbol";
            public const string edge_symbol = "edge_symbol";
            public const string udp_instantiation = "udp_instantiation";
            public const string udp_instantiation_many = "udp_instantiation_many";
            public const string udp_instance = "udp_instance";
            public const string udp_instance_many = "udp_instance_many";
            public const string name_of_udp_instance = "name_of_udp_instance";
            public const string continuous_assign = "continuous_assign";
            public const string list_of_net_assignments = "list_of_net_assignments";
            public const string list_of_net_assignments_many = "list_of_net_assignments_many";
            public const string net_assignment = "net_assignment";
            public const string analog_construct = "analog_construct";
            public const string analog_procedural_assignment = "analog_procedural_assignment";
            public const string analog_variable_assignment = "analog_variable_assignment";
            public const string scalar_analog_variable_assignment = "scalar_analog_variable_assignment";
            public const string scalar_analog_variable_lvalue = "scalar_analog_variable_lvalue";
            public const string scalar_analog_variable_lvalue_many = "scalar_analog_variable_lvalue_many";
            public const string initial_construct = "initial_construct";
            public const string always_construct = "always_construct";
            public const string blocking_assignment = "blocking_assignment";
            public const string nonblocking_assignment = "nonblocking_assignment";
            public const string procedural_continuous_assignments = "procedural_continuous_assignments";
            public const string variable_assignment = "variable_assignment";
            public const string analog_seq_block = "analog_seq_block";
            public const string analog_seq_block_optional = "analog_seq_block_optional";
            public const string analog_event_seq_block = "analog_event_seq_block";
            public const string analog_event_seq_block_optional = "analog_event_seq_block_optional";
            public const string analog_function_seq_block = "analog_function_seq_block";
            public const string analog_function_seq_block_optional = "analog_function_seq_block_optional";
            public const string par_block = "par_block";
            public const string par_block_optional = "par_block_optional";
            public const string seq_block = "seq_block";
            public const string seq_block_optional = "seq_block_optional";
            public const string analog_statement = "analog_statement";
            public const string analog_statement_or_null = "analog_statement_or_null";
            public const string analog_event_statement = "analog_event_statement";
            public const string analog_function_statement = "analog_function_statement";
            public const string analog_function_statement_or_null = "analog_function_statement_or_null";
            public const string statement = "statement";
            public const string statement_or_null = "statement_or_null";
            public const string function_statement = "function_statement";
            public const string analog_event_control_statement = "analog_event_control_statement";
            public const string analog_event_control = "analog_event_control";
            public const string analog_event_expression = "analog_event_expression";
            public const string analog_event_expression_optional = "analog_event_expression_optional";
            public const string analog_event_expression_optional_2 = "analog_event_expression_optional_2";
            public const string analog_event_expression_many = "analog_event_expression_many";
            public const string analog_event_expression_many_2 = "analog_event_expression_many_2";
            public const string analog_event_functions = "analog_event_functions";
            public const string analog_event_functions_optional = "analog_event_functions_optional";
            public const string analog_event_functions_optional_2 = "analog_event_functions_optional_2";
            public const string analog_event_functions_optional_3 = "analog_event_functions_optional_3";
            public const string analog_event_functions_optional_4 = "analog_event_functions_optional_4";
            public const string analog_event_functions_optional_5 = "analog_event_functions_optional_5";
            public const string analog_event_functions_optional_6 = "analog_event_functions_optional_6";
            public const string analog_event_functions_optional_7 = "analog_event_functions_optional_7";
            public const string analog_event_functions_optional_8 = "analog_event_functions_optional_8";
            public const string analog_event_functions_optional_9 = "analog_event_functions_optional_9";
            public const string analog_event_functions_optional_10 = "analog_event_functions_optional_10";
            public const string analog_event_functions_optional_11 = "analog_event_functions_optional_11";
            public const string analog_event_functions_optional_12 = "analog_event_functions_optional_12";
            public const string analog_event_functions_optional_13 = "analog_event_functions_optional_13";
            public const string delay_control = "delay_control";
            public const string delay_or_event_control = "delay_or_event_control";
            public const string disable_statement = "disable_statement";
            public const string event_control = "event_control";
            public const string event_trigger = "event_trigger";
            public const string event_trigger_many = "event_trigger_many";
            public const string event_expression = "event_expression";
            public const string procedural_timing_control = "procedural_timing_control";
            public const string procedural_timing_control_statement = "procedural_timing_control_statement";
            public const string wait_statement = "wait_statement";
            public const string analog_conditional_statement = "analog_conditional_statement";
            public const string analog_conditional_statement_many = "analog_conditional_statement_many";
            public const string analog_conditional_statement_else = "analog_conditional_statement_else";
            public const string analog_function_conditional_statement = "analog_function_conditional_statement";
            public const string analog_function_conditional_statement_many = "analog_function_conditional_statement_many";
            public const string analog_function_conditional_statement_else = "analog_function_conditional_statement_else";
            public const string conditional_statement = "conditional_statement";
            public const string conditional_statement_else = "conditional_statement_else";
            public const string if_else_if_statement = "if_else_if_statement";
            public const string if_else_if_statement_many = "if_else_if_statement_many";
            public const string if_else_if_statement_else = "if_else_if_statement_else";
            public const string analog_case_statement = "analog_case_statement";
            public const string analog_case_item = "analog_case_item";
            public const string analog_case_item_many = "analog_case_item_many";
            public const string analog_case_item_optional = "analog_case_item_optional";
            public const string analog_function_case_statement = "analog_function_case_statement";
            public const string analog_function_case_item = "analog_function_case_item";
            public const string analog_function_case_item_many = "analog_function_case_item_many";
            public const string analog_function_case_item_optional = "analog_function_case_item_optional";
            public const string case_statement = "case_statement";
            public const string case_item = "case_item";
            public const string case_item_many = "case_item_many";
            public const string case_item_optional = "case_item_optional";
            public const string analog_loop_statement = "analog_loop_statement";
            public const string analog_function_loop_statement = "analog_function_loop_statement";
            public const string analog_function_statement_loop_statement = "analog_function_statement_loop_statement";
            public const string loop_statement = "loop_statement";
            public const string analog_system_task_enable = "analog_system_task_enable";
            public const string analog_system_task_enable_optional = "analog_system_task_enable_optional";
            public const string analog_system_task_enable_many = "analog_system_task_enable_many";
            public const string system_task_enable = "system_task_enable";
            public const string system_task_enable_optional = "system_task_enable_optional";
            public const string system_task_enable_many = "system_task_enable_many";
            public const string task_enable = "task_enable";
            public const string task_enable_optional = "task_enable_optional";
            public const string task_enable_many = "task_enable_many";
            public const string contribution_statement = "contribution_statement";
            public const string indirect_contribution_statement = "indirect_contribution_statement";
            public const string specify_block = "specify_block";
            public const string specify_item = "specify_item";
            public const string pulsestyle_declaration = "pulsestyle_declaration";
            public const string showcancelled_declaration = "showcancelled_declaration";
            public const string path_declaration = "path_declaration";
            public const string simple_path_declaration = "simple_path_declaration";
            public const string parallel_path_description = "parallel_path_description";
            public const string full_path_description = "full_path_description";
            public const string list_of_path_inputs = "list_of_path_inputs";
            public const string list_of_path_inputs_many = "list_of_path_inputs_many";
            public const string list_of_path_outputs = "list_of_path_outputs";
            public const string list_of_path_outputs_many = "list_of_path_outputs_many";
            public const string specify_input_terminal_descriptor = "specify_input_terminal_descriptor";
            public const string specify_input_terminal_descriptor_optional = "specify_input_terminal_descriptor_optional";
            public const string specify_output_terminal_descriptor = "specify_output_terminal_descriptor";
            public const string specify_output_terminal_descriptor_optional = "specify_output_terminal_descriptor_optional";
            public const string input_identifier = "input_identifier";
            public const string output_identifier = "output_identifier";
            public const string path_delay_value = "path_delay_value";
            public const string list_of_path_delay_expressions = "list_of_path_delay_expressions";
            public const string t_path_delay_expression = "t_path_delay_expression";
            public const string trise_path_delay_expression = "trise_path_delay_expression";
            public const string tfall_path_delay_expression = "tfall_path_delay_expression";
            public const string tz_path_delay_expression = "tz_path_delay_expression";
            public const string t01_path_delay_expression = "t01_path_delay_expression";
            public const string t10_path_delay_expression = "t10_path_delay_expression";
            public const string t0z_path_delay_expression = "t0z_path_delay_expression";
            public const string tz1_path_delay_expression = "tz1_path_delay_expression";
            public const string t1z_path_delay_expression = "t1z_path_delay_expression";
            public const string tz0_path_delay_expression = "tz0_path_delay_expression";
            public const string t0x_path_delay_expression = "t0x_path_delay_expression";
            public const string tx1_path_delay_expression = "tx1_path_delay_expression";
            public const string t1x_path_delay_expression = "t1x_path_delay_expression";
            public const string tx0_path_delay_expression = "tx0_path_delay_expression";
            public const string txz_path_delay_expression = "txz_path_delay_expression";
            public const string tzx_path_delay_expression = "tzx_path_delay_expression";
            public const string path_delay_expression = "path_delay_expression";
            public const string edge_sensitive_path_declaration = "edge_sensitive_path_declaration";
            public const string parallel_edge_sensitive_path_description = "parallel_edge_sensitive_path_description";
            public const string full_edge_sensitive_path_description = "full_edge_sensitive_path_description";
            public const string data_source_expression = "data_source_expression";
            public const string edge_identifier = "edge_identifier";
            public const string state_dependent_path_declaration = "state_dependent_path_declaration";
            public const string polarity_operator = "polarity_operator";
            public const string system_timing_check = "system_timing_check";
            public const string setup_timing_check = "$setup_timing_check";
            public const string setup_timing_check_optional = "$setup_timing_check_optional";
            public const string hold_timing_check = "$hold_timing_check";
            public const string hold_timing_check_optional = "$hold_timing_check_optional";
            public const string setuphold_timing_check = "$setuphold_timing_check";
            public const string setuphold_timing_check_optional = "$setuphold_timing_check_optional";
            public const string setuphold_timing_check_optional_2 = "$setuphold_timing_check_optional_2";
            public const string setuphold_timing_check_optional_3 = "$setuphold_timing_check_optional_3";
            public const string setuphold_timing_check_optional_4 = "$setuphold_timing_check_optional_4";
            public const string setuphold_timing_check_optional_5 = "$setuphold_timing_check_optional_5";
            public const string recovery_timing_check = "$recovery_timing_check";
            public const string recovery_timing_check_optional = "$recovery_timing_check_optional";
            public const string removal_timing_check = "$removal_timing_check";
            public const string removal_timing_check_optional = "$removal_timing_check_optional";
            public const string recrem_timing_check = "$recrem_timing_check";
            public const string recrem_timing_check_optional = "$recrem_timing_check_optional";
            public const string recrem_timing_check_optional_2 = "$recrem_timing_check_optional_2";
            public const string recrem_timing_check_optional_3 = "$recrem_timing_check_optional_3";
            public const string recrem_timing_check_optional_4 = "$recrem_timing_check_optional_4";
            public const string recrem_timing_check_optional_5 = "$recrem_timing_check_optional_5";
            public const string skew_timing_check = "$skew_timing_check";
            public const string skew_timing_check_optional = "$skew_timing_check_optional";
            public const string timeskew_timing_check = "$timeskew_timing_check";
            public const string timeskew_timing_check_optional = "$timeskew_timing_check_optional";
            public const string timeskew_timing_check_optional_2 = "$timeskew_timing_check_optional_2";
            public const string timeskew_timing_check_optional_3 = "$timeskew_timing_check_optional_3";
            public const string fullskew_timing_check = "$fullskew_timing_check";
            public const string fullskew_timing_check_optional = "$fullskew_timing_check_optional";
            public const string fullskew_timing_check_optional_2 = "$fullskew_timing_check_optional_2";
            public const string fullskew_timing_check_optional_3 = "$fullskew_timing_check_optional_3";
            public const string period_timing_check = "$period_timing_check";
            public const string period_timing_check_optional = "$period_timing_check_optional";
            public const string width_timing_check = "$width_timing_check";
            public const string width_timing_check_optional = "$width_timing_check_optional";
            public const string width_timing_check_optional_2 = "$width_timing_check_optional_2";
            public const string nochange_timing_check = "$nochange_timing_check";
            public const string nochange_timing_check_optional = "$nochange_timing_check_optional";
            public const string checktime_condition = "checktime_condition";
            public const string controlled_reference_event = "controlled_reference_event";
            public const string data_event = "data_event";
            public const string delayed_data = "delayed_data";
            public const string delayed_reference = "delayed_reference";
            public const string end_edge_offset = "end_edge_offset";
            public const string event_based_flag = "event_based_flag";
            public const string notifier = "notifier";
            public const string reference_event = "reference_event";
            public const string remain_active_flag = "remain_active_flag";
            public const string stamptime_condition = "stamptime_condition";
            public const string start_edge_offset = "start_edge_offset";
            public const string threshold = "threshold";
            public const string timing_check_limit = "timing_check_limit";
            public const string timing_check_event = "timing_check_event";
            public const string timing_check_event_optional = "timing_check_event_optional";
            public const string controlled_timing_check_event = "controlled_timing_check_event";
            public const string controlled_timing_check_event_optional = "controlled_timing_check_event_optional";
            public const string timing_check_event_control = "timing_check_event_control";
            public const string specify_terminal_descriptor = "specify_terminal_descriptor";
            public const string edge_control_specifier = "edge_control_specifier";
            public const string edge_control_specifier_optional = "edge_control_specifier_optional";
            public const string edge_control_specifier_many = "edge_control_specifier_many";
            public const string edge_descriptor = "edge_descriptor";
            public const string zero_or_one = "zero_or_one";
            public const string z_or_x = "z_or_x";
            public const string timing_check_condition = "timing_check_condition";
            public const string scalar_timing_check_condition = "scalar_timing_check_condition";
            public const string scalar_constant = "scalar_constant";
            public const string analog_concatenation = "analog_concatenation";
            public const string analog_concatenation_many = "analog_concatenation_many";
            public const string analog_multiple_concatenation = "analog_multiple_concatenation";
            public const string analog_filter_function_arg = "analog_filter_function_arg";
            public const string concatenation = "concatenation";
            public const string concatenation_many = "concatenation_many";
            public const string constant_concatenation = "constant_concatenation";
            public const string constant_concatenation_many = "constant_concatenation_many";
            public const string constant_multiple_concatenation = "constant_multiple_concatenation";
            public const string module_path_concatenation = "module_path_concatenation";
            public const string module_path_concatenation_many = "module_path_concatenation_many";
            public const string module_path_multiple_concatenation = "module_path_multiple_concatenation";
            public const string multiple_concatenation = "multiple_concatenation";
            public const string assignment_pattern = "assignment_pattern";
            public const string assignment_pattern_many = "assignment_pattern_many";
            public const string assignment_pattern_many_2 = "assignment_pattern_many_2";
            public const string constant_assignment_pattern = "constant_assignment_pattern";
            public const string constant_assignment_pattern_many = "constant_assignment_pattern_many";
            public const string constant_assignment_pattern_many_2 = "constant_assignment_pattern_many_2";
            public const string constant_arrayinit = "constant_arrayinit";
            public const string constant_arrayinit_many = "constant_arrayinit_many";
            public const string constant_optional_arrayinit = "constant_optional_arrayinit";
            public const string constant_optional_arrayinit_many = "constant_optional_arrayinit_many";
            public const string analog_function_call = "analog_function_call";
            public const string analog_function_call_many = "analog_function_call_many";
            public const string analog_system_function_call = "analog_system_function_call";
            public const string analog_system_function_call_optional = "analog_system_function_call_optional";
            public const string analog_system_function_call_many = "analog_system_function_call_many";
            public const string analog_built_in_function_call = "analog_built_in_function_call";
            public const string analog_built_in_function_call_optional = "analog_built_in_function_call_optional";
            public const string analog_built_in_function_name = "analog_built_in_function_name";
            public const string analysis_function_call = "analysis_function_call";
            public const string analysis_function_call_many = "analysis_function_call_many";
            public const string analog_filter_function_call = "analog_filter_function_call";
            public const string analog_filter_function_call_optional = "analog_filter_function_call_optional";
            public const string analog_filter_function_call_optional_2 = "analog_filter_function_call_optional_2";
            public const string analog_filter_function_call_optional_3 = "analog_filter_function_call_optional_3";
            public const string analog_filter_function_call_optional_4 = "analog_filter_function_call_optional_4";
            public const string analog_filter_function_call_optional_5 = "analog_filter_function_call_optional_5";
            public const string analog_filter_function_call_optional_6 = "analog_filter_function_call_optional_6";
            public const string analog_filter_function_call_optional_7 = "analog_filter_function_call_optional_7";
            public const string analog_filter_function_call_optional_8 = "analog_filter_function_call_optional_8";
            public const string analog_filter_function_call_optional_9 = "analog_filter_function_call_optional_9";
            public const string analog_filter_function_call_optional_10 = "analog_filter_function_call_optional_10";
            public const string analog_filter_function_call_optional_11 = "analog_filter_function_call_optional_11";
            public const string analog_filter_function_call_optional_12 = "analog_filter_function_call_optional_12";
            public const string analog_filter_function_call_optional_13 = "analog_filter_function_call_optional_13";
            public const string analog_filter_function_call_optional_14 = "analog_filter_function_call_optional_14";
            public const string analog_filter_function_call_optional_15 = "analog_filter_function_call_optional_15";
            public const string analog_filter_function_call_optional_16 = "analog_filter_function_call_optional_16";
            public const string analog_filter_function_call_optional_17 = "analog_filter_function_call_optional_17";
            public const string analog_filter_function_call_optional_18 = "analog_filter_function_call_optional_18";
            public const string analog_filter_function_call_optional_19 = "analog_filter_function_call_optional_19";
            public const string analog_small_signal_function_call = "analog_small_signal_function_call";
            public const string analog_small_signal_function_call_optional = "analog_small_signal_function_call_optional";
            public const string analog_small_signal_function_call_optional_2 = "analog_small_signal_function_call_optional_2";
            public const string analog_small_signal_function_call_optional_3 = "analog_small_signal_function_call_optional_3";
            public const string analog_small_signal_function_call_optional_4 = "analog_small_signal_function_call_optional_4";
            public const string analog_small_signal_function_call_optional_5 = "analog_small_signal_function_call_optional_5";
            public const string analog_small_signal_function_call_optional_6 = "analog_small_signal_function_call_optional_6";
            public const string analog_small_signal_function_call_optional_7 = "analog_small_signal_function_call_optional_7";
            public const string noise_table_input_arg = "noise_table_input_arg";
            public const string noise_table_input_arg_optional = "noise_table_input_arg_optional";
            public const string laplace_filter_name = "laplace_filter_name";
            public const string zi_filter_name = "zi_filter_name";
            public const string nature_access_function = "nature_access_function";
            public const string branch_probe_function_call = "branch_probe_function_call";
            public const string branch_probe_function_call_optional = "branch_probe_function_call_optional";
            public const string port_probe_function_call = "port_probe_function_call";
            public const string constant_analog_function_call = "constant_analog_function_call";
            public const string constant_analog_function_call_many = "constant_analog_function_call_many";
            public const string constant_function_call = "constant_function_call";
            public const string constant_function_call_many = "constant_function_call_many";
            public const string constant_system_function_call = "constant_system_function_call";
            public const string constant_system_function_call_many = "constant_system_function_call_many";
            public const string constant_analog_built_in_function_call = "constant_analog_built_in_function_call";
            public const string constant_analog_built_in_function_call_optional = "constant_analog_built_in_function_call_optional";
            public const string function_call = "function_call";
            public const string function_call_many = "function_call_many";
            public const string system_function_call = "system_function_call";
            public const string system_function_call_optional = "system_function_call_optional";
            public const string system_function_call_many = "system_function_call_many";
            public const string analog_conditional_expression = "analog_conditional_expression";
            public const string analog_expression = "analog_expression";
            public const string analog_expression_10 = "analog_expression_10";
            public const string analog_expression_10_many = "analog_expression_10_many";
            public const string analog_expression_9 = "analog_expression_9";
            public const string analog_expression_9_many = "analog_expression_9_many";
            public const string analog_expression_8 = "analog_expression_8";
            public const string analog_expression_8_many = "analog_expression_8_many";
            public const string analog_expression_7 = "analog_expression_7";
            public const string analog_expression_7_many = "analog_expression_7_many";
            public const string analog_expression_6 = "analog_expression_6";
            public const string analog_expression_6_many = "analog_expression_6_many";
            public const string analog_expression_5 = "analog_expression_5";
            public const string analog_expression_5_many = "analog_expression_5_many";
            public const string analog_expression_4 = "analog_expression_4";
            public const string analog_expression_4_many = "analog_expression_4_many";
            public const string analog_expression_3 = "analog_expression_3";
            public const string analog_expression_3_many = "analog_expression_3_many";
            public const string analog_expression_2 = "analog_expression_2";
            public const string analog_expression_2_many = "analog_expression_2_many";
            public const string analog_expression_1 = "analog_expression_1";
            public const string analog_expression_1_many = "analog_expression_1_many";
            public const string analog_expression_0 = "analog_expression_0";
            public const string analog_expression_0_many = "analog_expression_0_many";
            public const string analog_expression_primary = "analog_expression_primary";
            public const string abstol_expression = "abstol_expression";
            public const string analog_range_expression = "analog_range_expression";
            public const string analog_expression_or_null = "analog_expression_or_null";
            public const string base_expression = "base_expression";
            public const string conditional_expression = "conditional_expression";
            public const string constant_base_expression = "constant_base_expression";
            public const string constant_expression_or_null = "constant_expression_or_null";
            public const string constant_expression = "constant_expression";
            public const string constant_conditional_expression = "constant_conditional_expression";
            public const string constant_expression_10 = "constant_expression_10";
            public const string constant_expression_10_many = "constant_expression_10_many";
            public const string constant_expression_9 = "constant_expression_9";
            public const string constant_expression_9_many = "constant_expression_9_many";
            public const string constant_expression_8 = "constant_expression_8";
            public const string constant_expression_8_many = "constant_expression_8_many";
            public const string constant_expression_7 = "constant_expression_7";
            public const string constant_expression_7_many = "constant_expression_7_many";
            public const string constant_expression_6 = "constant_expression_6";
            public const string constant_expression_6_many = "constant_expression_6_many";
            public const string constant_expression_5 = "constant_expression_5";
            public const string constant_expression_5_many = "constant_expression_5_many";
            public const string constant_expression_4 = "constant_expression_4";
            public const string constant_expression_4_many = "constant_expression_4_many";
            public const string constant_expression_3 = "constant_expression_3";
            public const string constant_expression_3_many = "constant_expression_3_many";
            public const string constant_expression_2 = "constant_expression_2";
            public const string constant_expression_2_many = "constant_expression_2_many";
            public const string constant_expression_1 = "constant_expression_1";
            public const string constant_expression_1_many = "constant_expression_1_many";
            public const string constant_expression_0 = "constant_expression_0";
            public const string constant_expression_0_many = "constant_expression_0_many";
            public const string constant_expression_primary = "constant_expression_primary";
            public const string analysis_or_constant_expression = "analysis_or_constant_expression";
            public const string analysis_or_constant_conditional_expression = "analysis_or_constant_conditional_expression";
            public const string analysis_or_constant_expression_10 = "analysis_or_constant_expression_10";
            public const string analysis_or_constant_expression_10_many = "analysis_or_constant_expression_10_many";
            public const string analysis_or_constant_expression_9 = "analysis_or_constant_expression_9";
            public const string analysis_or_constant_expression_9_many = "analysis_or_constant_expression_9_many";
            public const string analysis_or_constant_expression_8 = "analysis_or_constant_expression_8";
            public const string analysis_or_constant_expression_8_many = "analysis_or_constant_expression_8_many";
            public const string analysis_or_constant_expression_7 = "analysis_or_constant_expression_7";
            public const string analysis_or_constant_expression_7_many = "analysis_or_constant_expression_7_many";
            public const string analysis_or_constant_expression_6 = "analysis_or_constant_expression_6";
            public const string analysis_or_constant_expression_6_many = "analysis_or_constant_expression_6_many";
            public const string analysis_or_constant_expression_5 = "analysis_or_constant_expression_5";
            public const string analysis_or_constant_expression_5_many = "analysis_or_constant_expression_5_many";
            public const string analysis_or_constant_expression_4 = "analysis_or_constant_expression_4";
            public const string analysis_or_constant_expression_4_many = "analysis_or_constant_expression_4_many";
            public const string analysis_or_constant_expression_3 = "analysis_or_constant_expression_3";
            public const string analysis_or_constant_expression_3_many = "analysis_or_constant_expression_3_many";
            public const string analysis_or_constant_expression_2 = "analysis_or_constant_expression_2";
            public const string analysis_or_constant_expression_2_many = "analysis_or_constant_expression_2_many";
            public const string analysis_or_constant_expression_1 = "analysis_or_constant_expression_1";
            public const string analysis_or_constant_expression_1_many = "analysis_or_constant_expression_1_many";
            public const string analysis_or_constant_expression_0 = "analysis_or_constant_expression_0";
            public const string analysis_or_constant_expression_0_many = "analysis_or_constant_expression_0_many";
            public const string analysis_or_constant_expression_primary = "analysis_or_constant_expression_primary";
            public const string constant_mintypmax_expression = "constant_mintypmax_expression";
            public const string constant_range_expression = "constant_range_expression";
            public const string dimension_constant_expression = "dimension_constant_expression";
            public const string expression = "expression";
            public const string expression_10 = "expression_10";
            public const string expression_10_many = "expression_10_many";
            public const string expression_9 = "expression_9";
            public const string expression_9_many = "expression_9_many";
            public const string expression_8 = "expression_8";
            public const string expression_8_many = "expression_8_many";
            public const string expression_7 = "expression_7";
            public const string expression_7_many = "expression_7_many";
            public const string expression_6 = "expression_6";
            public const string expression_6_many = "expression_6_many";
            public const string expression_5 = "expression_5";
            public const string expression_5_many = "expression_5_many";
            public const string expression_4 = "expression_4";
            public const string expression_4_many = "expression_4_many";
            public const string expression_3 = "expression_3";
            public const string expression_3_many = "expression_3_many";
            public const string expression_2 = "expression_2";
            public const string expression_2_many = "expression_2_many";
            public const string expression_1 = "expression_1";
            public const string expression_1_many = "expression_1_many";
            public const string expression_0 = "expression_0";
            public const string expression_0_many = "expression_0_many";
            public const string expression_primary = "expression_primary";
            public const string expression1 = "expression1";
            public const string expression2 = "expression2";
            public const string expression3 = "expression3";
            public const string indirect_expression = "indirect_expression";
            public const string indirect_expression_optional = "indirect_expression_optional";
            public const string indirect_expression_optional_2 = "indirect_expression_optional_2";
            public const string indirect_expression_optional_3 = "indirect_expression_optional_3";
            public const string indirect_expression_optional_4 = "indirect_expression_optional_4";
            public const string indirect_expression_optional_5 = "indirect_expression_optional_5";
            public const string indirect_expression_optional_6 = "indirect_expression_optional_6";
            public const string indirect_expression_optional_7 = "indirect_expression_optional_7";
            public const string indirect_expression_optional_8 = "indirect_expression_optional_8";
            public const string indirect_expression_optional_9 = "indirect_expression_optional_9";
            public const string indirect_expression_optional_10 = "indirect_expression_optional_10";
            public const string indirect_expression_optional_11 = "indirect_expression_optional_11";
            public const string indirect_expression_optional_12 = "indirect_expression_optional_12";
            public const string indirect_expression_optional_13 = "indirect_expression_optional_13";
            public const string indirect_expression_optional_14 = "indirect_expression_optional_14";
            public const string indirect_expression_optional_15 = "indirect_expression_optional_15";
            public const string indirect_expression_optional_16 = "indirect_expression_optional_16";
            public const string lsb_constant_expression = "lsb_constant_expression";
            public const string mintypmax_expression = "mintypmax_expression";
            public const string module_path_conditional_expression = "module_path_conditional_expression";
            public const string module_path_expression = "module_path_expression";
            public const string module_path_mintypmax_expression = "module_path_mintypmax_expression";
            public const string msb_constant_expression = "msb_constant_expression";
            public const string nature_attribute_expression = "nature_attribute_expression";
            public const string range_expression = "range_expression";
            public const string width_constant_expression = "width_constant_expression";
            public const string analog_primary = "analog_primary";
            public const string constant_primary = "constant_primary";
            public const string constant_primary_optional = "constant_primary_optional";
            public const string constant_primary_optional_2 = "constant_primary_optional_2";
            public const string module_path_primary = "module_path_primary";
            public const string primary = "primary";
            public const string primary_h = "primary_h";
            public const string primary_h_optional = "primary_h_optional";
            public const string analog_variable_lvalue = "analog_variable_lvalue";
            public const string analog_variable_lvalue_many = "analog_variable_lvalue_many";
            public const string array_analog_variable_assignment = "array_analog_variable_assignment";
            public const string array_analog_variable_rvalue = "array_analog_variable_rvalue";
            public const string array_analog_variable_rvalue_many = "array_analog_variable_rvalue_many";
            public const string branch_lvalue = "branch_lvalue";
            public const string net_lvalue = "net_lvalue";
            public const string net_lvalue_optional = "net_lvalue_optional";
            public const string net_lvalue_many = "net_lvalue_many";
            public const string constant_expression_lazy = "constant_expression_lazy";
            public const string variable_lvalue = "variable_lvalue";
            public const string variable_lvalue_optional = "variable_lvalue_optional";
            public const string variable_lvalue_many = "variable_lvalue_many";
            public const string lazy_expressions = "lazy_expressions";
            public const string unary_operator = "unary_operator";
            public const string binary_operator = "binary_operator";
            public const string binary_operator_0 = "binary_operator_0";
            public const string binary_operator_1 = "binary_operator_1";
            public const string binary_operator_2 = "binary_operator_2";
            public const string binary_operator_3 = "binary_operator_3";
            public const string binary_operator_4 = "binary_operator_4";
            public const string binary_operator_5 = "binary_operator_5";
            public const string binary_operator_6 = "binary_operator_6";
            public const string binary_operator_7 = "binary_operator_7";
            public const string binary_operator_8 = "binary_operator_8";
            public const string binary_operator_9 = "binary_operator_9";
            public const string binary_operator_10 = "binary_operator_10";
            public const string unary_module_path_operator = "unary_module_path_operator";
            public const string binary_module_path_operator = "binary_module_path_operator";
            public const string number = "number";
            public const string real_number = "real_number";
            public const string real_number_optional = "real_number_optional";
            public const string real_number_optional_2 = "real_number_optional_2";
            public const string exp = "exp";
            public const string scale_factor = "scale_factor";
            public const string decimal_number = "decimal_number";
            public const string decimal_number_many = "decimal_number_many";
            public const string decimal_number_many_2 = "decimal_number_many_2";
            public const string binary_number = "binary_number";
            public const string octal_number = "octal_number";
            public const string hex_number = "hex_number";
            public const string sign = "sign";
            public const string size = "size";
            public const string unsigned_number = "unsigned_number";
            public const string binary_value = "binary_value";
            public const string octal_value = "octal_value";
            public const string hex_value = "hex_value";
            public const string decimal_base = "decimal_base";
            public const string binary_base = "binary_base";
            public const string octal_base = "octal_base";
            public const string hex_base = "hex_base";
            public const string @string = "string";
            public const string nature_attribute_reference = "nature_attribute_reference";
            public const string analog_port_reference = "analog_port_reference";
            public const string analog_net_reference = "analog_net_reference";
            public const string branch_reference = "branch_reference";
            public const string hierarchical_unnamed_branch_reference = "hierarchical_unnamed_branch_reference";
            public const string hierarchical_unnamed_branch_reference_optional = "hierarchical_unnamed_branch_reference_optional";
            public const string parameter_reference = "parameter_reference";
            public const string variable_reference = "variable_reference";
            public const string variable_reference_many = "variable_reference_many";
            public const string variable_reference_many_2 = "variable_reference_many_2";
            public const string net_reference = "net_reference";
            public const string attribute_instance = "attribute_instance";
            public const string attribute_instance_many = "attribute_instance_many";
            public const string attr_spec = "attr_spec";
            public const string attr_spec_optional = "attr_spec_optional";
            public const string attr_name = "attr_name";
            public const string ams_net_identifier = "ams_net_identifier";
            public const string analog_block_identifier = "analog_block_identifier";
            public const string analog_function_identifier = "analog_function_identifier";
            public const string analog_system_task_identifier = "analog_system_task_identifier";
            public const string analog_system_function_identifier = "analog_system_function_identifier";
            public const string analysis_identifier = "analysis_identifier";
            public const string block_identifier = "block_identifier";
            public const string branch_identifier = "branch_identifier";
            public const string cell_identifier = "cell_identifier";
            public const string config_identifier = "config_identifier";
            public const string connectmodule_identifier = "connectmodule_identifier";
            public const string connectrules_identifier = "connectrules_identifier";
            public const string discipline_identifier = "discipline_identifier";
            public const string escaped_identifier = "escaped_identifier";
            public const string event_identifier = "event_identifier";
            public const string function_identifier = "function_identifier";
            public const string gate_instance_identifier = "gate_instance_identifier";
            public const string generate_block_identifier = "generate_block_identifier";
            public const string genvar_identifier = "genvar_identifier";
            public const string hierarchical_block_identifier = "hierarchical_block_identifier";
            public const string hierarchical_branch_identifier = "hierarchical_branch_identifier";
            public const string hierarchical_event_identifier = "hierarchical_event_identifier";
            public const string hierarchical_function_identifier = "hierarchical_function_identifier";
            public const string hierarchical_identifier = "hierarchical_identifier";
            public const string hierarchical_identifier_optional = "hierarchical_identifier_optional";
            public const string hierarchical_identifier_lazy = "hierarchical_identifier_lazy";
            public const string hierarchical_identifier_lazy_optional = "hierarchical_identifier_lazy_optional";
            public const string hierarchical_inst_identifier = "hierarchical_inst_identifier";
            public const string hierarchical_net_identifier = "hierarchical_net_identifier";
            public const string hierarchical_parameter_identifier = "hierarchical_parameter_identifier";
            public const string hierarchical_port_identifier = "hierarchical_port_identifier";
            public const string hierarchical_variable_identifier = "hierarchical_variable_identifier";
            public const string hierarchical_task_identifier = "hierarchical_task_identifier";
            public const string identifier = "identifier";
            public const string inout_port_identifier = "inout_port_identifier";
            public const string input_port_identifier = "input_port_identifier";
            public const string instance_identifier = "instance_identifier";
            public const string library_identifier = "library_identifier";
            public const string module_identifier = "module_identifier";
            public const string module_instance_identifier = "module_instance_identifier";
            public const string module_or_paramset_identifier = "module_or_paramset_identifier";
            public const string module_output_variable_identifier = "module_output_variable_identifier";
            public const string module_parameter_identifier = "module_parameter_identifier";
            public const string nature_identifier = "nature_identifier";
            public const string nature_access_identifier = "nature_access_identifier";
            public const string nature_attribute_identifier = "nature_attribute_identifier";
            public const string net_identifier = "net_identifier";
            public const string output_port_identifier = "output_port_identifier";
            public const string parameter_identifier = "parameter_identifier";
            public const string paramset_identifier = "paramset_identifier";
            public const string port_identifier = "port_identifier";
            public const string real_identifier = "real_identifier";
            public const string simple_identifier = "simple_identifier";
            public const string specparam_identifier = "specparam_identifier";
            public const string system_function_identifier = "system_function_identifier";
            public const string system_parameter_identifier = "system_parameter_identifier";
            public const string system_task_identifier = "system_task_identifier";
            public const string task_identifier = "task_identifier";
            public const string terminal_identifier = "terminal_identifier";
            public const string text_macro_identifier = "text_macro_identifier";
            public const string topmodule_identifier = "topmodule_identifier";
            public const string udp_identifier = "udp_identifier";
            public const string udp_instance_identifier = "udp_instance_identifier";
            public const string variable_identifier = "variable_identifier";
            public const string analog_event_expression_prim = "analog_event_expression_prim";
            public const string analog_expression_prim = "analog_expression_prim";
            public const string analysis_or_constant_expression_prim = "analysis_or_constant_expression_prim";
            public const string constant_expression_prim = "constant_expression_prim";
            public const string event_expression_prim = "event_expression_prim";
            public const string expression1_prim = "expression1_prim";
            public const string genvar_expression_prim = "genvar_expression_prim";
            public const string module_path_expression_prim = "module_path_expression_prim";
            public const string paramset_constant_expression_prim = "paramset_constant_expression_prim";
            public const string analog_block_item_declaration_prefix = "analog_block_item_declaration_prefix";
            public const string analog_block_item_declaration_rest = "analog_block_item_declaration_rest";
            public const string analog_construct_prefix = "analog_construct_prefix";
            public const string analog_construct_rest = "analog_construct_rest";
            public const string analog_event_control_prefix = "analog_event_control_prefix";
            public const string analog_event_control_rest = "analog_event_control_rest";
            public const string analog_event_statement_prefix = "analog_event_statement_prefix";
            public const string analog_event_statement_rest = "analog_event_statement_rest";
            public const string analog_function_statement_prefix = "analog_function_statement_prefix";
            public const string analog_function_statement_rest = "analog_function_statement_rest";
            public const string analog_statement_prefix = "analog_statement_prefix";
            public const string analog_statement_rest = "analog_statement_rest";
            public const string analog_variable_lvalue_prefix = "analog_variable_lvalue_prefix";
            public const string analog_variable_lvalue_rest = "analog_variable_lvalue_rest";
            public const string assignment_pattern_prefix = "assignment_pattern_prefix";
            public const string assignment_pattern_rest = "assignment_pattern_rest";
            public const string block_item_declaration_prefix = "block_item_declaration_prefix";
            public const string block_item_declaration_rest = "block_item_declaration_rest";
            public const string branch_probe_function_call_prefix = "branch_probe_function_call_prefix";
            public const string branch_probe_function_call_rest = "branch_probe_function_call_rest";
            public const string charge_strength_prefix = "charge_strength_prefix";
            public const string charge_strength_rest = "charge_strength_rest";
            public const string constant_assignment_pattern_prefix = "constant_assignment_pattern_prefix";
            public const string constant_assignment_pattern_rest = "constant_assignment_pattern_rest";
            public const string constant_mintypmax_expression_prefix = "constant_mintypmax_expression_prefix";
            public const string constant_mintypmax_expression_rest = "constant_mintypmax_expression_rest";
            public const string delay_control_prefix = "delay_control_prefix";
            public const string delay_control_rest = "delay_control_rest";
            public const string delay2_prefix = "delay2_prefix";
            public const string delay2_rest = "delay2_rest";
            public const string delay3_prefix = "delay3_prefix";
            public const string delay3_rest = "delay3_rest";
            public const string delayed_data_prefix = "delayed_data_prefix";
            public const string delayed_data_rest = "delayed_data_rest";
            public const string delayed_reference_prefix = "delayed_reference_prefix";
            public const string delayed_reference_rest = "delayed_reference_rest";
            public const string disable_statement_prefix = "disable_statement_prefix";
            public const string disable_statement_rest = "disable_statement_rest";
            public const string drive_strength_prefix = "drive_strength_prefix";
            public const string drive_strength_rest = "drive_strength_rest";
            public const string function_declaration_prefix = "function_declaration_prefix";
            public const string function_declaration_rest = "function_declaration_rest";
            public const string hierarchical_unnamed_branch_reference_prefix = "hierarchical_unnamed_branch_reference_prefix";
            public const string hierarchical_unnamed_branch_reference_rest = "hierarchical_unnamed_branch_reference_rest";
            public const string list_of_port_declarations_prefix = "list_of_port_declarations_prefix";
            public const string list_of_port_declarations_rest = "list_of_port_declarations_rest";
            public const string local_parameter_declaration_prefix = "local_parameter_declaration_prefix";
            public const string local_parameter_declaration_rest = "local_parameter_declaration_rest";
            public const string mintypmax_expression_prefix = "mintypmax_expression_prefix";
            public const string mintypmax_expression_rest = "mintypmax_expression_rest";
            public const string module_declaration_prefix = "module_declaration_prefix";
            public const string module_declaration_rest = "module_declaration_rest";
            public const string module_or_generate_item_prefix = "module_or_generate_item_prefix";
            public const string module_or_generate_item_rest = "module_or_generate_item_rest";
            public const string named_parameter_assignment_prefix = "named_parameter_assignment_prefix";
            public const string named_parameter_assignment_rest = "named_parameter_assignment_rest";
            public const string output_declaration_prefix = "output_declaration_prefix";
            public const string output_declaration_rest = "output_declaration_rest";
            public const string param_assignment_prefix = "param_assignment_prefix";
            public const string param_assignment_rest = "param_assignment_rest";
            public const string parameter_declaration_prefix = "parameter_declaration_prefix";
            public const string parameter_declaration_rest = "parameter_declaration_rest";
            public const string parameter_reference_prefix = "parameter_reference_prefix";
            public const string parameter_reference_rest = "parameter_reference_rest";
            public const string parameter_value_assignment_prefix = "parameter_value_assignment_prefix";
            public const string parameter_value_assignment_rest = "parameter_value_assignment_rest";
            public const string port_branch_declaration_prefix = "port_branch_declaration_prefix";
            public const string port_branch_declaration_rest = "port_branch_declaration_rest";
            public const string port_declaration_prefix = "port_declaration_prefix";
            public const string port_declaration_rest = "port_declaration_rest";
            public const string pulldown_strength_prefix = "pulldown_strength_prefix";
            public const string pulldown_strength_rest = "pulldown_strength_rest";
            public const string pullup_strength_prefix = "pullup_strength_prefix";
            public const string pullup_strength_rest = "pullup_strength_rest";
            public const string pulse_control_specparam_prefix = "pulse_control_specparam_prefix";
            public const string pulse_control_specparam_rest = "pulse_control_specparam_rest";
            public const string real_number_prefix = "real_number_prefix";
            public const string real_number_rest = "real_number_rest";
            public const string real_type_prefix = "real_type_prefix";
            public const string real_type_rest = "real_type_rest";
            public const string scalar_analog_variable_lvalue_prefix = "scalar_analog_variable_lvalue_prefix";
            public const string scalar_analog_variable_lvalue_rest = "scalar_analog_variable_lvalue_rest";
            public const string statement_prefix = "statement_prefix";
            public const string statement_rest = "statement_rest";
            public const string task_declaration_prefix = "task_declaration_prefix";
            public const string task_declaration_rest = "task_declaration_rest";
            public const string task_port_item_prefix = "task_port_item_prefix";
            public const string task_port_item_rest = "task_port_item_rest";
            public const string tf_inout_declaration_prefix = "tf_inout_declaration_prefix";
            public const string tf_inout_declaration_rest = "tf_inout_declaration_rest";
            public const string tf_input_declaration_prefix = "tf_input_declaration_prefix";
            public const string tf_input_declaration_rest = "tf_input_declaration_rest";
            public const string tf_output_declaration_prefix = "tf_output_declaration_prefix";
            public const string tf_output_declaration_rest = "tf_output_declaration_rest";
            public const string udp_declaration_prefix = "udp_declaration_prefix";
            public const string udp_declaration_rest = "udp_declaration_rest";
            public const string udp_output_declaration_prefix = "udp_output_declaration_prefix";
            public const string udp_output_declaration_rest = "udp_output_declaration_rest";
            public const string variable_type_prefix = "variable_type_prefix";
            public const string variable_type_rest = "variable_type_rest";

        }

    }
}