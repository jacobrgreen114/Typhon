namespace Typhon.Core.LexicalAnalysis;

public interface ILexicalRuleSettings
{
    const bool DefaultIgnore = false;
    const bool DefaultCapture = true;
    const bool DefaultBreakOnMatch = false;

    bool Ignore { get; }
    bool Capture { get; }
    bool BreakOnMatch { get; }

    static ILexicalRuleSettings Create(
        bool ignore = DefaultIgnore, bool capture = DefaultCapture,
        bool breakOnMatch = DefaultBreakOnMatch
    ) =>
        new LexicalRuleSettings(ignore, capture, breakOnMatch);
}

internal class LexicalRuleSettings : ILexicalRuleSettings
{
    public LexicalRuleSettings(bool ignore, bool capture, bool breakOnMatch)
    {
        Ignore = ignore;
        Capture = capture;
        BreakOnMatch = breakOnMatch;
    }

    public bool Ignore { get; }
    public bool Capture { get; }
    public bool BreakOnMatch { get; }
}
