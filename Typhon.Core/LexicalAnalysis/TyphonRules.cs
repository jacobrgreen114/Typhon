namespace Typhon.Core.LexicalAnalysis;

/*
 * ORDER OF RULES MATTER
 */

internal static class TyphonLexicalRule
{
    public static readonly IReadOnlyList<ILexicalRule> Rules = Helpers.Combine(
        Ignorable.Rules, Symbols.Rules, Keywords.Rules, Identifiers.Rules,
        Literals.Rules, Operators.Rules
    );

    private static class Ignorable
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create(true, false, true);

        private static readonly ILexicalRule Whitespace =
            ILexicalRule.Create(TokenType.Whitespace, Settings, @"\s+");

        private static readonly ILexicalRule CommentSingle =
            ILexicalRule.Create(TokenType.Comment, Settings, @"\/\/.*");

        private static readonly ILexicalRule CommentMultiline =
            ILexicalRule.Create(
                TokenType.Comment, Settings, @"\/\*[\S\s]*?\*\/"
            );

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Whitespace, CommentSingle, CommentMultiline
        };
    }

    private static class Literals
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create(false, true, true);

        private static readonly ILexicalRule Integer = ILexicalRule.Create(
            TokenType.LiteralInteger, Settings, "[0-9]+"
        );

        private static readonly ILexicalRule Float =
            ILexicalRule.Create(TokenType.LiteralFloat, Settings, "");

        private static readonly ILexicalRule String = ILexicalRule.Create(
            TokenType.LiteralString, Settings,
            @"""(?:[^\\""\n]|\\[\s\S]|\\"")*"""
        );

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Integer /*, Float*/, String
        };
    }

    private static class Symbols
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create(false, false, true);

        private static readonly ILexicalRule Terminator =
            ILexicalRule.Create(TokenType.Terminator, Settings, @";");

        private static readonly ILexicalRule BraceOpen =
            ILexicalRule.Create(TokenType.BraceOpen, Settings, @"{");

        private static readonly ILexicalRule BraceClose =
            ILexicalRule.Create(TokenType.BraceClose, Settings, @"}");

        private static readonly ILexicalRule ParenOpen =
            ILexicalRule.Create(TokenType.ParenOpen, Settings, @"\(");

        private static readonly ILexicalRule ParenClose =
            ILexicalRule.Create(TokenType.ParenClose, Settings, @"\)");

        private static readonly ILexicalRule BracketOpen =
            ILexicalRule.Create(TokenType.BracketOpen, Settings, @"\[");

        private static readonly ILexicalRule BracketClose =
            ILexicalRule.Create(TokenType.BracketClose, Settings, @"\]");

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Terminator, BraceOpen, BraceClose, ParenOpen, ParenClose,
            BracketOpen, BracketClose
        };
    }


    private static class Operators
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create(false, false, true);

        private static readonly ILexicalRule Assign =
            ILexicalRule.Create(TokenType.Assign, Settings, @"=");

        private static readonly ILexicalRule Increment =
            ILexicalRule.Create(TokenType.Increment, Settings, @"\+\+");

        private static readonly ILexicalRule Decrement =
            ILexicalRule.Create(TokenType.Decrement, Settings, @"--");

        private static readonly ILexicalRule Add = ILexicalRule.Create(
            TokenType.Add, Settings, @"\+"
        );

        private static readonly ILexicalRule Sub = ILexicalRule.Create(
            TokenType.Sub, Settings, @"-"
        );

        private static readonly ILexicalRule Mul = ILexicalRule.Create(
            TokenType.Mul, Settings, @"\*"
        );

        private static readonly ILexicalRule Div = ILexicalRule.Create(
            TokenType.Div, Settings, @"/"
        );

        private static readonly ILexicalRule Mod = ILexicalRule.Create(
            TokenType.Mod, Settings, @"%"
        );

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Assign, Increment, Decrement, Add, Sub, Mul, Div, Mod
        };
    }

    private static class Identifiers
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create();

        private static readonly ILexicalRule Identifier = ILexicalRule.Create(
            TokenType.Identifier, Settings, "_?[a-zA-Z]+[a-zA-Z0-9_]*"
        );

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Identifier
        };
    }

    private static class Keywords
    {
        private static readonly ILexicalRuleSettings Settings =
            ILexicalRuleSettings.Create(false, false);

        private static readonly ILexicalRule Function = ILexicalRule.Create(
            TokenType.Function, Settings, "func"
        );

        private static readonly ILexicalRule Class = ILexicalRule.Create(
            TokenType.Class, Settings, "class"
        );

        private static readonly ILexicalRule Struct = ILexicalRule.Create(
            TokenType.Struct, Settings, "struct"
        );

        private static readonly ILexicalRule Return = ILexicalRule.Create(
            TokenType.Return, Settings, "return"
        );

        public static readonly IEnumerable<ILexicalRule> Rules = new[]
        {
            Function, Class, Struct, Return
        };
    }
}
