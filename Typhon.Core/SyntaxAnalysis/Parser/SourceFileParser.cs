namespace Typhon.Core.SyntaxAnalysis.Parser;

/*
internal interface ISourceFileSyntaxNode : ISyntaxNode
{
    static ISourceFileSyntaxNode Create(IEnumerable<ISyntaxNode> children) =
}

internal class SourceFileParser : ISyntaxParser
{
    private IEnumerable<ISyntaxParser> Parsers { get; }

    public bool TryParse(
        ISyntaxAnalysisContext context,
        [NotNullWhen(true)] out ISyntaxNode? node
    )
    {
        var children = new List<ISyntaxNode>();

        var matchFound = false;

        do
        {
            matchFound = false;

            foreach (var parser in Parsers)
            {
                if (!parser.TryParse(context, out var matchedNode)) continue;
                children.Add(matchedNode);
                matchFound = true;
                break;
            }
        } while (matchFound);

        node = ISourceFileSyntaxNode.Create(children);
        return true;
    }
}
*/
