namespace Typhon.Core.SyntaxAnalysis.SyntaxNode;

public interface IExpressionSyntaxNode : ISyntaxNode
{
    SyntaxType ISyntaxNode.Type => SyntaxType.Expression;
}
