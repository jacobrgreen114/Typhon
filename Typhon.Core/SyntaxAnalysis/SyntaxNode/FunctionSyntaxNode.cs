namespace Typhon.Core.SyntaxAnalysis.SyntaxNode;

public interface IFunctionSyntaxNode : ISyntaxNode
{
    SyntaxType ISyntaxNode.Type => SyntaxType.Function;
}
