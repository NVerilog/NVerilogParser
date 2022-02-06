using CFGToolkit.AST;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Generic;

namespace NVerilogParser
{
    public partial class Parsers
    {
        public static Lazy<IParser<CharToken, SyntaxNode>> source_text =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("source_text", (args) => CreateSyntaxNode(true, true, nameof(source_text), args), new Lazy<IParser<CharToken>>(() => description.Value.Many(greedy: true))).Token());

        public static Lazy<IParser<CharToken, SyntaxNode>> description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("description", Parser.Sequence<CharToken, SyntaxNode>("description#0", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => module_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#1", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => udp_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#2", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => config_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#3", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => paramset_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#4", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => nature_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#5", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => discipline_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("description#6", (args) => CreateSyntaxNode(false, true, nameof(description), args), new Lazy<IParser<CharToken>>(() => connectrules_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_declaration", Parser.Sequence<CharToken, SyntaxNode>("module_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(module_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_keyword.Value), new Lazy<IParser<CharToken>>(() => module_identifier.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_ports.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => module_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2897933668_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(module_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_keyword.Value), new Lazy<IParser<CharToken>>(() => module_identifier.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_declarations.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2897933668_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_keyword =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_keyword", Parser.Sequence<CharToken, SyntaxNode>("module_keyword#0", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_2245455489_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_keyword#1", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_1604288512_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_keyword#2", (args) => CreateSyntaxNode(false, true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => _keyword_2756096282_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_port_list", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_port_list), args), new Lazy<IParser<CharToken>>(() => _keyword_4125440978_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => module_parameter_port_list_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_ports", (args) => CreateSyntaxNode(false, true, nameof(list_of_ports), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port.Value), new Lazy<IParser<CharToken>>(() => list_of_ports_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_ports_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_ports_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => port.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_port_declarations", Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port_declaration.Value), new Lazy<IParser<CharToken>>(() => list_of_port_declarations_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_declarations_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => port_declaration.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port", Parser.Sequence<CharToken, SyntaxNode>("port#0", (args) => CreateSyntaxNode(false, true, nameof(port), args), new Lazy<IParser<CharToken>>(() => port_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("port#1", (args) => CreateSyntaxNode(false, true, nameof(port), args), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_expression", (args) => CreateSyntaxNode(false, true, nameof(port_expression), args), new Lazy<IParser<CharToken>>(() => port_reference.Value), new Lazy<IParser<CharToken>>(() => port_expression_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_expression_many", (args) => CreateSyntaxNode(false, true, nameof(port_expression_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => port_reference.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_reference", (args) => CreateSyntaxNode(false, true, nameof(port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => port_reference_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_reference_optional", (args) => CreateSyntaxNode(false, true, nameof(port_reference_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port_declaration", Parser.Sequence<CharToken, SyntaxNode>("port_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => inout_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("port_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => input_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("port_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => output_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_item", Parser.Sequence<CharToken, SyntaxNode>("module_item#0", (args) => CreateSyntaxNode(false, true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => port_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_item#1", (args) => CreateSyntaxNode(false, true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_or_generate_item", Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_or_generate_item_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#2", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_override.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#3", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => continuous_assign.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#4", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => gate_instantiation.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#5", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => udp_instantiation.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#6", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_instantiation.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#7", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => initial_construct.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#8", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => always_construct.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#9", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => loop_generate_construct.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#10", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => conditional_generate_construct.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item#11", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_construct.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_or_generate_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => net_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => reg_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => real_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => time_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#5", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => realtime_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#6", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => event_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#7", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => genvar_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#8", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => task_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#9", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => function_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#10", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => branch_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#11", (args) => CreateSyntaxNode(false, true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_function_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_port_module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("non_port_module_item", Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#0", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#1", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => generate_region.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#2", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => specify_block.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#3", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#4", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("non_port_module_item#5", (args) => CreateSyntaxNode(false, true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_override", (args) => CreateSyntaxNode(false, true, nameof(parameter_override), args), new Lazy<IParser<CharToken>>(() => _keyword_2027232758_True.Value), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("config_declaration", (args) => CreateSyntaxNode(false, true, nameof(config_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2876807419_True.Value), new Lazy<IParser<CharToken>>(() => config_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => design_statement.Value), new Lazy<IParser<CharToken>>(() => config_rule_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_923015071_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement", (args) => CreateSyntaxNode(false, true, nameof(design_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2323362373_True.Value), new Lazy<IParser<CharToken>>(() => design_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement_many", (args) => CreateSyntaxNode(false, true, nameof(design_statement_many), args), new Lazy<IParser<CharToken>>(() => design_statement_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("design_statement_optional", (args) => CreateSyntaxNode(false, true, nameof(design_statement_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_rule_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("config_rule_statement", Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#0", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => default_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#1", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#2", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value), new Lazy<IParser<CharToken>>(() => use_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#3", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value), new Lazy<IParser<CharToken>>(() => liblist_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("config_rule_statement#4", (args) => CreateSyntaxNode(false, true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value), new Lazy<IParser<CharToken>>(() => use_clause.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> default_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("default_clause", (args) => CreateSyntaxNode(false, true, nameof(default_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_2376211287_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_clause", (args) => CreateSyntaxNode(false, true, nameof(inst_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_176835622_True.Value), new Lazy<IParser<CharToken>>(() => inst_name.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_name", (args) => CreateSyntaxNode(false, true, nameof(inst_name), args), new Lazy<IParser<CharToken>>(() => topmodule_identifier.Value), new Lazy<IParser<CharToken>>(() => inst_name_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inst_name_many", (args) => CreateSyntaxNode(false, true, nameof(inst_name_many), args), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => instance_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_clause", (args) => CreateSyntaxNode(false, true, nameof(cell_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_4169065027_True.Value), new Lazy<IParser<CharToken>>(() => cell_clause_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_clause_optional", (args) => CreateSyntaxNode(false, true, nameof(cell_clause_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> liblist_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("liblist_clause", (args) => CreateSyntaxNode(false, true, nameof(liblist_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_2202799827_True.Value), new Lazy<IParser<CharToken>>(() => library_identifier.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_clause", (args) => CreateSyntaxNode(false, true, nameof(use_clause), args), new Lazy<IParser<CharToken>>(() => _keyword_1753121903_True.Value), new Lazy<IParser<CharToken>>(() => use_clause_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cell_identifier.Value), new Lazy<IParser<CharToken>>(() => use_config.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_clause_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_clause_optional", (args) => CreateSyntaxNode(false, true, nameof(use_clause_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_config =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("use_config", (args) => CreateSyntaxNode(false, true, nameof(use_config), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_2876807419_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1236812367_True.Value), new Lazy<IParser<CharToken>>(() => nature_identifier.Value), new Lazy<IParser<CharToken>>(() => nature_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => nature_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => nature_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2361480391_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => parent_nature.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(nature_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parent_nature =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parent_nature", Parser.Sequence<CharToken, SyntaxNode>("parent_nature#0", (args) => CreateSyntaxNode(false, true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parent_nature#1", (args) => CreateSyntaxNode(false, true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_item", (args) => CreateSyntaxNode(false, true, nameof(nature_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => nature_attribute_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_declaration", (args) => CreateSyntaxNode(false, true, nameof(discipline_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1665704165_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => discipline_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => discipline_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2297153116_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(discipline_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discipline_item", Parser.Sequence<CharToken, SyntaxNode>("discipline_item#0", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_binding.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_item#1", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => discipline_domain_binding.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_item#2", (args) => CreateSyntaxNode(false, true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute_override.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_binding", (args) => CreateSyntaxNode(false, true, nameof(nature_binding), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => nature_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> potential_or_flow =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("potential_or_flow", Parser.Sequence<CharToken, SyntaxNode>("potential_or_flow#0", (args) => CreateSyntaxNode(false, true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => _keyword_1226409641_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("potential_or_flow#1", (args) => CreateSyntaxNode(false, true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => _keyword_2981697799_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_domain_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_domain_binding", (args) => CreateSyntaxNode(false, true, nameof(discipline_domain_binding), args), new Lazy<IParser<CharToken>>(() => _keyword_1583021792_True.Value), new Lazy<IParser<CharToken>>(() => discrete_or_continuous.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discrete_or_continuous =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discrete_or_continuous", Parser.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#0", (args) => CreateSyntaxNode(false, true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => _keyword_92496478_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#1", (args) => CreateSyntaxNode(false, true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => _keyword_2493040520_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_override", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_override), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => nature_attribute.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectrules_declaration", (args) => CreateSyntaxNode(false, true, nameof(connectrules_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2095749790_True.Value), new Lazy<IParser<CharToken>>(() => connectrules_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => connectrules_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2013220074_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connectrules_item", Parser.Sequence<CharToken, SyntaxNode>("connectrules_item#0", (args) => CreateSyntaxNode(false, true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_insertion.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("connectrules_item#1", (args) => CreateSyntaxNode(false, true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_resolution.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_insertion =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_insertion", (args) => CreateSyntaxNode(false, true, nameof(connect_insertion), args), new Lazy<IParser<CharToken>>(() => _keyword_467549850_True.Value), new Lazy<IParser<CharToken>>(() => connectmodule_identifier.Value), new Lazy<IParser<CharToken>>(() => connect_mode.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => connect_port_overrides.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_mode =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connect_mode", Parser.Sequence<CharToken, SyntaxNode>("connect_mode#0", (args) => CreateSyntaxNode(false, true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => _keyword_2611634036_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("connect_mode#1", (args) => CreateSyntaxNode(false, true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => _keyword_2022167860_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_port_overrides =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("connect_port_overrides", Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#0", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#1", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#2", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("connect_port_overrides#3", (args) => CreateSyntaxNode(false, true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => _keyword_3265484267_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3265484267_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_resolution", (args) => CreateSyntaxNode(false, true, nameof(connect_resolution), args), new Lazy<IParser<CharToken>>(() => _keyword_467549850_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => connect_resolution_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1292097932_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier_or_exclude.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connect_resolution_many", (args) => CreateSyntaxNode(false, true, nameof(connect_resolution_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier_or_exclude =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("discipline_identifier_or_exclude", Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#0", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#1", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => _keyword_2410607647_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_declaration", (args) => CreateSyntaxNode(false, true, nameof(paramset_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_838051505_True.Value), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_statement.Value), new Lazy<IParser<CharToken>>(() => paramset_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_596789015_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => real_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_statement", (args) => CreateSyntaxNode(false, true, nameof(paramset_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => module_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_constant_expression", Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("local_parameter_declaration", Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2841273682_True.Value), new Lazy<IParser<CharToken>>(() => local_parameter_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2841273682_True.Value), new Lazy<IParser<CharToken>>(() => parameter_type.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(local_parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_declaration", Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_325026961_True.Value), new Lazy<IParser<CharToken>>(() => parameter_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_325026961_True.Value), new Lazy<IParser<CharToken>>(() => parameter_type.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specparam_declaration", (args) => CreateSyntaxNode(false, true, nameof(specparam_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2772951146_True.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_type", Parser.Sequence<CharToken, SyntaxNode>("parameter_type#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1579686364_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#2", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#3", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_type#4", (args) => CreateSyntaxNode(false, true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1622526449_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> aliasparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("aliasparam_declaration", (args) => CreateSyntaxNode(false, true, nameof(aliasparam_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1962817519_True.Value), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_declaration", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3265484267_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => inout_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => inout_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("inout_declaration_optional", Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3525870581_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_declaration", (args) => CreateSyntaxNode(false, true, nameof(input_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => input_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => input_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("input_declaration_optional", Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3525870581_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_declaration", Parser.Sequence<CharToken, SyntaxNode>("output_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => output_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => output_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value), new Lazy<IParser<CharToken>>(() => output_declaration_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => output_variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_declaration_optional", Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional#0", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional#1", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3525870581_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_declaration_optional_3", (args) => CreateSyntaxNode(false, true, nameof(output_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_declaration", Parser.Sequence<CharToken, SyntaxNode>("branch_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_4211402917_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value), new Lazy<IParser<CharToken>>(() => branch_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => port_branch_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(branch_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("port_branch_declaration", Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_4211402917_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("port_branch_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(port_branch_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_4211402917_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_terminal", Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#0", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#1", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#2", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#3", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#4", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_terminal#5", (args) => CreateSyntaxNode(false, true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_declaration", (args) => CreateSyntaxNode(false, true, nameof(event_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3873115350_True.Value), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> integer_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("integer_declaration", (args) => CreateSyntaxNode(false, true, nameof(integer_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration", Parser.Sequence<CharToken, SyntaxNode>("net_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_156611110_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_7.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#5", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_156611110_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_8.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#6", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_156611110_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_9.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_10.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#7", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_156611110_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_11.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => net_declaration_optional_12.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#8", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#9", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#10", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3525870581_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#11", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3525870581_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration#12", (args) => CreateSyntaxNode(false, true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3380179321_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_3", Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_2939226663_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_1376360468_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_4", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_5", Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_2939226663_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_1376360468_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_6", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_7", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_8", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_9", Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_2939226663_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_1376360468_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_10", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_declaration_optional_11", Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#0", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_2939226663_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#1", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_1376360468_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_declaration_optional_12", (args) => CreateSyntaxNode(false, true, nameof(net_declaration_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_declaration", (args) => CreateSyntaxNode(false, true, nameof(real_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> realtime_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("realtime_declaration", (args) => CreateSyntaxNode(false, true, nameof(realtime_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1579686364_True.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reg_declaration", (args) => CreateSyntaxNode(false, true, nameof(reg_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => reg_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reg_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(reg_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> time_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("time_declaration", (args) => CreateSyntaxNode(false, true, nameof(time_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_type", Parser.Sequence<CharToken, SyntaxNode>("net_type#0", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1050326929_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#1", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4138178808_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#2", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1855085678_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#3", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1329918423_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#4", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4007132734_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#5", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3406387942_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#6", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1682082968_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#7", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1411434385_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#8", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_2953276485_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#9", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_21733340_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_type#10", (args) => CreateSyntaxNode(false, true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1525937688_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("output_variable_type", Parser.Sequence<CharToken, SyntaxNode>("output_variable_type#0", (args) => CreateSyntaxNode(false, true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_variable_type#1", (args) => CreateSyntaxNode(false, true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("real_type", Parser.Sequence<CharToken, SyntaxNode>("real_type#0", (args) => CreateSyntaxNode(false, true, nameof(real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("real_type#1", (args) => CreateSyntaxNode(false, true, nameof(real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => real_type_optional.Value.Optional(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_type_optional", (args) => CreateSyntaxNode(false, true, nameof(real_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_type", Parser.Sequence<CharToken, SyntaxNode>("variable_type#0", (args) => CreateSyntaxNode(false, true, nameof(variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("variable_type#1", (args) => CreateSyntaxNode(false, true, nameof(variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => variable_type_optional.Value.Optional(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_type_optional", (args) => CreateSyntaxNode(false, true, nameof(variable_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> drive_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("drive_strength", Parser.Sequence<CharToken, SyntaxNode>("drive_strength#0", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength#1", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength#2", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_555958830_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength#3", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3929886150_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength#4", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3929886150_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("drive_strength#5", (args) => CreateSyntaxNode(false, true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_555958830_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("strength0", Parser.Sequence<CharToken, SyntaxNode>("strength0#0", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_1050326929_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#1", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_3024379416_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#2", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_2243030978_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength0#3", (args) => CreateSyntaxNode(false, true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => _keyword_1701182130_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("strength1", Parser.Sequence<CharToken, SyntaxNode>("strength1#0", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_4138178808_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#1", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_946377925_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#2", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_505091316_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("strength1#3", (args) => CreateSyntaxNode(false, true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => _keyword_2828316346_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> charge_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("charge_strength", Parser.Sequence<CharToken, SyntaxNode>("charge_strength#0", (args) => CreateSyntaxNode(false, true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_4262166542_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("charge_strength#1", (args) => CreateSyntaxNode(false, true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_63936939_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("charge_strength#2", (args) => CreateSyntaxNode(false, true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_4073852739_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay3", Parser.Sequence<CharToken, SyntaxNode>("delay3#0", (args) => CreateSyntaxNode(false, false, nameof(delay3), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => delay_value.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay3#1", (args) => CreateSyntaxNode(false, false, nameof(delay3), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => _keyword_2334665092_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay3_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1278134773_False.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3_optional", (args) => CreateSyntaxNode(false, false, nameof(delay3_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_825355425_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay3_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay3_optional_2", (args) => CreateSyntaxNode(false, false, nameof(delay3_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_825355425_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay2", Parser.Sequence<CharToken, SyntaxNode>("delay2#0", (args) => CreateSyntaxNode(false, false, nameof(delay2), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => delay_value.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay2#1", (args) => CreateSyntaxNode(false, false, nameof(delay2), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => _keyword_2334665092_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => delay2_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1278134773_False.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("delay2_optional", (args) => CreateSyntaxNode(false, false, nameof(delay2_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_825355425_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_value", Parser.Sequence<CharToken, SyntaxNode>("delay_value#0", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay_value#1", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => real_number.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay_value#2", (args) => CreateSyntaxNode(false, true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_branch_identifiers), args), new Lazy<IParser<CharToken>>(() => branch_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_branch_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => branch_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_defparam_assignments), args), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_defparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_event_identifiers), args), new Lazy<IParser<CharToken>>(() => event_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_event_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => event_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_decl_assignments), args), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_decl_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_identifiers), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_param_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_param_assignments), args), new Lazy<IParser<CharToken>>(() => param_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_param_assignments_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_param_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_param_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => param_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_real_identifiers), args), new Lazy<IParser<CharToken>>(() => real_type.Value), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => real_type.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_specparam_assignments), args), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_specparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => variable_type.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_variable_port_identifiers_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> defparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("defparam_assignment", (args) => CreateSyntaxNode(false, true, nameof(defparam_assignment), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_decl_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_decl_assignment", (args) => CreateSyntaxNode(false, true, nameof(net_decl_assignment), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> param_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("param_assignment", Parser.Sequence<CharToken, SyntaxNode>("param_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(param_assignment), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("param_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(param_assignment), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specparam_assignment", Parser.Sequence<CharToken, SyntaxNode>("specparam_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specparam_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => pulse_control_specparam.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("pulse_control_specparam", Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam#0", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam), args), new Lazy<IParser<CharToken>>(() => _keyword_2477967257_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam#1", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam), args), new Lazy<IParser<CharToken>>(() => _keyword_2477967257_True.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_3385534110_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => error_limit_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional_2", (args) => CreateSyntaxNode(false, true, nameof(pulse_control_specparam_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => error_limit_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> error_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("error_limit_value", (args) => CreateSyntaxNode(false, true, nameof(error_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> reject_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reject_limit_value", (args) => CreateSyntaxNode(false, true, nameof(reject_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("limit_value", (args) => CreateSyntaxNode(false, true, nameof(limit_value), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("dimension", (args) => CreateSyntaxNode(false, true, nameof(dimension), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("range", (args) => CreateSyntaxNode(false, true, nameof(range), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range", Parser.Sequence<CharToken, SyntaxNode>("value_range#0", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#1", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#2", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#3", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => value_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#4", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value), new Lazy<IParser<CharToken>>(() => value_range_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range#5", (args) => CreateSyntaxNode(false, true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => _keyword_2410607647_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("value_range_many", (args) => CreateSyntaxNode(false, true, nameof(value_range_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range_type", Parser.Sequence<CharToken, SyntaxNode>("value_range_type#0", (args) => CreateSyntaxNode(false, true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => _keyword_2159469382_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_type#1", (args) => CreateSyntaxNode(false, true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => _keyword_2410607647_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("value_range_expression", Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_1458171649_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_436272535_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("value_range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_declaration", (args) => CreateSyntaxNode(false, true, nameof(analog_function_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_552732405_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_864928946_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_4243255454_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_type", Parser.Sequence<CharToken, SyntaxNode>("analog_function_type#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_type#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => inout_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_declaration", Parser.Sequence<CharToken, SyntaxNode>("function_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(function_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_864928946_True.Value), new Lazy<IParser<CharToken>>(() => function_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_4243255454_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("function_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(function_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_864928946_True.Value), new Lazy<IParser<CharToken>>(() => function_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => function_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => function_statement.Value), new Lazy<IParser<CharToken>>(() => _keyword_4243255454_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3581235388_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(function_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3581235388_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("function_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("function_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_port_list", (args) => CreateSyntaxNode(false, true, nameof(function_port_list), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => function_port_list_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(function_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("function_range_or_type", Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#0", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => function_range_or_type_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#1", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#2", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#3", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1579686364_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type#4", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_range_or_type_optional", (args) => CreateSyntaxNode(false, true, nameof(function_range_or_type_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_declaration", Parser.Sequence<CharToken, SyntaxNode>("task_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(task_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1896238475_True.Value), new Lazy<IParser<CharToken>>(() => task_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => task_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => _keyword_2293046360_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(task_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1896238475_True.Value), new Lazy<IParser<CharToken>>(() => task_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => task_port_list.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => _keyword_2293046360_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3581235388_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(task_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3581235388_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_list", (args) => CreateSyntaxNode(false, true, nameof(task_port_list), args), new Lazy<IParser<CharToken>>(() => task_port_item.Value), new Lazy<IParser<CharToken>>(() => task_port_list_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(task_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => task_port_item.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_port_item", Parser.Sequence<CharToken, SyntaxNode>("task_port_item#0", (args) => CreateSyntaxNode(false, true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_item#1", (args) => CreateSyntaxNode(false, true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_item#2", (args) => CreateSyntaxNode(false, true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_input_declaration", Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_output_declaration", Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("tf_inout_declaration", Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3265484267_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3265484267_True.Value), new Lazy<IParser<CharToken>>(() => task_port_type.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional_2", (args) => CreateSyntaxNode(false, true, nameof(tf_inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("task_port_type", Parser.Sequence<CharToken, SyntaxNode>("task_port_type#0", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#1", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_1579686364_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#2", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("task_port_type#3", (args) => CreateSyntaxNode(false, true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_block_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => integer_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => real_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("block_item_declaration", Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => block_item_declaration_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3350338320_True.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4156358108_True.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#3", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_4075039361_True.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#4", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1579686364_True.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#5", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => event_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#6", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration#7", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_item_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(block_item_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_821833129_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => block_variable_type.Value), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => block_variable_type.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_real_identifiers), args), new Lazy<IParser<CharToken>>(() => block_real_type.Value), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_block_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => block_real_type.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_variable_type", (args) => CreateSyntaxNode(false, true, nameof(block_variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_real_type", (args) => CreateSyntaxNode(false, true, nameof(block_real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("gate_instantiation", Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#0", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => cmos_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#1", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => enable_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#2", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => mos_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_3.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#3", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_input_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_4.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#4", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_output_gatetype.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_5.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#5", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_en_switchtype.Value), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_6.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#6", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_switchtype.Value), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_7.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#7", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => _keyword_120121795_True.Value), new Lazy<IParser<CharToken>>(() => pulldown_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_8.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation#8", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => _keyword_1462721993_True.Value), new Lazy<IParser<CharToken>>(() => pullup_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_9.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_2", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_3", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_4", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_5", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_6", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_6), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_7", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_8", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_8), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_9", (args) => CreateSyntaxNode(false, true, nameof(gate_instantiation_many_9), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cmos_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(cmos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => ncontrol_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => pcontrol_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("enable_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(enable_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("mos_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(mos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_input_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(n_input_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => n_input_gate_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_input_gate_instance_many", (args) => CreateSyntaxNode(false, true, nameof(n_input_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_output_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(n_output_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => n_output_gate_instance_many.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("n_output_gate_instance_many", (args) => CreateSyntaxNode(false, true, nameof(n_output_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pass_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(pass_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_enable_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pass_enable_switch_instance", (args) => CreateSyntaxNode(false, true, nameof(pass_enable_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => inout_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => enable_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> pull_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pull_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(pull_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_gate_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_gate_instance), args), new Lazy<IParser<CharToken>>(() => gate_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulldown_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pulldown_strength", Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength#0", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength#1", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pulldown_strength#2", (args) => CreateSyntaxNode(false, true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pullup_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pullup_strength", Parser.Sequence<CharToken, SyntaxNode>("pullup_strength#0", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pullup_strength#1", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => strength0.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pullup_strength#2", (args) => CreateSyntaxNode(false, true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => strength1.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("enable_terminal", (args) => CreateSyntaxNode(false, true, nameof(enable_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_terminal", (args) => CreateSyntaxNode(false, true, nameof(inout_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_terminal", (args) => CreateSyntaxNode(false, true, nameof(input_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> ncontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ncontrol_terminal", (args) => CreateSyntaxNode(false, true, nameof(ncontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_terminal", (args) => CreateSyntaxNode(false, true, nameof(output_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> pcontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("pcontrol_terminal", (args) => CreateSyntaxNode(false, true, nameof(pcontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("cmos_switchtype", Parser.Sequence<CharToken, SyntaxNode>("cmos_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_3531683679_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("cmos_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_157721049_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("enable_gatetype", Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_759950902_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2878985343_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#2", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2582813136_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("enable_gatetype#3", (args) => CreateSyntaxNode(false, true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_3398281119_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("mos_switchtype", Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_1611652091_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_2100841696_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#2", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_3025743086_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("mos_switchtype#3", (args) => CreateSyntaxNode(false, true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_573963708_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("n_input_gatetype", Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2889127852_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_3832443294_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#2", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_1955606722_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#3", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2456964475_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#4", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_497270797_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_input_gatetype#5", (args) => CreateSyntaxNode(false, true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_3950774444_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("n_output_gatetype", Parser.Sequence<CharToken, SyntaxNode>("n_output_gatetype#0", (args) => CreateSyntaxNode(false, true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2495771150_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("n_output_gatetype#1", (args) => CreateSyntaxNode(false, true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => _keyword_2944532632_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_en_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pass_en_switchtype", Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_1334901423_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_4223992414_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#2", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_1016077314_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#3", (args) => CreateSyntaxNode(false, true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_611975199_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pass_switchtype", Parser.Sequence<CharToken, SyntaxNode>("pass_switchtype#0", (args) => CreateSyntaxNode(false, true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_1147754730_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pass_switchtype#1", (args) => CreateSyntaxNode(false, true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => _keyword_801892086_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instantiation", (args) => CreateSyntaxNode(false, true, nameof(module_instantiation), args), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => module_instance.Value), new Lazy<IParser<CharToken>>(() => module_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(module_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => module_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_value_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_value_assignment", Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_4125440978_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_value_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_value_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_4125440978_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_parameter_assignments", Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many_2.Value.Many(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_parameter_assignments_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ordered_parameter_assignment", (args) => CreateSyntaxNode(false, true, nameof(ordered_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("named_parameter_assignment", Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("named_parameter_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(named_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance", (args) => CreateSyntaxNode(false, true, nameof(module_instance), args), new Lazy<IParser<CharToken>>(() => name_of_module_instance.Value), new Lazy<IParser<CharToken>>(() => module_instance_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance_optional", (args) => CreateSyntaxNode(false, true, nameof(module_instance_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_module_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_module_instance), args), new Lazy<IParser<CharToken>>(() => module_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_port_connections", Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => named_port_connection.Value), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many_2.Value.Many(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many_2", (args) => CreateSyntaxNode(false, true, nameof(list_of_port_connections_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => named_port_connection.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("ordered_port_connection", (args) => CreateSyntaxNode(false, true, nameof(ordered_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("named_port_connection", (args) => CreateSyntaxNode(false, true, nameof(named_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_region =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_region", (args) => CreateSyntaxNode(false, true, nameof(generate_region), args), new Lazy<IParser<CharToken>>(() => _keyword_2502614553_True.Value), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_172689083_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_declaration", (args) => CreateSyntaxNode(false, true, nameof(genvar_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_788066338_True.Value), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers", (args) => CreateSyntaxNode(false, true, nameof(list_of_genvar_identifiers), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_genvar_identifiers_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_generate_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_loop_generate_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_generate_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("loop_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(loop_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => generate_block.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_initialization =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_initialization", (args) => CreateSyntaxNode(false, true, nameof(genvar_initialization), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("genvar_expression", Parser.Sequence<CharToken, SyntaxNode>("genvar_expression#0", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => genvar_primary.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression#1", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_primary.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_iteration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_iteration", (args) => CreateSyntaxNode(false, true, nameof(genvar_iteration), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_primary", (args) => CreateSyntaxNode(false, true, nameof(genvar_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("conditional_generate_construct", Parser.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#0", (args) => CreateSyntaxNode(false, true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => if_generate_construct.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#1", (args) => CreateSyntaxNode(false, true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => case_generate_construct.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(if_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value), new Lazy<IParser<CharToken>>(() => if_generate_construct_else.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_generate_construct_else", (args) => CreateSyntaxNode(false, true, nameof(if_generate_construct_else), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_construct", (args) => CreateSyntaxNode(false, true, nameof(case_generate_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_72430413_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => case_generate_item.Value), new Lazy<IParser<CharToken>>(() => case_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_generate_item", Parser.Sequence<CharToken, SyntaxNode>("case_generate_item#0", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => case_generate_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("case_generate_item#1", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => _keyword_2376211287_True.Value), new Lazy<IParser<CharToken>>(() => case_generate_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_item_many", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_generate_item_optional", (args) => CreateSyntaxNode(false, true, nameof(case_generate_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("generate_block", Parser.Sequence<CharToken, SyntaxNode>("generate_block#0", (args) => CreateSyntaxNode(false, true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => _keyword_863083765_True.Value), new Lazy<IParser<CharToken>>(() => generate_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_511466925_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("generate_block#1", (args) => CreateSyntaxNode(false, true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_block_optional", (args) => CreateSyntaxNode(false, true, nameof(generate_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => generate_block_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("generate_block_or_null", Parser.Sequence<CharToken, SyntaxNode>("generate_block_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => generate_block.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("generate_block_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_declaration", Parser.Sequence<CharToken, SyntaxNode>("udp_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1178389322_True.Value), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => udp_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => udp_body.Value), new Lazy<IParser<CharToken>>(() => _keyword_3446624936_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("udp_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1178389322_True.Value), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => udp_body.Value), new Lazy<IParser<CharToken>>(() => _keyword_3446624936_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_port_list", (args) => CreateSyntaxNode(false, true, nameof(udp_port_list), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value), new Lazy<IParser<CharToken>>(() => udp_port_list_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(udp_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_port_list), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list_many", (args) => CreateSyntaxNode(false, true, nameof(udp_declaration_port_list_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_port_declaration", Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("udp_port_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_reg_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("udp_output_declaration", Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_367843927_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => udp_output_declaration_optional.Value.Optional(greedy: true)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_output_declaration_optional", (args) => CreateSyntaxNode(false, true, nameof(udp_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_input_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_input_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2563759981_True.Value), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_reg_declaration", (args) => CreateSyntaxNode(false, true, nameof(udp_reg_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2453516508_True.Value), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("udp_body", Parser.Sequence<CharToken, SyntaxNode>("udp_body#0", (args) => CreateSyntaxNode(false, true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => combinational_body.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("udp_body#1", (args) => CreateSyntaxNode(false, true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => sequential_body.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("combinational_body", (args) => CreateSyntaxNode(false, true, nameof(combinational_body), args), new Lazy<IParser<CharToken>>(() => _keyword_1219073474_True.Value), new Lazy<IParser<CharToken>>(() => combinational_entry.Value), new Lazy<IParser<CharToken>>(() => combinational_entry.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_310002382_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("combinational_entry", (args) => CreateSyntaxNode(false, true, nameof(combinational_entry), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => output_symbol.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("sequential_body", (args) => CreateSyntaxNode(false, true, nameof(sequential_body), args), new Lazy<IParser<CharToken>>(() => udp_initial_statement.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1219073474_True.Value), new Lazy<IParser<CharToken>>(() => sequential_entry.Value), new Lazy<IParser<CharToken>>(() => sequential_entry.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_310002382_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_initial_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_initial_statement", (args) => CreateSyntaxNode(false, true, nameof(udp_initial_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_907450165_True.Value), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => init_val.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> init_val =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("init_val", Parser.Sequence<CharToken, SyntaxNode>("init_val#0", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_91929458_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#1", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_374113709_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#2", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_1118488951_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#3", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_199467539_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#4", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_3733152120_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#5", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_3950357332_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#6", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_2928060810_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#7", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_699269493_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#8", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_409858681_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("init_val#9", (args) => CreateSyntaxNode(false, true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => _keyword_2698331283_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("sequential_entry", (args) => CreateSyntaxNode(false, true, nameof(sequential_entry), args), new Lazy<IParser<CharToken>>(() => seq_input_list.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => current_state.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => next_state.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("seq_input_list", Parser.Sequence<CharToken, SyntaxNode>("seq_input_list#0", (args) => CreateSyntaxNode(false, true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("seq_input_list#1", (args) => CreateSyntaxNode(false, true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => edge_input_list.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("level_input_list", (args) => CreateSyntaxNode(false, true, nameof(level_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_input_list", (args) => CreateSyntaxNode(false, true, nameof(edge_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => edge_indicator.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_indicator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("edge_indicator", Parser.Sequence<CharToken, SyntaxNode>("edge_indicator#0", (args) => CreateSyntaxNode(false, true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => level_symbol.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_indicator#1", (args) => CreateSyntaxNode(false, true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => edge_symbol.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> current_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("current_state", (args) => CreateSyntaxNode(false, true, nameof(current_state), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> next_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("next_state", Parser.Sequence<CharToken, SyntaxNode>("next_state#0", (args) => CreateSyntaxNode(false, true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => output_symbol.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("next_state#1", (args) => CreateSyntaxNode(false, true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => _keyword_2284820266_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("output_symbol", Parser.Sequence<CharToken, SyntaxNode>("output_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_2698331283_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_409858681_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3675462840_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3529403227_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("level_symbol", Parser.Sequence<CharToken, SyntaxNode>("level_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_2698331283_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_409858681_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3675462840_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3529403227_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#4", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#5", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_728715020_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("level_symbol#6", (args) => CreateSyntaxNode(false, true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_1446930084_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_symbol", Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#0", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3333733167_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#1", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3308768308_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#2", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_68804517_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#3", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_248405696_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#4", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_3548952502_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#5", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_4039338677_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#6", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_950218840_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#7", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_4171570622_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_symbol#8", (args) => CreateSyntaxNode(false, true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => _keyword_2888712635_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instantiation", (args) => CreateSyntaxNode(false, true, nameof(udp_instantiation), args), new Lazy<IParser<CharToken>>(() => udp_identifier.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => udp_instance.Value), new Lazy<IParser<CharToken>>(() => udp_instantiation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instantiation_many", (args) => CreateSyntaxNode(false, true, nameof(udp_instantiation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => udp_instance.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance", (args) => CreateSyntaxNode(false, true, nameof(udp_instance), args), new Lazy<IParser<CharToken>>(() => name_of_udp_instance.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => output_terminal.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value), new Lazy<IParser<CharToken>>(() => udp_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance_many", (args) => CreateSyntaxNode(false, true, nameof(udp_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => input_terminal.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("name_of_udp_instance", (args) => CreateSyntaxNode(false, true, nameof(name_of_udp_instance), args), new Lazy<IParser<CharToken>>(() => udp_instance_identifier.Value), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> continuous_assign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("continuous_assign", (args) => CreateSyntaxNode(false, true, nameof(continuous_assign), args), new Lazy<IParser<CharToken>>(() => _keyword_1700178554_True.Value), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_net_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_assignments", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_assignments), args), new Lazy<IParser<CharToken>>(() => net_assignment.Value), new Lazy<IParser<CharToken>>(() => list_of_net_assignments_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_net_assignments_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_net_assignments_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => net_assignment.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_assignment", (args) => CreateSyntaxNode(false, true, nameof(net_assignment), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_construct", Parser.Sequence<CharToken, SyntaxNode>("analog_construct#0", (args) => CreateSyntaxNode(false, true, nameof(analog_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_552732405_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_907450165_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_construct#1", (args) => CreateSyntaxNode(false, true, nameof(analog_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_552732405_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_procedural_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_procedural_assignment", (args) => CreateSyntaxNode(false, true, nameof(analog_procedural_assignment), args), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_variable_assignment", Parser.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#0", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#1", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => array_analog_variable_assignment.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_analog_variable_lvalue", Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(scalar_analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> initial_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("initial_construct", (args) => CreateSyntaxNode(false, true, nameof(initial_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_907450165_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> always_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("always_construct", (args) => CreateSyntaxNode(false, true, nameof(always_construct), args), new Lazy<IParser<CharToken>>(() => _keyword_4108997822_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> blocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("blocking_assignment", (args) => CreateSyntaxNode(false, true, nameof(blocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nonblocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nonblocking_assignment", (args) => CreateSyntaxNode(false, true, nameof(nonblocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_81057015_True.Value), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_continuous_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("procedural_continuous_assignments", Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#0", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_1700178554_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#1", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_3707101204_True.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#2", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_3078464078_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#3", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_3078464078_True.Value), new Lazy<IParser<CharToken>>(() => net_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#4", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_1355571570_True.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#5", (args) => CreateSyntaxNode(false, true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => _keyword_1355571570_True.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(variable_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_863083765_True.Value), new Lazy<IParser<CharToken>>(() => analog_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_511466925_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_event_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_863083765_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_511466925_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_seq_block", (args) => CreateSyntaxNode(false, true, nameof(analog_function_seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_863083765_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_511466925_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_function_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("par_block", (args) => CreateSyntaxNode(false, true, nameof(par_block), args), new Lazy<IParser<CharToken>>(() => _keyword_2673958561_True.Value), new Lazy<IParser<CharToken>>(() => par_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1995528836_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("par_block_optional", (args) => CreateSyntaxNode(false, true, nameof(par_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => block_identifier.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("seq_block", (args) => CreateSyntaxNode(false, true, nameof(seq_block), args), new Lazy<IParser<CharToken>>(() => _keyword_863083765_True.Value), new Lazy<IParser<CharToken>>(() => seq_block_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_511466925_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("seq_block_optional", (args) => CreateSyntaxNode(false, true, nameof(seq_block_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => block_identifier.Value), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_statement#0", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_loop_generate_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#1", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#2", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#3", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#4", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#5", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_seq_block.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#6", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#7", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => contribution_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#8", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => indirect_contribution_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement#9", (args) => CreateSyntaxNode(true, true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_control_statement.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_statement_or_null", Parser.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_seq_block.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => disable_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#7", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => event_trigger.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_statement#8", (args) => CreateSyntaxNode(false, true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_case_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_loop_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_seq_block.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#4", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement#5", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement_or_null", Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("statement", Parser.Sequence<CharToken, SyntaxNode>("statement#0", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => blocking_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#1", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => case_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#2", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => conditional_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#3", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => disable_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#4", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => event_trigger.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#5", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => loop_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#6", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => nonblocking_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#7", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => par_block.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#8", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => procedural_continuous_assignments.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#9", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => procedural_timing_control_statement.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#10", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => seq_block.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#11", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => system_task_enable.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#12", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => task_enable.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("statement#13", (args) => CreateSyntaxNode(true, true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => wait_statement.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("statement_or_null", Parser.Sequence<CharToken, SyntaxNode>("statement_or_null#0", (args) => CreateSyntaxNode(false, true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("statement_or_null#1", (args) => CreateSyntaxNode(false, true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_statement", (args) => CreateSyntaxNode(false, true, nameof(function_statement), args), new Lazy<IParser<CharToken>>(() => statement.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_control_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control_statement), args), new Lazy<IParser<CharToken>>(() => analog_event_control.Value), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_control", Parser.Sequence<CharToken, SyntaxNode>("analog_event_control#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3226669864_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_control#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3226669864_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_expression", Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_1282709373_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_7350728_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_2966517335_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_320907322_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression#6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_many", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_many_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_functions", Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_1353610443_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_1888082240_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_1274835013_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions#3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => _keyword_26180012_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_5.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_6.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_7.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_8.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_9.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_10.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_11.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_8", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_12.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_9", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_13.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_10", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_11", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_12", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_13", (args) => CreateSyntaxNode(false, true, nameof(analog_event_functions_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_control", Parser.Sequence<CharToken, SyntaxNode>("delay_control#0", (args) => CreateSyntaxNode(true, false, nameof(delay_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => delay_value.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("delay_control#1", (args) => CreateSyntaxNode(true, false, nameof(delay_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3124444592_False.Value), new Lazy<IParser<CharToken>>(() => _keyword_2334665092_False.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1278134773_False.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_or_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delay_or_event_control", Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#0", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#1", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delay_or_event_control#2", (args) => CreateSyntaxNode(false, true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_355408454_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => event_control.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> disable_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("disable_statement", Parser.Sequence<CharToken, SyntaxNode>("disable_statement#0", (args) => CreateSyntaxNode(false, true, nameof(disable_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3851867783_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("disable_statement#1", (args) => CreateSyntaxNode(false, true, nameof(disable_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3851867783_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_block_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_control", Parser.Sequence<CharToken, SyntaxNode>("event_control#0", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3226669864_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#1", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3226669864_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#2", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_2184471391_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_control#3", (args) => CreateSyntaxNode(false, true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_3226669864_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_709963577_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_trigger", (args) => CreateSyntaxNode(false, true, nameof(event_trigger), args), new Lazy<IParser<CharToken>>(() => _keyword_1550184385_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => event_trigger_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_trigger_many", (args) => CreateSyntaxNode(false, true, nameof(event_trigger_many), args), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_expression", Parser.Sequence<CharToken, SyntaxNode>("event_expression#0", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_1282709373_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#1", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_7350728_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#2", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#3", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#4", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_2242954459_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#5", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression#6", (args) => CreateSyntaxNode(false, true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("procedural_timing_control", Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control#0", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control#1", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("procedural_timing_control_statement", (args) => CreateSyntaxNode(false, true, nameof(procedural_timing_control_statement), args), new Lazy<IParser<CharToken>>(() => procedural_timing_control.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> wait_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("wait_statement", (args) => CreateSyntaxNode(false, true, nameof(wait_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_1007397723_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_else.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_many", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_else.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(analog_function_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("conditional_statement", Parser.Sequence<CharToken, SyntaxNode>("conditional_statement#0", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => conditional_statement_else.Value.Optional(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("conditional_statement#1", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => if_else_if_statement.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("conditional_statement_else", (args) => CreateSyntaxNode(false, true, nameof(conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value), new Lazy<IParser<CharToken>>(() => if_else_if_statement_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => if_else_if_statement_else.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement_many", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("if_else_if_statement_else", (args) => CreateSyntaxNode(false, true, nameof(if_else_if_statement_else), args), new Lazy<IParser<CharToken>>(() => _keyword_3966533833_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_case_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_72430413_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_630725242_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2490707841_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_case_item", Parser.Sequence<CharToken, SyntaxNode>("analog_case_item#0", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_case_item#1", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_2376211287_True.Value), new Lazy<IParser<CharToken>>(() => analog_case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_case_item_many", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_statement", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_72430413_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_case_item", Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_2376211287_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_function_case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_statement", Parser.Sequence<CharToken, SyntaxNode>("case_statement#0", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_72430413_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("case_statement#1", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2490707841_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("case_statement#2", (args) => CreateSyntaxNode(false, true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_630725242_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => case_item.Value), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2805087811_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("case_item", Parser.Sequence<CharToken, SyntaxNode>("case_item#0", (args) => CreateSyntaxNode(false, true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => case_item_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => statement_or_null.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("case_item#1", (args) => CreateSyntaxNode(false, true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => _keyword_2376211287_True.Value), new Lazy<IParser<CharToken>>(() => case_item_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_item_many", (args) => CreateSyntaxNode(false, true, nameof(case_item_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("case_item_optional", (args) => CreateSyntaxNode(false, true, nameof(case_item_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_loop_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_355408454_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_552472682_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_statement.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_loop_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_355408454_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_552472682_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_function_statement_loop_statement", Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_950292364_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_355408454_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_552472682_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#3", (args) => CreateSyntaxNode(false, true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("loop_statement", Parser.Sequence<CharToken, SyntaxNode>("loop_statement#0", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_950292364_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#1", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_355408454_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#2", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_552472682_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("loop_statement#3", (args) => CreateSyntaxNode(false, true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => _keyword_2011146452_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value), new Lazy<IParser<CharToken>>(() => variable_assignment.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => statement.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable), args), new Lazy<IParser<CharToken>>(() => analog_system_task_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value), new Lazy<IParser<CharToken>>(() => system_task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => system_task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable", (args) => CreateSyntaxNode(false, true, nameof(task_enable), args), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value), new Lazy<IParser<CharToken>>(() => task_enable_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable_optional", (args) => CreateSyntaxNode(false, true, nameof(task_enable_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => task_enable_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_enable_many", (args) => CreateSyntaxNode(false, true, nameof(task_enable_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("contribution_statement", (args) => CreateSyntaxNode(false, true, nameof(contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_2830721637_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_contribution_statement", (args) => CreateSyntaxNode(false, true, nameof(indirect_contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => indirect_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2876906363_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_block", (args) => CreateSyntaxNode(false, true, nameof(specify_block), args), new Lazy<IParser<CharToken>>(() => _keyword_748174503_True.Value), new Lazy<IParser<CharToken>>(() => specify_item.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3997638659_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specify_item", Parser.Sequence<CharToken, SyntaxNode>("specify_item#0", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#1", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => pulsestyle_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#2", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => showcancelled_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#3", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => path_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specify_item#4", (args) => CreateSyntaxNode(false, true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => system_timing_check.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulsestyle_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("pulsestyle_declaration", Parser.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2407844859_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2406320805_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> showcancelled_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("showcancelled_declaration", Parser.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_1888842435_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3499064395_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("path_declaration", Parser.Sequence<CharToken, SyntaxNode>("path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("path_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => state_dependent_path_declaration.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("simple_path_declaration", Parser.Sequence<CharToken, SyntaxNode>("simple_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("simple_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parallel_path_description", (args) => CreateSyntaxNode(false, true, nameof(parallel_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3485873635_True.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("full_path_description", (args) => CreateSyntaxNode(false, true, nameof(full_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2113919788_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_inputs", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_inputs), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => list_of_path_inputs_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_195994027_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_inputs_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_inputs_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_outputs", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_outputs), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("list_of_path_outputs_many", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_outputs_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor", (args) => CreateSyntaxNode(false, true, nameof(specify_input_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => input_identifier.Value), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor_optional", (args) => CreateSyntaxNode(false, true, nameof(specify_input_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor", (args) => CreateSyntaxNode(false, true, nameof(specify_output_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => output_identifier.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor_optional", (args) => CreateSyntaxNode(false, true, nameof(specify_output_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("input_identifier", Parser.Sequence<CharToken, SyntaxNode>("input_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("input_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("output_identifier", Parser.Sequence<CharToken, SyntaxNode>("output_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("output_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("path_delay_value", Parser.Sequence<CharToken, SyntaxNode>("path_delay_value#0", (args) => CreateSyntaxNode(false, true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("path_delay_value#1", (args) => CreateSyntaxNode(false, true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_delay_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("list_of_path_delay_expressions", Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#0", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t_path_delay_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#1", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#2", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tz_path_delay_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#3", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#4", (args) => CreateSyntaxNode(false, true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t0x_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tx1_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => t1x_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tx0_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => txz_path_delay_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => tzx_path_delay_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> t_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> trise_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("trise_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(trise_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tfall_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tfall_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tfall_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t01_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t01_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t01_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t10_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t10_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t10_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t0z_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t0z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz1_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t1z_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t1z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tz0_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tz0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t0x_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t0x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tx1_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tx1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("t1x_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(t1x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tx0_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tx0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> txz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("txz_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(txz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> tzx_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("tzx_path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(tzx_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("path_delay_expression", (args) => CreateSyntaxNode(false, true, nameof(path_delay_expression), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_sensitive_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_sensitive_path_declaration", Parser.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_edge_sensitive_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_edge_sensitive_path_description.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => path_delay_value.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parallel_edge_sensitive_path_description", (args) => CreateSyntaxNode(false, true, nameof(parallel_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => _keyword_3485873635_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => data_source_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("full_edge_sensitive_path_description", (args) => CreateSyntaxNode(false, true, nameof(full_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value), new Lazy<IParser<CharToken>>(() => _keyword_2113919788_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => data_source_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_source_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("data_source_expression", (args) => CreateSyntaxNode(false, true, nameof(data_source_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_identifier", Parser.Sequence<CharToken, SyntaxNode>("edge_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_1282709373_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_7350728_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> state_dependent_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("state_dependent_path_declaration", Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#0", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#1", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_3778712205_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#2", (args) => CreateSyntaxNode(false, true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => _keyword_2608994791_True.Value), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> polarity_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("polarity_operator", Parser.Sequence<CharToken, SyntaxNode>("polarity_operator#0", (args) => CreateSyntaxNode(false, true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3484092898_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("polarity_operator#1", (args) => CreateSyntaxNode(false, true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2284820266_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("system_timing_check", Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#0", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setup_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#1", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => hold_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#2", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setuphold_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#3", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recovery_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#4", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => removal_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#5", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recrem_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#6", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => skew_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#7", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => timeskew_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#8", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => fullskew_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#9", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => period_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#10", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => width_timing_check.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("system_timing_check#11", (args) => CreateSyntaxNode(false, true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => nochange_timing_check.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setup_timing_check", (args) => CreateSyntaxNode(false, true, nameof(setup_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_2269120617_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => setup_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setup_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(setup_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hold_timing_check", (args) => CreateSyntaxNode(false, true, nameof(hold_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_1222278294_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => hold_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hold_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(hold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_949700965_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_3.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_4.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_4", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_5.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_5", (args) => CreateSyntaxNode(false, true, nameof(setuphold_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recovery_timing_check", (args) => CreateSyntaxNode(false, true, nameof(recovery_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_2314324922_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => recovery_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recovery_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(recovery_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("removal_timing_check", (args) => CreateSyntaxNode(false, true, nameof(removal_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_2042235774_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => removal_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("removal_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(removal_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_4120613171_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_3.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_4.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_4", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_5.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_5", (args) => CreateSyntaxNode(false, true, nameof(recrem_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("skew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(skew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_710158625_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => skew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("skew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(skew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_3493895360_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_3.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(timeskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_2553739734_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_3.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_3", (args) => CreateSyntaxNode(false, true, nameof(fullskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("period_timing_check", (args) => CreateSyntaxNode(false, true, nameof(period_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_329316949_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => period_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("period_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(period_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_1385041900_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value), new Lazy<IParser<CharToken>>(() => width_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => threshold.Value), new Lazy<IParser<CharToken>>(() => width_timing_check_optional_2.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_timing_check_optional_2", (args) => CreateSyntaxNode(false, true, nameof(width_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nochange_timing_check", (args) => CreateSyntaxNode(false, true, nameof(nochange_timing_check), args), new Lazy<IParser<CharToken>>(() => _keyword_3415218260_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => reference_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => data_event.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => start_edge_offset.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => end_edge_offset.Value), new Lazy<IParser<CharToken>>(() => nochange_timing_check_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nochange_timing_check_optional", (args) => CreateSyntaxNode(false, true, nameof(nochange_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> checktime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("checktime_condition", (args) => CreateSyntaxNode(false, true, nameof(checktime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_reference_event", (args) => CreateSyntaxNode(false, true, nameof(controlled_reference_event), args), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("data_event", (args) => CreateSyntaxNode(false, true, nameof(data_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_data =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delayed_data", Parser.Sequence<CharToken, SyntaxNode>("delayed_data#0", (args) => CreateSyntaxNode(false, true, nameof(delayed_data), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delayed_data#1", (args) => CreateSyntaxNode(false, true, nameof(delayed_data), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("delayed_reference", Parser.Sequence<CharToken, SyntaxNode>("delayed_reference#0", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("delayed_reference#1", (args) => CreateSyntaxNode(false, true, nameof(delayed_reference), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> end_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("end_edge_offset", (args) => CreateSyntaxNode(false, true, nameof(end_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_based_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_based_flag", (args) => CreateSyntaxNode(false, true, nameof(event_based_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> notifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("notifier", (args) => CreateSyntaxNode(false, true, nameof(notifier), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("reference_event", (args) => CreateSyntaxNode(false, true, nameof(reference_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> remain_active_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("remain_active_flag", (args) => CreateSyntaxNode(false, true, nameof(remain_active_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> stamptime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("stamptime_condition", (args) => CreateSyntaxNode(false, true, nameof(stamptime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> start_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("start_edge_offset", (args) => CreateSyntaxNode(false, true, nameof(start_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> threshold =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("threshold", (args) => CreateSyntaxNode(false, true, nameof(threshold), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_limit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_limit", (args) => CreateSyntaxNode(false, true, nameof(timing_check_limit), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_event", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => timing_check_event_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_optional", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_1502040989_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event", (args) => CreateSyntaxNode(false, true, nameof(controlled_timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event_optional", (args) => CreateSyntaxNode(false, true, nameof(controlled_timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_1502040989_True.Value), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("timing_check_event_control", Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#0", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_1282709373_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#1", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => _keyword_7350728_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_event_control#2", (args) => CreateSyntaxNode(false, true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => edge_control_specifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("specify_terminal_descriptor", Parser.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#0", (args) => CreateSyntaxNode(false, true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#1", (args) => CreateSyntaxNode(false, true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier), args), new Lazy<IParser<CharToken>>(() => _keyword_1967997535_True.Value), new Lazy<IParser<CharToken>>(() => edge_control_specifier_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier_optional", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier_optional), args), new Lazy<IParser<CharToken>>(() => edge_descriptor.Value), new Lazy<IParser<CharToken>>(() => edge_control_specifier_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("edge_control_specifier_many", (args) => CreateSyntaxNode(false, true, nameof(edge_control_specifier_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => edge_descriptor.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("edge_descriptor", Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#0", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => _keyword_3640831360_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#1", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => _keyword_1494554511_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#2", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => z_or_x.Value), new Lazy<IParser<CharToken>>(() => zero_or_one.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("edge_descriptor#3", (args) => CreateSyntaxNode(false, true, nameof(edge_descriptor), args), new Lazy<IParser<CharToken>>(() => zero_or_one.Value), new Lazy<IParser<CharToken>>(() => z_or_x.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> zero_or_one =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("zero_or_one", Parser.Sequence<CharToken, SyntaxNode>("zero_or_one#0", (args) => CreateSyntaxNode(false, true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => _keyword_2698331283_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("zero_or_one#1", (args) => CreateSyntaxNode(false, true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => _keyword_409858681_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> z_or_x =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("z_or_x", Parser.Sequence<CharToken, SyntaxNode>("z_or_x#0", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_3675462840_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#1", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_3529403227_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#2", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_4096588181_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("z_or_x#3", (args) => CreateSyntaxNode(false, true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => _keyword_3211112122_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("timing_check_condition", Parser.Sequence<CharToken, SyntaxNode>("timing_check_condition#0", (args) => CreateSyntaxNode(false, true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("timing_check_condition#1", (args) => CreateSyntaxNode(false, true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_timing_check_condition", Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2428589624_True.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2876906363_True.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#2", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3306557630_True.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#3", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_4287825326_True.Value), new Lazy<IParser<CharToken>>(() => scalar_constant.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#4", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => _keyword_489912722_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#5", (args) => CreateSyntaxNode(false, true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_constant =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("scalar_constant", Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#0", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_91929458_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#1", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_374113709_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#2", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_3733152120_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#3", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_3950357332_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#4", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_306362298_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#5", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_1603205205_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#6", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_3626308801_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#7", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_1998429085_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#8", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_409858681_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("scalar_constant#9", (args) => CreateSyntaxNode(false, true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => _keyword_2698331283_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_concatenation", (args) => CreateSyntaxNode(false, true, nameof(analog_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(analog_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(analog_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_filter_function_arg", Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#0", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#1", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => constant_optional_arrayinit.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("concatenation", (args) => CreateSyntaxNode(false, true, nameof(concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_concatenation", (args) => CreateSyntaxNode(false, true, nameof(constant_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(constant_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(constant_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_concatenation", (args) => CreateSyntaxNode(false, true, nameof(module_path_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_concatenation_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_concatenation_many", (args) => CreateSyntaxNode(false, true, nameof(module_path_concatenation_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(module_path_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("multiple_concatenation", (args) => CreateSyntaxNode(false, true, nameof(multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => concatenation.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("assignment_pattern", Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern#0", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => assignment_pattern_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern#1", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => assignment_pattern_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_many", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("assignment_pattern_many_2", (args) => CreateSyntaxNode(false, true, nameof(assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_assignment_pattern", Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern#0", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern#1", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many_2.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many_2", (args) => CreateSyntaxNode(false, true, nameof(constant_assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_arrayinit", (args) => CreateSyntaxNode(false, true, nameof(constant_arrayinit), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_arrayinit_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_arrayinit_many", (args) => CreateSyntaxNode(false, true, nameof(constant_arrayinit_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_optional_arrayinit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_optional_arrayinit", (args) => CreateSyntaxNode(false, true, nameof(constant_optional_arrayinit), args), new Lazy<IParser<CharToken>>(() => _keyword_2474897504_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_optional_arrayinit_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_optional_arrayinit_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_optional_arrayinit_many", (args) => CreateSyntaxNode(false, true, nameof(constant_optional_arrayinit_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call), args), new Lazy<IParser<CharToken>>(() => analog_system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => analog_system_function_call_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_built_in_function_name", Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#0", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_4193167054_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#1", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1498904446_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#2", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_3176731636_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#3", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_3783579331_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#4", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1669539447_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#5", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1826373095_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#6", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2507474701_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#7", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2634046237_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#8", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1910224335_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#9", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1223584218_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#10", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_3219761095_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#11", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1417260301_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#12", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1649204681_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#13", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1747258314_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#14", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_921345389_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#15", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_403357893_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#16", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2197758685_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#17", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_3709850663_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#18", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1259046995_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#19", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_724806680_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#20", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_159395197_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#21", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1076836200_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#22", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1648282529_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#23", (args) => CreateSyntaxNode(false, true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2224824178_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_function_call", (args) => CreateSyntaxNode(false, true, nameof(analysis_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_3176651955_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_filter_function_call", Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#0", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_1884525036_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#1", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2175229144_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2033707624_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#3", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_921709403_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#4", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2746077583_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#5", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2852911491_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#6", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2786283306_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#7", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_4042723641_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_7.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#8", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_350063903_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#9", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => laplace_filter_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_8.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#10", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => zi_filter_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_9.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_10.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_11.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_12.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_13.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_8", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_9", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_14.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_10", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_15.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_11", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_16.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_12", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_17.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_13", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_14", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_14), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_15", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_15), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_16", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_16), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_18.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_17 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_17", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_17), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_19.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_18 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_18", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_18), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_19 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_19", (args) => CreateSyntaxNode(false, true, nameof(analog_filter_function_call_optional_19), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_small_signal_function_call", Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#0", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_3165661158_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#1", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_2660238602_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#2", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_164276082_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#3", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_332868021_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#4", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => _keyword_3532582828_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_518535460_True.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_6.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_2", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_3", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_4", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_5", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => @string.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_6", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_7.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_7", (args) => CreateSyntaxNode(false, true, nameof(analog_small_signal_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("noise_table_input_arg", Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#0", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => noise_table_input_arg_optional.Value.Optional(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#1", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#2", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => @string.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#3", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("noise_table_input_arg_optional", (args) => CreateSyntaxNode(false, true, nameof(noise_table_input_arg_optional), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> laplace_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("laplace_filter_name", Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#0", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1949320743_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#1", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2651116246_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#2", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_2229096801_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("laplace_filter_name#3", (args) => CreateSyntaxNode(false, true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_3240052900_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> zi_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("zi_filter_name", Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#0", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1196748981_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#1", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_760369634_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#2", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1905861492_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("zi_filter_name#3", (args) => CreateSyntaxNode(false, true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => _keyword_1397030404_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_function =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_access_function", Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#0", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#1", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => _keyword_1226409641_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_access_function#2", (args) => CreateSyntaxNode(false, true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => _keyword_2981697799_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_probe_function_call", Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call#0", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_access_function.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_reference.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call#1", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_access_function.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(branch_probe_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_probe_function_call", (args) => CreateSyntaxNode(false, true, nameof(port_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value), new Lazy<IParser<CharToken>>(() => analog_port_reference.Value), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_analog_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_function_call), args), new Lazy<IParser<CharToken>>(() => function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_system_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(constant_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(constant_analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_call", (args) => CreateSyntaxNode(false, true, nameof(function_call), args), new Lazy<IParser<CharToken>>(() => hierarchical_function_identifier.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_call_many", (args) => CreateSyntaxNode(false, true, nameof(function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call", (args) => CreateSyntaxNode(false, true, nameof(system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value), new Lazy<IParser<CharToken>>(() => system_function_call_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call_optional", (args) => CreateSyntaxNode(false, true, nameof(system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => system_function_call_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_call_many", (args) => CreateSyntaxNode(false, true, nameof(system_function_call_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(analog_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression", (args) => CreateSyntaxNode(false, true, nameof(analog_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression_10.Value), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_10", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_10), args), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value), new Lazy<IParser<CharToken>>(() => analog_expression_10_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_9", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_9), args), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value), new Lazy<IParser<CharToken>>(() => analog_expression_9_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_8", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_8), args), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value), new Lazy<IParser<CharToken>>(() => analog_expression_8_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_7", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_7), args), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value), new Lazy<IParser<CharToken>>(() => analog_expression_7_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_6", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_6), args), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value), new Lazy<IParser<CharToken>>(() => analog_expression_6_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_5", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_5), args), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value), new Lazy<IParser<CharToken>>(() => analog_expression_5_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_4", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_4), args), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value), new Lazy<IParser<CharToken>>(() => analog_expression_4_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_3", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_3), args), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value), new Lazy<IParser<CharToken>>(() => analog_expression_3_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_2", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_2), args), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value), new Lazy<IParser<CharToken>>(() => analog_expression_2_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_1), args), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value), new Lazy<IParser<CharToken>>(() => analog_expression_1_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_0), args), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value), new Lazy<IParser<CharToken>>(() => analog_expression_0_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_expression_primary", Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => analog_primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_primary#2", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> abstol_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("abstol_expression", Parser.Sequence<CharToken, SyntaxNode>("abstol_expression#0", (args) => CreateSyntaxNode(false, true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("abstol_expression#1", (args) => CreateSyntaxNode(false, true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_range_expression", Parser.Sequence<CharToken, SyntaxNode>("analog_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_expression_or_null", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_or_null), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("base_expression", (args) => CreateSyntaxNode(false, true, nameof(base_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(conditional_expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => expression3.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_base_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_base_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_or_null", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_or_null), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression_10.Value), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_10", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_10), args), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value), new Lazy<IParser<CharToken>>(() => constant_expression_10_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_9", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_9), args), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value), new Lazy<IParser<CharToken>>(() => constant_expression_9_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_8", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_8), args), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value), new Lazy<IParser<CharToken>>(() => constant_expression_8_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_7", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_7), args), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value), new Lazy<IParser<CharToken>>(() => constant_expression_7_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_6", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_6), args), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value), new Lazy<IParser<CharToken>>(() => constant_expression_6_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_5", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_5), args), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value), new Lazy<IParser<CharToken>>(() => constant_expression_5_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_4", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_4), args), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value), new Lazy<IParser<CharToken>>(() => constant_expression_4_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_3", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_3), args), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value), new Lazy<IParser<CharToken>>(() => constant_expression_3_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_2", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_2), args), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value), new Lazy<IParser<CharToken>>(() => constant_expression_2_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_1), args), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value), new Lazy<IParser<CharToken>>(() => constant_expression_1_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_0), args), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value), new Lazy<IParser<CharToken>>(() => constant_expression_0_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_expression_primary", Parser.Sequence<CharToken, SyntaxNode>("constant_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_10), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_9), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_8), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_7), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_6), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_5), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_4), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_3), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_2), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_1), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_0), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analysis_or_constant_expression_primary", Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#2", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_mintypmax_expression", Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression#0", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression#1", (args) => CreateSyntaxNode(false, true, nameof(constant_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_range_expression", Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2674679959_True.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1192750534_True.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_range_expression#3", (args) => CreateSyntaxNode(false, true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("dimension_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(dimension_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("expression", Parser.Sequence<CharToken, SyntaxNode>("expression#0", (args) => CreateSyntaxNode(false, true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression_10.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("expression#1", (args) => CreateSyntaxNode(false, true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => expression3.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_10", (args) => CreateSyntaxNode(false, true, nameof(expression_10), args), new Lazy<IParser<CharToken>>(() => expression_9.Value), new Lazy<IParser<CharToken>>(() => expression_10_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_10_many", (args) => CreateSyntaxNode(false, true, nameof(expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_9.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_9", (args) => CreateSyntaxNode(false, true, nameof(expression_9), args), new Lazy<IParser<CharToken>>(() => expression_8.Value), new Lazy<IParser<CharToken>>(() => expression_9_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_9_many", (args) => CreateSyntaxNode(false, true, nameof(expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_8.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_8", (args) => CreateSyntaxNode(false, true, nameof(expression_8), args), new Lazy<IParser<CharToken>>(() => expression_7.Value), new Lazy<IParser<CharToken>>(() => expression_8_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_8_many", (args) => CreateSyntaxNode(false, true, nameof(expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_7.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_7", (args) => CreateSyntaxNode(false, true, nameof(expression_7), args), new Lazy<IParser<CharToken>>(() => expression_6.Value), new Lazy<IParser<CharToken>>(() => expression_7_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_7_many", (args) => CreateSyntaxNode(false, true, nameof(expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_6.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_6", (args) => CreateSyntaxNode(false, true, nameof(expression_6), args), new Lazy<IParser<CharToken>>(() => expression_5.Value), new Lazy<IParser<CharToken>>(() => expression_6_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_6_many", (args) => CreateSyntaxNode(false, true, nameof(expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_5.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_5", (args) => CreateSyntaxNode(false, true, nameof(expression_5), args), new Lazy<IParser<CharToken>>(() => expression_4.Value), new Lazy<IParser<CharToken>>(() => expression_5_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_5_many", (args) => CreateSyntaxNode(false, true, nameof(expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_4.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_4", (args) => CreateSyntaxNode(false, true, nameof(expression_4), args), new Lazy<IParser<CharToken>>(() => expression_3.Value), new Lazy<IParser<CharToken>>(() => expression_4_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_4_many", (args) => CreateSyntaxNode(false, true, nameof(expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_3.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_3", (args) => CreateSyntaxNode(false, true, nameof(expression_3), args), new Lazy<IParser<CharToken>>(() => expression_2.Value), new Lazy<IParser<CharToken>>(() => expression_3_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_3_many", (args) => CreateSyntaxNode(false, true, nameof(expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_2.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_2", (args) => CreateSyntaxNode(false, true, nameof(expression_2), args), new Lazy<IParser<CharToken>>(() => expression_1.Value), new Lazy<IParser<CharToken>>(() => expression_2_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_2_many", (args) => CreateSyntaxNode(false, true, nameof(expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_1.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_1", (args) => CreateSyntaxNode(false, true, nameof(expression_1), args), new Lazy<IParser<CharToken>>(() => expression_0.Value), new Lazy<IParser<CharToken>>(() => expression_1_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_1_many", (args) => CreateSyntaxNode(false, true, nameof(expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_0.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_0", (args) => CreateSyntaxNode(false, true, nameof(expression_0), args), new Lazy<IParser<CharToken>>(() => expression_primary.Value), new Lazy<IParser<CharToken>>(() => expression_0_many.Value.Many(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression_0_many", (args) => CreateSyntaxNode(false, true, nameof(expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression_primary.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("expression_primary", Parser.Sequence<CharToken, SyntaxNode>("expression_primary#0", (args) => CreateSyntaxNode(false, true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => primary.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("expression_primary#1", (args) => CreateSyntaxNode(false, true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => primary.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression1", (args) => CreateSyntaxNode(false, true, nameof(expression1), args), new Lazy<IParser<CharToken>>(() => expression_10.Value), new Lazy<IParser<CharToken>>(() => expression1_prim.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression2", (args) => CreateSyntaxNode(false, true, nameof(expression2), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("expression3", (args) => CreateSyntaxNode(false, true, nameof(expression3), args), new Lazy<IParser<CharToken>>(() => expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("indirect_expression", Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#0", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#1", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#2", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_1884525036_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#3", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_1884525036_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#4", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_2033707624_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_3.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#5", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_2033707624_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_4.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#6", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_921709403_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_5.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("indirect_expression#7", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => _keyword_921709403_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_6.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_2", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_3", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_3), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_7.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_4", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_8.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_5", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_9.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_6", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_6), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_10.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_7", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_11.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_8", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_8), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_12.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_9", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_9), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_13.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_10", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_10), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_14.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_11", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_11), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_12", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_12), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_13", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_13), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_15.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_14", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_14), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_16.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_15", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_15), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_16", (args) => CreateSyntaxNode(false, true, nameof(indirect_expression_optional_16), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => abstol_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> lsb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("lsb_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(lsb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("mintypmax_expression", Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression#0", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("mintypmax_expression#1", (args) => CreateSyntaxNode(false, true, nameof(mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_path_conditional_expression", (args) => CreateSyntaxNode(false, true, nameof(module_path_conditional_expression), args), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_expression", Parser.Sequence<CharToken, SyntaxNode>("module_path_expression#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_mintypmax_expression", Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#2", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#3", (args) => CreateSyntaxNode(false, true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_primary.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> msb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("msb_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(msb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_attribute_expression", Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#0", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#1", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("range_expression", Parser.Sequence<CharToken, SyntaxNode>("range_expression#0", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#1", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2674679959_True.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#2", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_1192750534_True.Value), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("range_expression#3", (args) => CreateSyntaxNode(false, true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("width_constant_expression", (args) => CreateSyntaxNode(false, true, nameof(width_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_primary", Parser.Sequence<CharToken, SyntaxNode>("analog_primary#0", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#1", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#2", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_multiple_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#3", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#4", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_system_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#5", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#6", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_filter_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#7", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#8", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#9", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#10", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#11", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => variable_reference.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#12", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => net_reference.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#13", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#14", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => parameter_reference.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#15", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("analog_primary#16", (args) => CreateSyntaxNode(true, true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("constant_primary", Parser.Sequence<CharToken, SyntaxNode>("constant_primary#0", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#1", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => constant_primary_optional.Value.Optional(greedy: true))).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#2", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value), new Lazy<IParser<CharToken>>(() => constant_primary_optional_2.Value.Optional(greedy: true))).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#3", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#4", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_multiple_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#5", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#6", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_system_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#7", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#8", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#9", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#10", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#11", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#12", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("constant_primary#13", (args) => CreateSyntaxNode(true, true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_primary_optional", (args) => CreateSyntaxNode(true, true, nameof(constant_primary_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)).Token());

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_primary_optional_2", (args) => CreateSyntaxNode(true, true, nameof(constant_primary_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)).Token());

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("module_path_primary", Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#0", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#1", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#2", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#3", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_multiple_concatenation.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#4", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#5", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_primary#6", (args) => CreateSyntaxNode(true, true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => module_path_mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("primary", Parser.Sequence<CharToken, SyntaxNode>("primary#0", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => number.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#1", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => concatenation.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#2", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => multiple_concatenation.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#3", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#4", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#5", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#6", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => @string.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#7", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#8", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#9", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#10", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#11", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("primary#12", (args) => CreateSyntaxNode(false, true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => primary_h.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("primary_h", (args) => CreateSyntaxNode(false, true, nameof(primary_h), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value), new Lazy<IParser<CharToken>>(() => primary_h_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("primary_h_optional", (args) => CreateSyntaxNode(false, true, nameof(primary_h_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_variable_lvalue", Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_assignment", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => _keyword_1862074603_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue.Value), new Lazy<IParser<CharToken>>(() => _keyword_1979957664_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("array_analog_variable_rvalue", Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#0", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_1779768050_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#1", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_1779768050_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#2", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => assignment_pattern.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue_many", (args) => CreateSyntaxNode(false, true, nameof(array_analog_variable_rvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_lvalue", (args) => CreateSyntaxNode(false, true, nameof(branch_lvalue), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_lvalue", Parser.Sequence<CharToken, SyntaxNode>("net_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => net_lvalue_optional.Value.Optional(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("net_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value), new Lazy<IParser<CharToken>>(() => net_lvalue_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_lvalue_optional", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => constant_expression_lazy.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(net_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => net_lvalue.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("constant_expression_lazy", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_lazy), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_lvalue", Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue#0", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_variable_identifier.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue_optional.Value.Optional(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue#1", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => _keyword_2830793585_True.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_2783565040_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue_optional", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_lvalue_many", (args) => CreateSyntaxNode(false, true, nameof(variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> lazy_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("lazy_expressions", (args) => CreateSyntaxNode(false, true, nameof(lazy_expressions), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("unary_operator", Parser.Sequence<CharToken, SyntaxNode>("unary_operator#0", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3484092898_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#1", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2284820266_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#2", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2498842453_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#3", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3169753218_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#4", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1770852932_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#5", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2879907818_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#6", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_489912722_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#7", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2994957244_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#8", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3777123988_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#9", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1588986440_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_operator#10", (args) => CreateSyntaxNode(false, true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3218759032_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("binary_operator", Parser.Sequence<CharToken, SyntaxNode>("binary_operator#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#4", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#5", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#6", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#7", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#8", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#9", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator#10", (args) => CreateSyntaxNode(false, true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_0", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_0#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_0), args), new Lazy<IParser<CharToken>>(() => _keyword_3484092898_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_0#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_0), args), new Lazy<IParser<CharToken>>(() => _keyword_2284820266_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_1), args), new Lazy<IParser<CharToken>>(() => _keyword_258570926_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_2", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_2#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => _keyword_2888712635_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_2#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => _keyword_2539695096_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_2#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => _keyword_1155227937_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_3", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_1097927229_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_2146800899_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_1113394692_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_3#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => _keyword_4109941571_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_4", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_81057015_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_4196597141_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_4#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_5", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_2428589624_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_3306557630_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_2876906363_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_5#3", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => _keyword_4287825326_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_6", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_6), args), new Lazy<IParser<CharToken>>(() => _keyword_2994957244_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("binary_operator_7", Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#0", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_1770852932_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#1", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3169753218_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_operator_7#2", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => _keyword_3218759032_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_8", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_8), args), new Lazy<IParser<CharToken>>(() => _keyword_3777123988_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_9", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_9), args), new Lazy<IParser<CharToken>>(() => _keyword_1690933265_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_operator_10", (args) => CreateSyntaxNode(false, true, nameof(binary_operator_10), args), new Lazy<IParser<CharToken>>(() => _keyword_2591393293_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("unary_module_path_operator", Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#0", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2498842453_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#1", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_489912722_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#2", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2994957244_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#3", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2879907818_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#4", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3777123988_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#5", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1588986440_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#6", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3218759032_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#7", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3169753218_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#8", (args) => CreateSyntaxNode(false, true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1770852932_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("binary_module_path_operator", Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#0", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2876906363_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#1", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_4287825326_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#2", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1690933265_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#3", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2591393293_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#4", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_2994957244_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#5", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3777123988_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#6", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3218759032_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#7", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_1770852932_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#8", (args) => CreateSyntaxNode(false, true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => _keyword_3169753218_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("number", Parser.Sequence<CharToken, SyntaxNode>("number#0", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => binary_number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("number#1", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => hex_number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("number#2", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => octal_number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("number#3", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => real_number.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("number#4", (args) => CreateSyntaxNode(true, true, nameof(number), args), new Lazy<IParser<CharToken>>(() => decimal_number.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("real_number", Parser.Sequence<CharToken, SyntaxNode>("real_number#0", (args) => CreateSyntaxNode(false, false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => real_number_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => exp.Value), new Lazy<IParser<CharToken>>(() => sign.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("real_number#1", (args) => CreateSyntaxNode(false, false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => real_number_optional_2.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => scale_factor.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("real_number#2", (args) => CreateSyntaxNode(false, false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => _keyword_886540259_False.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number_optional", (args) => CreateSyntaxNode(false, false, nameof(real_number_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_886540259_False.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_number_optional_2", (args) => CreateSyntaxNode(false, false, nameof(real_number_optional_2), args), new Lazy<IParser<CharToken>>(() => _keyword_886540259_False.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> exp =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("exp", Parser.Sequence<CharToken, SyntaxNode>("exp#0", (args) => CreateSyntaxNode(false, false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => _keyword_2295397158_False.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("exp#1", (args) => CreateSyntaxNode(false, false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => _keyword_3461597304_False.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> scale_factor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("scale_factor", (args) => CreateSyntaxNode(false, false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => _keyword_2757112911_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("decimal_number", Parser.Sequence<CharToken, SyntaxNode>("decimal_number#0", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#1", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => _keyword_673131677_True.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#2", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => _keyword_4178309827_True.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many_2.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("decimal_number#3", (args) => CreateSyntaxNode(false, true, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_number_many", (args) => CreateSyntaxNode(false, true, nameof(decimal_number_many), args), new Lazy<IParser<CharToken>>(() => _keyword_4023998832_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_number_many_2", (args) => CreateSyntaxNode(false, true, nameof(decimal_number_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_4023998832_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_number", (args) => CreateSyntaxNode(false, true, nameof(binary_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => binary_base.Value), new Lazy<IParser<CharToken>>(() => binary_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_number", (args) => CreateSyntaxNode(false, true, nameof(octal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => octal_base.Value), new Lazy<IParser<CharToken>>(() => octal_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_number", (args) => CreateSyntaxNode(false, true, nameof(hex_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => hex_base.Value), new Lazy<IParser<CharToken>>(() => hex_value.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> sign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("sign", Parser.Sequence<CharToken, SyntaxNode>("sign#0", (args) => CreateSyntaxNode(false, true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => _keyword_3484092898_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("sign#1", (args) => CreateSyntaxNode(false, true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => _keyword_2284820266_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> size =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("size", (args) => CreateSyntaxNode(false, false, nameof(size), args), new Lazy<IParser<CharToken>>(() => _keyword_1288340869_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> unsigned_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("unsigned_number", (args) => CreateSyntaxNode(false, false, nameof(unsigned_number), args), new Lazy<IParser<CharToken>>(() => _keyword_2759939237_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_value", (args) => CreateSyntaxNode(false, false, nameof(binary_value), args), new Lazy<IParser<CharToken>>(() => _keyword_599810771_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_value", (args) => CreateSyntaxNode(false, false, nameof(octal_value), args), new Lazy<IParser<CharToken>>(() => _keyword_2570772509_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_value", (args) => CreateSyntaxNode(false, false, nameof(hex_value), args), new Lazy<IParser<CharToken>>(() => _keyword_4067651772_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("decimal_base", (args) => CreateSyntaxNode(false, false, nameof(decimal_base), args), new Lazy<IParser<CharToken>>(() => _keyword_885904397_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("binary_base", (args) => CreateSyntaxNode(false, false, nameof(binary_base), args), new Lazy<IParser<CharToken>>(() => _keyword_1173505809_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("octal_base", (args) => CreateSyntaxNode(false, false, nameof(octal_base), args), new Lazy<IParser<CharToken>>(() => _keyword_582813607_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hex_base", (args) => CreateSyntaxNode(false, false, nameof(hex_base), args), new Lazy<IParser<CharToken>>(() => _keyword_2994862052_False.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> @string =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("@string", (args) => CreateSyntaxNode(false, true, nameof(@string), args), new Lazy<IParser<CharToken>>(() => _keyword_3038894918_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_reference", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_port_reference", Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#0", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#1", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#2", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_port_reference#3", (args) => CreateSyntaxNode(false, true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_net_reference", Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#0", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#1", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#2", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#3", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#4", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_net_reference#5", (args) => CreateSyntaxNode(false, true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("branch_reference", Parser.Sequence<CharToken, SyntaxNode>("branch_reference#0", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_reference#1", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("branch_reference#2", (args) => CreateSyntaxNode(false, true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("hierarchical_unnamed_branch_reference", Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#0", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_2127462654_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#1", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_2127462654_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value), new Lazy<IParser<CharToken>>(() => port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#2", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_2127462654_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_837414738_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3305599612_True.Value), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_1307890912_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_3919076239_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_unnamed_branch_reference_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => branch_terminal.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("parameter_reference", Parser.Sequence<CharToken, SyntaxNode>("parameter_reference#0", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("parameter_reference#1", (args) => CreateSyntaxNode(false, true, nameof(parameter_reference), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("variable_reference", Parser.Sequence<CharToken, SyntaxNode>("variable_reference#0", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value), new Lazy<IParser<CharToken>>(() => variable_reference_many.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#1", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value), new Lazy<IParser<CharToken>>(() => variable_reference_many_2.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#2", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("variable_reference#3", (args) => CreateSyntaxNode(false, true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_reference_many", (args) => CreateSyntaxNode(false, true, nameof(variable_reference_many), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_reference_many_2", (args) => CreateSyntaxNode(false, true, nameof(variable_reference_many_2), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("net_reference", Parser.Sequence<CharToken, SyntaxNode>("net_reference#0", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#1", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#2", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("net_reference#3", (args) => CreateSyntaxNode(false, true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attribute_instance", (args) => CreateSyntaxNode(false, true, nameof(attribute_instance), args), new Lazy<IParser<CharToken>>(() => _keyword_3866128923_True.Value), new Lazy<IParser<CharToken>>(() => attr_spec.Value), new Lazy<IParser<CharToken>>(() => attribute_instance_many.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_930470857_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attribute_instance_many", (args) => CreateSyntaxNode(false, true, nameof(attribute_instance_many), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => attr_spec.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_spec", (args) => CreateSyntaxNode(false, true, nameof(attr_spec), args), new Lazy<IParser<CharToken>>(() => attr_name.Value), new Lazy<IParser<CharToken>>(() => attr_spec_optional.Value.Optional(greedy: true))));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_spec_optional", (args) => CreateSyntaxNode(false, true, nameof(attr_spec_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_3600495398_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("attr_name", (args) => CreateSyntaxNode(false, true, nameof(attr_name), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> ams_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("ams_net_identifier", Parser.Sequence<CharToken, SyntaxNode>("ams_net_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true))),
           Parser.Sequence<CharToken, SyntaxNode>("ams_net_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_block_identifier), args), new Lazy<IParser<CharToken>>(() => block_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_system_task_identifier), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analog_system_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(analog_system_function_identifier), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("analysis_identifier", (args) => CreateSyntaxNode(false, true, nameof(analysis_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("block_identifier", (args) => CreateSyntaxNode(false, true, nameof(block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("branch_identifier", (args) => CreateSyntaxNode(false, true, nameof(branch_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("cell_identifier", (args) => CreateSyntaxNode(false, true, nameof(cell_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("config_identifier", (args) => CreateSyntaxNode(false, true, nameof(config_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectmodule_identifier", (args) => CreateSyntaxNode(false, true, nameof(connectmodule_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("connectrules_identifier", (args) => CreateSyntaxNode(false, true, nameof(connectrules_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("discipline_identifier", (args) => CreateSyntaxNode(false, true, nameof(discipline_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> escaped_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("escaped_identifier", (args) => CreateSyntaxNode(false, true, nameof(escaped_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_3614819217_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("event_identifier", (args) => CreateSyntaxNode(false, true, nameof(event_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("function_identifier", (args) => CreateSyntaxNode(false, true, nameof(function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("gate_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(gate_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("generate_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(generate_block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("genvar_identifier", (args) => CreateSyntaxNode(false, true, nameof(genvar_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_block_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_block_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_branch_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_branch_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_event_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_event_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_function_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_2523932409_True.Value), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_lazy), args), new Lazy<IParser<CharToken>>(() => identifier.Value), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy_optional.Value.Optional(greedy: true)), new Lazy<IParser<CharToken>>(() => _keyword_934619380_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy_optional", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_identifier_lazy_optional), args), new Lazy<IParser<CharToken>>(() => _keyword_681727057_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_3555555881_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_inst_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_inst_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_inst_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_net_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_port_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_variable_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("hierarchical_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(hierarchical_task_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("identifier", Parser.Sequence<CharToken, SyntaxNode>("identifier#0", (args) => CreateSyntaxNode(true, true, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => simple_identifier.Value)).Token(),
           Parser.Sequence<CharToken, SyntaxNode>("identifier#1", (args) => CreateSyntaxNode(true, true, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => escaped_identifier.Value)).Token()));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("inout_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(inout_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("input_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(input_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> library_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("library_identifier", (args) => CreateSyntaxNode(false, true, nameof(library_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("module_or_paramset_identifier", Parser.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_output_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_output_variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_output_variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("module_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(module_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_identifier", (args) => CreateSyntaxNode(false, true, nameof(nature_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("nature_access_identifier", (args) => CreateSyntaxNode(false, true, nameof(nature_access_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("nature_attribute_identifier", Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_882467288_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_739124038_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#2", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_42614690_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#3", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_3519979426_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#4", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_3306621183_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#5", (args) => CreateSyntaxNode(false, true, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("net_identifier", (args) => CreateSyntaxNode(false, true, nameof(net_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("output_port_identifier", (args) => CreateSyntaxNode(false, true, nameof(output_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("paramset_identifier", (args) => CreateSyntaxNode(false, true, nameof(paramset_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("port_identifier", (args) => CreateSyntaxNode(false, true, nameof(port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("real_identifier", (args) => CreateSyntaxNode(false, true, nameof(real_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("simple_identifier", (args) => CreateSyntaxNode(false, true, nameof(simple_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_941118442_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("specparam_identifier", (args) => CreateSyntaxNode(false, true, nameof(specparam_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_function_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_function_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_1632259463_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_parameter_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_1632259463_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("system_task_identifier", (args) => CreateSyntaxNode(false, true, nameof(system_task_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_1632259463_True.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("task_identifier", (args) => CreateSyntaxNode(false, true, nameof(task_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> terminal_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("terminal_identifier", (args) => CreateSyntaxNode(false, true, nameof(terminal_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> text_macro_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("text_macro_identifier", Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#0", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#1", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_2636296063_True.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("text_macro_identifier#2", (args) => CreateSyntaxNode(false, true, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => _keyword_2585919354_True.Value))));

        public static Lazy<IParser<CharToken, SyntaxNode>> topmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("topmodule_identifier", (args) => CreateSyntaxNode(false, true, nameof(topmodule_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_identifier", (args) => CreateSyntaxNode(false, true, nameof(udp_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("udp_instance_identifier", (args) => CreateSyntaxNode(false, true, nameof(udp_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Sequence<CharToken, SyntaxNode>("variable_identifier", (args) => CreateSyntaxNode(false, true, nameof(variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("analog_event_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_1955606722_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("analog_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("analog_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analog_expression.Value), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analog_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("analysis_or_constant_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("constant_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => constant_expression.Value), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("event_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_1955606722_True.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_3115127300_True.Value), new Lazy<IParser<CharToken>>(() => event_expression.Value), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("event_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("expression1_prim", Parser.Sequence<CharToken, SyntaxNode>("expression1_prim#0", (args) => CreateSyntaxNode(false, true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => expression2.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => expression3.Value), new Lazy<IParser<CharToken>>(() => expression1_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("expression1_prim#1", (args) => CreateSyntaxNode(false, true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.Or("genvar_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => genvar_expression.Value), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("module_path_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_module_path_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => module_path_expression.Value), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parser.XOr("paramset_constant_expression_prim", Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#0", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#1", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => _keyword_85001739_True.Value), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => _keyword_2396310477_True.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value)),
           Parser.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#2", (args) => CreateSyntaxNode(false, true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parser.Return(string.Empty)))));

        public static Lazy<IParser<CharToken, string>> _keyword_2897933668_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endmodule", true).Cached(2897933668));

        public static Lazy<IParser<CharToken, string>> _keyword_2245455489_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("module", true).Cached(2245455489));

        public static Lazy<IParser<CharToken, string>> _keyword_1604288512_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("macromodule", true).Cached(1604288512));

        public static Lazy<IParser<CharToken, string>> _keyword_2756096282_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connectmodule", true).Cached(2756096282));

        public static Lazy<IParser<CharToken, string>> _keyword_2027232758_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("defparam", true).Cached(2027232758));

        public static Lazy<IParser<CharToken, string>> _keyword_2876807419_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("config", true).Cached(2876807419));

        public static Lazy<IParser<CharToken, string>> _keyword_923015071_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endconfig", true).Cached(923015071));

        public static Lazy<IParser<CharToken, string>> _keyword_2323362373_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("design", true).Cached(2323362373));

        public static Lazy<IParser<CharToken, string>> _keyword_2376211287_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("default", true).Cached(2376211287));

        public static Lazy<IParser<CharToken, string>> _keyword_176835622_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("instance", true).Cached(176835622));

        public static Lazy<IParser<CharToken, string>> _keyword_4169065027_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cell", true).Cached(4169065027));

        public static Lazy<IParser<CharToken, string>> _keyword_2202799827_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("liblist", true).Cached(2202799827));

        public static Lazy<IParser<CharToken, string>> _keyword_1753121903_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("use", true).Cached(1753121903));

        public static Lazy<IParser<CharToken, string>> _keyword_1236812367_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nature", true).Cached(1236812367));

        public static Lazy<IParser<CharToken, string>> _keyword_2361480391_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endnature", true).Cached(2361480391));

        public static Lazy<IParser<CharToken, string>> _keyword_1665704165_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("discipline", true).Cached(1665704165));

        public static Lazy<IParser<CharToken, string>> _keyword_2297153116_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("enddiscipline", true).Cached(2297153116));

        public static Lazy<IParser<CharToken, string>> _keyword_1226409641_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("potential", true).Cached(1226409641));

        public static Lazy<IParser<CharToken, string>> _keyword_2981697799_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("flow", true).Cached(2981697799));

        public static Lazy<IParser<CharToken, string>> _keyword_1583021792_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("domain", true).Cached(1583021792));

        public static Lazy<IParser<CharToken, string>> _keyword_92496478_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("discrete", true).Cached(92496478));

        public static Lazy<IParser<CharToken, string>> _keyword_2493040520_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("continuous", true).Cached(2493040520));

        public static Lazy<IParser<CharToken, string>> _keyword_2095749790_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connectrules", true).Cached(2095749790));

        public static Lazy<IParser<CharToken, string>> _keyword_2013220074_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endconnectrules", true).Cached(2013220074));

        public static Lazy<IParser<CharToken, string>> _keyword_467549850_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("connect", true).Cached(467549850));

        public static Lazy<IParser<CharToken, string>> _keyword_2611634036_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("merged", true).Cached(2611634036));

        public static Lazy<IParser<CharToken, string>> _keyword_2022167860_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("split", true).Cached(2022167860));

        public static Lazy<IParser<CharToken, string>> _keyword_2563759981_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("input", true).Cached(2563759981));

        public static Lazy<IParser<CharToken, string>> _keyword_367843927_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("output", true).Cached(367843927));

        public static Lazy<IParser<CharToken, string>> _keyword_3265484267_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("inout", true).Cached(3265484267));

        public static Lazy<IParser<CharToken, string>> _keyword_1292097932_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("resolveto", true).Cached(1292097932));

        public static Lazy<IParser<CharToken, string>> _keyword_2410607647_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("exclude", true).Cached(2410607647));

        public static Lazy<IParser<CharToken, string>> _keyword_838051505_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("paramset", true).Cached(838051505));

        public static Lazy<IParser<CharToken, string>> _keyword_596789015_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endparamset", true).Cached(596789015));

        public static Lazy<IParser<CharToken, string>> _keyword_2841273682_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("localparam", true).Cached(2841273682));

        public static Lazy<IParser<CharToken, string>> _keyword_821833129_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("signed", true).Cached(821833129));

        public static Lazy<IParser<CharToken, string>> _keyword_325026961_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("parameter", true).Cached(325026961));

        public static Lazy<IParser<CharToken, string>> _keyword_2772951146_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("specparam", true).Cached(2772951146));

        public static Lazy<IParser<CharToken, string>> _keyword_3350338320_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("integer", true).Cached(3350338320));

        public static Lazy<IParser<CharToken, string>> _keyword_1579686364_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("realtime", true).Cached(1579686364));

        public static Lazy<IParser<CharToken, string>> _keyword_4075039361_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("real", true).Cached(4075039361));

        public static Lazy<IParser<CharToken, string>> _keyword_4156358108_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("time", true).Cached(4156358108));

        public static Lazy<IParser<CharToken, string>> _keyword_1622526449_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("string", true).Cached(1622526449));

        public static Lazy<IParser<CharToken, string>> _keyword_1962817519_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("aliasparam", true).Cached(1962817519));

        public static Lazy<IParser<CharToken, string>> _keyword_3525870581_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wreal", true).Cached(3525870581));

        public static Lazy<IParser<CharToken, string>> _keyword_2453516508_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("reg", true).Cached(2453516508));

        public static Lazy<IParser<CharToken, string>> _keyword_4211402917_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("branch", true).Cached(4211402917));

        public static Lazy<IParser<CharToken, string>> _keyword_3873115350_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("event", true).Cached(3873115350));

        public static Lazy<IParser<CharToken, string>> _keyword_156611110_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("trireg", true).Cached(156611110));

        public static Lazy<IParser<CharToken, string>> _keyword_3380179321_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ground", true).Cached(3380179321));

        public static Lazy<IParser<CharToken, string>> _keyword_2939226663_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("vectored", true).Cached(2939226663));

        public static Lazy<IParser<CharToken, string>> _keyword_1376360468_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("scalared", true).Cached(1376360468));

        public static Lazy<IParser<CharToken, string>> _keyword_1050326929_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("supply0", true).Cached(1050326929));

        public static Lazy<IParser<CharToken, string>> _keyword_4138178808_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("supply1", true).Cached(4138178808));

        public static Lazy<IParser<CharToken, string>> _keyword_1855085678_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("triand", true).Cached(1855085678));

        public static Lazy<IParser<CharToken, string>> _keyword_1329918423_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("trior", true).Cached(1329918423));

        public static Lazy<IParser<CharToken, string>> _keyword_4007132734_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri0", true).Cached(4007132734));

        public static Lazy<IParser<CharToken, string>> _keyword_3406387942_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri1", true).Cached(3406387942));

        public static Lazy<IParser<CharToken, string>> _keyword_1682082968_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tri", true).Cached(1682082968));

        public static Lazy<IParser<CharToken, string>> _keyword_1411434385_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("uwire", true).Cached(1411434385));

