namespace Typhon.Core.LexicalAnalysis;

public struct Token
{
    public Token(TokenType type, string? value = null)
    {
        Type = type;
        Value = value;
    }

    public TokenType Type;
    public string? Value;
}
