using CFGToolkit.ParserCombinator;
using NVerilogParser.AST;
using System;
using System.Collections.Generic;

namespace CFGToolkit.Parsers.VerilogAMS
{
    public class Parsers
    {
        public static Lazy<IParser<CharToken, SyntaxNode>> source_text =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("source_text#0", (args) => CreateSyntaxNode(true, nameof(source_text), args), new Lazy<IParser<CharToken>>(() => description.Value.Many(greedy: true).Token())).Named("source_text"));

        public static Lazy<IParser<CharToken, SyntaxNode>> description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("description#0", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => module_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#1", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => udp_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#2", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => config_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#3", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => paramset_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#4", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => nature_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#5", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => discipline_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("description#6", (args) => CreateSyntaxNode(true, nameof(description), args), new Lazy<IParser<CharToken>>(() => connectrules_declaration.Value.Token())))))))).Named("description"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_declaration#0", (args) => CreateSyntaxNode(true, nameof(module_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_keyword.Value.Token()), new Lazy<IParser<CharToken>>(() => module_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_ports.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => module_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endmodule", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_declaration#1", (args) => CreateSyntaxNode(true, nameof(module_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_keyword.Value.Token()), new Lazy<IParser<CharToken>>(() => module_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => module_parameter_port_list.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_declarations.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endmodule", true).Text()))).Named("module_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_keyword =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_keyword#0", (args) => CreateSyntaxNode(true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => Parse.String("module", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_keyword#1", (args) => CreateSyntaxNode(true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => Parse.String("macromodule", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_keyword#2", (args) => CreateSyntaxNode(true, nameof(module_keyword), args), new Lazy<IParser<CharToken>>(() => Parse.String("connectmodule", true).Text())))).Named("module_keyword"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_parameter_port_list#0", (args) => CreateSyntaxNode(true, nameof(module_parameter_port_list), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => module_parameter_port_list_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("module_parameter_port_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_parameter_port_list_many#0", (args) => CreateSyntaxNode(true, nameof(module_parameter_port_list_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token())).Named("module_parameter_port_list_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_ports#0", (args) => CreateSyntaxNode(true, nameof(list_of_ports), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_ports_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("list_of_ports"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_ports_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_ports_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_ports_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => port.Value.Token())).Named("list_of_ports_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_declarations#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_declarations), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_declarations_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_port_declarations#1", (args) => CreateSyntaxNode(true, nameof(list_of_port_declarations), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("list_of_port_declarations"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_declarations_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_declarations_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_declarations_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => port_declaration.Value.Token())).Named("list_of_port_declarations_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port#0", (args) => CreateSyntaxNode(true, nameof(port), args), new Lazy<IParser<CharToken>>(() => port_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("port#1", (args) => CreateSyntaxNode(true, nameof(port), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port_expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("port"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_expression#0", (args) => CreateSyntaxNode(true, nameof(port_expression), args), new Lazy<IParser<CharToken>>(() => port_reference.Value.Token()), new Lazy<IParser<CharToken>>(() => port_expression_many.Value.Many(greedy: true).Token())).Named("port_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_expression_many#0", (args) => CreateSyntaxNode(true, nameof(port_expression_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => port_reference.Value.Token())).Named("port_expression_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_reference#0", (args) => CreateSyntaxNode(true, nameof(port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => port_reference_optional.Value.Optional(greedy: false).Token())).Named("port_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_reference_optional#0", (args) => CreateSyntaxNode(true, nameof(port_reference_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("port_reference_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_declaration#0", (args) => CreateSyntaxNode(true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => inout_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("port_declaration#1", (args) => CreateSyntaxNode(true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => input_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("port_declaration#2", (args) => CreateSyntaxNode(true, nameof(port_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => output_declaration.Value.Token())))).Named("port_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_item#0", (args) => CreateSyntaxNode(true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => port_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_item#1", (args) => CreateSyntaxNode(true, nameof(module_item), args), new Lazy<IParser<CharToken>>(() => non_port_module_item.Value.Token()))).Named("module_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#0", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_or_generate_item_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#1", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#2", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => parameter_override.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#3", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => continuous_assign.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#4", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#5", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => udp_instantiation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#6", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_instantiation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#7", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => initial_construct.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#8", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => always_construct.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#9", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => loop_generate_construct.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#10", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => conditional_generate_construct.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item#11", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_construct.Value.Token()))))))))))))).Named("module_or_generate_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_generate_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => net_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => reg_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => integer_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#3", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => real_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#4", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => time_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#5", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => realtime_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#6", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => event_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#7", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => genvar_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#8", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => task_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#9", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => function_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#10", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => branch_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_or_generate_item_declaration#11", (args) => CreateSyntaxNode(true, nameof(module_or_generate_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_function_declaration.Value.Token()))))))))))))).Named("module_or_generate_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_port_module_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#0", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#1", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => generate_region.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#2", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => specify_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#3", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#4", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_port_module_item#5", (args) => CreateSyntaxNode(true, nameof(non_port_module_item), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value.Token()))))))).Named("non_port_module_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_override#0", (args) => CreateSyntaxNode(true, nameof(parameter_override), args), new Lazy<IParser<CharToken>>(() => Parse.String("defparam", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("parameter_override"));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("config_declaration#0", (args) => CreateSyntaxNode(true, nameof(config_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("config", true).Text()), new Lazy<IParser<CharToken>>(() => config_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => design_statement.Value.Token()), new Lazy<IParser<CharToken>>(() => config_rule_statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endconfig", true).Text())).Named("config_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("design_statement#0", (args) => CreateSyntaxNode(true, nameof(design_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("design", true).Text()), new Lazy<IParser<CharToken>>(() => design_statement_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("design_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> design_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("design_statement_many#0", (args) => CreateSyntaxNode(true, nameof(design_statement_many), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("[library_identifier.]").Token()), new Lazy<IParser<CharToken>>(() => cell_identifier.Value.Token())).Named("design_statement_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_rule_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("config_rule_statement#0", (args) => CreateSyntaxNode(true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => default_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => liblist_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("config_rule_statement#1", (args) => CreateSyntaxNode(true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => liblist_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("config_rule_statement#2", (args) => CreateSyntaxNode(true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => inst_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => use_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("config_rule_statement#3", (args) => CreateSyntaxNode(true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => liblist_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("config_rule_statement#4", (args) => CreateSyntaxNode(true, nameof(config_rule_statement), args), new Lazy<IParser<CharToken>>(() => cell_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => use_clause.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))))).Named("config_rule_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> default_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("default_clause#0", (args) => CreateSyntaxNode(true, nameof(default_clause), args), new Lazy<IParser<CharToken>>(() => Parse.String("default", true).Text())).Named("default_clause"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inst_clause#0", (args) => CreateSyntaxNode(true, nameof(inst_clause), args), new Lazy<IParser<CharToken>>(() => Parse.String("instance", true).Text()), new Lazy<IParser<CharToken>>(() => inst_name.Value.Token())).Named("inst_clause"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inst_name#0", (args) => CreateSyntaxNode(true, nameof(inst_name), args), new Lazy<IParser<CharToken>>(() => topmodule_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => inst_name_many.Value.Many(greedy: true).Token())).Named("inst_name"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inst_name_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inst_name_many#0", (args) => CreateSyntaxNode(true, nameof(inst_name_many), args), new Lazy<IParser<CharToken>>(() => Parse.String(".instance_identifier", true).Text())).Named("inst_name_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("cell_clause#0", (args) => CreateSyntaxNode(true, nameof(cell_clause), args), new Lazy<IParser<CharToken>>(() => Parse.String("cell", true).Text()), new Lazy<IParser<CharToken>>(() => cell_clause_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => cell_identifier.Value.Token())).Named("cell_clause"));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_clause_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("cell_clause_optional#0", (args) => CreateSyntaxNode(true, nameof(cell_clause_optional), args), new Lazy<IParser<CharToken>>(() => library_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true))).Named("cell_clause_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> liblist_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("liblist_clause#0", (args) => CreateSyntaxNode(true, nameof(liblist_clause), args), new Lazy<IParser<CharToken>>(() => Parse.String("liblist", true).Text()), new Lazy<IParser<CharToken>>(() => library_identifier.Value.Many(greedy: true).Token())).Named("liblist_clause"));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_clause =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("use_clause#0", (args) => CreateSyntaxNode(true, nameof(use_clause), args), new Lazy<IParser<CharToken>>(() => Parse.String("use", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Regex("[library_identifier.]").Token()), new Lazy<IParser<CharToken>>(() => cell_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => use_config.Value.Optional(greedy: false).Token())).Named("use_clause"));

        public static Lazy<IParser<CharToken, SyntaxNode>> use_config =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("use_config#0", (args) => CreateSyntaxNode(false, nameof(use_config), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', false)), new Lazy<IParser<CharToken>>(() => Parse.String("config", false).Text())).Named("use_config"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_declaration#0", (args) => CreateSyntaxNode(true, nameof(nature_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("nature", true).Text()), new Lazy<IParser<CharToken>>(() => nature_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => nature_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => nature_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => nature_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endnature", true).Text())).Named("nature_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(nature_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => parent_nature.Value.Token())).Named("nature_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(nature_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("nature_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parent_nature =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parent_nature#0", (args) => CreateSyntaxNode(true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parent_nature#1", (args) => CreateSyntaxNode(true, nameof(parent_nature), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value.Token()))).Named("parent_nature"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_item#0", (args) => CreateSyntaxNode(true, nameof(nature_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute.Value.Token())).Named("nature_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_attribute#0", (args) => CreateSyntaxNode(true, nameof(nature_attribute), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => nature_attribute_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("nature_attribute"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_declaration#0", (args) => CreateSyntaxNode(true, nameof(discipline_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("discipline", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => discipline_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => discipline_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("enddiscipline", true).Text())).Named("discipline_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(discipline_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("discipline_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_item#0", (args) => CreateSyntaxNode(true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_binding.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("discipline_item#1", (args) => CreateSyntaxNode(true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => discipline_domain_binding.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("discipline_item#2", (args) => CreateSyntaxNode(true, nameof(discipline_item), args), new Lazy<IParser<CharToken>>(() => nature_attribute_override.Value.Token())))).Named("discipline_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_binding#0", (args) => CreateSyntaxNode(true, nameof(nature_binding), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value.Token()), new Lazy<IParser<CharToken>>(() => nature_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("nature_binding"));

        public static Lazy<IParser<CharToken, SyntaxNode>> potential_or_flow =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("potential_or_flow#0", (args) => CreateSyntaxNode(true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => Parse.String("potential", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("potential_or_flow#1", (args) => CreateSyntaxNode(true, nameof(potential_or_flow), args), new Lazy<IParser<CharToken>>(() => Parse.String("flow", true).Text()))).Named("potential_or_flow"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_domain_binding =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_domain_binding#0", (args) => CreateSyntaxNode(true, nameof(discipline_domain_binding), args), new Lazy<IParser<CharToken>>(() => Parse.String("domain", true).Text()), new Lazy<IParser<CharToken>>(() => discrete_or_continuous.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("discipline_domain_binding"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discrete_or_continuous =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#0", (args) => CreateSyntaxNode(true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => Parse.String("discrete", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("discrete_or_continuous#1", (args) => CreateSyntaxNode(true, nameof(discrete_or_continuous), args), new Lazy<IParser<CharToken>>(() => Parse.String("continuous", true).Text()))).Named("discrete_or_continuous"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_override =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_override#0", (args) => CreateSyntaxNode(true, nameof(nature_attribute_override), args), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => nature_attribute.Value.Token())).Named("nature_attribute_override"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connectrules_declaration#0", (args) => CreateSyntaxNode(true, nameof(connectrules_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("connectrules", true).Text()), new Lazy<IParser<CharToken>>(() => connectrules_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => connectrules_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endconnectrules", true).Text())).Named("connectrules_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connectrules_item#0", (args) => CreateSyntaxNode(true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_insertion.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("connectrules_item#1", (args) => CreateSyntaxNode(true, nameof(connectrules_item), args), new Lazy<IParser<CharToken>>(() => connect_resolution.Value.Token()))).Named("connectrules_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_insertion =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connect_insertion#0", (args) => CreateSyntaxNode(true, nameof(connect_insertion), args), new Lazy<IParser<CharToken>>(() => Parse.String("connect", true).Text()), new Lazy<IParser<CharToken>>(() => connectmodule_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => connect_mode.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => connect_port_overrides.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("connect_insertion"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_mode =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connect_mode#0", (args) => CreateSyntaxNode(true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => Parse.String("merged", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("connect_mode#1", (args) => CreateSyntaxNode(true, nameof(connect_mode), args), new Lazy<IParser<CharToken>>(() => Parse.String("split", true).Text()))).Named("connect_mode"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_port_overrides =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connect_port_overrides#0", (args) => CreateSyntaxNode(true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("connect_port_overrides#1", (args) => CreateSyntaxNode(true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("connect_port_overrides#2", (args) => CreateSyntaxNode(true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("connect_port_overrides#3", (args) => CreateSyntaxNode(true, nameof(connect_port_overrides), args), new Lazy<IParser<CharToken>>(() => Parse.String("inout", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("inout", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()))))).Named("connect_port_overrides"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connect_resolution#0", (args) => CreateSyntaxNode(true, nameof(connect_resolution), args), new Lazy<IParser<CharToken>>(() => Parse.String("connect", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => connect_resolution_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("resolveto", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier_or_exclude.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("connect_resolution"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connect_resolution_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connect_resolution_many#0", (args) => CreateSyntaxNode(true, nameof(connect_resolution_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token())).Named("connect_resolution_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier_or_exclude =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#0", (args) => CreateSyntaxNode(true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("discipline_identifier_or_exclude#1", (args) => CreateSyntaxNode(true, nameof(discipline_identifier_or_exclude), args), new Lazy<IParser<CharToken>>(() => Parse.String("exclude", true).Text()))).Named("discipline_identifier_or_exclude"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_declaration#0", (args) => CreateSyntaxNode(true, nameof(paramset_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("paramset", true).Text()), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => paramset_statement.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endparamset", true).Text())).Named("paramset_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => aliasparam_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#3", (args) => CreateSyntaxNode(true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => integer_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_item_declaration#4", (args) => CreateSyntaxNode(true, nameof(paramset_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => real_declaration.Value.Token())))))).Named("paramset_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_statement#0", (args) => CreateSyntaxNode(true, nameof(paramset_statement), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => module_parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("paramset_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#1", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression#2", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value.Token())))).Named("paramset_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("local_parameter_declaration#0", (args) => CreateSyntaxNode(true, nameof(local_parameter_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("localparam", true).Text()), new Lazy<IParser<CharToken>>(() => local_parameter_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("local_parameter_declaration#1", (args) => CreateSyntaxNode(true, nameof(local_parameter_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("localparam", true).Text()), new Lazy<IParser<CharToken>>(() => parameter_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value.Token()))).Named("local_parameter_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> local_parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("local_parameter_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(local_parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("local_parameter_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_declaration#0", (args) => CreateSyntaxNode(true, nameof(parameter_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("parameter", true).Text()), new Lazy<IParser<CharToken>>(() => parameter_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_declaration#1", (args) => CreateSyntaxNode(true, nameof(parameter_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("parameter", true).Text()), new Lazy<IParser<CharToken>>(() => parameter_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_param_assignments.Value.Token()))).Named("parameter_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(parameter_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("parameter_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specparam_declaration#0", (args) => CreateSyntaxNode(true, nameof(specparam_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("specparam", true).Text()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("specparam_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_type#0", (args) => CreateSyntaxNode(true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_type#1", (args) => CreateSyntaxNode(true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("realtime", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_type#2", (args) => CreateSyntaxNode(true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_type#3", (args) => CreateSyntaxNode(true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_type#4", (args) => CreateSyntaxNode(true, nameof(parameter_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("string", true).Text())))))).Named("parameter_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> aliasparam_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("aliasparam_declaration#0", (args) => CreateSyntaxNode(true, nameof(aliasparam_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("aliasparam", true).Text()), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("aliasparam_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inout_declaration#0", (args) => CreateSyntaxNode(true, nameof(inout_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("inout", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => inout_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => inout_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token())).Named("inout_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("inout_declaration_optional#1", (args) => CreateSyntaxNode(true, nameof(inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("wreal", true).Text()))).Named("inout_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inout_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("inout_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_declaration#0", (args) => CreateSyntaxNode(true, nameof(input_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => input_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => input_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token())).Named("input_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("input_declaration_optional#1", (args) => CreateSyntaxNode(true, nameof(input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("wreal", true).Text()))).Named("input_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("input_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_declaration#0", (args) => CreateSyntaxNode(true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => output_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => output_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("output_declaration#1", (args) => CreateSyntaxNode(true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text()), new Lazy<IParser<CharToken>>(() => output_declaration_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("output_declaration#2", (args) => CreateSyntaxNode(true, nameof(output_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => output_variable_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers.Value.Token())))).Named("output_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("output_declaration_optional#1", (args) => CreateSyntaxNode(true, nameof(output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("wreal", true).Text()))).Named("output_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("output_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_declaration_optional_3#0", (args) => CreateSyntaxNode(true, nameof(output_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("output_declaration_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_declaration#0", (args) => CreateSyntaxNode(true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => branch_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_declaration#1", (args) => CreateSyntaxNode(true, nameof(branch_declaration), args), new Lazy<IParser<CharToken>>(() => port_branch_declaration.Value.Token()))).Named("branch_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(branch_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => branch_terminal.Value.Token())).Named("branch_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_branch_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_branch_declaration#0", (args) => CreateSyntaxNode(true, nameof(port_branch_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("port_branch_declaration#1", (args) => CreateSyntaxNode(true, nameof(port_branch_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("port_branch_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#0", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#1", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#2", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#3", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#4", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_terminal#5", (args) => CreateSyntaxNode(true, nameof(branch_terminal), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()))))))).Named("branch_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_declaration#0", (args) => CreateSyntaxNode(true, nameof(event_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("event", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("event_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> integer_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("integer_declaration#0", (args) => CreateSyntaxNode(true, nameof(integer_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("integer_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration#0", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#1", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#2", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_4.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#3", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => net_type.Value.Token()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_5.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_6.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#4", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("trireg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_7.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#5", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("trireg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_8.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#6", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("trireg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => charge_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_9.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_10.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#7", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("trireg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_11.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => net_declaration_optional_12.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#8", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#9", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#10", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("wreal", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#11", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("wreal", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration#12", (args) => CreateSyntaxNode(true, nameof(net_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("ground", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))))))))))))).Named("net_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.String("vectored", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_3#1", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.String("scalared", true).Text()))).Named("net_declaration_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_4#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("vectored", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_5#1", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("scalared", true).Text()))).Named("net_declaration_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_6#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_6), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_7#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_7), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_8#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_8), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => Parse.String("vectored", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_9#1", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_9), args), new Lazy<IParser<CharToken>>(() => Parse.String("scalared", true).Text()))).Named("net_declaration_optional_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_10#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_10), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => Parse.String("vectored", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_11#1", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_11), args), new Lazy<IParser<CharToken>>(() => Parse.String("scalared", true).Text()))).Named("net_declaration_optional_11"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_declaration_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_declaration_optional_12#0", (args) => CreateSyntaxNode(true, nameof(net_declaration_optional_12), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("net_declaration_optional_12"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_declaration#0", (args) => CreateSyntaxNode(true, nameof(real_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("real_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> realtime_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("realtime_declaration#0", (args) => CreateSyntaxNode(true, nameof(realtime_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("realtime", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("realtime_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("reg_declaration#0", (args) => CreateSyntaxNode(true, nameof(reg_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => reg_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("reg_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> reg_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("reg_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(reg_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("reg_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> time_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("time_declaration#0", (args) => CreateSyntaxNode(true, nameof(time_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("time_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_type#0", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("supply0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#1", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("supply1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#2", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("triand", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#3", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("trior", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#4", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("tri0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#5", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("tri1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#6", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("tri", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#7", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("uwire", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#8", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("wire", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#9", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("wand", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_type#10", (args) => CreateSyntaxNode(true, nameof(net_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("wor", true).Text())))))))))))).Named("net_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_variable_type#0", (args) => CreateSyntaxNode(true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("output_variable_type#1", (args) => CreateSyntaxNode(true, nameof(output_variable_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text()))).Named("output_variable_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_type#0", (args) => CreateSyntaxNode(true, nameof(real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("real_type#1", (args) => CreateSyntaxNode(true, nameof(real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => real_type_optional.Value.Optional(greedy: false).Token()))).Named("real_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_type_optional#0", (args) => CreateSyntaxNode(true, nameof(real_type_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value.Token())).Named("real_type_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_type#0", (args) => CreateSyntaxNode(true, nameof(variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("variable_type#1", (args) => CreateSyntaxNode(true, nameof(variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => variable_type_optional.Value.Optional(greedy: false).Token()))).Named("variable_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_type_optional#0", (args) => CreateSyntaxNode(true, nameof(variable_type_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value.Token())).Named("variable_type_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> drive_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("drive_strength#0", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("drive_strength#1", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("drive_strength#2", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("highz1", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("drive_strength#3", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("highz0", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("drive_strength#4", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("highz0", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("drive_strength#5", (args) => CreateSyntaxNode(true, nameof(drive_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("highz1", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))))))).Named("drive_strength"));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("strength0#0", (args) => CreateSyntaxNode(true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => Parse.String("supply0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength0#1", (args) => CreateSyntaxNode(true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => Parse.String("strong0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength0#2", (args) => CreateSyntaxNode(true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => Parse.String("pull0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength0#3", (args) => CreateSyntaxNode(true, nameof(strength0), args), new Lazy<IParser<CharToken>>(() => Parse.String("weak0", true).Text()))))).Named("strength0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> strength1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("strength1#0", (args) => CreateSyntaxNode(true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => Parse.String("supply1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength1#1", (args) => CreateSyntaxNode(true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => Parse.String("strong1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength1#2", (args) => CreateSyntaxNode(true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => Parse.String("pull1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("strength1#3", (args) => CreateSyntaxNode(true, nameof(strength1), args), new Lazy<IParser<CharToken>>(() => Parse.String("weak1", true).Text()))))).Named("strength1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> charge_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("charge_strength#0", (args) => CreateSyntaxNode(true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("small", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("charge_strength#1", (args) => CreateSyntaxNode(true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("medium", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("charge_strength#2", (args) => CreateSyntaxNode(true, nameof(charge_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("large", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))).Named("charge_strength"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay3#0", (args) => CreateSyntaxNode(true, nameof(delay3), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => delay_value.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay3#1", (args) => CreateSyntaxNode(true, nameof(delay3), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("delay3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay3_optional#0", (args) => CreateSyntaxNode(true, nameof(delay3_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3_optional_2.Value.Optional(greedy: false).Token())).Named("delay3_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay3_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay3_optional_2#0", (args) => CreateSyntaxNode(true, nameof(delay3_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("delay3_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay2#0", (args) => CreateSyntaxNode(true, nameof(delay2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => delay_value.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay2#1", (args) => CreateSyntaxNode(true, nameof(delay2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => delay2_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("delay2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay2_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay2_optional#0", (args) => CreateSyntaxNode(true, nameof(delay2_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("delay2_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay_value#0", (args) => CreateSyntaxNode(true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay_value#1", (args) => CreateSyntaxNode(true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => real_number.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay_value#2", (args) => CreateSyntaxNode(true, nameof(delay_value), args), new Lazy<IParser<CharToken>>(() => identifier.Value.Token())))).Named("delay_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_branch_identifiers), args), new Lazy<IParser<CharToken>>(() => branch_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_branch_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_branch_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_branch_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_branch_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_branch_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => branch_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token())).Named("list_of_branch_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_defparam_assignments), args), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_defparam_assignments_many.Value.Many(greedy: true).Token())).Named("list_of_defparam_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_defparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_defparam_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_defparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => defparam_assignment.Value.Token())).Named("list_of_defparam_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_event_identifiers), args), new Lazy<IParser<CharToken>>(() => event_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => list_of_event_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_event_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_event_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_event_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_event_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => event_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token())).Named("list_of_event_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_decl_assignments), args), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_net_decl_assignments_many.Value.Many(greedy: true).Token())).Named("list_of_net_decl_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_decl_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_decl_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_decl_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => net_decl_assignment.Value.Token())).Named("list_of_net_decl_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_identifiers), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_net_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_net_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value.Token())).Named("list_of_net_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_param_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_param_assignments), args), new Lazy<IParser<CharToken>>(() => param_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_param_assignments_many.Value.Many(greedy: true).Token())).Named("list_of_param_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_param_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_param_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_param_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => param_assignment.Value.Token())).Named("list_of_param_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_port_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token())).Named("list_of_port_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_real_identifiers), args), new Lazy<IParser<CharToken>>(() => real_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_real_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_real_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_real_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => real_type.Value.Token())).Named("list_of_real_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_specparam_assignments), args), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_specparam_assignments_many.Value.Many(greedy: true).Token())).Named("list_of_specparam_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_specparam_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_specparam_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_specparam_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => specparam_assignment.Value.Token())).Named("list_of_specparam_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => variable_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_variable_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => variable_type.Value.Token())).Named("list_of_variable_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_port_identifiers), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_variable_port_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_port_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_variable_port_identifiers_optional_2.Value.Optional(greedy: false).Token())).Named("list_of_variable_port_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_port_identifiers_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("list_of_variable_port_identifiers_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_variable_port_identifiers_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_variable_port_identifiers_optional_2#0", (args) => CreateSyntaxNode(true, nameof(list_of_variable_port_identifiers_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("list_of_variable_port_identifiers_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> defparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("defparam_assignment#0", (args) => CreateSyntaxNode(true, nameof(defparam_assignment), args), new Lazy<IParser<CharToken>>(() => hierarchical_parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token())).Named("defparam_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_decl_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_decl_assignment#0", (args) => CreateSyntaxNode(true, nameof(net_decl_assignment), args), new Lazy<IParser<CharToken>>(() => ams_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("net_decl_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> param_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("param_assignment#0", (args) => CreateSyntaxNode(true, nameof(param_assignment), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true).Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("param_assignment#1", (args) => CreateSyntaxNode(true, nameof(param_assignment), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value.Token()), new Lazy<IParser<CharToken>>(() => value_range.Value.Many(greedy: true).Token()))).Named("param_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specparam_assignment#0", (args) => CreateSyntaxNode(true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("specparam_assignment#1", (args) => CreateSyntaxNode(true, nameof(specparam_assignment), args), new Lazy<IParser<CharToken>>(() => pulse_control_specparam.Value.Token()))).Named("specparam_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pulse_control_specparam#0", (args) => CreateSyntaxNode(true, nameof(pulse_control_specparam), args), new Lazy<IParser<CharToken>>(() => Parse.String("PATHPULSE$", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value.Token()), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("pulse_control_specparam#1", (args) => CreateSyntaxNode(true, nameof(pulse_control_specparam), args), new Lazy<IParser<CharToken>>(() => Parse.String("PATHPULSE$", true).Text()), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("$specify_output_terminal_descriptor", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reject_limit_value.Value.Token()), new Lazy<IParser<CharToken>>(() => pulse_control_specparam_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("pulse_control_specparam"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional#0", (args) => CreateSyntaxNode(true, nameof(pulse_control_specparam_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => error_limit_value.Value.Token())).Named("pulse_control_specparam_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulse_control_specparam_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pulse_control_specparam_optional_2#0", (args) => CreateSyntaxNode(true, nameof(pulse_control_specparam_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => error_limit_value.Value.Token())).Named("pulse_control_specparam_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> error_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("error_limit_value#0", (args) => CreateSyntaxNode(true, nameof(error_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value.Token())).Named("error_limit_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> reject_limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("reject_limit_value#0", (args) => CreateSyntaxNode(true, nameof(reject_limit_value), args), new Lazy<IParser<CharToken>>(() => limit_value.Value.Token())).Named("reject_limit_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> limit_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("limit_value#0", (args) => CreateSyntaxNode(true, nameof(limit_value), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token())).Named("limit_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("dimension#0", (args) => CreateSyntaxNode(true, nameof(dimension), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => dimension_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("dimension"));

        public static Lazy<IParser<CharToken, SyntaxNode>> range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("range#0", (args) => CreateSyntaxNode(true, nameof(range), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("range"));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("value_range#0", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range#1", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range#2", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range#3", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => value_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range#4", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => value_range_type.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => @string.Value.Token()), new Lazy<IParser<CharToken>>(() => value_range_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range#5", (args) => CreateSyntaxNode(true, nameof(value_range), args), new Lazy<IParser<CharToken>>(() => Parse.String("exclude", true).Text()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))))))).Named("value_range"));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("value_range_many#0", (args) => CreateSyntaxNode(true, nameof(value_range_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => @string.Value.Token())).Named("value_range_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("value_range_type#0", (args) => CreateSyntaxNode(true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("from", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("value_range_type#1", (args) => CreateSyntaxNode(true, nameof(value_range_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("exclude", true).Text()))).Named("value_range_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> value_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("value_range_expression#0", (args) => CreateSyntaxNode(true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("-inf", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range_expression#1", (args) => CreateSyntaxNode(true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("inf", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("value_range_expression#2", (args) => CreateSyntaxNode(true, nameof(value_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())))).Named("value_range_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_declaration#0", (args) => CreateSyntaxNode(true, nameof(analog_function_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("analog", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.String("function", true).Text()), new Lazy<IParser<CharToken>>(() => analog_function_type.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_function_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endfunction", true).Text())).Named("analog_function_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_type#0", (args) => CreateSyntaxNode(true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_type#1", (args) => CreateSyntaxNode(true, nameof(analog_function_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()))).Named("analog_function_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => output_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_item_declaration#3", (args) => CreateSyntaxNode(true, nameof(analog_function_item_declaration), args), new Lazy<IParser<CharToken>>(() => inout_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))))).Named("analog_function_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_declaration#0", (args) => CreateSyntaxNode(true, nameof(function_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("function", true).Text()), new Lazy<IParser<CharToken>>(() => function_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => function_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => function_statement.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endfunction", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_declaration#1", (args) => CreateSyntaxNode(true, nameof(function_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("function", true).Text()), new Lazy<IParser<CharToken>>(() => function_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => function_range_or_type.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => function_port_list.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => function_statement.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endfunction", true).Text()))).Named("function_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(function_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("automatic", true).Text())).Named("function_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(function_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("automatic", true).Text())).Named("function_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(function_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("function_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_port_list#0", (args) => CreateSyntaxNode(true, nameof(function_port_list), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => function_port_list_many.Value.Many(greedy: true).Token())).Named("function_port_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_port_list_many#0", (args) => CreateSyntaxNode(true, nameof(function_port_list_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value.Token())).Named("function_port_list_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type#0", (args) => CreateSyntaxNode(true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => function_range_or_type_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type#1", (args) => CreateSyntaxNode(true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type#2", (args) => CreateSyntaxNode(true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type#3", (args) => CreateSyntaxNode(true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("realtime", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type#4", (args) => CreateSyntaxNode(true, nameof(function_range_or_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text())))))).Named("function_range_or_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_range_or_type_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_range_or_type_optional#0", (args) => CreateSyntaxNode(true, nameof(function_range_or_type_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("function_range_or_type_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_declaration#0", (args) => CreateSyntaxNode(true, nameof(task_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("task", true).Text()), new Lazy<IParser<CharToken>>(() => task_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => task_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endtask", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_declaration#1", (args) => CreateSyntaxNode(true, nameof(task_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("task", true).Text()), new Lazy<IParser<CharToken>>(() => task_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => task_port_list.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endtask", true).Text()))).Named("task_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(task_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("automatic", true).Text())).Named("task_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(task_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("automatic", true).Text())).Named("task_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_item_declaration#3", (args) => CreateSyntaxNode(true, nameof(task_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))))).Named("task_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_port_list#0", (args) => CreateSyntaxNode(true, nameof(task_port_list), args), new Lazy<IParser<CharToken>>(() => task_port_item.Value.Token()), new Lazy<IParser<CharToken>>(() => task_port_list_many.Value.Many(greedy: true).Token())).Named("task_port_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_port_list_many#0", (args) => CreateSyntaxNode(true, nameof(task_port_list_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => task_port_item.Value.Token())).Named("task_port_list_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_port_item#0", (args) => CreateSyntaxNode(true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_port_item#1", (args) => CreateSyntaxNode(true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_output_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_port_item#2", (args) => CreateSyntaxNode(true, nameof(task_port_item), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => tf_inout_declaration.Value.Token())))).Named("task_port_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_input_declaration#0", (args) => CreateSyntaxNode(true, nameof(tf_input_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_input_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("tf_input_declaration#1", (args) => CreateSyntaxNode(true, nameof(tf_input_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => task_port_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))).Named("tf_input_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(tf_input_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text())).Named("tf_input_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_input_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_input_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(tf_input_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("tf_input_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_output_declaration#0", (args) => CreateSyntaxNode(true, nameof(tf_output_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_output_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("tf_output_declaration#1", (args) => CreateSyntaxNode(true, nameof(tf_output_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => task_port_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))).Named("tf_output_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(tf_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text())).Named("tf_output_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_output_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_output_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(tf_output_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("tf_output_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_inout_declaration#0", (args) => CreateSyntaxNode(true, nameof(tf_inout_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("inout", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => tf_inout_declaration_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("tf_inout_declaration#1", (args) => CreateSyntaxNode(true, nameof(tf_inout_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("inout", true).Text()), new Lazy<IParser<CharToken>>(() => task_port_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token()))).Named("tf_inout_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(tf_inout_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text())).Named("tf_inout_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tf_inout_declaration_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tf_inout_declaration_optional_2#0", (args) => CreateSyntaxNode(true, nameof(tf_inout_declaration_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("tf_inout_declaration_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_port_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_port_type#0", (args) => CreateSyntaxNode(true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_port_type#1", (args) => CreateSyntaxNode(true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("realtime", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_port_type#2", (args) => CreateSyntaxNode(true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("task_port_type#3", (args) => CreateSyntaxNode(true, nameof(task_port_type), args), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text()))))).Named("task_port_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => integer_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_block_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(analog_block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => real_declaration.Value.Token())))).Named("analog_block_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#0", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => block_item_declaration_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#1", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("integer", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#2", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("time", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#3", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("real", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#4", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("realtime", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#5", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => event_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#6", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => local_parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration#7", (args) => CreateSyntaxNode(true, nameof(block_item_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => parameter_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))))))))).Named("block_item_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_item_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("block_item_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(block_item_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("signed", true).Text())).Named("block_item_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_block_variable_identifiers), args), new Lazy<IParser<CharToken>>(() => block_variable_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_block_variable_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_block_variable_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_variable_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_block_variable_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_block_variable_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => block_variable_type.Value.Token())).Named("list_of_block_variable_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_block_real_identifiers), args), new Lazy<IParser<CharToken>>(() => block_real_type.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_block_real_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_block_real_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_block_real_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_block_real_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_block_real_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => block_real_type.Value.Token())).Named("list_of_block_real_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_variable_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("block_variable_type#0", (args) => CreateSyntaxNode(true, nameof(block_variable_type), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token())).Named("block_variable_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_real_type =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("block_real_type#0", (args) => CreateSyntaxNode(true, nameof(block_real_type), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token())).Named("block_real_type"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => cmos_switchtype.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#1", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => enable_gatetype.Value.Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_2.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#2", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => mos_switchtype.Value.Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_3.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#3", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_input_gatetype.Value.Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_4.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#4", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => n_output_gatetype.Value.Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_5.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#5", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_en_switchtype.Value.Token()), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_6.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#6", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => pass_switchtype.Value.Token()), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_7.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#7", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => Parse.String("pulldown", true).Text()), new Lazy<IParser<CharToken>>(() => pulldown_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_8.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation#8", (args) => CreateSyntaxNode(true, nameof(gate_instantiation), args), new Lazy<IParser<CharToken>>(() => Parse.String("pullup", true).Text()), new Lazy<IParser<CharToken>>(() => pullup_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => gate_instantiation_many_9.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))))))))).Named("gate_instantiation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => cmos_switch_instance.Value.Token())).Named("gate_instantiation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_2#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => enable_gate_instance.Value.Token())).Named("gate_instantiation_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_3#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => mos_switch_instance.Value.Token())).Named("gate_instantiation_many_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_4#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => n_input_gate_instance.Value.Token())).Named("gate_instantiation_many_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_5#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => n_output_gate_instance.Value.Token())).Named("gate_instantiation_many_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_6#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => pass_enable_switch_instance.Value.Token())).Named("gate_instantiation_many_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_7#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => pass_switch_instance.Value.Token())).Named("gate_instantiation_many_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_8#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_8), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value.Token())).Named("gate_instantiation_many_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instantiation_many_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instantiation_many_9#0", (args) => CreateSyntaxNode(true, nameof(gate_instantiation_many_9), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => pull_gate_instance.Value.Token())).Named("gate_instantiation_many_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("cmos_switch_instance#0", (args) => CreateSyntaxNode(true, nameof(cmos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => ncontrol_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => pcontrol_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("cmos_switch_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("enable_gate_instance#0", (args) => CreateSyntaxNode(true, nameof(enable_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => enable_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("enable_gate_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("mos_switch_instance#0", (args) => CreateSyntaxNode(true, nameof(mos_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => enable_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("mos_switch_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_input_gate_instance#0", (args) => CreateSyntaxNode(true, nameof(n_input_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => n_input_gate_instance_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("n_input_gate_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_input_gate_instance_many#0", (args) => CreateSyntaxNode(true, nameof(n_input_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token())).Named("n_input_gate_instance_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_output_gate_instance#0", (args) => CreateSyntaxNode(true, nameof(n_output_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => n_output_gate_instance_many.Value.Many(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("n_output_gate_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gate_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_output_gate_instance_many#0", (args) => CreateSyntaxNode(true, nameof(n_output_gate_instance_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token())).Named("n_output_gate_instance_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pass_switch_instance#0", (args) => CreateSyntaxNode(true, nameof(pass_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => inout_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => inout_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("pass_switch_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_enable_switch_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pass_enable_switch_instance#0", (args) => CreateSyntaxNode(true, nameof(pass_enable_switch_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => inout_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => inout_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => enable_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("pass_enable_switch_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pull_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pull_gate_instance#0", (args) => CreateSyntaxNode(true, nameof(pull_gate_instance), args), new Lazy<IParser<CharToken>>(() => name_of_gate_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("pull_gate_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_gate_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("name_of_gate_instance#0", (args) => CreateSyntaxNode(true, nameof(name_of_gate_instance), args), new Lazy<IParser<CharToken>>(() => gate_instance_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token())).Named("name_of_gate_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulldown_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pulldown_strength#0", (args) => CreateSyntaxNode(true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pulldown_strength#1", (args) => CreateSyntaxNode(true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pulldown_strength#2", (args) => CreateSyntaxNode(true, nameof(pulldown_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))).Named("pulldown_strength"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pullup_strength =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pullup_strength#0", (args) => CreateSyntaxNode(true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pullup_strength#1", (args) => CreateSyntaxNode(true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => strength0.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pullup_strength#2", (args) => CreateSyntaxNode(true, nameof(pullup_strength), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => strength1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))).Named("pullup_strength"));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("enable_terminal#0", (args) => CreateSyntaxNode(true, nameof(enable_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("enable_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inout_terminal#0", (args) => CreateSyntaxNode(true, nameof(inout_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token())).Named("inout_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_terminal#0", (args) => CreateSyntaxNode(true, nameof(input_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("input_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> ncontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("ncontrol_terminal#0", (args) => CreateSyntaxNode(true, nameof(ncontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("ncontrol_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_terminal#0", (args) => CreateSyntaxNode(true, nameof(output_terminal), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token())).Named("output_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pcontrol_terminal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pcontrol_terminal#0", (args) => CreateSyntaxNode(true, nameof(pcontrol_terminal), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("pcontrol_terminal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> cmos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("cmos_switchtype#0", (args) => CreateSyntaxNode(true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("cmos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("cmos_switchtype#1", (args) => CreateSyntaxNode(true, nameof(cmos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rcmos", true).Text()))).Named("cmos_switchtype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> enable_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("enable_gatetype#0", (args) => CreateSyntaxNode(true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("bufif0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("enable_gatetype#1", (args) => CreateSyntaxNode(true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("bufif1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("enable_gatetype#2", (args) => CreateSyntaxNode(true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("notif0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("enable_gatetype#3", (args) => CreateSyntaxNode(true, nameof(enable_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("notif1", true).Text()))))).Named("enable_gatetype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> mos_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("mos_switchtype#0", (args) => CreateSyntaxNode(true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("nmos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("mos_switchtype#1", (args) => CreateSyntaxNode(true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("pmos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("mos_switchtype#2", (args) => CreateSyntaxNode(true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rnmos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("mos_switchtype#3", (args) => CreateSyntaxNode(true, nameof(mos_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rpmos", true).Text()))))).Named("mos_switchtype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_input_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#0", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("and", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#1", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("nand", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#2", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("or", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#3", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("nor", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#4", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("xor", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_input_gatetype#5", (args) => CreateSyntaxNode(true, nameof(n_input_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("xnor", true).Text()))))))).Named("n_input_gatetype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> n_output_gatetype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("n_output_gatetype#0", (args) => CreateSyntaxNode(true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("buf", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("n_output_gatetype#1", (args) => CreateSyntaxNode(true, nameof(n_output_gatetype), args), new Lazy<IParser<CharToken>>(() => Parse.String("not", true).Text()))).Named("n_output_gatetype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_en_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#0", (args) => CreateSyntaxNode(true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("tranif0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#1", (args) => CreateSyntaxNode(true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("tranif1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#2", (args) => CreateSyntaxNode(true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rtranif1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pass_en_switchtype#3", (args) => CreateSyntaxNode(true, nameof(pass_en_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rtranif0", true).Text()))))).Named("pass_en_switchtype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pass_switchtype =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pass_switchtype#0", (args) => CreateSyntaxNode(true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("tran", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pass_switchtype#1", (args) => CreateSyntaxNode(true, nameof(pass_switchtype), args), new Lazy<IParser<CharToken>>(() => Parse.String("rtran", true).Text()))).Named("pass_switchtype"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_instantiation#0", (args) => CreateSyntaxNode(true, nameof(module_instantiation), args), new Lazy<IParser<CharToken>>(() => module_or_paramset_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => parameter_value_assignment.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => module_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => module_instantiation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("module_instantiation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_instantiation_many#0", (args) => CreateSyntaxNode(true, nameof(module_instantiation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => module_instance.Value.Token())).Named("module_instantiation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_value_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_value_assignment#0", (args) => CreateSyntaxNode(true, nameof(parameter_value_assignment), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("parameter_value_assignment#1", (args) => CreateSyntaxNode(true, nameof(parameter_value_assignment), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("parameter_value_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments#1", (args) => CreateSyntaxNode(true, nameof(list_of_parameter_assignments), args), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_parameter_assignments_many_2.Value.Many(greedy: true).Token()))).Named("list_of_parameter_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_parameter_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => ordered_parameter_assignment.Value.Token())).Named("list_of_parameter_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_parameter_assignments_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_parameter_assignments_many_2#0", (args) => CreateSyntaxNode(true, nameof(list_of_parameter_assignments_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => named_parameter_assignment.Value.Token())).Named("list_of_parameter_assignments_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("ordered_parameter_assignment#0", (args) => CreateSyntaxNode(true, nameof(ordered_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("ordered_parameter_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_parameter_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("named_parameter_assignment#0", (args) => CreateSyntaxNode(true, nameof(named_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("named_parameter_assignment#1", (args) => CreateSyntaxNode(true, nameof(named_parameter_assignment), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("named_parameter_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_instance#0", (args) => CreateSyntaxNode(true, nameof(module_instance), args), new Lazy<IParser<CharToken>>(() => name_of_module_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => module_instance_optional.Value.Optional(greedy: false).Token())).Named("module_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_instance_optional#0", (args) => CreateSyntaxNode(true, nameof(module_instance_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => list_of_port_connections.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("module_instance_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_module_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("name_of_module_instance#0", (args) => CreateSyntaxNode(true, nameof(name_of_module_instance), args), new Lazy<IParser<CharToken>>(() => module_instance_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token())).Named("name_of_module_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_connections#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_port_connections#1", (args) => CreateSyntaxNode(true, nameof(list_of_port_connections), args), new Lazy<IParser<CharToken>>(() => named_port_connection.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_port_connections_many_2.Value.Many(greedy: true).Token()))).Named("list_of_port_connections"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_connections_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => ordered_port_connection.Value.Token())).Named("list_of_port_connections_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_port_connections_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_port_connections_many_2#0", (args) => CreateSyntaxNode(true, nameof(list_of_port_connections_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => named_port_connection.Value.Token())).Named("list_of_port_connections_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> ordered_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("ordered_port_connection#0", (args) => CreateSyntaxNode(true, nameof(ordered_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("ordered_port_connection"));

        public static Lazy<IParser<CharToken, SyntaxNode>> named_port_connection =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("named_port_connection#0", (args) => CreateSyntaxNode(true, nameof(named_port_connection), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("named_port_connection"));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_region =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("generate_region#0", (args) => CreateSyntaxNode(true, nameof(generate_region), args), new Lazy<IParser<CharToken>>(() => Parse.String("generate", true).Text()), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endgenerate", true).Text())).Named("generate_region"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_declaration#0", (args) => CreateSyntaxNode(true, nameof(genvar_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("genvar", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("genvar_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers#0", (args) => CreateSyntaxNode(true, nameof(list_of_genvar_identifiers), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_genvar_identifiers_many.Value.Many(greedy: true).Token())).Named("list_of_genvar_identifiers"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_genvar_identifiers_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_genvar_identifiers_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_genvar_identifiers_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token())).Named("list_of_genvar_identifiers_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_generate_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_loop_generate_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_loop_generate_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token())).Named("analog_loop_generate_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("loop_generate_construct#0", (args) => CreateSyntaxNode(true, nameof(loop_generate_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => genvar_initialization.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => genvar_iteration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => generate_block.Value.Token())).Named("loop_generate_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_initialization =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_initialization#0", (args) => CreateSyntaxNode(true, nameof(genvar_initialization), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("genvar_initialization"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_expression#0", (args) => CreateSyntaxNode(true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => genvar_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("genvar_expression#1", (args) => CreateSyntaxNode(true, nameof(genvar_expression), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => genvar_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value.Token()))).Named("genvar_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_iteration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_iteration#0", (args) => CreateSyntaxNode(true, nameof(genvar_iteration), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token())).Named("genvar_iteration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_primary#0", (args) => CreateSyntaxNode(true, nameof(genvar_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token())).Named("genvar_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#0", (args) => CreateSyntaxNode(true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => if_generate_construct.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("conditional_generate_construct#1", (args) => CreateSyntaxNode(true, nameof(conditional_generate_construct), args), new Lazy<IParser<CharToken>>(() => case_generate_construct.Value.Token()))).Named("conditional_generate_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("if_generate_construct#0", (args) => CreateSyntaxNode(true, nameof(if_generate_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => if_generate_construct_else.Value.Optional(greedy: true).Token())).Named("if_generate_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_generate_construct_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("if_generate_construct_else#0", (args) => CreateSyntaxNode(true, nameof(if_generate_construct_else), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value.Token())).Named("if_generate_construct_else"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_generate_construct#0", (args) => CreateSyntaxNode(true, nameof(case_generate_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("case", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => case_generate_item.Value.Token()), new Lazy<IParser<CharToken>>(() => case_generate_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text())).Named("case_generate_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_generate_item#0", (args) => CreateSyntaxNode(true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => case_generate_item_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("case_generate_item#1", (args) => CreateSyntaxNode(true, nameof(case_generate_item), args), new Lazy<IParser<CharToken>>(() => Parse.String("default", true).Text()), new Lazy<IParser<CharToken>>(() => case_generate_item_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => generate_block_or_null.Value.Token()))).Named("case_generate_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_generate_item_many#0", (args) => CreateSyntaxNode(true, nameof(case_generate_item_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("case_generate_item_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_generate_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_generate_item_optional#0", (args) => CreateSyntaxNode(true, nameof(case_generate_item_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true))).Named("case_generate_item_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("generate_block#0", (args) => CreateSyntaxNode(true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("generate_block#1", (args) => CreateSyntaxNode(true, nameof(generate_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("begin", true).Text()), new Lazy<IParser<CharToken>>(() => generate_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => module_or_generate_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("end", true).Text()))).Named("generate_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("generate_block_optional#0", (args) => CreateSyntaxNode(true, nameof(generate_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => generate_block_identifier.Value.Token())).Named("generate_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("generate_block_or_null#0", (args) => CreateSyntaxNode(true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => generate_block.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("generate_block_or_null#1", (args) => CreateSyntaxNode(true, nameof(generate_block_or_null), args), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("generate_block_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_declaration#0", (args) => CreateSyntaxNode(true, nameof(udp_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("primitive", true).Text()), new Lazy<IParser<CharToken>>(() => udp_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => udp_port_list.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_port_declaration.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => udp_body.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endprimitive", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("udp_declaration#1", (args) => CreateSyntaxNode(true, nameof(udp_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("primitive", true).Text()), new Lazy<IParser<CharToken>>(() => udp_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => udp_body.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endprimitive", true).Text()))).Named("udp_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_port_list#0", (args) => CreateSyntaxNode(true, nameof(udp_port_list), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_port_list_many.Value.Many(greedy: true).Token())).Named("udp_port_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_port_list_many#0", (args) => CreateSyntaxNode(true, nameof(udp_port_list_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value.Token())).Named("udp_port_list_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list#0", (args) => CreateSyntaxNode(true, nameof(udp_declaration_port_list), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_declaration_port_list_many.Value.Many(greedy: true).Token())).Named("udp_declaration_port_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_declaration_port_list_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_declaration_port_list_many#0", (args) => CreateSyntaxNode(true, nameof(udp_declaration_port_list_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value.Token())).Named("udp_declaration_port_list_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_port_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_port_declaration#0", (args) => CreateSyntaxNode(true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_output_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("udp_port_declaration#1", (args) => CreateSyntaxNode(true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_input_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("udp_port_declaration#2", (args) => CreateSyntaxNode(true, nameof(udp_port_declaration), args), new Lazy<IParser<CharToken>>(() => udp_reg_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))).Named("udp_port_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_output_declaration#0", (args) => CreateSyntaxNode(true, nameof(udp_output_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("udp_output_declaration#1", (args) => CreateSyntaxNode(true, nameof(udp_output_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("output", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text()), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_output_declaration_optional.Value.Optional(greedy: false).Token()))).Named("udp_output_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_output_declaration_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_output_declaration_optional#0", (args) => CreateSyntaxNode(true, nameof(udp_output_declaration_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("udp_output_declaration_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_input_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_input_declaration#0", (args) => CreateSyntaxNode(true, nameof(udp_input_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("input", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_port_identifiers.Value.Token())).Named("udp_input_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_reg_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_reg_declaration#0", (args) => CreateSyntaxNode(true, nameof(udp_reg_declaration), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("reg", true).Text()), new Lazy<IParser<CharToken>>(() => discipline_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token())).Named("udp_reg_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_body#0", (args) => CreateSyntaxNode(true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => combinational_body.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("udp_body#1", (args) => CreateSyntaxNode(true, nameof(udp_body), args), new Lazy<IParser<CharToken>>(() => sequential_body.Value.Token()))).Named("udp_body"));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("combinational_body#0", (args) => CreateSyntaxNode(true, nameof(combinational_body), args), new Lazy<IParser<CharToken>>(() => Parse.String("table", true).Text()), new Lazy<IParser<CharToken>>(() => combinational_entry.Value.Token()), new Lazy<IParser<CharToken>>(() => combinational_entry.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endtable", true).Text())).Named("combinational_body"));

        public static Lazy<IParser<CharToken, SyntaxNode>> combinational_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("combinational_entry#0", (args) => CreateSyntaxNode(true, nameof(combinational_entry), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => output_symbol.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("combinational_entry"));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_body =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("sequential_body#0", (args) => CreateSyntaxNode(true, nameof(sequential_body), args), new Lazy<IParser<CharToken>>(() => udp_initial_statement.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("table", true).Text()), new Lazy<IParser<CharToken>>(() => sequential_entry.Value.Token()), new Lazy<IParser<CharToken>>(() => sequential_entry.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endtable", true).Text())).Named("sequential_body"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_initial_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_initial_statement#0", (args) => CreateSyntaxNode(true, nameof(udp_initial_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("initial", true).Text()), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => init_val.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("udp_initial_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> init_val =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("init_val#0", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'b0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#1", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'b1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#2", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'bx", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#3", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'bX", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#4", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'B0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#5", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'B1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#6", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'Bx", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#7", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'BX", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#8", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("init_val#9", (args) => CreateSyntaxNode(true, nameof(init_val), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', true)))))))))))).Named("init_val"));

        public static Lazy<IParser<CharToken, SyntaxNode>> sequential_entry =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("sequential_entry#0", (args) => CreateSyntaxNode(true, nameof(sequential_entry), args), new Lazy<IParser<CharToken>>(() => seq_input_list.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => current_state.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => next_state.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("sequential_entry"));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("seq_input_list#0", (args) => CreateSyntaxNode(true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => level_input_list.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("seq_input_list#1", (args) => CreateSyntaxNode(true, nameof(seq_input_list), args), new Lazy<IParser<CharToken>>(() => edge_input_list.Value.Token()))).Named("seq_input_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("level_input_list#0", (args) => CreateSyntaxNode(true, nameof(level_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Token()), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true).Token())).Named("level_input_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_input_list =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_input_list#0", (args) => CreateSyntaxNode(true, nameof(edge_input_list), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => edge_indicator.Value.Token()), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Many(greedy: true).Token())).Named("edge_input_list"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_indicator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_indicator#0", (args) => CreateSyntaxNode(true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Token()), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("edge_indicator#1", (args) => CreateSyntaxNode(true, nameof(edge_indicator), args), new Lazy<IParser<CharToken>>(() => edge_symbol.Value.Token()))).Named("edge_indicator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> current_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("current_state#0", (args) => CreateSyntaxNode(true, nameof(current_state), args), new Lazy<IParser<CharToken>>(() => level_symbol.Value.Token())).Named("current_state"));

        public static Lazy<IParser<CharToken, SyntaxNode>> next_state =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("next_state#0", (args) => CreateSyntaxNode(true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => output_symbol.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("next_state#1", (args) => CreateSyntaxNode(true, nameof(next_state), args), new Lazy<IParser<CharToken>>(() => Parse.Char('-', true)))).Named("next_state"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_symbol#0", (args) => CreateSyntaxNode(true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("output_symbol#1", (args) => CreateSyntaxNode(true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("output_symbol#2", (args) => CreateSyntaxNode(true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('x', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("output_symbol#3", (args) => CreateSyntaxNode(true, nameof(output_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('X', true)))))).Named("output_symbol"));

        public static Lazy<IParser<CharToken, SyntaxNode>> level_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("level_symbol#0", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#1", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#2", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('x', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#3", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('X', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#4", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#5", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('b', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("level_symbol#6", (args) => CreateSyntaxNode(true, nameof(level_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('B', true))))))))).Named("level_symbol"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_symbol =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#0", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('r', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#1", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('R', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#2", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('f', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#3", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('F', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#4", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('p', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#5", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('P', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#6", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('n', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#7", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('N', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_symbol#8", (args) => CreateSyntaxNode(true, nameof(edge_symbol), args), new Lazy<IParser<CharToken>>(() => Parse.Char('*', true))))))))))).Named("edge_symbol"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_instantiation#0", (args) => CreateSyntaxNode(true, nameof(udp_instantiation), args), new Lazy<IParser<CharToken>>(() => udp_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => udp_instance.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_instantiation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("udp_instantiation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instantiation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_instantiation_many#0", (args) => CreateSyntaxNode(true, nameof(udp_instantiation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => udp_instance.Value.Token())).Named("udp_instantiation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_instance#0", (args) => CreateSyntaxNode(true, nameof(udp_instance), args), new Lazy<IParser<CharToken>>(() => name_of_udp_instance.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => output_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => udp_instance_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("udp_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_instance_many#0", (args) => CreateSyntaxNode(true, nameof(udp_instance_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => input_terminal.Value.Token())).Named("udp_instance_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> name_of_udp_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("name_of_udp_instance#0", (args) => CreateSyntaxNode(true, nameof(name_of_udp_instance), args), new Lazy<IParser<CharToken>>(() => udp_instance_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => range.Value.Optional(greedy: false).Token())).Named("name_of_udp_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> continuous_assign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("continuous_assign#0", (args) => CreateSyntaxNode(true, nameof(continuous_assign), args), new Lazy<IParser<CharToken>>(() => Parse.String("assign", true).Text()), new Lazy<IParser<CharToken>>(() => drive_strength.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => delay3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_net_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("continuous_assign"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_assignments#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_assignments), args), new Lazy<IParser<CharToken>>(() => net_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_net_assignments_many.Value.Many(greedy: true).Token())).Named("list_of_net_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_net_assignments_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_net_assignments_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_net_assignments_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => net_assignment.Value.Token())).Named("list_of_net_assignments_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_assignment#0", (args) => CreateSyntaxNode(true, nameof(net_assignment), args), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("net_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_construct#0", (args) => CreateSyntaxNode(true, nameof(analog_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("analog", true).Text()), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_construct#1", (args) => CreateSyntaxNode(true, nameof(analog_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("analog", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.String("initial", true).Text()), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Token()))).Named("analog_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_procedural_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_procedural_assignment#0", (args) => CreateSyntaxNode(true, nameof(analog_procedural_assignment), args), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("analog_procedural_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#0", (args) => CreateSyntaxNode(true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_variable_assignment#1", (args) => CreateSyntaxNode(true, nameof(analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => array_analog_variable_assignment.Value.Token()))).Named("analog_variable_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_assignment#0", (args) => CreateSyntaxNode(true, nameof(scalar_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("scalar_analog_variable_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue#0", (args) => CreateSyntaxNode(true, nameof(scalar_analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)), new Lazy<IParser<CharToken>>(() => scalar_analog_variable_lvalue_many.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue#1", (args) => CreateSyntaxNode(true, nameof(scalar_analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()))).Named("scalar_analog_variable_lvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scalar_analog_variable_lvalue_many#0", (args) => CreateSyntaxNode(true, nameof(scalar_analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("scalar_analog_variable_lvalue_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> initial_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("initial_construct#0", (args) => CreateSyntaxNode(true, nameof(initial_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("initial", true).Text()), new Lazy<IParser<CharToken>>(() => statement.Value.Token())).Named("initial_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> always_construct =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("always_construct#0", (args) => CreateSyntaxNode(true, nameof(always_construct), args), new Lazy<IParser<CharToken>>(() => Parse.String("always", true).Text()), new Lazy<IParser<CharToken>>(() => statement.Value.Token())).Named("always_construct"));

        public static Lazy<IParser<CharToken, SyntaxNode>> blocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("blocking_assignment#0", (args) => CreateSyntaxNode(true, nameof(blocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("blocking_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nonblocking_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nonblocking_assignment#0", (args) => CreateSyntaxNode(true, nameof(nonblocking_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("<=", true).Text()), new Lazy<IParser<CharToken>>(() => delay_or_event_control.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("nonblocking_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_continuous_assignments =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#0", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("assign", true).Text()), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#1", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("deassign", true).Text()), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#2", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("force", true).Text()), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#3", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("force", true).Text()), new Lazy<IParser<CharToken>>(() => net_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#4", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("release", true).Text()), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_continuous_assignments#5", (args) => CreateSyntaxNode(true, nameof(procedural_continuous_assignments), args), new Lazy<IParser<CharToken>>(() => Parse.String("release", true).Text()), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token()))))))).Named("procedural_continuous_assignments"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_assignment#0", (args) => CreateSyntaxNode(true, nameof(variable_assignment), args), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("variable_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_seq_block#0", (args) => CreateSyntaxNode(true, nameof(analog_seq_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("begin", true).Text()), new Lazy<IParser<CharToken>>(() => analog_seq_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("end", true).Text())).Named("analog_seq_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_seq_block_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true).Token())).Named("analog_seq_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_seq_block#0", (args) => CreateSyntaxNode(true, nameof(analog_event_seq_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("begin", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_seq_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("end", true).Text())).Named("analog_event_seq_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_seq_block_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_event_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true).Token())).Named("analog_event_seq_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_seq_block#0", (args) => CreateSyntaxNode(true, nameof(analog_function_seq_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("begin", true).Text()), new Lazy<IParser<CharToken>>(() => analog_function_seq_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("end", true).Text())).Named("analog_function_seq_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_seq_block_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_function_seq_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_block_item_declaration.Value.Many(greedy: true).Token())).Named("analog_function_seq_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("par_block#0", (args) => CreateSyntaxNode(true, nameof(par_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("fork", true).Text()), new Lazy<IParser<CharToken>>(() => par_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("join", true).Text())).Named("par_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> par_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("par_block_optional#0", (args) => CreateSyntaxNode(true, nameof(par_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true).Token())).Named("par_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("seq_block#0", (args) => CreateSyntaxNode(true, nameof(seq_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("begin", true).Text()), new Lazy<IParser<CharToken>>(() => seq_block_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => statement.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("end", true).Text())).Named("seq_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> seq_block_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("seq_block_optional#0", (args) => CreateSyntaxNode(true, nameof(seq_block_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => block_item_declaration.Value.Many(greedy: true).Token())).Named("seq_block_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_loop_generate_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#3", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#4", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#5", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_seq_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#6", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#7", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => contribution_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#8", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => indirect_contribution_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement#9", (args) => CreateSyntaxNode(true, nameof(analog_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_event_control_statement.Value.Token()))))))))))).Named("analog_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#0", (args) => CreateSyntaxNode(true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_statement_or_null#1", (args) => CreateSyntaxNode(true, nameof(analog_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("analog_statement_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_loop_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_case_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_conditional_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#3", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#4", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_event_seq_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#5", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#6", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => disable_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#7", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => event_trigger.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_statement#8", (args) => CreateSyntaxNode(true, nameof(analog_event_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))))))))).Named("analog_event_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_case_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_loop_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#3", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_seq_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#4", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_procedural_assignment.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement#5", (args) => CreateSyntaxNode(true, nameof(analog_function_statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_system_task_enable.Value.Token()))))))).Named("analog_function_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#0", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_or_null#1", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("analog_function_statement_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("statement#0", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => blocking_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#1", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => case_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#2", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => conditional_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#3", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => disable_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#4", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => event_trigger.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#5", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => loop_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#6", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => nonblocking_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#7", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => par_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#8", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => procedural_continuous_assignments.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#9", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => procedural_timing_control_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#10", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => seq_block.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#11", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => system_task_enable.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#12", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => task_enable.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("statement#13", (args) => CreateSyntaxNode(true, nameof(statement), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => wait_statement.Value.Token()))))))))))))))).Named("statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> statement_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("statement_or_null#0", (args) => CreateSyntaxNode(true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("statement_or_null#1", (args) => CreateSyntaxNode(true, nameof(statement_or_null), args), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("statement_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_statement#0", (args) => CreateSyntaxNode(true, nameof(function_statement), args), new Lazy<IParser<CharToken>>(() => statement.Value.Token())).Named("function_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_control_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_event_control_statement), args), new Lazy<IParser<CharToken>>(() => analog_event_control.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_statement.Value.Token())).Named("analog_event_control_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_control#0", (args) => CreateSyntaxNode(true, nameof(analog_event_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('@', true)), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_control#1", (args) => CreateSyntaxNode(true, nameof(analog_event_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('@', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("analog_event_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#1", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("posedge", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#2", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("negedge", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#3", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#4", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("initial_step", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#5", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("final_step", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_expression_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression#6", (args) => CreateSyntaxNode(true, nameof(analog_event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token())))))))).Named("analog_event_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_expression_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_event_expression_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_optional_2#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_expression_many_2.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_event_expression_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_many#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text())).Named("analog_event_expression_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_many_2#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text())).Named("analog_event_expression_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => Parse.String("cross", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions#1", (args) => CreateSyntaxNode(true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => Parse.String("above", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions#2", (args) => CreateSyntaxNode(true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => Parse.String("timer", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions#3", (args) => CreateSyntaxNode(true, nameof(analog_event_functions), args), new Lazy<IParser<CharToken>>(() => Parse.String("absdelta", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_4.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))))).Named("analog_event_functions"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_5.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_2#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_6.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_3#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_7.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_4#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_8.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_5#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_9.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_6#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_10.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_7#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_11.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_8#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_8), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_12.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_9#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_9), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_functions_optional_13.Value.Optional(greedy: false).Token())).Named("analog_event_functions_optional_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_10#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_10), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_event_functions_optional_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_11#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_11), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_event_functions_optional_11"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_12#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_12), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_event_functions_optional_12"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_functions_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_functions_optional_13#0", (args) => CreateSyntaxNode(true, nameof(analog_event_functions_optional_13), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_event_functions_optional_13"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay_control#0", (args) => CreateSyntaxNode(true, nameof(delay_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => delay_value.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay_control#1", (args) => CreateSyntaxNode(true, nameof(delay_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('#', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("delay_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delay_or_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delay_or_event_control#0", (args) => CreateSyntaxNode(true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay_or_event_control#1", (args) => CreateSyntaxNode(true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("delay_or_event_control#2", (args) => CreateSyntaxNode(true, nameof(delay_or_event_control), args), new Lazy<IParser<CharToken>>(() => Parse.String("repeat", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => event_control.Value.Token())))).Named("delay_or_event_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> disable_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("disable_statement#0", (args) => CreateSyntaxNode(true, nameof(disable_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("disable", true).Text()), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("disable_statement#1", (args) => CreateSyntaxNode(true, nameof(disable_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("disable", true).Text()), new Lazy<IParser<CharToken>>(() => hierarchical_block_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("disable_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_control#0", (args) => CreateSyntaxNode(true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('@', true)), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_control#1", (args) => CreateSyntaxNode(true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('@', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_control#2", (args) => CreateSyntaxNode(true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => Parse.String("@*", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_control#3", (args) => CreateSyntaxNode(true, nameof(event_control), args), new Lazy<IParser<CharToken>>(() => Parse.Char('@', true)), new Lazy<IParser<CharToken>>(() => Parse.String("(*)", true).Text()))))).Named("event_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_trigger#0", (args) => CreateSyntaxNode(true, nameof(event_trigger), args), new Lazy<IParser<CharToken>>(() => Parse.String("->", true).Text()), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => event_trigger_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("event_trigger"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_trigger_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_trigger_many#0", (args) => CreateSyntaxNode(true, nameof(event_trigger_many), args), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: false).Token())).Named("event_trigger_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_expression#0", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("posedge", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#1", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("negedge", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#2", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => hierarchical_event_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#3", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_event_functions.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#4", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("driver_update", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#5", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression#6", (args) => CreateSyntaxNode(true, nameof(event_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token())))))))).Named("event_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("procedural_timing_control#0", (args) => CreateSyntaxNode(true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => delay_control.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("procedural_timing_control#1", (args) => CreateSyntaxNode(true, nameof(procedural_timing_control), args), new Lazy<IParser<CharToken>>(() => event_control.Value.Token()))).Named("procedural_timing_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> procedural_timing_control_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("procedural_timing_control_statement#0", (args) => CreateSyntaxNode(true, nameof(procedural_timing_control_statement), args), new Lazy<IParser<CharToken>>(() => procedural_timing_control.Value.Token()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token())).Named("procedural_timing_control_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> wait_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("wait_statement#0", (args) => CreateSyntaxNode(true, nameof(wait_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("wait", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token())).Named("wait_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_conditional_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_conditional_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_conditional_statement_else.Value.Optional(greedy: true).Token())).Named("analog_conditional_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_many#0", (args) => CreateSyntaxNode(true, nameof(analog_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value.Token())).Named("analog_conditional_statement_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_conditional_statement_else#0", (args) => CreateSyntaxNode(true, nameof(analog_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value.Token())).Named("analog_conditional_statement_else"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_function_conditional_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_function_conditional_statement_else.Value.Optional(greedy: true).Token())).Named("analog_function_conditional_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_many#0", (args) => CreateSyntaxNode(true, nameof(analog_function_conditional_statement_many), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value.Token())).Named("analog_function_conditional_statement_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_conditional_statement_else#0", (args) => CreateSyntaxNode(true, nameof(analog_function_conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value.Token())).Named("analog_function_conditional_statement_else"));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("conditional_statement#0", (args) => CreateSyntaxNode(true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => conditional_statement_else.Value.Optional(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("conditional_statement#1", (args) => CreateSyntaxNode(true, nameof(conditional_statement), args), new Lazy<IParser<CharToken>>(() => if_else_if_statement.Value.Token()))).Named("conditional_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("conditional_statement_else#0", (args) => CreateSyntaxNode(true, nameof(conditional_statement_else), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token())).Named("conditional_statement_else"));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("if_else_if_statement#0", (args) => CreateSyntaxNode(true, nameof(if_else_if_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()), new Lazy<IParser<CharToken>>(() => if_else_if_statement_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => if_else_if_statement_else.Value.Optional(greedy: true).Token())).Named("if_else_if_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("if_else_if_statement_many#0", (args) => CreateSyntaxNode(true, nameof(if_else_if_statement_many), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token())).Named("if_else_if_statement_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> if_else_if_statement_else =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("if_else_if_statement_else#0", (args) => CreateSyntaxNode(true, nameof(if_else_if_statement_else), args), new Lazy<IParser<CharToken>>(() => Parse.String("else", true).Text()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token())).Named("if_else_if_statement_else"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_case_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("case", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_case_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("casex", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_case_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("casez", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text())))).Named("analog_case_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_case_item#0", (args) => CreateSyntaxNode(true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_case_item_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_case_item#1", (args) => CreateSyntaxNode(true, nameof(analog_case_item), args), new Lazy<IParser<CharToken>>(() => Parse.String("default", true).Text()), new Lazy<IParser<CharToken>>(() => analog_case_item_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_statement_or_null.Value.Token()))).Named("analog_case_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_case_item_many#0", (args) => CreateSyntaxNode(true, nameof(analog_case_item_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_case_item_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_case_item_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_case_item_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true))).Named("analog_case_item_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_case_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_function_case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("case", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_function_case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text())).Named("analog_function_case_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_case_item#0", (args) => CreateSyntaxNode(true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_function_case_item_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_case_item#1", (args) => CreateSyntaxNode(true, nameof(analog_function_case_item), args), new Lazy<IParser<CharToken>>(() => Parse.String("default", true).Text()), new Lazy<IParser<CharToken>>(() => analog_function_case_item_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_function_statement_or_null.Value.Token()))).Named("analog_function_case_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_case_item_many#0", (args) => CreateSyntaxNode(true, nameof(analog_function_case_item_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_function_case_item_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_case_item_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_function_case_item_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true))).Named("analog_function_case_item_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_statement#0", (args) => CreateSyntaxNode(true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("case", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("case_statement#1", (args) => CreateSyntaxNode(true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("casez", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("case_statement#2", (args) => CreateSyntaxNode(true, nameof(case_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("casex", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => case_item.Value.Token()), new Lazy<IParser<CharToken>>(() => case_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endcase", true).Text())))).Named("case_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_item#0", (args) => CreateSyntaxNode(true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => case_item_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("case_item#1", (args) => CreateSyntaxNode(true, nameof(case_item), args), new Lazy<IParser<CharToken>>(() => Parse.String("default", true).Text()), new Lazy<IParser<CharToken>>(() => case_item_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => statement_or_null.Value.Token()))).Named("case_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_item_many#0", (args) => CreateSyntaxNode(true, nameof(case_item_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("case_item_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> case_item_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("case_item_optional#0", (args) => CreateSyntaxNode(true, nameof(case_item_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true))).Named("case_item_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_loop_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("repeat", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_loop_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("while", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_loop_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_statement.Value.Token())))).Named("analog_loop_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("repeat", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("while", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => analog_function_statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_loop_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_function_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => analog_variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))).Named("analog_function_loop_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_statement_loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#0", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("forever", true).Text()), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#1", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("repeat", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#2", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("while", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_function_statement_loop_statement#3", (args) => CreateSyntaxNode(true, nameof(analog_function_statement_loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))))).Named("analog_function_statement_loop_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> loop_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("loop_statement#0", (args) => CreateSyntaxNode(true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("forever", true).Text()), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("loop_statement#1", (args) => CreateSyntaxNode(true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("repeat", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("loop_statement#2", (args) => CreateSyntaxNode(true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("while", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("loop_statement#3", (args) => CreateSyntaxNode(true, nameof(loop_statement), args), new Lazy<IParser<CharToken>>(() => Parse.String("for", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)), new Lazy<IParser<CharToken>>(() => variable_assignment.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => statement.Value.Token()))))).Named("loop_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_task_enable#0", (args) => CreateSyntaxNode(true, nameof(analog_system_task_enable), args), new Lazy<IParser<CharToken>>(() => analog_system_task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("analog_system_task_enable"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_system_task_enable_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_system_task_enable_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_task_enable_many#0", (args) => CreateSyntaxNode(true, nameof(analog_system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: false).Token())).Named("analog_system_task_enable_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_task_enable#0", (args) => CreateSyntaxNode(true, nameof(system_task_enable), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => system_task_enable_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("system_task_enable"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_task_enable_optional#0", (args) => CreateSyntaxNode(true, nameof(system_task_enable_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => system_task_enable_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("system_task_enable_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_task_enable_many#0", (args) => CreateSyntaxNode(true, nameof(system_task_enable_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Optional(greedy: false).Token())).Named("system_task_enable_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_enable#0", (args) => CreateSyntaxNode(true, nameof(task_enable), args), new Lazy<IParser<CharToken>>(() => hierarchical_task_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => task_enable_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("task_enable"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_enable_optional#0", (args) => CreateSyntaxNode(true, nameof(task_enable_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => task_enable_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("task_enable_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_enable_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_enable_many#0", (args) => CreateSyntaxNode(true, nameof(task_enable_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("task_enable_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("contribution_statement#0", (args) => CreateSyntaxNode(true, nameof(contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("<+", true).Text()), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("contribution_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_contribution_statement =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_contribution_statement#0", (args) => CreateSyntaxNode(true, nameof(indirect_contribution_statement), args), new Lazy<IParser<CharToken>>(() => branch_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => indirect_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("==", true).Text()), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("indirect_contribution_statement"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_block =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_block#0", (args) => CreateSyntaxNode(true, nameof(specify_block), args), new Lazy<IParser<CharToken>>(() => Parse.String("specify", true).Text()), new Lazy<IParser<CharToken>>(() => specify_item.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("endspecify", true).Text())).Named("specify_block"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_item =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_item#0", (args) => CreateSyntaxNode(true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => specparam_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("specify_item#1", (args) => CreateSyntaxNode(true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => pulsestyle_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("specify_item#2", (args) => CreateSyntaxNode(true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => showcancelled_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("specify_item#3", (args) => CreateSyntaxNode(true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => path_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("specify_item#4", (args) => CreateSyntaxNode(true, nameof(specify_item), args), new Lazy<IParser<CharToken>>(() => system_timing_check.Value.Token())))))).Named("specify_item"));

        public static Lazy<IParser<CharToken, SyntaxNode>> pulsestyle_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#0", (args) => CreateSyntaxNode(true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("pulsestyle_onevent", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("pulsestyle_declaration#1", (args) => CreateSyntaxNode(true, nameof(pulsestyle_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("pulsestyle_ondetect", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("pulsestyle_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> showcancelled_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#0", (args) => CreateSyntaxNode(true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("showcancelled", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("showcancelled_declaration#1", (args) => CreateSyntaxNode(true, nameof(showcancelled_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("noshowcancelled", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))).Named("showcancelled_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("path_declaration#0", (args) => CreateSyntaxNode(true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("path_declaration#1", (args) => CreateSyntaxNode(true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("path_declaration#2", (args) => CreateSyntaxNode(true, nameof(path_declaration), args), new Lazy<IParser<CharToken>>(() => state_dependent_path_declaration.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))))).Named("path_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("simple_path_declaration#0", (args) => CreateSyntaxNode(true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_path_description.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => path_delay_value.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("simple_path_declaration#1", (args) => CreateSyntaxNode(true, nameof(simple_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_path_description.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => path_delay_value.Value.Token()))).Named("simple_path_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parallel_path_description#0", (args) => CreateSyntaxNode(true, nameof(parallel_path_description), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("=>", true).Text()), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("parallel_path_description"));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("full_path_description#0", (args) => CreateSyntaxNode(true, nameof(full_path_description), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value.Token()), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("*>", true).Text()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("full_path_description"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_path_inputs#0", (args) => CreateSyntaxNode(true, nameof(list_of_path_inputs), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_path_inputs_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\\", true).Text())).Named("list_of_path_inputs"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_inputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_path_inputs_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_path_inputs_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token())).Named("list_of_path_inputs_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_path_outputs#0", (args) => CreateSyntaxNode(true, nameof(list_of_path_outputs), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => list_of_path_outputs_many.Value.Many(greedy: true).Token())).Named("list_of_path_outputs"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_outputs_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_path_outputs_many#0", (args) => CreateSyntaxNode(true, nameof(list_of_path_outputs_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value.Token())).Named("list_of_path_outputs_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor#0", (args) => CreateSyntaxNode(true, nameof(specify_input_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => input_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor_optional.Value.Optional(greedy: false).Token())).Named("specify_input_terminal_descriptor"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_input_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_input_terminal_descriptor_optional#0", (args) => CreateSyntaxNode(true, nameof(specify_input_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("specify_input_terminal_descriptor_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor#0", (args) => CreateSyntaxNode(true, nameof(specify_output_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => output_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor_optional.Value.Optional(greedy: false).Token())).Named("specify_output_terminal_descriptor"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_output_terminal_descriptor_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_output_terminal_descriptor_optional#0", (args) => CreateSyntaxNode(true, nameof(specify_output_terminal_descriptor_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("specify_output_terminal_descriptor_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_identifier#0", (args) => CreateSyntaxNode(true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => input_port_identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("input_identifier#1", (args) => CreateSyntaxNode(true, nameof(input_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value.Token()))).Named("input_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_identifier#0", (args) => CreateSyntaxNode(true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => output_port_identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("output_identifier#1", (args) => CreateSyntaxNode(true, nameof(output_identifier), args), new Lazy<IParser<CharToken>>(() => inout_port_identifier.Value.Token()))).Named("output_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("path_delay_value#0", (args) => CreateSyntaxNode(true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("path_delay_value#1", (args) => CreateSyntaxNode(true, nameof(path_delay_value), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => list_of_path_delay_expressions.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("path_delay_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> list_of_path_delay_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#0", (args) => CreateSyntaxNode(true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t_path_delay_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#1", (args) => CreateSyntaxNode(true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#2", (args) => CreateSyntaxNode(true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => trise_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tfall_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tz_path_delay_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#3", (args) => CreateSyntaxNode(true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("list_of_path_delay_expressions#4", (args) => CreateSyntaxNode(true, nameof(list_of_path_delay_expressions), args), new Lazy<IParser<CharToken>>(() => t01_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t10_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t0z_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tz1_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t1z_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tz0_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t0x_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tx1_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => t1x_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tx0_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => txz_path_delay_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => tzx_path_delay_expression.Value.Token())))))).Named("list_of_path_delay_expressions"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> trise_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("trise_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(trise_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("trise_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tfall_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tfall_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tfall_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tfall_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tz_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tz_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t01_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t01_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t01_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t01_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t10_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t10_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t10_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t10_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t0z_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t0z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t0z_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tz1_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tz1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tz1_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1z_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t1z_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t1z_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t1z_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tz0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tz0_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tz0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tz0_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t0x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t0x_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t0x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t0x_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx1_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tx1_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tx1_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tx1_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> t1x_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("t1x_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(t1x_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("t1x_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tx0_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tx0_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tx0_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tx0_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> txz_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("txz_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(txz_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("txz_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> tzx_path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("tzx_path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(tzx_path_delay_expression), args), new Lazy<IParser<CharToken>>(() => path_delay_expression.Value.Token())).Named("tzx_path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> path_delay_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("path_delay_expression#0", (args) => CreateSyntaxNode(true, nameof(path_delay_expression), args), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token())).Named("path_delay_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_sensitive_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#0", (args) => CreateSyntaxNode(true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => parallel_edge_sensitive_path_description.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => path_delay_value.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_sensitive_path_declaration#1", (args) => CreateSyntaxNode(true, nameof(edge_sensitive_path_declaration), args), new Lazy<IParser<CharToken>>(() => full_edge_sensitive_path_description.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => path_delay_value.Value.Token()))).Named("edge_sensitive_path_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parallel_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parallel_edge_sensitive_path_description#0", (args) => CreateSyntaxNode(true, nameof(parallel_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("=>", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => data_source_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("parallel_edge_sensitive_path_description"));

        public static Lazy<IParser<CharToken, SyntaxNode>> full_edge_sensitive_path_description =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("full_edge_sensitive_path_description#0", (args) => CreateSyntaxNode(true, nameof(full_edge_sensitive_path_description), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => edge_identifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => list_of_path_inputs.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("*>", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => list_of_path_outputs.Value.Token()), new Lazy<IParser<CharToken>>(() => polarity_operator.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => data_source_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("full_edge_sensitive_path_description"));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_source_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("data_source_expression#0", (args) => CreateSyntaxNode(true, nameof(data_source_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("data_source_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_identifier#0", (args) => CreateSyntaxNode(true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("posedge", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("edge_identifier#1", (args) => CreateSyntaxNode(true, nameof(edge_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("negedge", true).Text()))).Named("edge_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> state_dependent_path_declaration =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#0", (args) => CreateSyntaxNode(true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#1", (args) => CreateSyntaxNode(true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("if", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => edge_sensitive_path_declaration.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("state_dependent_path_declaration#2", (args) => CreateSyntaxNode(true, nameof(state_dependent_path_declaration), args), new Lazy<IParser<CharToken>>(() => Parse.String("ifnone", true).Text()), new Lazy<IParser<CharToken>>(() => simple_path_declaration.Value.Token())))).Named("state_dependent_path_declaration"));

        public static Lazy<IParser<CharToken, SyntaxNode>> polarity_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("polarity_operator#0", (args) => CreateSyntaxNode(true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('+', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("polarity_operator#1", (args) => CreateSyntaxNode(true, nameof(polarity_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('-', true)))).Named("polarity_operator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#0", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setup_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#1", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => hold_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#2", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => setuphold_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#3", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recovery_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#4", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => removal_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#5", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => recrem_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#6", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => skew_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#7", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => timeskew_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#8", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => fullskew_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#9", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => period_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#10", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => width_timing_check.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("system_timing_check#11", (args) => CreateSyntaxNode(true, nameof(system_timing_check), args), new Lazy<IParser<CharToken>>(() => nochange_timing_check.Value.Token()))))))))))))).Named("system_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setup_timing_check#0", (args) => CreateSyntaxNode(true, nameof(setup_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$setup", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => setup_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$setup_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setup_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setup_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(setup_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$setup_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hold_timing_check#0", (args) => CreateSyntaxNode(true, nameof(hold_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$hold", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => hold_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$hold_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hold_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(hold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$hold_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$setuphold", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$setuphold_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_2.Value.Optional(greedy: false).Token())).Named("$setuphold_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_2#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_3.Value.Optional(greedy: false).Token())).Named("$setuphold_timing_check_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_3#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_4.Value.Optional(greedy: false).Token())).Named("$setuphold_timing_check_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_4#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => setuphold_timing_check_optional_5.Value.Optional(greedy: false).Token())).Named("$setuphold_timing_check_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> setuphold_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("setuphold_timing_check_optional_5#0", (args) => CreateSyntaxNode(true, nameof(setuphold_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: false).Token())).Named("$setuphold_timing_check_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recovery_timing_check#0", (args) => CreateSyntaxNode(true, nameof(recovery_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$recovery", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => recovery_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$recovery_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recovery_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recovery_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(recovery_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$recovery_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("removal_timing_check#0", (args) => CreateSyntaxNode(true, nameof(removal_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$removal", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => removal_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$removal_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> removal_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("removal_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(removal_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$removal_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$recrem", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$recrem_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_2.Value.Optional(greedy: false).Token())).Named("$recrem_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_2#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => stamptime_condition.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_3.Value.Optional(greedy: false).Token())).Named("$recrem_timing_check_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_3#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => checktime_condition.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_4.Value.Optional(greedy: false).Token())).Named("$recrem_timing_check_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_4#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => delayed_reference.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => recrem_timing_check_optional_5.Value.Optional(greedy: false).Token())).Named("$recrem_timing_check_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> recrem_timing_check_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("recrem_timing_check_optional_5#0", (args) => CreateSyntaxNode(true, nameof(recrem_timing_check_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => delayed_data.Value.Optional(greedy: false).Token())).Named("$recrem_timing_check_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("skew_timing_check#0", (args) => CreateSyntaxNode(true, nameof(skew_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$skew", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => skew_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$skew_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> skew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("skew_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(skew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$skew_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timeskew_timing_check#0", (args) => CreateSyntaxNode(true, nameof(timeskew_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$timeskew", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$timeskew_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(timeskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_2.Value.Optional(greedy: false).Token())).Named("$timeskew_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_2#0", (args) => CreateSyntaxNode(true, nameof(timeskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => timeskew_timing_check_optional_3.Value.Optional(greedy: false).Token())).Named("$timeskew_timing_check_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timeskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timeskew_timing_check_optional_3#0", (args) => CreateSyntaxNode(true, nameof(timeskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: false).Token())).Named("$timeskew_timing_check_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("fullskew_timing_check#0", (args) => CreateSyntaxNode(true, nameof(fullskew_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$fullskew", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$fullskew_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(fullskew_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_2.Value.Optional(greedy: false).Token())).Named("$fullskew_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_2#0", (args) => CreateSyntaxNode(true, nameof(fullskew_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => event_based_flag.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => fullskew_timing_check_optional_3.Value.Optional(greedy: false).Token())).Named("$fullskew_timing_check_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> fullskew_timing_check_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("fullskew_timing_check_optional_3#0", (args) => CreateSyntaxNode(true, nameof(fullskew_timing_check_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => remain_active_flag.Value.Optional(greedy: false).Token())).Named("$fullskew_timing_check_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("period_timing_check#0", (args) => CreateSyntaxNode(true, nameof(period_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$period", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => period_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$period_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> period_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("period_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(period_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$period_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("width_timing_check#0", (args) => CreateSyntaxNode(true, nameof(width_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$width", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => controlled_reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => timing_check_limit.Value.Token()), new Lazy<IParser<CharToken>>(() => width_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$width_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("width_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(width_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => threshold.Value.Token()), new Lazy<IParser<CharToken>>(() => width_timing_check_optional_2.Value.Optional(greedy: false).Token())).Named("$width_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_timing_check_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("width_timing_check_optional_2#0", (args) => CreateSyntaxNode(true, nameof(width_timing_check_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Token())).Named("$width_timing_check_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nochange_timing_check#0", (args) => CreateSyntaxNode(true, nameof(nochange_timing_check), args), new Lazy<IParser<CharToken>>(() => Parse.String("$nochange", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => reference_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => data_event.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => start_edge_offset.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => end_edge_offset.Value.Token()), new Lazy<IParser<CharToken>>(() => nochange_timing_check_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("$nochange_timing_check"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nochange_timing_check_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nochange_timing_check_optional#0", (args) => CreateSyntaxNode(true, nameof(nochange_timing_check_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => notifier.Value.Optional(greedy: false).Token())).Named("$nochange_timing_check_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> checktime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("checktime_condition#0", (args) => CreateSyntaxNode(true, nameof(checktime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("checktime_condition"));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("controlled_reference_event#0", (args) => CreateSyntaxNode(true, nameof(controlled_reference_event), args), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event.Value.Token())).Named("controlled_reference_event"));

        public static Lazy<IParser<CharToken, SyntaxNode>> data_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("data_event#0", (args) => CreateSyntaxNode(true, nameof(data_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value.Token())).Named("data_event"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_data =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delayed_data#0", (args) => CreateSyntaxNode(true, nameof(delayed_data), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("delayed_data#1", (args) => CreateSyntaxNode(true, nameof(delayed_data), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))).Named("delayed_data"));

        public static Lazy<IParser<CharToken, SyntaxNode>> delayed_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("delayed_reference#0", (args) => CreateSyntaxNode(true, nameof(delayed_reference), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("delayed_reference#1", (args) => CreateSyntaxNode(true, nameof(delayed_reference), args), new Lazy<IParser<CharToken>>(() => terminal_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))).Named("delayed_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> end_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("end_edge_offset#0", (args) => CreateSyntaxNode(true, nameof(end_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("end_edge_offset"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_based_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_based_flag#0", (args) => CreateSyntaxNode(true, nameof(event_based_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("event_based_flag"));

        public static Lazy<IParser<CharToken, SyntaxNode>> notifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("notifier#0", (args) => CreateSyntaxNode(true, nameof(notifier), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token())).Named("notifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> reference_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("reference_event#0", (args) => CreateSyntaxNode(true, nameof(reference_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event.Value.Token())).Named("reference_event"));

        public static Lazy<IParser<CharToken, SyntaxNode>> remain_active_flag =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("remain_active_flag#0", (args) => CreateSyntaxNode(true, nameof(remain_active_flag), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("remain_active_flag"));

        public static Lazy<IParser<CharToken, SyntaxNode>> stamptime_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("stamptime_condition#0", (args) => CreateSyntaxNode(true, nameof(stamptime_condition), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("stamptime_condition"));

        public static Lazy<IParser<CharToken, SyntaxNode>> start_edge_offset =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("start_edge_offset#0", (args) => CreateSyntaxNode(true, nameof(start_edge_offset), args), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token())).Named("start_edge_offset"));

        public static Lazy<IParser<CharToken, SyntaxNode>> threshold =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("threshold#0", (args) => CreateSyntaxNode(true, nameof(threshold), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("threshold"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_limit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timing_check_limit#0", (args) => CreateSyntaxNode(true, nameof(timing_check_limit), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("timing_check_limit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timing_check_event#0", (args) => CreateSyntaxNode(true, nameof(timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => timing_check_event_optional.Value.Optional(greedy: false).Token())).Named("timing_check_event"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timing_check_event_optional#0", (args) => CreateSyntaxNode(true, nameof(timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("&&&", true).Text()), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value.Token())).Named("timing_check_event_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event#0", (args) => CreateSyntaxNode(true, nameof(controlled_timing_check_event), args), new Lazy<IParser<CharToken>>(() => timing_check_event_control.Value.Token()), new Lazy<IParser<CharToken>>(() => specify_terminal_descriptor.Value.Token()), new Lazy<IParser<CharToken>>(() => controlled_timing_check_event_optional.Value.Optional(greedy: false).Token())).Named("controlled_timing_check_event"));

        public static Lazy<IParser<CharToken, SyntaxNode>> controlled_timing_check_event_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("controlled_timing_check_event_optional#0", (args) => CreateSyntaxNode(true, nameof(controlled_timing_check_event_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("&&&", true).Text()), new Lazy<IParser<CharToken>>(() => timing_check_condition.Value.Token())).Named("controlled_timing_check_event_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_event_control =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timing_check_event_control#0", (args) => CreateSyntaxNode(true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => Parse.String("posedge", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("timing_check_event_control#1", (args) => CreateSyntaxNode(true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => Parse.String("negedge", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("timing_check_event_control#2", (args) => CreateSyntaxNode(true, nameof(timing_check_event_control), args), new Lazy<IParser<CharToken>>(() => edge_control_specifier.Value.Token())))).Named("timing_check_event_control"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specify_terminal_descriptor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#0", (args) => CreateSyntaxNode(true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_input_terminal_descriptor.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("specify_terminal_descriptor#1", (args) => CreateSyntaxNode(true, nameof(specify_terminal_descriptor), args), new Lazy<IParser<CharToken>>(() => specify_output_terminal_descriptor.Value.Token()))).Named("specify_terminal_descriptor"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_control_specifier#0", (args) => CreateSyntaxNode(true, nameof(edge_control_specifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("edge", true).Text()), new Lazy<IParser<CharToken>>(() => edge_control_specifier_optional.Value.Optional(greedy: false).Token())).Named("edge_control_specifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_control_specifier_optional#0", (args) => CreateSyntaxNode(true, nameof(edge_control_specifier_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("edge_descriptor", true).Text()), new Lazy<IParser<CharToken>>(() => edge_control_specifier_many.Value.Many(greedy: true).Token())).Named("edge_control_specifier_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_control_specifier_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_control_specifier_many#0", (args) => CreateSyntaxNode(true, nameof(edge_control_specifier_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("edge_descriptor", true).Text())).Named("edge_control_specifier_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> edge_descriptor2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("edge_descriptor2#0", (args) => CreateSyntaxNode(true, nameof(edge_descriptor2), args), new Lazy<IParser<CharToken>>(() => Parse.String("01", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("edge_descriptor2#1", (args) => CreateSyntaxNode(true, nameof(edge_descriptor2), args), new Lazy<IParser<CharToken>>(() => Parse.String("10", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("edge_descriptor2#2", (args) => CreateSyntaxNode(true, nameof(edge_descriptor2), args), new Lazy<IParser<CharToken>>(() => z_or_x.Value.Token()), new Lazy<IParser<CharToken>>(() => zero_or_one.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("edge_descriptor2#3", (args) => CreateSyntaxNode(true, nameof(edge_descriptor2), args), new Lazy<IParser<CharToken>>(() => zero_or_one.Value.Token()), new Lazy<IParser<CharToken>>(() => z_or_x.Value.Token()))))).Named("edge_descriptor2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> zero_or_one =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("zero_or_one#0", (args) => CreateSyntaxNode(true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("zero_or_one#1", (args) => CreateSyntaxNode(true, nameof(zero_or_one), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', true)))).Named("zero_or_one"));

        public static Lazy<IParser<CharToken, SyntaxNode>> z_or_x =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("z_or_x#0", (args) => CreateSyntaxNode(true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => Parse.Char('x', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("z_or_x#1", (args) => CreateSyntaxNode(true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => Parse.Char('X', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("z_or_x#2", (args) => CreateSyntaxNode(true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => Parse.Char('z', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("z_or_x#3", (args) => CreateSyntaxNode(true, nameof(z_or_x), args), new Lazy<IParser<CharToken>>(() => Parse.Char('Z', true)))))).Named("z_or_x"));

        public static Lazy<IParser<CharToken, SyntaxNode>> timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("timing_check_condition#0", (args) => CreateSyntaxNode(true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("timing_check_condition#1", (args) => CreateSyntaxNode(true, nameof(timing_check_condition), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => scalar_timing_check_condition.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("timing_check_condition"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_timing_check_condition =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#0", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#1", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => Parse.Char('~', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#2", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("==", true).Text()), new Lazy<IParser<CharToken>>(() => scalar_constant.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#3", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("===", true).Text()), new Lazy<IParser<CharToken>>(() => scalar_constant.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#4", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("!=", true).Text()), new Lazy<IParser<CharToken>>(() => scalar_constant.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scalar_timing_check_condition#5", (args) => CreateSyntaxNode(true, nameof(scalar_timing_check_condition), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("!==", true).Text()), new Lazy<IParser<CharToken>>(() => scalar_constant.Value.Token()))))))).Named("scalar_timing_check_condition"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scalar_constant =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#0", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'b0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#1", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'b1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#2", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'B0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#3", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("1'B1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#4", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("'b0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#5", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("'b1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#6", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("'B0", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#7", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.String("'B1", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#8", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("scalar_constant#9", (args) => CreateSyntaxNode(true, nameof(scalar_constant), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', true)))))))))))).Named("scalar_constant"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_concatenation#0", (args) => CreateSyntaxNode(true, nameof(analog_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_concatenation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("analog_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_concatenation_many#0", (args) => CreateSyntaxNode(true, nameof(analog_concatenation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_concatenation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_multiple_concatenation#0", (args) => CreateSyntaxNode(true, nameof(analog_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("analog_multiple_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#1", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_arg#2", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_arg), args), new Lazy<IParser<CharToken>>(() => Parse.String("constant_optional_arrayinit", true).Text())))).Named("analog_filter_function_arg"));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("concatenation#0", (args) => CreateSyntaxNode(true, nameof(concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => concatenation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("concatenation_many#0", (args) => CreateSyntaxNode(true, nameof(concatenation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("concatenation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_concatenation#0", (args) => CreateSyntaxNode(true, nameof(constant_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_concatenation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("constant_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_concatenation_many#0", (args) => CreateSyntaxNode(true, nameof(constant_concatenation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_concatenation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_multiple_concatenation#0", (args) => CreateSyntaxNode(true, nameof(constant_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("constant_multiple_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_concatenation#0", (args) => CreateSyntaxNode(true, nameof(module_path_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_concatenation_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("module_path_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_concatenation_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_concatenation_many#0", (args) => CreateSyntaxNode(true, nameof(module_path_concatenation_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token())).Named("module_path_concatenation_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_multiple_concatenation#0", (args) => CreateSyntaxNode(true, nameof(module_path_multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("module_path_multiple_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> multiple_concatenation =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("multiple_concatenation#0", (args) => CreateSyntaxNode(true, nameof(multiple_concatenation), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => concatenation.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("multiple_concatenation"));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("assignment_pattern#0", (args) => CreateSyntaxNode(true, nameof(assignment_pattern), args), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => assignment_pattern_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("assignment_pattern#1", (args) => CreateSyntaxNode(true, nameof(assignment_pattern), args), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => assignment_pattern_many_2.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))).Named("assignment_pattern"));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("assignment_pattern_many#0", (args) => CreateSyntaxNode(true, nameof(assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("assignment_pattern_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("assignment_pattern_many_2#0", (args) => CreateSyntaxNode(true, nameof(assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("assignment_pattern_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern#0", (args) => CreateSyntaxNode(true, nameof(constant_assignment_pattern), args), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern#1", (args) => CreateSyntaxNode(true, nameof(constant_assignment_pattern), args), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_assignment_pattern_many_2.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))).Named("constant_assignment_pattern"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many#0", (args) => CreateSyntaxNode(true, nameof(constant_assignment_pattern_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_assignment_pattern_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_assignment_pattern_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_assignment_pattern_many_2#0", (args) => CreateSyntaxNode(true, nameof(constant_assignment_pattern_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_assignment_pattern_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_arrayinit#0", (args) => CreateSyntaxNode(true, nameof(constant_arrayinit), args), new Lazy<IParser<CharToken>>(() => Parse.String("'{", true).Text()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_arrayinit_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true))).Named("constant_arrayinit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_arrayinit_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_arrayinit_many#0", (args) => CreateSyntaxNode(true, nameof(constant_arrayinit_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_arrayinit_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_call#0", (args) => CreateSyntaxNode(true, nameof(analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_function_call#0", (args) => CreateSyntaxNode(true, nameof(analog_system_function_call), args), new Lazy<IParser<CharToken>>(() => analog_system_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_system_function_call_optional.Value.Optional(greedy: false).Token())).Named("analog_system_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_system_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_system_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(analog_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: false).Token())).Named("analog_system_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call#0", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analog_built_in_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_built_in_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_built_in_function_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#0", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("ln", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#1", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("log", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#2", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("exp", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#3", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("sqrt", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#4", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("min", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#5", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("max", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#6", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("abs", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#7", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("pow", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#8", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("floor", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#9", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("ceil", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#10", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("tanh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#11", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("asinh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#12", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("acosh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#13", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("atan2", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#14", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("atanh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#15", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("hypot", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#16", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("sinh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#17", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("sin", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#18", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("cosh", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#19", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("cos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#20", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("tan", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#21", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("asin", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#22", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("acos", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_built_in_function_name#23", (args) => CreateSyntaxNode(true, nameof(analog_built_in_function_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("atan", true).Text()))))))))))))))))))))))))).Named("analog_built_in_function_name"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_function_call#0", (args) => CreateSyntaxNode(true, nameof(analysis_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("analysis", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("analysis_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text())).Named("analysis_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("ddt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#1", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("ddx", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#2", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("idt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#3", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("idtmod", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#4", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("absdelay", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_4.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#5", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("transition", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_5.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#6", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("slew", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_6.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#7", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("last_crossing", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_7.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#8", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("limexp", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#9", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => laplace_filter_name.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_8.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call#10", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call), args), new Lazy<IParser<CharToken>>(() => zi_filter_name.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_filter_function_arg.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_9.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))))))))))).Named("analog_filter_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("analog_filter_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_2#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_10.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_3#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_11.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_4#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("analog_filter_function_call_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_5#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_12.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_6#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_13.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_7#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_filter_function_call_optional_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_8#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_8), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("analog_filter_function_call_optional_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_9#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_9), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_14.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_10#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_10), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_15.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_11#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_11), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_16.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_11"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_12#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_12), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_17.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_12"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_13#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_13), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_filter_function_call_optional_13"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_14#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_14), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("analog_filter_function_call_optional_14"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_15#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_15), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("analog_filter_function_call_optional_15"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_16#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_16), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_18.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_16"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_17 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_17#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_17), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_filter_function_call_optional_19.Value.Optional(greedy: false).Token())).Named("analog_filter_function_call_optional_17"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_18 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_18#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_18), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("analog_filter_function_call_optional_18"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_filter_function_call_optional_19 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_filter_function_call_optional_19#0", (args) => CreateSyntaxNode(true, nameof(analog_filter_function_call_optional_19), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("analog_filter_function_call_optional_19"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("ac_stim", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#1", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("white_noise", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#2", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("flicker_noise", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#3", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("noise_table", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_4.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call#4", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call), args), new Lazy<IParser<CharToken>>(() => Parse.String("noise_table_log", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => noise_table_input_arg.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_5.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))))).Named("analog_small_signal_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analysis_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("\"", true).Text()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_6.Value.Optional(greedy: false).Token())).Named("analog_small_signal_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_2#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => @string.Value.Token())).Named("analog_small_signal_function_call_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_3#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => @string.Value.Token())).Named("analog_small_signal_function_call_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_4#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => @string.Value.Token())).Named("analog_small_signal_function_call_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_5#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => @string.Value.Token())).Named("analog_small_signal_function_call_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_6#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call_optional_7.Value.Optional(greedy: false).Token())).Named("analog_small_signal_function_call_optional_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_small_signal_function_call_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_small_signal_function_call_optional_7#0", (args) => CreateSyntaxNode(true, nameof(analog_small_signal_function_call_optional_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_small_signal_function_call_optional_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#0", (args) => CreateSyntaxNode(true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => noise_table_input_arg_optional.Value.Optional(greedy: false).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#1", (args) => CreateSyntaxNode(true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#2", (args) => CreateSyntaxNode(true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => @string.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("noise_table_input_arg#3", (args) => CreateSyntaxNode(true, nameof(noise_table_input_arg), args), new Lazy<IParser<CharToken>>(() => constant_arrayinit.Value.Token()))))).Named("noise_table_input_arg"));

        public static Lazy<IParser<CharToken, SyntaxNode>> noise_table_input_arg_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("noise_table_input_arg_optional#0", (args) => CreateSyntaxNode(true, nameof(noise_table_input_arg_optional), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token())).Named("noise_table_input_arg_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> laplace_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("laplace_filter_name#0", (args) => CreateSyntaxNode(true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("laplace_zd", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("laplace_filter_name#1", (args) => CreateSyntaxNode(true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("laplace_zp", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("laplace_filter_name#2", (args) => CreateSyntaxNode(true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("laplace_np", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("laplace_filter_name#3", (args) => CreateSyntaxNode(true, nameof(laplace_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("laplace_nd", true).Text()))))).Named("laplace_filter_name"));

        public static Lazy<IParser<CharToken, SyntaxNode>> zi_filter_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("zi_filter_name#0", (args) => CreateSyntaxNode(true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("zi_zp", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("zi_filter_name#1", (args) => CreateSyntaxNode(true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("zi_zd", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("zi_filter_name#2", (args) => CreateSyntaxNode(true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("zi_np", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("zi_filter_name#3", (args) => CreateSyntaxNode(true, nameof(zi_filter_name), args), new Lazy<IParser<CharToken>>(() => Parse.String("zi_nd", true).Text()))))).Named("zi_filter_name"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_function =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_access_function#0", (args) => CreateSyntaxNode(true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_access_function#1", (args) => CreateSyntaxNode(true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => Parse.String("potential", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_access_function#2", (args) => CreateSyntaxNode(true, nameof(nature_access_function), args), new Lazy<IParser<CharToken>>(() => Parse.String("flow", true).Text())))).Named("nature_access_function"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_probe_function_call#0", (args) => CreateSyntaxNode(true, nameof(branch_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_access_function.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_reference.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_probe_function_call#1", (args) => CreateSyntaxNode(true, nameof(branch_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_access_function.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value.Token()), new Lazy<IParser<CharToken>>(() => branch_probe_function_call_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))).Named("branch_probe_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_probe_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_probe_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(branch_probe_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_net_reference.Value.Token())).Named("branch_probe_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_probe_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_probe_function_call#0", (args) => CreateSyntaxNode(true, nameof(port_probe_function_call), args), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)), new Lazy<IParser<CharToken>>(() => analog_port_reference.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("port_probe_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_analog_function_call#0", (args) => CreateSyntaxNode(true, nameof(constant_analog_function_call), args), new Lazy<IParser<CharToken>>(() => analog_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_analog_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("constant_analog_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_analog_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(constant_analog_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_analog_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_function_call#0", (args) => CreateSyntaxNode(true, nameof(constant_function_call), args), new Lazy<IParser<CharToken>>(() => function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("constant_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(constant_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_system_function_call#0", (args) => CreateSyntaxNode(true, nameof(constant_system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_system_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("constant_system_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_system_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(constant_system_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_system_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call#0", (args) => CreateSyntaxNode(true, nameof(constant_analog_built_in_function_call), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_name.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("constant_analog_built_in_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_analog_built_in_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_analog_built_in_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(constant_analog_built_in_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_analog_built_in_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_call#0", (args) => CreateSyntaxNode(true, nameof(function_call), args), new Lazy<IParser<CharToken>>(() => hierarchical_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_call_many#0", (args) => CreateSyntaxNode(true, nameof(function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_function_call#0", (args) => CreateSyntaxNode(true, nameof(system_function_call), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => system_function_call_optional.Value.Optional(greedy: false).Token())).Named("system_function_call"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_function_call_optional#0", (args) => CreateSyntaxNode(true, nameof(system_function_call_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => system_function_call_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))).Named("system_function_call_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_call_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_function_call_many#0", (args) => CreateSyntaxNode(true, nameof(system_function_call_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("system_function_call_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_conditional_expression#0", (args) => CreateSyntaxNode(true, nameof(analog_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token())).Named("analog_conditional_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression#0", (args) => CreateSyntaxNode(true, nameof(analog_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression_10.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value.Token())).Named("analog_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_10#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_10), args), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_10_many.Value.Many(greedy: true).Token())).Named("analog_expression_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_10_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_9.Value.Token())).Named("analog_expression_10_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_9#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_9), args), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_9_many.Value.Many(greedy: true).Token())).Named("analog_expression_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_9_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_8.Value.Token())).Named("analog_expression_9_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_8#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_8), args), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_8_many.Value.Many(greedy: true).Token())).Named("analog_expression_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_8_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_7.Value.Token())).Named("analog_expression_8_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_7#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_7), args), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_7_many.Value.Many(greedy: true).Token())).Named("analog_expression_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_7_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_6.Value.Token())).Named("analog_expression_7_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_6#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_6), args), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_6_many.Value.Many(greedy: true).Token())).Named("analog_expression_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_6_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_5.Value.Token())).Named("analog_expression_6_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_5#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_5), args), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_5_many.Value.Many(greedy: true).Token())).Named("analog_expression_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_5_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_4.Value.Token())).Named("analog_expression_5_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_4#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_4), args), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_4_many.Value.Many(greedy: true).Token())).Named("analog_expression_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_4_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_3.Value.Token())).Named("analog_expression_4_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_3#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_3), args), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_3_many.Value.Many(greedy: true).Token())).Named("analog_expression_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_3_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_2.Value.Token())).Named("analog_expression_3_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_2#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_2), args), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_2_many.Value.Many(greedy: true).Token())).Named("analog_expression_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_2_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_1.Value.Token())).Named("analog_expression_2_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_1#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_1), args), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_1_many.Value.Many(greedy: true).Token())).Named("analog_expression_1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_1_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_0.Value.Token())).Named("analog_expression_1_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_0#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_0), args), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_0_many.Value.Many(greedy: true).Token())).Named("analog_expression_0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_0_many#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression_primary.Value.Token())).Named("analog_expression_0_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_primary#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => analog_primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_expression_primary#1", (args) => CreateSyntaxNode(true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_expression_primary#2", (args) => CreateSyntaxNode(true, nameof(analog_expression_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value.Token())))).Named("analog_expression_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> abstol_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("abstol_expression#0", (args) => CreateSyntaxNode(true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("abstol_expression#1", (args) => CreateSyntaxNode(true, nameof(abstol_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value.Token()))).Named("abstol_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_range_expression#0", (args) => CreateSyntaxNode(true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_range_expression#1", (args) => CreateSyntaxNode(true, nameof(analog_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token()))).Named("analog_range_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_or_null#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_or_null), args), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Optional(greedy: false).Token())).Named("analog_expression_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("base_expression#0", (args) => CreateSyntaxNode(true, nameof(base_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("base_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("conditional_expression#0", (args) => CreateSyntaxNode(true, nameof(conditional_expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression2.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => expression3.Value.Token())).Named("conditional_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_base_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_base_expression#0", (args) => CreateSyntaxNode(true, nameof(constant_base_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_base_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_or_null =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_or_null#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_or_null), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Optional(greedy: false).Token())).Named("constant_expression_or_null"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression#0", (args) => CreateSyntaxNode(true, nameof(constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression_10.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value.Token())).Named("constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_conditional_expression#0", (args) => CreateSyntaxNode(true, nameof(constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("constant_conditional_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_10#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_10), args), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_10_many.Value.Many(greedy: true).Token())).Named("constant_expression_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_10_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_9.Value.Token())).Named("constant_expression_10_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_9#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_9), args), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_9_many.Value.Many(greedy: true).Token())).Named("constant_expression_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_9_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_8.Value.Token())).Named("constant_expression_9_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_8#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_8), args), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_8_many.Value.Many(greedy: true).Token())).Named("constant_expression_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_8_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_7.Value.Token())).Named("constant_expression_8_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_7#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_7), args), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_7_many.Value.Many(greedy: true).Token())).Named("constant_expression_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_7_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_6.Value.Token())).Named("constant_expression_7_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_6#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_6), args), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_6_many.Value.Many(greedy: true).Token())).Named("constant_expression_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_6_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_5.Value.Token())).Named("constant_expression_6_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_5#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_5), args), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_5_many.Value.Many(greedy: true).Token())).Named("constant_expression_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_5_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_4.Value.Token())).Named("constant_expression_5_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_4#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_4), args), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_4_many.Value.Many(greedy: true).Token())).Named("constant_expression_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_4_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_3.Value.Token())).Named("constant_expression_4_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_3#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_3), args), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_3_many.Value.Many(greedy: true).Token())).Named("constant_expression_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_3_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_2.Value.Token())).Named("constant_expression_3_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_2#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_2), args), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_2_many.Value.Many(greedy: true).Token())).Named("constant_expression_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_2_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_1.Value.Token())).Named("constant_expression_2_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_1#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_1), args), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_1_many.Value.Many(greedy: true).Token())).Named("constant_expression_1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_1_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_0.Value.Token())).Named("constant_expression_1_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_0#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_0), args), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_0_many.Value.Many(greedy: true).Token())).Named("constant_expression_0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_0_many#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression_primary.Value.Token())).Named("constant_expression_0_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_primary#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_expression_primary#1", (args) => CreateSyntaxNode(true, nameof(constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()))).Named("constant_expression_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value.Token())).Named("analysis_or_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_conditional_expression#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_conditional_expression), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value.Token())).Named("analysis_or_constant_conditional_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_10), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_10_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_10_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9.Value.Token())).Named("analysis_or_constant_expression_10_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_9), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_9_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_9_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8.Value.Token())).Named("analysis_or_constant_expression_9_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_8), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_8_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_8_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7.Value.Token())).Named("analysis_or_constant_expression_8_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_7), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_7_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_7_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6.Value.Token())).Named("analysis_or_constant_expression_7_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_6), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_6_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_6_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5.Value.Token())).Named("analysis_or_constant_expression_6_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_5), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_5_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_5_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4.Value.Token())).Named("analysis_or_constant_expression_5_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_4), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_4_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_4_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3.Value.Token())).Named("analysis_or_constant_expression_4_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_3), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_3_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_3_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2.Value.Token())).Named("analysis_or_constant_expression_3_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_2), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_2_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_2_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1.Value.Token())).Named("analysis_or_constant_expression_2_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_1), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_1_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_1_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0.Value.Token())).Named("analysis_or_constant_expression_1_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_0), args), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_0_many.Value.Many(greedy: true).Token())).Named("analysis_or_constant_expression_0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_0_many#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_primary.Value.Token())).Named("analysis_or_constant_expression_0_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#1", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_primary#2", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value.Token())))).Named("analysis_or_constant_expression_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression#0", (args) => CreateSyntaxNode(true, nameof(constant_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_mintypmax_expression#1", (args) => CreateSyntaxNode(true, nameof(constant_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))).Named("constant_mintypmax_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_range_expression#0", (args) => CreateSyntaxNode(true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_range_expression#1", (args) => CreateSyntaxNode(true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_range_expression#2", (args) => CreateSyntaxNode(true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("+:", true).Text()), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_range_expression#3", (args) => CreateSyntaxNode(true, nameof(constant_range_expression), args), new Lazy<IParser<CharToken>>(() => constant_base_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("-:", true).Text()), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value.Token()))))).Named("constant_range_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> dimension_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("dimension_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(dimension_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("dimension_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression#0", (args) => CreateSyntaxNode(true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression_10.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("expression#1", (args) => CreateSyntaxNode(true, nameof(expression), args), new Lazy<IParser<CharToken>>(() => expression1.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression2.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => expression3.Value.Token()))).Named("expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_10#0", (args) => CreateSyntaxNode(true, nameof(expression_10), args), new Lazy<IParser<CharToken>>(() => expression_9.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_10_many.Value.Many(greedy: true).Token())).Named("expression_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_10_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_10_many#0", (args) => CreateSyntaxNode(true, nameof(expression_10_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_9.Value.Token())).Named("expression_10_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_9#0", (args) => CreateSyntaxNode(true, nameof(expression_9), args), new Lazy<IParser<CharToken>>(() => expression_8.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_9_many.Value.Many(greedy: true).Token())).Named("expression_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_9_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_9_many#0", (args) => CreateSyntaxNode(true, nameof(expression_9_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_8.Value.Token())).Named("expression_9_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_8#0", (args) => CreateSyntaxNode(true, nameof(expression_8), args), new Lazy<IParser<CharToken>>(() => expression_7.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_8_many.Value.Many(greedy: true).Token())).Named("expression_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_8_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_8_many#0", (args) => CreateSyntaxNode(true, nameof(expression_8_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_7.Value.Token())).Named("expression_8_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_7#0", (args) => CreateSyntaxNode(true, nameof(expression_7), args), new Lazy<IParser<CharToken>>(() => expression_6.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_7_many.Value.Many(greedy: true).Token())).Named("expression_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_7_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_7_many#0", (args) => CreateSyntaxNode(true, nameof(expression_7_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_6.Value.Token())).Named("expression_7_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_6#0", (args) => CreateSyntaxNode(true, nameof(expression_6), args), new Lazy<IParser<CharToken>>(() => expression_5.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_6_many.Value.Many(greedy: true).Token())).Named("expression_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_6_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_6_many#0", (args) => CreateSyntaxNode(true, nameof(expression_6_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_5.Value.Token())).Named("expression_6_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_5#0", (args) => CreateSyntaxNode(true, nameof(expression_5), args), new Lazy<IParser<CharToken>>(() => expression_4.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_5_many.Value.Many(greedy: true).Token())).Named("expression_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_5_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_5_many#0", (args) => CreateSyntaxNode(true, nameof(expression_5_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_4.Value.Token())).Named("expression_5_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_4#0", (args) => CreateSyntaxNode(true, nameof(expression_4), args), new Lazy<IParser<CharToken>>(() => expression_3.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_4_many.Value.Many(greedy: true).Token())).Named("expression_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_4_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_4_many#0", (args) => CreateSyntaxNode(true, nameof(expression_4_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_3.Value.Token())).Named("expression_4_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_3#0", (args) => CreateSyntaxNode(true, nameof(expression_3), args), new Lazy<IParser<CharToken>>(() => expression_2.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_3_many.Value.Many(greedy: true).Token())).Named("expression_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_3_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_3_many#0", (args) => CreateSyntaxNode(true, nameof(expression_3_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_2.Value.Token())).Named("expression_3_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_2#0", (args) => CreateSyntaxNode(true, nameof(expression_2), args), new Lazy<IParser<CharToken>>(() => expression_1.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_2_many.Value.Many(greedy: true).Token())).Named("expression_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_2_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_2_many#0", (args) => CreateSyntaxNode(true, nameof(expression_2_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_1.Value.Token())).Named("expression_2_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_1#0", (args) => CreateSyntaxNode(true, nameof(expression_1), args), new Lazy<IParser<CharToken>>(() => expression_0.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_1_many.Value.Many(greedy: true).Token())).Named("expression_1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_1_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_1_many#0", (args) => CreateSyntaxNode(true, nameof(expression_1_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_0.Value.Token())).Named("expression_1_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_0#0", (args) => CreateSyntaxNode(true, nameof(expression_0), args), new Lazy<IParser<CharToken>>(() => expression_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => expression_0_many.Value.Many(greedy: true).Token())).Named("expression_0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_0_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_0_many#0", (args) => CreateSyntaxNode(true, nameof(expression_0_many), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression_primary.Value.Token())).Named("expression_0_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression_primary#0", (args) => CreateSyntaxNode(true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => primary.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("expression_primary#1", (args) => CreateSyntaxNode(true, nameof(expression_primary), args), new Lazy<IParser<CharToken>>(() => unary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => primary.Value.Token()))).Named("expression_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression1#0", (args) => CreateSyntaxNode(true, nameof(expression1), args), new Lazy<IParser<CharToken>>(() => expression_10.Value.Token()), new Lazy<IParser<CharToken>>(() => expression1_prim.Value.Token())).Named("expression1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression2#0", (args) => CreateSyntaxNode(true, nameof(expression2), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("expression2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression3#0", (args) => CreateSyntaxNode(true, nameof(expression3), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token())).Named("expression3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#1", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#2", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("ddt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#3", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("ddt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_2.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#4", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("idt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_3.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#5", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("idt", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_4.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#6", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("idtmod", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_5.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("indirect_expression#7", (args) => CreateSyntaxNode(true, nameof(indirect_expression), args), new Lazy<IParser<CharToken>>(() => Parse.String("idtmod", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_6.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))))))))).Named("indirect_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_2#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_3#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_3), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_7.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_4#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_8.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_5#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_5), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_9.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_6#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_10.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_7#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_11.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_8#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_8), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_12.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_9#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_9), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_13.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_10#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_10), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_14.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_11 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_11#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_11), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional_11"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_12 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_12#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_12), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional_12"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_13 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_13#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_13), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_15.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_13"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_14 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_14#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_14), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => indirect_expression_optional_16.Value.Optional(greedy: false).Token())).Named("indirect_expression_optional_14"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_15 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_15#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_15), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional_15"));

        public static Lazy<IParser<CharToken, SyntaxNode>> indirect_expression_optional_16 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("indirect_expression_optional_16#0", (args) => CreateSyntaxNode(true, nameof(indirect_expression_optional_16), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => abstol_expression.Value.Token())).Named("indirect_expression_optional_16"));

        public static Lazy<IParser<CharToken, SyntaxNode>> lsb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("lsb_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(lsb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("lsb_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("mintypmax_expression#0", (args) => CreateSyntaxNode(true, nameof(mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("mintypmax_expression#1", (args) => CreateSyntaxNode(true, nameof(mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()))).Named("mintypmax_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_conditional_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_conditional_expression#0", (args) => CreateSyntaxNode(true, nameof(module_path_conditional_expression), args), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token())).Named("module_path_conditional_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_expression#0", (args) => CreateSyntaxNode(true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_path_expression#1", (args) => CreateSyntaxNode(true, nameof(module_path_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))).Named("module_path_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_mintypmax_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#0", (args) => CreateSyntaxNode(true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#1", (args) => CreateSyntaxNode(true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#2", (args) => CreateSyntaxNode(true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_mintypmax_expression#3", (args) => CreateSyntaxNode(true, nameof(module_path_mintypmax_expression), args), new Lazy<IParser<CharToken>>(() => unary_module_path_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_primary.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()))))).Named("module_path_mintypmax_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> msb_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("msb_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(msb_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("msb_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#0", (args) => CreateSyntaxNode(true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_expression#1", (args) => CreateSyntaxNode(true, nameof(nature_attribute_expression), args), new Lazy<IParser<CharToken>>(() => nature_identifier.Value.Token()))).Named("nature_attribute_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> range_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("range_expression#0", (args) => CreateSyntaxNode(true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("range_expression#1", (args) => CreateSyntaxNode(true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => msb_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => lsb_constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("range_expression#2", (args) => CreateSyntaxNode(true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("+:", true).Text()), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("range_expression#3", (args) => CreateSyntaxNode(true, nameof(range_expression), args), new Lazy<IParser<CharToken>>(() => base_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String("-:", true).Text()), new Lazy<IParser<CharToken>>(() => width_constant_expression.Value.Token()))))).Named("range_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> width_constant_expression =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("width_constant_expression#0", (args) => CreateSyntaxNode(true, nameof(width_constant_expression), args), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("width_constant_expression"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_primary#0", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => number.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#1", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#2", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_multiple_concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#3", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#4", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_system_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#5", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#6", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_filter_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#7", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analog_small_signal_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#8", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => analysis_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#9", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#10", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#11", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => variable_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#12", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => net_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#13", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#14", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => parameter_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#15", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_primary#16", (args) => CreateSyntaxNode(true, nameof(analog_primary), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))))))))))))))))).Named("analog_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_primary#0", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => number.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#1", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_primary_optional.Value.Optional(greedy: false).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#2", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => specparam_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_primary_optional_2.Value.Optional(greedy: false).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#3", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#4", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_multiple_concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#5", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#6", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_system_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#7", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_built_in_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#8", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => constant_mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#9", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => @string.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#10", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => system_parameter_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#11", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#12", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => constant_analog_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("constant_primary#13", (args) => CreateSyntaxNode(true, nameof(constant_primary), args), new Lazy<IParser<CharToken>>(() => genvar_identifier.Value.Token()))))))))))))))).Named("constant_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_primary_optional#0", (args) => CreateSyntaxNode(true, nameof(constant_primary_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("constant_primary_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_primary_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_primary_optional_2#0", (args) => CreateSyntaxNode(true, nameof(constant_primary_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("constant_primary_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#0", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => number.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#1", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => identifier.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#2", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_concatenation.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#3", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => module_path_multiple_concatenation.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#4", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#5", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_path_primary#6", (args) => CreateSyntaxNode(true, nameof(module_path_primary), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => module_path_mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))))))).Named("module_path_primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("primary#0", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => number.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#1", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#2", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => multiple_concatenation.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#3", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#4", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => system_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#5", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => mintypmax_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#6", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => @string.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#7", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#8", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => port_probe_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#9", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => nature_attribute_reference.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#10", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#11", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => analog_built_in_function_call.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("primary#12", (args) => CreateSyntaxNode(true, nameof(primary), args), new Lazy<IParser<CharToken>>(() => primary_h.Value.Token())))))))))))))).Named("primary"));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("primary_h#0", (args) => CreateSyntaxNode(true, nameof(primary_h), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => primary_h_optional.Value.Optional(greedy: false).Token())).Named("primary_h"));

        public static Lazy<IParser<CharToken, SyntaxNode>> primary_h_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("primary_h_optional#0", (args) => CreateSyntaxNode(true, nameof(primary_h_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("primary_h_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue#0", (args) => CreateSyntaxNode(true, nameof(analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)), new Lazy<IParser<CharToken>>(() => analog_variable_lvalue_many.Value.Many(greedy: true).Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue#1", (args) => CreateSyntaxNode(true, nameof(analog_variable_lvalue), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()))).Named("analog_variable_lvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_variable_lvalue_many#0", (args) => CreateSyntaxNode(true, nameof(analog_variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("analog_variable_lvalue_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_assignment =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("array_analog_variable_assignment#0", (args) => CreateSyntaxNode(true, nameof(array_analog_variable_assignment), args), new Lazy<IParser<CharToken>>(() => Parse.String("array_analog_variable_lvalue", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(';', true))).Named("array_analog_variable_assignment"));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#0", (args) => CreateSyntaxNode(true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => Parse.String("array_variable_identifier", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#1", (args) => CreateSyntaxNode(true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => Parse.String("array_", true).Text()), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)), new Lazy<IParser<CharToken>>(() => array_analog_variable_rvalue_many.Value.Many(greedy: true).Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue#2", (args) => CreateSyntaxNode(true, nameof(array_analog_variable_rvalue), args), new Lazy<IParser<CharToken>>(() => assignment_pattern.Value.Token())))).Named("array_analog_variable_rvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> array_analog_variable_rvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("array_analog_variable_rvalue_many#0", (args) => CreateSyntaxNode(true, nameof(array_analog_variable_rvalue_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("array_analog_variable_rvalue_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_lvalue#0", (args) => CreateSyntaxNode(true, nameof(branch_lvalue), args), new Lazy<IParser<CharToken>>(() => branch_probe_function_call.Value.Token())).Named("branch_lvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_lvalue#0", (args) => CreateSyntaxNode(true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => net_lvalue_optional.Value.Optional(greedy: false).Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("net_lvalue#1", (args) => CreateSyntaxNode(true, nameof(net_lvalue), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => net_lvalue_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))).Named("net_lvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_lvalue_optional#0", (args) => CreateSyntaxNode(true, nameof(net_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => constant_expression_lazy.Value.Many(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("net_lvalue_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_lvalue_many#0", (args) => CreateSyntaxNode(true, nameof(net_lvalue_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => net_lvalue.Value.Token())).Named("net_lvalue_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_lazy#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_lazy), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("constant_expression_lazy"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_lvalue#0", (args) => CreateSyntaxNode(true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => hierarchical_variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => variable_lvalue_optional.Value.Optional(greedy: false).Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("variable_lvalue#1", (args) => CreateSyntaxNode(true, nameof(variable_lvalue), args), new Lazy<IParser<CharToken>>(() => Parse.Char('{', true)), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token()), new Lazy<IParser<CharToken>>(() => variable_lvalue_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('}', true)))).Named("variable_lvalue"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_lvalue_optional#0", (args) => CreateSyntaxNode(true, nameof(variable_lvalue_optional), args), new Lazy<IParser<CharToken>>(() => lazy_expressions.Value.Many(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("variable_lvalue_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_lvalue_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_lvalue_many#0", (args) => CreateSyntaxNode(true, nameof(variable_lvalue_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => variable_lvalue.Value.Token())).Named("variable_lvalue_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> lazy_expressions =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("lazy_expressions#0", (args) => CreateSyntaxNode(true, nameof(lazy_expressions), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("lazy_expressions"));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("unary_operator#0", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('+', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#1", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('-', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#2", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('!', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#3", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~^", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#4", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("^~", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#5", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~&", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#6", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('~', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#7", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('&', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#8", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('|', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#9", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~|", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("unary_operator#10", (args) => CreateSyntaxNode(true, nameof(unary_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('^', true))))))))))))).Named("unary_operator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator#0", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_0.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#1", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_1.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#2", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_2.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#3", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_3.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#4", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_4.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#5", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_5.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#6", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_6.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#7", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_7.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#8", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_8.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#9", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_9.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator#10", (args) => CreateSyntaxNode(true, nameof(binary_operator), args), new Lazy<IParser<CharToken>>(() => binary_operator_10.Value.Token())))))))))))).Named("binary_operator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_0 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_0#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_0), args), new Lazy<IParser<CharToken>>(() => Parse.Char('+', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_0#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_0), args), new Lazy<IParser<CharToken>>(() => Parse.Char('-', true)))).Named("binary_operator_0"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_1 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_1#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_1), args), new Lazy<IParser<CharToken>>(() => Parse.String("**", true).Text())).Named("binary_operator_1"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_2#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('*', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_2#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('/', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_2#2", (args) => CreateSyntaxNode(true, nameof(binary_operator_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('%', true))))).Named("binary_operator_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_3 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_3#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => Parse.String("<<", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_3#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => Parse.String(">>", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_3#2", (args) => CreateSyntaxNode(true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => Parse.String("<<<", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_3#3", (args) => CreateSyntaxNode(true, nameof(binary_operator_3), args), new Lazy<IParser<CharToken>>(() => Parse.String(">>>", true).Text()))))).Named("binary_operator_3"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_4 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_4#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => Parse.String("<=", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_4#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => Parse.String(">=", true).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_4#2", (args) => CreateSyntaxNode(true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_4#3", (args) => CreateSyntaxNode(true, nameof(binary_operator_4), args), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)))))).Named("binary_operator_4"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_5 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_5#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("==", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_5#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("!=", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_5#2", (args) => CreateSyntaxNode(true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("===", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_5#3", (args) => CreateSyntaxNode(true, nameof(binary_operator_5), args), new Lazy<IParser<CharToken>>(() => Parse.String("!==", true).Text()))))).Named("binary_operator_5"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_6 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_6#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_6), args), new Lazy<IParser<CharToken>>(() => Parse.Char('&', true))).Named("binary_operator_6"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_7 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_7#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => Parse.Char('^', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_7#1", (args) => CreateSyntaxNode(true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => Parse.String("^~", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_operator_7#2", (args) => CreateSyntaxNode(true, nameof(binary_operator_7), args), new Lazy<IParser<CharToken>>(() => Parse.String("~^", true).Text())))).Named("binary_operator_7"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_8 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_8#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_8), args), new Lazy<IParser<CharToken>>(() => Parse.Char('|', true))).Named("binary_operator_8"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_9 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_9#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_9), args), new Lazy<IParser<CharToken>>(() => Parse.String("&&", true).Text())).Named("binary_operator_9"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_operator_10 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_operator_10#0", (args) => CreateSyntaxNode(true, nameof(binary_operator_10), args), new Lazy<IParser<CharToken>>(() => Parse.String("||", true).Text())).Named("binary_operator_10"));

        public static Lazy<IParser<CharToken, SyntaxNode>> unary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#0", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('!', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#1", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('~', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#2", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('&', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#3", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~&", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#4", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('|', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#5", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~|", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#6", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('^', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#7", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~^", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unary_module_path_operator#8", (args) => CreateSyntaxNode(true, nameof(unary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("^~", true).Text())))))))))).Named("unary_module_path_operator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_module_path_operator =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#0", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("==", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#1", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("!=", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#2", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("&&", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#3", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("||", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#4", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('&', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#5", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('|', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#6", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.Char('^', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#7", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("^~", true).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_module_path_operator#8", (args) => CreateSyntaxNode(true, nameof(binary_module_path_operator), args), new Lazy<IParser<CharToken>>(() => Parse.String("~^", true).Text())))))))))).Named("binary_module_path_operator"));

        public static Lazy<IParser<CharToken, SyntaxNode>> number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("number#0", (args) => CreateSyntaxNode(false, nameof(number), args), new Lazy<IParser<CharToken>>(() => binary_number.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("number#1", (args) => CreateSyntaxNode(false, nameof(number), args), new Lazy<IParser<CharToken>>(() => hex_number.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("number#2", (args) => CreateSyntaxNode(false, nameof(number), args), new Lazy<IParser<CharToken>>(() => octal_number.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("number#3", (args) => CreateSyntaxNode(false, nameof(number), args), new Lazy<IParser<CharToken>>(() => real_number_of_decimal.Value))))).Named("number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_of_decimal =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_number_of_decimal#0", (args) => CreateSyntaxNode(false, nameof(real_number_of_decimal), args), new Lazy<IParser<CharToken>>(() => real_number.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("real_number_of_decimal#1", (args) => CreateSyntaxNode(false, nameof(real_number_of_decimal), args), new Lazy<IParser<CharToken>>(() => decimal_number.Value))).Named("real_number_of_decimal"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_number#0", (args) => CreateSyntaxNode(false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => real_number_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => exp.Value), new Lazy<IParser<CharToken>>(() => sign.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => unsigned_number.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("real_number#1", (args) => CreateSyntaxNode(false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => real_number_optional_2.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => scale_factor.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("real_number#2", (args) => CreateSyntaxNode(false, nameof(real_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value), new Lazy<IParser<CharToken>>(() => Parse.Char('.', false)), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)))).Named("real_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_number_optional#0", (args) => CreateSyntaxNode(false, nameof(real_number_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', false)), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Named("real_number_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_number_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_number_optional_2#0", (args) => CreateSyntaxNode(false, nameof(real_number_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('.', false)), new Lazy<IParser<CharToken>>(() => unsigned_number.Value)).Named("real_number_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> exp =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("exp#0", (args) => CreateSyntaxNode(false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => Parse.Char('e', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("exp#1", (args) => CreateSyntaxNode(false, nameof(exp), args), new Lazy<IParser<CharToken>>(() => Parse.Char('E', false)))).Named("exp"));

        public static Lazy<IParser<CharToken, SyntaxNode>> scale_factor =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("scale_factor#0", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('T', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#1", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('G', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#2", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('M', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#3", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('K', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#4", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('k', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#5", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('m', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#6", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('u', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#7", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('n', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#8", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('p', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#9", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('f', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("scale_factor#10", (args) => CreateSyntaxNode(false, nameof(scale_factor), args), new Lazy<IParser<CharToken>>(() => Parse.Char('a', false))))))))))))).Named("scale_factor"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_number#0", (args) => CreateSyntaxNode(false, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => unsigned_number.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_number#1", (args) => CreateSyntaxNode(false, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => x_digit.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many.Value.Many(greedy: true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_number#2", (args) => CreateSyntaxNode(false, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => decimal_base.Value), new Lazy<IParser<CharToken>>(() => z_digit.Value), new Lazy<IParser<CharToken>>(() => decimal_number_many_2.Value.Many(greedy: true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_number#3", (args) => CreateSyntaxNode(false, nameof(decimal_number), args), new Lazy<IParser<CharToken>>(() => unsigned_number.Value))))).Named("decimal_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_number_many#0", (args) => CreateSyntaxNode(false, nameof(decimal_number_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false))).Named("decimal_number_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_number_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_number_many_2#0", (args) => CreateSyntaxNode(false, nameof(decimal_number_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false))).Named("decimal_number_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_number#0", (args) => CreateSyntaxNode(false, nameof(binary_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => binary_base.Value), new Lazy<IParser<CharToken>>(() => binary_value.Value)).Named("binary_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_number#0", (args) => CreateSyntaxNode(false, nameof(octal_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => octal_base.Value), new Lazy<IParser<CharToken>>(() => octal_value.Value)).Named("octal_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_number#0", (args) => CreateSyntaxNode(false, nameof(hex_number), args), new Lazy<IParser<CharToken>>(() => size.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => hex_base.Value), new Lazy<IParser<CharToken>>(() => hex_value.Value)).Named("hex_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> sign =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("sign#0", (args) => CreateSyntaxNode(true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => Parse.Char('+', true)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("sign#1", (args) => CreateSyntaxNode(true, nameof(sign), args), new Lazy<IParser<CharToken>>(() => Parse.Char('-', true)))).Named("sign"));

        public static Lazy<IParser<CharToken, SyntaxNode>> size =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("size#0", (args) => CreateSyntaxNode(false, nameof(size), args), new Lazy<IParser<CharToken>>(() => non_zero_unsigned_number.Value)).Named("size"));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_zero_unsigned_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("non_zero_unsigned_number#0", (args) => CreateSyntaxNode(false, nameof(non_zero_unsigned_number), args), new Lazy<IParser<CharToken>>(() => non_zero_decimal_digit.Value), new Lazy<IParser<CharToken>>(() => non_zero_unsigned_number_many.Value.Many(greedy: true))).Named("non_zero_unsigned_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_zero_unsigned_number_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("non_zero_unsigned_number_many#0", (args) => CreateSyntaxNode(false, nameof(non_zero_unsigned_number_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("non_zero_unsigned_number_many#1", (args) => CreateSyntaxNode(false, nameof(non_zero_unsigned_number_many), args), new Lazy<IParser<CharToken>>(() => decimal_digit.Value))).Named("non_zero_unsigned_number_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> unsigned_number =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("unsigned_number#0", (args) => CreateSyntaxNode(false, nameof(unsigned_number), args), new Lazy<IParser<CharToken>>(() => decimal_digit.Value), new Lazy<IParser<CharToken>>(() => unsigned_number_many.Value.Many(greedy: true))).Named("unsigned_number"));

        public static Lazy<IParser<CharToken, SyntaxNode>> unsigned_number_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("unsigned_number_many#0", (args) => CreateSyntaxNode(false, nameof(unsigned_number_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("unsigned_number_many#1", (args) => CreateSyntaxNode(false, nameof(unsigned_number_many), args), new Lazy<IParser<CharToken>>(() => decimal_digit.Value))).Named("unsigned_number_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_value#0", (args) => CreateSyntaxNode(false, nameof(binary_value), args), new Lazy<IParser<CharToken>>(() => binary_digit.Value), new Lazy<IParser<CharToken>>(() => binary_value_many.Value.Many(greedy: true))).Named("binary_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_value_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_value_many#0", (args) => CreateSyntaxNode(false, nameof(binary_value_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_value_many#1", (args) => CreateSyntaxNode(false, nameof(binary_value_many), args), new Lazy<IParser<CharToken>>(() => binary_digit.Value))).Named("binary_value_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_value#0", (args) => CreateSyntaxNode(false, nameof(octal_value), args), new Lazy<IParser<CharToken>>(() => octal_digit.Value), new Lazy<IParser<CharToken>>(() => octal_value_many.Value.Many(greedy: true))).Named("octal_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_value_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_value_many#0", (args) => CreateSyntaxNode(false, nameof(octal_value_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("octal_value_many#1", (args) => CreateSyntaxNode(false, nameof(octal_value_many), args), new Lazy<IParser<CharToken>>(() => octal_digit.Value))).Named("octal_value_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_value =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_value#0", (args) => CreateSyntaxNode(false, nameof(hex_value), args), new Lazy<IParser<CharToken>>(() => hex_digit.Value), new Lazy<IParser<CharToken>>(() => hex_value_many.Value.Many(greedy: true))).Named("hex_value"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_value_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_value_many#0", (args) => CreateSyntaxNode(false, nameof(hex_value_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('_', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("hex_value_many#1", (args) => CreateSyntaxNode(false, nameof(hex_value_many), args), new Lazy<IParser<CharToken>>(() => hex_digit.Value))).Named("hex_value_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_base#0", (args) => CreateSyntaxNode(false, nameof(decimal_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => decimal_base_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('d', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("decimal_base#1", (args) => CreateSyntaxNode(false, nameof(decimal_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => decimal_base_optional_2.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('D', false)))).Named("decimal_base"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_base_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_base_optional#0", (args) => CreateSyntaxNode(false, nameof(decimal_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("decimal_base_optional#1", (args) => CreateSyntaxNode(false, nameof(decimal_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("decimal_base_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_base_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_base_optional_2#0", (args) => CreateSyntaxNode(false, nameof(decimal_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("decimal_base_optional_2#1", (args) => CreateSyntaxNode(false, nameof(decimal_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("decimal_base_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_base#0", (args) => CreateSyntaxNode(false, nameof(binary_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => binary_base_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('b', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_base#1", (args) => CreateSyntaxNode(false, nameof(binary_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => binary_base_optional_2.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('B', false)))).Named("binary_base"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_base_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_base_optional#0", (args) => CreateSyntaxNode(false, nameof(binary_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_base_optional#1", (args) => CreateSyntaxNode(false, nameof(binary_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("binary_base_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_base_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_base_optional_2#0", (args) => CreateSyntaxNode(false, nameof(binary_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("binary_base_optional_2#1", (args) => CreateSyntaxNode(false, nameof(binary_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("binary_base_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_base#0", (args) => CreateSyntaxNode(false, nameof(octal_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => octal_base_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('o', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("octal_base#1", (args) => CreateSyntaxNode(false, nameof(octal_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => octal_base_optional_2.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('O', false)))).Named("octal_base"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_base_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_base_optional#0", (args) => CreateSyntaxNode(false, nameof(octal_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("octal_base_optional#1", (args) => CreateSyntaxNode(false, nameof(octal_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("octal_base_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_base_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_base_optional_2#0", (args) => CreateSyntaxNode(false, nameof(octal_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("octal_base_optional_2#1", (args) => CreateSyntaxNode(false, nameof(octal_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("octal_base_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_base =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_base#0", (args) => CreateSyntaxNode(false, nameof(hex_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => hex_base_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('h', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("hex_base#1", (args) => CreateSyntaxNode(false, nameof(hex_base), args), new Lazy<IParser<CharToken>>(() => Parse.Char('\'', false)), new Lazy<IParser<CharToken>>(() => hex_base_optional_2.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('H', false)))).Named("hex_base"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_base_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_base_optional#0", (args) => CreateSyntaxNode(false, nameof(hex_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("hex_base_optional#1", (args) => CreateSyntaxNode(false, nameof(hex_base_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("hex_base_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_base_optional_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_base_optional_2#0", (args) => CreateSyntaxNode(false, nameof(hex_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('s', false)))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("hex_base_optional_2#1", (args) => CreateSyntaxNode(false, nameof(hex_base_optional_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('S', false)))).Named("hex_base_optional_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> non_zero_decimal_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#0", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#1", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('2', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#2", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('3', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#3", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('4', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#4", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('5', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#5", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('6', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#6", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('7', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#7", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('8', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("non_zero_decimal_digit#8", (args) => CreateSyntaxNode(false, nameof(non_zero_decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('9', false))))))))))).Named("non_zero_decimal_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> decimal_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#0", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#1", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#2", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('2', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#3", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('3', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#4", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('4', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#5", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('5', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#6", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('6', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#7", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('7', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#8", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('8', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("decimal_digit#9", (args) => CreateSyntaxNode(false, nameof(decimal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('9', false)))))))))))).Named("decimal_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> binary_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("binary_digit#0", (args) => CreateSyntaxNode(false, nameof(binary_digit), args), new Lazy<IParser<CharToken>>(() => x_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_digit#1", (args) => CreateSyntaxNode(false, nameof(binary_digit), args), new Lazy<IParser<CharToken>>(() => z_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_digit#2", (args) => CreateSyntaxNode(false, nameof(binary_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("binary_digit#3", (args) => CreateSyntaxNode(false, nameof(binary_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', false)))))).Named("binary_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> octal_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("octal_digit#0", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => x_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#1", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => z_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#2", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#3", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#4", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('2', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#5", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('3', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#6", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('4', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#7", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('5', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#8", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('6', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("octal_digit#9", (args) => CreateSyntaxNode(false, nameof(octal_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('7', false)))))))))))).Named("octal_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hex_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hex_digit#0", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => x_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#1", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => z_digit.Value))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#2", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('0', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#3", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('1', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#4", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('2', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#5", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('3', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#6", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('4', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#7", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('5', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#8", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('6', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#9", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('7', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#10", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('8', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#11", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('9', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#12", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('a', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#13", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('b', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#14", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('c', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#15", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('d', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#16", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('e', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#17", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('f', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#18", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('A', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#19", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('B', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#20", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('C', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#21", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('D', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#22", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('E', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hex_digit#23", (args) => CreateSyntaxNode(false, nameof(hex_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('F', false)))))))))))))))))))))))))).Named("hex_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> x_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("x_digit#0", (args) => CreateSyntaxNode(false, nameof(x_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('x', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("x_digit#1", (args) => CreateSyntaxNode(false, nameof(x_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('X', false)))).Named("x_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> z_digit =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("z_digit#0", (args) => CreateSyntaxNode(false, nameof(z_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('z', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("z_digit#1", (args) => CreateSyntaxNode(false, nameof(z_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('Z', false)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("z_digit#2", (args) => CreateSyntaxNode(false, nameof(z_digit), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', false))))).Named("z_digit"));

        public static Lazy<IParser<CharToken, SyntaxNode>> @string =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("@string#0", (args) => CreateSyntaxNode(true, nameof(@string), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("\"((?:\\\\.|[^\\\"])*)\"").Token())).Named("string"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_reference#0", (args) => CreateSyntaxNode(true, nameof(nature_attribute_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => potential_or_flow.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', true)), new Lazy<IParser<CharToken>>(() => nature_attribute_identifier.Value.Token())).Named("nature_attribute_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_port_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_port_reference#0", (args) => CreateSyntaxNode(true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_port_reference#1", (args) => CreateSyntaxNode(true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_port_reference#2", (args) => CreateSyntaxNode(true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_port_reference#3", (args) => CreateSyntaxNode(true, nameof(analog_port_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()))))).Named("analog_port_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#0", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#1", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#2", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#3", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#4", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_net_reference#5", (args) => CreateSyntaxNode(true, nameof(analog_net_reference), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value.Token()))))))).Named("analog_net_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_reference#0", (args) => CreateSyntaxNode(true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_reference#1", (args) => CreateSyntaxNode(true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_branch_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("branch_reference#2", (args) => CreateSyntaxNode(true, nameof(branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference.Value.Token())))).Named("branch_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#0", (args) => CreateSyntaxNode(true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String(".branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => branch_terminal.Value.Token()), new Lazy<IParser<CharToken>>(() => hierarchical_unnamed_branch_reference_optional.Value.Optional(greedy: false).Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#1", (args) => CreateSyntaxNode(true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String(".branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)), new Lazy<IParser<CharToken>>(() => port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference#2", (args) => CreateSyntaxNode(true, nameof(hierarchical_unnamed_branch_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_inst_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.String(".branch", true).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('(', true)), new Lazy<IParser<CharToken>>(() => Parse.Char('<', true)), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('>', true)), new Lazy<IParser<CharToken>>(() => Parse.Char(')', true))))).Named("hierarchical_unnamed_branch_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_unnamed_branch_reference_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_unnamed_branch_reference_optional#0", (args) => CreateSyntaxNode(true, nameof(hierarchical_unnamed_branch_reference_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => branch_terminal.Value.Token())).Named("hierarchical_unnamed_branch_reference_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_reference#0", (args) => CreateSyntaxNode(true, nameof(parameter_reference), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("parameter_reference#1", (args) => CreateSyntaxNode(true, nameof(parameter_reference), args), new Lazy<IParser<CharToken>>(() => parameter_identifier.Value.Token()))).Named("parameter_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_reference#0", (args) => CreateSyntaxNode(true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)), new Lazy<IParser<CharToken>>(() => variable_reference_many.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("variable_reference#1", (args) => CreateSyntaxNode(true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)), new Lazy<IParser<CharToken>>(() => variable_reference_many_2.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("variable_reference#2", (args) => CreateSyntaxNode(true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => variable_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("variable_reference#3", (args) => CreateSyntaxNode(true, nameof(variable_reference), args), new Lazy<IParser<CharToken>>(() => real_identifier.Value.Token()))))).Named("variable_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_reference_many#0", (args) => CreateSyntaxNode(true, nameof(variable_reference_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("variable_reference_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_reference_many_2 =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_reference_many_2#0", (args) => CreateSyntaxNode(true, nameof(variable_reference_many_2), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true))).Named("variable_reference_many_2"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_reference =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_reference#0", (args) => CreateSyntaxNode(true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_reference#1", (args) => CreateSyntaxNode(true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char('[', true)), new Lazy<IParser<CharToken>>(() => analog_range_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', true)))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_reference#2", (args) => CreateSyntaxNode(true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("net_reference#3", (args) => CreateSyntaxNode(true, nameof(net_reference), args), new Lazy<IParser<CharToken>>(() => hierarchical_port_identifier.Value.Token()))))).Named("net_reference"));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("attribute_instance#0", (args) => CreateSyntaxNode(true, nameof(attribute_instance), args), new Lazy<IParser<CharToken>>(() => Parse.String("(*", true).Text()), new Lazy<IParser<CharToken>>(() => attr_spec.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance_many.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => Parse.String("*)", true).Text())).Named("attribute_instance"));

        public static Lazy<IParser<CharToken, SyntaxNode>> attribute_instance_many =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("attribute_instance_many#0", (args) => CreateSyntaxNode(true, nameof(attribute_instance_many), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => attr_spec.Value.Token())).Named("attribute_instance_many"));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("attr_spec#0", (args) => CreateSyntaxNode(true, nameof(attr_spec), args), new Lazy<IParser<CharToken>>(() => attr_name.Value.Token()), new Lazy<IParser<CharToken>>(() => attr_spec_optional.Value.Optional(greedy: false).Token())).Named("attr_spec"));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_spec_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("attr_spec_optional#0", (args) => CreateSyntaxNode(true, nameof(attr_spec_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('=', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token())).Named("attr_spec_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> attr_name =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("attr_name#0", (args) => CreateSyntaxNode(true, nameof(attr_name), args), new Lazy<IParser<CharToken>>(() => identifier.Value.Token())).Named("attr_name"));

        public static Lazy<IParser<CharToken, SyntaxNode>> ams_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("ams_net_identifier#0", (args) => CreateSyntaxNode(false, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => net_identifier.Value), new Lazy<IParser<CharToken>>(() => dimension.Value.Many(greedy: true).Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("ams_net_identifier#1", (args) => CreateSyntaxNode(false, nameof(ams_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_net_identifier.Value))).Named("ams_net_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_block_identifier#0", (args) => CreateSyntaxNode(false, nameof(analog_block_identifier), args), new Lazy<IParser<CharToken>>(() => block_identifier.Value)).Named("analog_block_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_function_identifier#0", (args) => CreateSyntaxNode(false, nameof(analog_function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("analog_function_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_task_identifier#0", (args) => CreateSyntaxNode(false, nameof(analog_system_task_identifier), args), new Lazy<IParser<CharToken>>(() => system_task_identifier.Value)).Named("analog_system_task_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_system_function_identifier#0", (args) => CreateSyntaxNode(false, nameof(analog_system_function_identifier), args), new Lazy<IParser<CharToken>>(() => system_function_identifier.Value)).Named("analog_system_function_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_identifier#0", (args) => CreateSyntaxNode(false, nameof(analysis_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("analysis_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("block_identifier#0", (args) => CreateSyntaxNode(false, nameof(block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("block_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("branch_identifier#0", (args) => CreateSyntaxNode(false, nameof(branch_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("branch_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> cell_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("cell_identifier#0", (args) => CreateSyntaxNode(false, nameof(cell_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("cell_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> config_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("config_identifier#0", (args) => CreateSyntaxNode(false, nameof(config_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("config_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connectmodule_identifier#0", (args) => CreateSyntaxNode(false, nameof(connectmodule_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value)).Named("connectmodule_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> connectrules_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("connectrules_identifier#0", (args) => CreateSyntaxNode(false, nameof(connectrules_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("connectrules_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> discipline_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("discipline_identifier#0", (args) => CreateSyntaxNode(false, nameof(discipline_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("discipline_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> escaped_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("escaped_identifier#0", (args) => CreateSyntaxNode(true, nameof(escaped_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("\\\\[^ ]+ ").Token())).Named("escaped_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_identifier#0", (args) => CreateSyntaxNode(false, nameof(event_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("event_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("function_identifier#0", (args) => CreateSyntaxNode(false, nameof(function_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("function_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> gate_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("gate_instance_identifier#0", (args) => CreateSyntaxNode(false, nameof(gate_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("gate_instance_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> generate_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("generate_block_identifier#0", (args) => CreateSyntaxNode(false, nameof(generate_block_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("generate_block_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_identifier#0", (args) => CreateSyntaxNode(false, nameof(genvar_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("genvar_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_block_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_block_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_block_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_block_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_branch_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_branch_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_branch_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_branch_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_event_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_event_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_event_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_event_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_function_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_function_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_function_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy.Value.Many(greedy: false)), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("hierarchical_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_optional#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_identifier_optional), args), new Lazy<IParser<CharToken>>(() => Parse.String("$root", false).Text()), new Lazy<IParser<CharToken>>(() => Parse.Char('.', false))).Named("hierarchical_identifier_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_identifier_lazy), args), new Lazy<IParser<CharToken>>(() => identifier.Value), new Lazy<IParser<CharToken>>(() => hierarchical_identifier_lazy_optional.Value.Optional(greedy: false)), new Lazy<IParser<CharToken>>(() => Parse.Char('.', false))).Named("hierarchical_identifier_lazy"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_identifier_lazy_optional =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_identifier_lazy_optional#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_identifier_lazy_optional), args), new Lazy<IParser<CharToken>>(() => Parse.Char('[', false)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(']', false))).Named("hierarchical_identifier_lazy_optional"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_inst_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_inst_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_inst_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_inst_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_net_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_net_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_net_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_parameter_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_parameter_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_port_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_port_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_port_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_variable_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_variable_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_variable_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> hierarchical_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("hierarchical_task_identifier#0", (args) => CreateSyntaxNode(false, nameof(hierarchical_task_identifier), args), new Lazy<IParser<CharToken>>(() => hierarchical_identifier.Value)).Named("hierarchical_task_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("identifier#0", (args) => CreateSyntaxNode(false, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => simple_identifier.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("identifier#1", (args) => CreateSyntaxNode(false, nameof(identifier), args), new Lazy<IParser<CharToken>>(() => escaped_identifier.Value.Token()))).Named("identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> inout_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("inout_port_identifier#0", (args) => CreateSyntaxNode(false, nameof(inout_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("inout_port_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> input_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("input_port_identifier#0", (args) => CreateSyntaxNode(false, nameof(input_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("input_port_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("instance_identifier#0", (args) => CreateSyntaxNode(false, nameof(instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("instance_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> library_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("library_identifier#0", (args) => CreateSyntaxNode(false, nameof(library_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("library_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_identifier#0", (args) => CreateSyntaxNode(false, nameof(module_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("module_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_instance_identifier#0", (args) => CreateSyntaxNode(false, nameof(module_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("module_instance_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_or_paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#0", (args) => CreateSyntaxNode(false, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => module_identifier.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("module_or_paramset_identifier#1", (args) => CreateSyntaxNode(false, nameof(module_or_paramset_identifier), args), new Lazy<IParser<CharToken>>(() => paramset_identifier.Value))).Named("module_or_paramset_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_output_variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_output_variable_identifier#0", (args) => CreateSyntaxNode(false, nameof(module_output_variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("module_output_variable_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_parameter_identifier#0", (args) => CreateSyntaxNode(false, nameof(module_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("module_parameter_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_identifier#0", (args) => CreateSyntaxNode(false, nameof(nature_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("nature_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_access_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_access_identifier#0", (args) => CreateSyntaxNode(false, nameof(nature_access_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("nature_access_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> nature_attribute_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#0", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("abstol", false).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#1", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("access", false).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#2", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("ddt_nature", false).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#3", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("idt_nature", false).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#4", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("units", false).Text()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("nature_attribute_identifier#5", (args) => CreateSyntaxNode(false, nameof(nature_attribute_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value))))))).Named("nature_attribute_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> net_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("net_identifier#0", (args) => CreateSyntaxNode(false, nameof(net_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("net_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> output_port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("output_port_identifier#0", (args) => CreateSyntaxNode(false, nameof(output_port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("output_port_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("parameter_identifier#0", (args) => CreateSyntaxNode(false, nameof(parameter_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("parameter_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_identifier#0", (args) => CreateSyntaxNode(false, nameof(paramset_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("paramset_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> port_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("port_identifier#0", (args) => CreateSyntaxNode(false, nameof(port_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("port_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> real_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("real_identifier#0", (args) => CreateSyntaxNode(false, nameof(real_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("real_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> simple_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("simple_identifier#0", (args) => CreateSyntaxNode(false, nameof(simple_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("[a-zA-Z_][a-zA-Z0-9_$]*"))).Named("simple_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> specparam_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("specparam_identifier#0", (args) => CreateSyntaxNode(true, nameof(specparam_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value.Token())).Named("specparam_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_function_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_function_identifier#0", (args) => CreateSyntaxNode(false, nameof(system_function_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("\\$[a-zA-Z0-9_$][a-zA-Z0-9_$]*"))).Named("system_function_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_parameter_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_parameter_identifier#0", (args) => CreateSyntaxNode(false, nameof(system_parameter_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("\\$[a-zA-Z0-9_$][a-zA-Z0-9_$]*"))).Named("system_parameter_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> system_task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("system_task_identifier#0", (args) => CreateSyntaxNode(false, nameof(system_task_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.Regex("\\$[a-zA-Z0-9_$][a-zA-Z0-9_$]*"))).Named("system_task_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> task_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("task_identifier#0", (args) => CreateSyntaxNode(false, nameof(task_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("task_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> terminal_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("terminal_identifier#0", (args) => CreateSyntaxNode(false, nameof(terminal_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("terminal_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> text_macro_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("text_macro_identifier#0", (args) => CreateSyntaxNode(false, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("text_macro_identifier#1", (args) => CreateSyntaxNode(false, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("__VAMS_ENABLE__", false).Text()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("text_macro_identifier#2", (args) => CreateSyntaxNode(false, nameof(text_macro_identifier), args), new Lazy<IParser<CharToken>>(() => Parse.String("__VAMS_COMPACT_MODELING__", false).Text())))).Named("text_macro_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> topmodule_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("topmodule_identifier#0", (args) => CreateSyntaxNode(false, nameof(topmodule_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("topmodule_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_identifier#0", (args) => CreateSyntaxNode(false, nameof(udp_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("udp_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> udp_instance_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("udp_instance_identifier#0", (args) => CreateSyntaxNode(false, nameof(udp_instance_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("udp_instance_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> variable_identifier =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("variable_identifier#0", (args) => CreateSyntaxNode(false, nameof(variable_identifier), args), new Lazy<IParser<CharToken>>(() => identifier.Value)).Named("variable_identifier"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.String("or", true).Text()), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => analog_event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("analog_event_expression_prim#2", (args) => CreateSyntaxNode(true, nameof(analog_event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty))))).Named("analog_event_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analog_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analog_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analog_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analog_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analog_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(analog_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty)))).Named("analog_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> analysis_or_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => analysis_or_constant_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("analysis_or_constant_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(analysis_or_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty)))).Named("analysis_or_constant_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("constant_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => constant_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("constant_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty)))).Named("constant_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> event_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("event_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.String("or", true).Text()), new Lazy<IParser<CharToken>>(() => event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char(',', true)), new Lazy<IParser<CharToken>>(() => event_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => event_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("event_expression_prim#2", (args) => CreateSyntaxNode(true, nameof(event_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty))))).Named("event_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> expression1_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("expression1_prim#0", (args) => CreateSyntaxNode(true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => expression2.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => expression3.Value.Token()), new Lazy<IParser<CharToken>>(() => expression1_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("expression1_prim#1", (args) => CreateSyntaxNode(true, nameof(expression1_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty)))).Named("expression1_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> genvar_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => genvar_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => genvar_expression_prim.Value.Token()))
           .Or(Parse.Sequence<CharToken, SyntaxNode>("genvar_expression_prim#2", (args) => CreateSyntaxNode(true, nameof(genvar_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty))))).Named("genvar_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> module_path_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_module_path_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => module_path_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => module_path_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("module_path_expression_prim#2", (args) => CreateSyntaxNode(true, nameof(module_path_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty))))).Named("module_path_expression_prim"));

        public static Lazy<IParser<CharToken, SyntaxNode>> paramset_constant_expression_prim =
          new Lazy<IParser<CharToken, SyntaxNode>>(() => Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#0", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => binary_operator.Value.Token()), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#1", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Char('?', true)), new Lazy<IParser<CharToken>>(() => attribute_instance.Value.Many(greedy: true).Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => Parse.Char(':', true)), new Lazy<IParser<CharToken>>(() => paramset_constant_expression.Value.Token()), new Lazy<IParser<CharToken>>(() => paramset_constant_expression_prim.Value.Token()))
           .XOr(Parse.Sequence<CharToken, SyntaxNode>("paramset_constant_expression_prim#2", (args) => CreateSyntaxNode(true, nameof(paramset_constant_expression_prim), args), new Lazy<IParser<CharToken>>(() => Parse.Return(string.Empty))))).Named("paramset_constant_expression_prim"));

        public static Func<bool, string, (string valueParserName, object value)[], SyntaxNode> CreateSyntaxNode =
        (tokenize, name, args) => {
            var result = new (string valueParserName, object value)[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                var res = args[i].value;

                if (res is IOption<object> c)
                {
                    result[i].value = new SyntaxNodeOption(c.GetOrDefault());
                }
                else
                {
                    result[i].value = res;
                }

                result[i].valueParserName = args[i].valueParserName;
            }
            return new SyntaxNode(name, tokenize, result);
        };


    }
}