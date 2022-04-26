using System.Collections;

namespace Typhon.Core.LexicalAnalysis;

public interface ILexicalRuleset : IReadOnlyList<ILexicalRule>
{
    static readonly ILexicalRuleset Instance = new TyphonLexicalRuleset();
}

internal class TyphonLexicalRuleset : ILexicalRuleset
{
    private readonly IReadOnlyList<ILexicalRule> _rules;

    public TyphonLexicalRuleset()
    {
        _rules = TyphonLexicalRule.Rules;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<ILexicalRule> GetEnumerator() => _rules.GetEnumerator();

    public int Count => _rules.Count;

    public ILexicalRule this[int index] => _rules[index];
}
