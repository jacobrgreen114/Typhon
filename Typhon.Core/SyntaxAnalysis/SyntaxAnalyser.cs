using Typhon.Core.LexicalAnalysis;

namespace Typhon.Core.SyntaxAnalysis;

public interface ISyntaxAnalyser
{
    ISyntaxTree Analyse(ITokenStream tokenStream);

    IEnumerable<ISyntaxTree> Analyse(IEnumerable<ITokenStream> tokenStreams) =>
        tokenStreams.Select(Analyse);

    static ISyntaxAnalyser Create() => new SyntaxAnalyser();
}

internal class SyntaxAnalyser : ISyntaxAnalyser
{
    public ISyntaxTree Analyse(ITokenStream tokenStream)
    {
        var context = ISyntaxAnalysisContext.Create(this, tokenStream);
        return context.Analyse();
    }
}
