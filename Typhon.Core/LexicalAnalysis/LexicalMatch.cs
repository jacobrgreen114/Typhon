namespace Typhon.Core.LexicalAnalysis;

public readonly struct LexicalMatch : IComparable<LexicalMatch>
{
    public bool Success { get; }
    public ILexicalRule Rule { get; }
    public string Value { get; }

    public LexicalMatch(ILexicalRule rule, string value)
    {
        Success = true;
        Rule = rule;
        Value = value;
    }

    private LexicalMatch(bool _)
    {
        Success = false;
        Rule = null!;
        Value = null!;
    }


    public int CompareTo(LexicalMatch other) =>
        Comparer<int>.Default.Compare(
            Value?.Length ?? 0, other.Value?.Length ?? 0
        );

    public static readonly LexicalMatch Invalid = new(false);
}