        public static Lazy<IParser<CharToken, string>> _keyword_2953276485_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wire", true).Cached(2953276485));

        public static Lazy<IParser<CharToken, string>> _keyword_21733340_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wand", true).Cached(21733340));

        public static Lazy<IParser<CharToken, string>> _keyword_1525937688_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wor", true).Cached(1525937688));

        public static Lazy<IParser<CharToken, string>> _keyword_555958830_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("highz1", true).Cached(555958830));

        public static Lazy<IParser<CharToken, string>> _keyword_3929886150_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("highz0", true).Cached(3929886150));

        public static Lazy<IParser<CharToken, string>> _keyword_3024379416_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("strong0", true).Cached(3024379416));

        public static Lazy<IParser<CharToken, string>> _keyword_2243030978_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pull0", true).Cached(2243030978));

        public static Lazy<IParser<CharToken, string>> _keyword_1701182130_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("weak0", true).Cached(1701182130));

        public static Lazy<IParser<CharToken, string>> _keyword_946377925_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("strong1", true).Cached(946377925));

        public static Lazy<IParser<CharToken, string>> _keyword_505091316_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pull1", true).Cached(505091316));

        public static Lazy<IParser<CharToken, string>> _keyword_2828316346_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("weak1", true).Cached(2828316346));

        public static Lazy<IParser<CharToken, string>> _keyword_4262166542_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("small", true).Cached(4262166542));

        public static Lazy<IParser<CharToken, string>> _keyword_63936939_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("medium", true).Cached(63936939));

        public static Lazy<IParser<CharToken, string>> _keyword_4073852739_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("large", true).Cached(4073852739));

        public static Lazy<IParser<CharToken, string>> _keyword_2477967257_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("PATHPULSE$", true).Cached(2477967257));

        public static Lazy<IParser<CharToken, string>> _keyword_3385534110_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$specify_output_terminal_descriptor", true).Cached(3385534110));

        public static Lazy<IParser<CharToken, string>> _keyword_2474897504_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'{", true).Cached(2474897504));

        public static Lazy<IParser<CharToken, string>> _keyword_2159469382_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("from", true).Cached(2159469382));

        public static Lazy<IParser<CharToken, string>> _keyword_1458171649_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("-inf", true).Cached(1458171649));

        public static Lazy<IParser<CharToken, string>> _keyword_436272535_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("inf", true).Cached(436272535));

        public static Lazy<IParser<CharToken, string>> _keyword_552732405_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("analog", true).Cached(552732405));

        public static Lazy<IParser<CharToken, string>> _keyword_864928946_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("function", true).Cached(864928946));

        public static Lazy<IParser<CharToken, string>> _keyword_4243255454_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endfunction", true).Cached(4243255454));

        public static Lazy<IParser<CharToken, string>> _keyword_3581235388_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("automatic", true).Cached(3581235388));

        public static Lazy<IParser<CharToken, string>> _keyword_1896238475_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("task", true).Cached(1896238475));

        public static Lazy<IParser<CharToken, string>> _keyword_2293046360_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endtask", true).Cached(2293046360));

        public static Lazy<IParser<CharToken, string>> _keyword_120121795_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulldown", true).Cached(120121795));

        public static Lazy<IParser<CharToken, string>> _keyword_1462721993_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pullup", true).Cached(1462721993));

        public static Lazy<IParser<CharToken, string>> _keyword_3531683679_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cmos", true).Cached(3531683679));

        public static Lazy<IParser<CharToken, string>> _keyword_157721049_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rcmos", true).Cached(157721049));

        public static Lazy<IParser<CharToken, string>> _keyword_759950902_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("bufif0", true).Cached(759950902));

        public static Lazy<IParser<CharToken, string>> _keyword_2878985343_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("bufif1", true).Cached(2878985343));

        public static Lazy<IParser<CharToken, string>> _keyword_2582813136_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("notif0", true).Cached(2582813136));

        public static Lazy<IParser<CharToken, string>> _keyword_3398281119_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("notif1", true).Cached(3398281119));

        public static Lazy<IParser<CharToken, string>> _keyword_1611652091_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nmos", true).Cached(1611652091));

        public static Lazy<IParser<CharToken, string>> _keyword_2100841696_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pmos", true).Cached(2100841696));

        public static Lazy<IParser<CharToken, string>> _keyword_3025743086_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rnmos", true).Cached(3025743086));

        public static Lazy<IParser<CharToken, string>> _keyword_573963708_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rpmos", true).Cached(573963708));

        public static Lazy<IParser<CharToken, string>> _keyword_2889127852_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("and", true).Cached(2889127852));

        public static Lazy<IParser<CharToken, string>> _keyword_3832443294_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nand", true).Cached(3832443294));

        public static Lazy<IParser<CharToken, string>> _keyword_1955606722_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("or", true).Cached(1955606722));

        public static Lazy<IParser<CharToken, string>> _keyword_2456964475_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("nor", true).Cached(2456964475));

        public static Lazy<IParser<CharToken, string>> _keyword_497270797_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("xor", true).Cached(497270797));

        public static Lazy<IParser<CharToken, string>> _keyword_3950774444_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("xnor", true).Cached(3950774444));

        public static Lazy<IParser<CharToken, string>> _keyword_2495771150_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("buf", true).Cached(2495771150));

        public static Lazy<IParser<CharToken, string>> _keyword_2944532632_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("not", true).Cached(2944532632));

        public static Lazy<IParser<CharToken, string>> _keyword_1334901423_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tranif0", true).Cached(1334901423));

        public static Lazy<IParser<CharToken, string>> _keyword_4223992414_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tranif1", true).Cached(4223992414));

        public static Lazy<IParser<CharToken, string>> _keyword_1016077314_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtranif1", true).Cached(1016077314));

        public static Lazy<IParser<CharToken, string>> _keyword_611975199_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtranif0", true).Cached(611975199));

        public static Lazy<IParser<CharToken, string>> _keyword_1147754730_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tran", true).Cached(1147754730));

        public static Lazy<IParser<CharToken, string>> _keyword_801892086_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("rtran", true).Cached(801892086));

        public static Lazy<IParser<CharToken, string>> _keyword_2502614553_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("generate", true).Cached(2502614553));

        public static Lazy<IParser<CharToken, string>> _keyword_172689083_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endgenerate", true).Cached(172689083));

        public static Lazy<IParser<CharToken, string>> _keyword_788066338_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("genvar", true).Cached(788066338));

        public static Lazy<IParser<CharToken, string>> _keyword_2011146452_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("for", true).Cached(2011146452));

        public static Lazy<IParser<CharToken, string>> _keyword_3778712205_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("if", true).Cached(3778712205));

        public static Lazy<IParser<CharToken, string>> _keyword_3966533833_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("else", true).Cached(3966533833));

        public static Lazy<IParser<CharToken, string>> _keyword_72430413_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("case", true).Cached(72430413));

        public static Lazy<IParser<CharToken, string>> _keyword_2805087811_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endcase", true).Cached(2805087811));

        public static Lazy<IParser<CharToken, string>> _keyword_863083765_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("begin", true).Cached(863083765));

        public static Lazy<IParser<CharToken, string>> _keyword_511466925_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("end", true).Cached(511466925));

        public static Lazy<IParser<CharToken, string>> _keyword_1178389322_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("primitive", true).Cached(1178389322));

        public static Lazy<IParser<CharToken, string>> _keyword_3446624936_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endprimitive", true).Cached(3446624936));

        public static Lazy<IParser<CharToken, string>> _keyword_1219073474_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("table", true).Cached(1219073474));

        public static Lazy<IParser<CharToken, string>> _keyword_310002382_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endtable", true).Cached(310002382));

        public static Lazy<IParser<CharToken, string>> _keyword_907450165_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("initial", true).Cached(907450165));

        public static Lazy<IParser<CharToken, string>> _keyword_91929458_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'b0", true).Cached(91929458));

        public static Lazy<IParser<CharToken, string>> _keyword_374113709_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'b1", true).Cached(374113709));

        public static Lazy<IParser<CharToken, string>> _keyword_1118488951_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'bx", true).Cached(1118488951));

        public static Lazy<IParser<CharToken, string>> _keyword_199467539_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'bX", true).Cached(199467539));

        public static Lazy<IParser<CharToken, string>> _keyword_3733152120_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'B0", true).Cached(3733152120));

        public static Lazy<IParser<CharToken, string>> _keyword_3950357332_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'B1", true).Cached(3950357332));

        public static Lazy<IParser<CharToken, string>> _keyword_2928060810_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'Bx", true).Cached(2928060810));

        public static Lazy<IParser<CharToken, string>> _keyword_699269493_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("1'BX", true).Cached(699269493));

        public static Lazy<IParser<CharToken, string>> _keyword_1700178554_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("assign", true).Cached(1700178554));

        public static Lazy<IParser<CharToken, string>> _keyword_4108997822_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("always", true).Cached(4108997822));

        public static Lazy<IParser<CharToken, string>> _keyword_81057015_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<=", true).Cached(81057015));

        public static Lazy<IParser<CharToken, string>> _keyword_3707101204_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("deassign", true).Cached(3707101204));

        public static Lazy<IParser<CharToken, string>> _keyword_3078464078_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("force", true).Cached(3078464078));

        public static Lazy<IParser<CharToken, string>> _keyword_1355571570_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("release", true).Cached(1355571570));

        public static Lazy<IParser<CharToken, string>> _keyword_2673958561_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("fork", true).Cached(2673958561));

        public static Lazy<IParser<CharToken, string>> _keyword_1995528836_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("join", true).Cached(1995528836));

        public static Lazy<IParser<CharToken, string>> _keyword_1282709373_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("posedge", true).Cached(1282709373));

        public static Lazy<IParser<CharToken, string>> _keyword_7350728_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("negedge", true).Cached(7350728));

        public static Lazy<IParser<CharToken, string>> _keyword_2966517335_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("initial_step", true).Cached(2966517335));

        public static Lazy<IParser<CharToken, string>> _keyword_320907322_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("final_step", true).Cached(320907322));

        public static Lazy<IParser<CharToken, string>> _keyword_518535460_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("\"", true).Cached(518535460));

        public static Lazy<IParser<CharToken, string>> _keyword_1353610443_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cross", true).Cached(1353610443));

        public static Lazy<IParser<CharToken, string>> _keyword_1888082240_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("above", true).Cached(1888082240));

        public static Lazy<IParser<CharToken, string>> _keyword_1274835013_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("timer", true).Cached(1274835013));

        public static Lazy<IParser<CharToken, string>> _keyword_26180012_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("absdelta", true).Cached(26180012));

        public static Lazy<IParser<CharToken, string>> _keyword_355408454_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("repeat", true).Cached(355408454));

        public static Lazy<IParser<CharToken, string>> _keyword_3851867783_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("disable", true).Cached(3851867783));

        public static Lazy<IParser<CharToken, string>> _keyword_2184471391_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("@*", true).Cached(2184471391));

        public static Lazy<IParser<CharToken, string>> _keyword_709963577_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("(*)", true).Cached(709963577));

        public static Lazy<IParser<CharToken, string>> _keyword_1550184385_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("->", true).Cached(1550184385));

        public static Lazy<IParser<CharToken, string>> _keyword_2242954459_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("driver_update", true).Cached(2242954459));

        public static Lazy<IParser<CharToken, string>> _keyword_1007397723_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("wait", true).Cached(1007397723));

        public static Lazy<IParser<CharToken, string>> _keyword_630725242_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("casex", true).Cached(630725242));

        public static Lazy<IParser<CharToken, string>> _keyword_2490707841_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("casez", true).Cached(2490707841));

        public static Lazy<IParser<CharToken, string>> _keyword_552472682_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("while", true).Cached(552472682));

        public static Lazy<IParser<CharToken, string>> _keyword_950292364_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("forever", true).Cached(950292364));

        public static Lazy<IParser<CharToken, string>> _keyword_2830721637_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<+", true).Cached(2830721637));

        public static Lazy<IParser<CharToken, string>> _keyword_2876906363_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("==", true).Cached(2876906363));

        public static Lazy<IParser<CharToken, string>> _keyword_748174503_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("specify", true).Cached(748174503));

        public static Lazy<IParser<CharToken, string>> _keyword_3997638659_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("endspecify", true).Cached(3997638659));

        public static Lazy<IParser<CharToken, string>> _keyword_2407844859_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulsestyle_onevent", true).Cached(2407844859));

        public static Lazy<IParser<CharToken, string>> _keyword_2406320805_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pulsestyle_ondetect", true).Cached(2406320805));

        public static Lazy<IParser<CharToken, string>> _keyword_1888842435_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("showcancelled", true).Cached(1888842435));

        public static Lazy<IParser<CharToken, string>> _keyword_3499064395_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noshowcancelled", true).Cached(3499064395));

        public static Lazy<IParser<CharToken, string>> _keyword_3485873635_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("=>", true).Cached(3485873635));

        public static Lazy<IParser<CharToken, string>> _keyword_2113919788_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("*>", true).Cached(2113919788));

        public static Lazy<IParser<CharToken, string>> _keyword_195994027_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("\\", true).Cached(195994027));

        public static Lazy<IParser<CharToken, string>> _keyword_2608994791_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ifnone", true).Cached(2608994791));

        public static Lazy<IParser<CharToken, string>> _keyword_2269120617_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$setup", true).Cached(2269120617));

        public static Lazy<IParser<CharToken, string>> _keyword_1222278294_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$hold", true).Cached(1222278294));

        public static Lazy<IParser<CharToken, string>> _keyword_949700965_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$setuphold", true).Cached(949700965));

        public static Lazy<IParser<CharToken, string>> _keyword_2314324922_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$recovery", true).Cached(2314324922));

        public static Lazy<IParser<CharToken, string>> _keyword_2042235774_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$removal", true).Cached(2042235774));

        public static Lazy<IParser<CharToken, string>> _keyword_4120613171_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$recrem", true).Cached(4120613171));

        public static Lazy<IParser<CharToken, string>> _keyword_710158625_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$skew", true).Cached(710158625));

        public static Lazy<IParser<CharToken, string>> _keyword_3493895360_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$timeskew", true).Cached(3493895360));

        public static Lazy<IParser<CharToken, string>> _keyword_2553739734_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$fullskew", true).Cached(2553739734));

        public static Lazy<IParser<CharToken, string>> _keyword_329316949_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$period", true).Cached(329316949));

        public static Lazy<IParser<CharToken, string>> _keyword_1385041900_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$width", true).Cached(1385041900));

        public static Lazy<IParser<CharToken, string>> _keyword_3415218260_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$nochange", true).Cached(3415218260));

        public static Lazy<IParser<CharToken, string>> _keyword_1502040989_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("&&&", true).Cached(1502040989));

        public static Lazy<IParser<CharToken, string>> _keyword_1967997535_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("edge", true).Cached(1967997535));

        public static Lazy<IParser<CharToken, string>> _keyword_3640831360_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("01", true).Cached(3640831360));

        public static Lazy<IParser<CharToken, string>> _keyword_1494554511_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("10", true).Cached(1494554511));

        public static Lazy<IParser<CharToken, string>> _keyword_2428589624_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("===", true).Cached(2428589624));

        public static Lazy<IParser<CharToken, string>> _keyword_3306557630_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("!==", true).Cached(3306557630));

        public static Lazy<IParser<CharToken, string>> _keyword_4287825326_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("!=", true).Cached(4287825326));

        public static Lazy<IParser<CharToken, string>> _keyword_306362298_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'b0", true).Cached(306362298));

        public static Lazy<IParser<CharToken, string>> _keyword_1603205205_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'b1", true).Cached(1603205205));

        public static Lazy<IParser<CharToken, string>> _keyword_3626308801_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'B0", true).Cached(3626308801));

        public static Lazy<IParser<CharToken, string>> _keyword_1998429085_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("'B1", true).Cached(1998429085));

        public static Lazy<IParser<CharToken, string>> _keyword_4193167054_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ln", true).Cached(4193167054));

        public static Lazy<IParser<CharToken, string>> _keyword_1498904446_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("log", true).Cached(1498904446));

        public static Lazy<IParser<CharToken, string>> _keyword_3176731636_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("exp", true).Cached(3176731636));

        public static Lazy<IParser<CharToken, string>> _keyword_3783579331_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sqrt", true).Cached(3783579331));

        public static Lazy<IParser<CharToken, string>> _keyword_1669539447_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("min", true).Cached(1669539447));

        public static Lazy<IParser<CharToken, string>> _keyword_1826373095_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("max", true).Cached(1826373095));

        public static Lazy<IParser<CharToken, string>> _keyword_2507474701_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("abs", true).Cached(2507474701));

        public static Lazy<IParser<CharToken, string>> _keyword_2634046237_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("pow", true).Cached(2634046237));

        public static Lazy<IParser<CharToken, string>> _keyword_1910224335_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("floor", true).Cached(1910224335));

        public static Lazy<IParser<CharToken, string>> _keyword_1223584218_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ceil", true).Cached(1223584218));

        public static Lazy<IParser<CharToken, string>> _keyword_3219761095_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tanh", true).Cached(3219761095));

        public static Lazy<IParser<CharToken, string>> _keyword_1417260301_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("asinh", true).Cached(1417260301));

        public static Lazy<IParser<CharToken, string>> _keyword_1649204681_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("acosh", true).Cached(1649204681));

        public static Lazy<IParser<CharToken, string>> _keyword_1747258314_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atan2", true).Cached(1747258314));

        public static Lazy<IParser<CharToken, string>> _keyword_921345389_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atanh", true).Cached(921345389));

        public static Lazy<IParser<CharToken, string>> _keyword_403357893_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("hypot", true).Cached(403357893));

        public static Lazy<IParser<CharToken, string>> _keyword_2197758685_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sinh", true).Cached(2197758685));

        public static Lazy<IParser<CharToken, string>> _keyword_3709850663_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("sin", true).Cached(3709850663));

        public static Lazy<IParser<CharToken, string>> _keyword_1259046995_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cosh", true).Cached(1259046995));

        public static Lazy<IParser<CharToken, string>> _keyword_724806680_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("cos", true).Cached(724806680));

        public static Lazy<IParser<CharToken, string>> _keyword_159395197_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("tan", true).Cached(159395197));

        public static Lazy<IParser<CharToken, string>> _keyword_1076836200_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("asin", true).Cached(1076836200));

        public static Lazy<IParser<CharToken, string>> _keyword_1648282529_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("acos", true).Cached(1648282529));

        public static Lazy<IParser<CharToken, string>> _keyword_2224824178_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("atan", true).Cached(2224824178));

        public static Lazy<IParser<CharToken, string>> _keyword_3176651955_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("analysis", true).Cached(3176651955));

        public static Lazy<IParser<CharToken, string>> _keyword_1884525036_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddt", true).Cached(1884525036));

        public static Lazy<IParser<CharToken, string>> _keyword_2175229144_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddx", true).Cached(2175229144));

        public static Lazy<IParser<CharToken, string>> _keyword_2033707624_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idt", true).Cached(2033707624));

        public static Lazy<IParser<CharToken, string>> _keyword_921709403_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idtmod", true).Cached(921709403));

        public static Lazy<IParser<CharToken, string>> _keyword_2746077583_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("absdelay", true).Cached(2746077583));

        public static Lazy<IParser<CharToken, string>> _keyword_2852911491_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("transition", true).Cached(2852911491));

        public static Lazy<IParser<CharToken, string>> _keyword_2786283306_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("slew", true).Cached(2786283306));

        public static Lazy<IParser<CharToken, string>> _keyword_4042723641_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("last_crossing", true).Cached(4042723641));

        public static Lazy<IParser<CharToken, string>> _keyword_350063903_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("limexp", true).Cached(350063903));

        public static Lazy<IParser<CharToken, string>> _keyword_3165661158_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ac_stim", true).Cached(3165661158));

        public static Lazy<IParser<CharToken, string>> _keyword_2660238602_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("white_noise", true).Cached(2660238602));

        public static Lazy<IParser<CharToken, string>> _keyword_164276082_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("flicker_noise", true).Cached(164276082));

        public static Lazy<IParser<CharToken, string>> _keyword_332868021_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noise_table", true).Cached(332868021));

        public static Lazy<IParser<CharToken, string>> _keyword_3532582828_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("noise_table_log", true).Cached(3532582828));

        public static Lazy<IParser<CharToken, string>> _keyword_1949320743_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_zd", true).Cached(1949320743));

        public static Lazy<IParser<CharToken, string>> _keyword_2651116246_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_zp", true).Cached(2651116246));

        public static Lazy<IParser<CharToken, string>> _keyword_2229096801_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_np", true).Cached(2229096801));

        public static Lazy<IParser<CharToken, string>> _keyword_3240052900_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("laplace_nd", true).Cached(3240052900));

        public static Lazy<IParser<CharToken, string>> _keyword_1196748981_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_zp", true).Cached(1196748981));

        public static Lazy<IParser<CharToken, string>> _keyword_760369634_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_zd", true).Cached(760369634));

        public static Lazy<IParser<CharToken, string>> _keyword_1905861492_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_np", true).Cached(1905861492));

        public static Lazy<IParser<CharToken, string>> _keyword_1397030404_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("zi_nd", true).Cached(1397030404));

        public static Lazy<IParser<CharToken, string>> _keyword_2674679959_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("+:", true).Cached(2674679959));

        public static Lazy<IParser<CharToken, string>> _keyword_1192750534_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("-:", true).Cached(1192750534));

        public static Lazy<IParser<CharToken, string>> _keyword_1862074603_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("array_analog_variable_lvalue", true).Cached(1862074603));

        public static Lazy<IParser<CharToken, string>> _keyword_1779768050_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("array_variable_identifier", true).Cached(1779768050));

        public static Lazy<IParser<CharToken, string>> _keyword_3169753218_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~^", true).Cached(3169753218));

        public static Lazy<IParser<CharToken, string>> _keyword_1770852932_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("^~", true).Cached(1770852932));

        public static Lazy<IParser<CharToken, string>> _keyword_2879907818_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~&", true).Cached(2879907818));

        public static Lazy<IParser<CharToken, string>> _keyword_1588986440_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("~|", true).Cached(1588986440));

        public static Lazy<IParser<CharToken, string>> _keyword_258570926_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("**", true).Cached(258570926));

        public static Lazy<IParser<CharToken, string>> _keyword_1097927229_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<<<", true).Cached(1097927229));

        public static Lazy<IParser<CharToken, string>> _keyword_2146800899_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">>>", true).Cached(2146800899));

        public static Lazy<IParser<CharToken, string>> _keyword_1113394692_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("<<", true).Cached(1113394692));

        public static Lazy<IParser<CharToken, string>> _keyword_4109941571_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">>", true).Cached(4109941571));

        public static Lazy<IParser<CharToken, string>> _keyword_4196597141_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(">=", true).Cached(4196597141));

        public static Lazy<IParser<CharToken, string>> _keyword_1690933265_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("&&", true).Cached(1690933265));

        public static Lazy<IParser<CharToken, string>> _keyword_2591393293_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("||", true).Cached(2591393293));

        public static Lazy<IParser<CharToken, string>> _keyword_673131677_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("x_digit", true).Cached(673131677));

        public static Lazy<IParser<CharToken, string>> _keyword_4178309827_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("z_digit", true).Cached(4178309827));

        public static Lazy<IParser<CharToken, string>> _keyword_2127462654_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String(".branch", true).Cached(2127462654));

        public static Lazy<IParser<CharToken, string>> _keyword_3866128923_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("(*", true).Cached(3866128923));

        public static Lazy<IParser<CharToken, string>> _keyword_930470857_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("*)", true).Cached(930470857));

        public static Lazy<IParser<CharToken, string>> _keyword_2523932409_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("$root", true).Cached(2523932409));

        public static Lazy<IParser<CharToken, string>> _keyword_882467288_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("abstol", true).Cached(882467288));

        public static Lazy<IParser<CharToken, string>> _keyword_739124038_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("access", true).Cached(739124038));

        public static Lazy<IParser<CharToken, string>> _keyword_42614690_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("ddt_nature", true).Cached(42614690));

        public static Lazy<IParser<CharToken, string>> _keyword_3519979426_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("idt_nature", true).Cached(3519979426));

        public static Lazy<IParser<CharToken, string>> _keyword_3306621183_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("units", true).Cached(3306621183));

        public static Lazy<IParser<CharToken, string>> _keyword_2636296063_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("__VAMS_ENABLE__", true).Cached(2636296063));

        public static Lazy<IParser<CharToken, string>> _keyword_2585919354_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.String("__VAMS_COMPACT_MODELING__", true).Cached(2585919354));

        public static Lazy<IParser<CharToken, char>> _keyword_1979957664_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(';', true).Cached(1979957664));

        public static Lazy<IParser<CharToken, char>> _keyword_4125440978_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('#', true).Cached(4125440978));

        public static Lazy<IParser<CharToken, char>> _keyword_837414738_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('(', true).Cached(837414738));

        public static Lazy<IParser<CharToken, char>> _keyword_3919076239_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(')', true).Cached(3919076239));

        public static Lazy<IParser<CharToken, char>> _keyword_3115127300_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(',', true).Cached(3115127300));

        public static Lazy<IParser<CharToken, char>> _keyword_934619380_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('.', true).Cached(934619380));

        public static Lazy<IParser<CharToken, char>> _keyword_681727057_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('[', true).Cached(681727057));

        public static Lazy<IParser<CharToken, char>> _keyword_3555555881_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(']', true).Cached(3555555881));

        public static Lazy<IParser<CharToken, char>> _keyword_2396310477_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(':', true).Cached(2396310477));

        public static Lazy<IParser<CharToken, char>> _keyword_3600495398_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('=', true).Cached(3600495398));

        public static Lazy<IParser<CharToken, char>> _keyword_3305599612_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('<', true).Cached(3305599612));

        public static Lazy<IParser<CharToken, char>> _keyword_1307890912_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('>', true).Cached(1307890912));

        public static Lazy<IParser<CharToken, char>> _keyword_3124444592_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('#', true).Cached(3124444592));

        public static Lazy<IParser<CharToken, char>> _keyword_2334665092_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('(', true).Cached(2334665092));

        public static Lazy<IParser<CharToken, char>> _keyword_1278134773_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(')', true).Cached(1278134773));

        public static Lazy<IParser<CharToken, char>> _keyword_825355425_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char(',', true).Cached(825355425));

        public static Lazy<IParser<CharToken, char>> _keyword_2783565040_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('}', true).Cached(2783565040));

        public static Lazy<IParser<CharToken, char>> _keyword_409858681_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('1', true).Cached(409858681));

        public static Lazy<IParser<CharToken, char>> _keyword_2698331283_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('0', true).Cached(2698331283));

        public static Lazy<IParser<CharToken, char>> _keyword_2284820266_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('-', true).Cached(2284820266));

        public static Lazy<IParser<CharToken, char>> _keyword_3675462840_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('x', true).Cached(3675462840));

        public static Lazy<IParser<CharToken, char>> _keyword_3529403227_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('X', true).Cached(3529403227));

        public static Lazy<IParser<CharToken, char>> _keyword_85001739_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('?', true).Cached(85001739));

        public static Lazy<IParser<CharToken, char>> _keyword_728715020_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('b', true).Cached(728715020));

        public static Lazy<IParser<CharToken, char>> _keyword_1446930084_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('B', true).Cached(1446930084));

        public static Lazy<IParser<CharToken, char>> _keyword_3333733167_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('r', true).Cached(3333733167));

        public static Lazy<IParser<CharToken, char>> _keyword_3308768308_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('R', true).Cached(3308768308));

        public static Lazy<IParser<CharToken, char>> _keyword_68804517_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('f', true).Cached(68804517));

        public static Lazy<IParser<CharToken, char>> _keyword_248405696_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('F', true).Cached(248405696));

        public static Lazy<IParser<CharToken, char>> _keyword_3548952502_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('p', true).Cached(3548952502));

        public static Lazy<IParser<CharToken, char>> _keyword_4039338677_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('P', true).Cached(4039338677));

        public static Lazy<IParser<CharToken, char>> _keyword_950218840_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('n', true).Cached(950218840));

        public static Lazy<IParser<CharToken, char>> _keyword_4171570622_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('N', true).Cached(4171570622));

        public static Lazy<IParser<CharToken, char>> _keyword_2888712635_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('*', true).Cached(2888712635));

        public static Lazy<IParser<CharToken, char>> _keyword_3226669864_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('@', true).Cached(3226669864));

        public static Lazy<IParser<CharToken, char>> _keyword_3484092898_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('+', true).Cached(3484092898));

        public static Lazy<IParser<CharToken, char>> _keyword_4096588181_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('z', true).Cached(4096588181));

        public static Lazy<IParser<CharToken, char>> _keyword_3211112122_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('Z', true).Cached(3211112122));

        public static Lazy<IParser<CharToken, char>> _keyword_489912722_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('~', true).Cached(489912722));

        public static Lazy<IParser<CharToken, char>> _keyword_2830793585_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('{', true).Cached(2830793585));

        public static Lazy<IParser<CharToken, char>> _keyword_2498842453_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('!', true).Cached(2498842453));

        public static Lazy<IParser<CharToken, char>> _keyword_2994957244_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('&', true).Cached(2994957244));

        public static Lazy<IParser<CharToken, char>> _keyword_3777123988_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('|', true).Cached(3777123988));

        public static Lazy<IParser<CharToken, char>> _keyword_3218759032_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('^', true).Cached(3218759032));

        public static Lazy<IParser<CharToken, char>> _keyword_2539695096_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('/', true).Cached(2539695096));

        public static Lazy<IParser<CharToken, char>> _keyword_1155227937_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('%', true).Cached(1155227937));

        public static Lazy<IParser<CharToken, char>> _keyword_886540259_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('.', true).Cached(886540259));

        public static Lazy<IParser<CharToken, char>> _keyword_2295397158_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('e', true).Cached(2295397158));

        public static Lazy<IParser<CharToken, char>> _keyword_3461597304_False =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('E', true).Cached(3461597304));

        public static Lazy<IParser<CharToken, char>> _keyword_4023998832_True =
          new Lazy<IParser<CharToken, char>>(() => Parser.Char('_', true).Cached(4023998832));

        public static Lazy<IParser<CharToken, string>> _keyword_2757112911_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[TGMKkmunpfa]", false).Cached(2757112911));

        public static Lazy<IParser<CharToken, string>> _keyword_1288340869_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[1-9][1-9_]*", false).Cached(1288340869));

        public static Lazy<IParser<CharToken, string>> _keyword_2759939237_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[0-9][0-9_]*", false).Cached(2759939237));

        public static Lazy<IParser<CharToken, string>> _keyword_599810771_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX01zZ\\?][_xX01zZ\\?]*", false).Cached(599810771));

        public static Lazy<IParser<CharToken, string>> _keyword_2570772509_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX0-7zZ\\?][xX0-7zZ\\?_]*", false).Cached(2570772509));

        public static Lazy<IParser<CharToken, string>> _keyword_4067651772_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[xX0-9a-fA-FzZ\\?][xX0-9a-fA-FzZ\\?_]*", false).Cached(4067651772));

        public static Lazy<IParser<CharToken, string>> _keyword_885904397_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[dD]?", false).Cached(885904397));

        public static Lazy<IParser<CharToken, string>> _keyword_1173505809_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[bB]?", false).Cached(1173505809));

        public static Lazy<IParser<CharToken, string>> _keyword_582813607_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[oO]?", false).Cached(582813607));

        public static Lazy<IParser<CharToken, string>> _keyword_2994862052_False =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("'[sS]?[hH]?", false).Cached(2994862052));

        public static Lazy<IParser<CharToken, string>> _keyword_3038894918_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\"((?:\\\\.|[^\\\"])*)\"", true).Cached(3038894918));

        public static Lazy<IParser<CharToken, string>> _keyword_3614819217_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\\\\[^ ]+", true).Cached(3614819217));

        public static Lazy<IParser<CharToken, string>> _keyword_941118442_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("[a-zA-Z_][a-zA-Z0-9_\\$]*", true).Cached(941118442));

        public static Lazy<IParser<CharToken, string>> _keyword_1632259463_True =
          new Lazy<IParser<CharToken, string>>(() => Parser.Regex("\\$[a-zA-Z0-9_$][a-zA-Z0-9_\\$]*", true).Cached(1632259463));


    }
}