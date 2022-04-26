using Typhon.Core.LexicalAnalysis;
using Typhon.Core.SyntaxAnalysis.SyntaxNode;

namespace Typhon.Core.SyntaxAnalysis;


public struct SyntaxParserData
{
    public readonly ISyntaxAnalyser Analyser { get; }
    public readonly ITokenStream TokenStream { get; }
    public int Index;

    public SyntaxParserData(ISyntaxAnalyser analyser, ITokenStream tokenStream, int index = 0)
    {
        Analyser = analyser;
        TokenStream = tokenStream;
        Index = index;
    }

    public SyntaxParserData(SyntaxParserData oldData, int newIndex)
        : this(oldData.Analyser, oldData.TokenStream, newIndex){}
    
}


public interface ISyntaxParser<out T> where T : ISyntaxNode
{
    T? TryParse(SyntaxParserData context);
}
