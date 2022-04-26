using Typhon.Core.Source;

namespace Typhon.Core.LexicalAnalysis;

public interface ILexicalAnalyser
{
    ILexicalRuleset Ruleset { get; }

    ITokenStream Analyse(ISource source);

    IEnumerable<ITokenStream> Analyse(IEnumerable<ISource> sources) =>
        sources.Select(Analyse);

    static ILexicalAnalyser Create(ILexicalRuleset ruleset) =>
        new LexicalAnalyser(ruleset);
}

internal class LexicalAnalyser : ILexicalAnalyser
{
    public LexicalAnalyser(ILexicalRuleset rules)
    {
        Ruleset = rules;
    }

    public ILexicalRuleset Ruleset { get; }

    public ITokenStream Analyse(ISource source) =>
        ILexicalAnalyserContext.Create(this, source).Analyze();
}
