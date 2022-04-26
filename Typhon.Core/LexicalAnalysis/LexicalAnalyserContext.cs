using Typhon.Core.Source;

namespace Typhon.Core.LexicalAnalysis;

public interface ILexicalAnalyserContext
{
    public string SourceText { get; }
    public int CurrentIndex { get; }

    ITokenStream Analyze();

    static ILexicalAnalyserContext Create(
        ILexicalAnalyser analyser, ISource source
    ) =>
        new LexicalAnalyserContext(analyser, source);
}

internal class LexicalAnalyserContext : ILexicalAnalyserContext
{
    public LexicalAnalyserContext(ILexicalAnalyser analyser, ISource source)
    {
        using var reader = source.OpenRead();

        Analyser = analyser;
        Source = source;
        SourceText = reader.ReadToEnd();
        CurrentIndex = 0;
        Position = FilePosition.Start;
    }

    public ILexicalAnalyser Analyser { get; }
    public ISource Source { get; }
    public FilePosition Position { get; }

    public string SourceText { get; }
    public int CurrentIndex { get; private set; }

    public ITokenStream Analyze()
    {
        var stream = new TokenStream(Source);

        while (CurrentIndex < SourceText.Length)
        {
            var match = FindBestMatch();
            if (!match.Rule.Settings.Ignore)
            {
                var value = match.Rule.Settings.Capture ? match.Value : null;
                var token = new Token(match.Rule.Type, value);
                stream.Add(token);
            }

            CurrentIndex += match.Value.Length;
        }

        return stream;
    }


    private LexicalMatch FindBestMatch()
    {
        var bestMatch = LexicalMatch.Invalid;

        foreach (var match in EnumerateMatches())
        {
            if (match.Rule.Settings.BreakOnMatch) return match;
            if (match.CompareTo(bestMatch) > 0) bestMatch = match;
        }

        if (!bestMatch.Success)
            throw new Exception(
                $"No match found for token starting at {SourceText[CurrentIndex]}"
            );

        return bestMatch;
    }

    private IEnumerable<LexicalMatch> EnumerateMatches()
    {
        return Analyser.Ruleset.Select(rule => rule.Match(this))
            .Where(match => match.Success);
    }
}
