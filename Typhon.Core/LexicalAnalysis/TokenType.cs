namespace Typhon.Core.LexicalAnalysis;

public enum TokenType
{
    Whitespace = 1,
    Comment,

    Identifier,


    // Symbols
    Terminator,
    ParenOpen,
    ParenClose,
    BraceOpen,
    BraceClose,
    BracketOpen,
    BracketClose,

    // Literals
    LiteralInteger,
    LiteralFloat,
    LiteralString,

    // Operators
    Assign,
    Increment,
    Decrement,
    Add,
    Sub,
    Mul,
    Div,
    Mod,

    // Keywords
    Function,
    Class,
    Struct,
    Return
}
