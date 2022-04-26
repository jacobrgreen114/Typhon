using System.Text.RegularExpressions;

namespace Typhon.Core.LexicalAnalysis;

public interface ILexicalRule
{
    TokenType Type { get; }
    ILexicalRuleSettings Settings { get; }

    LexicalMatch Match(ILexicalAnalyserContext context);


    static ILexicalRule Create(
        TokenType type, ILexicalRuleSettings settings, string regexPattern
    ) =>
        new RegexLexicalRule(type, settings, regexPattern);

    static ILexicalRule Create(TokenType type, string regexPattern) =>
        Create(type, ILexicalRuleSettings.Create(), regexPattern);
}

internal class RegexLexicalRule : ILexicalRule
{
    private readonly Regex _regex;

    public RegexLexicalRule(
        TokenType type, ILexicalRuleSettings settings, string pattern
    )
    {
        Type = type;
        Settings = settings;
        _regex = new Regex(@"\G" + pattern, RegexOptions.Compiled);
    }

    public TokenType Type { get; }
    public ILexicalRuleSettings Settings { get; }

    public LexicalMatch Match(ILexicalAnalyserContext context)
    {
        var regexMatch = _regex.Match(context.SourceText, context.CurrentIndex);
        if (!regexMatch.Success) return LexicalMatch.Invalid;

        var match = new LexicalMatch(this, regexMatch.Value);
        return match;
    }
}
