using Typhon.Core.SyntaxAnalysis.SyntaxNode;

namespace Typhon.Core.SyntaxAnalysis.Parser;

public interface IExpressionParser : ISyntaxParser<IExpressionSyntaxNode>
{
    static IExpressionParser Instance { get; } = new ExpressionParser();
}

public class ExpressionParser : IExpressionParser
{
    public IExpressionSyntaxNode? TryParse(SyntaxParserData context) =>
        throw new NotImplementedException();
}
