using Typhon.Core.LexicalAnalysis;

namespace Typhon.Core.SyntaxAnalysis;

public struct SyntaxMatch
{
    public ISyntaxRule Rule { get; }

    public IReadOnlyList<Token> Tokens { get; }

    public SyntaxMatch(ISyntaxRule rule, IReadOnlyList<Token> tokens)
    {
        Rule = rule;
        Tokens = tokens;
    }
}
