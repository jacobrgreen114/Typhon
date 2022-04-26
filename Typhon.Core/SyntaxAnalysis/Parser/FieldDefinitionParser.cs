using System.Xml.Serialization;
using Typhon.Core.LexicalAnalysis;
using Typhon.Core.SyntaxAnalysis.SyntaxNode;

namespace Typhon.Core.SyntaxAnalysis.Parser;



public class FieldDefinitionParser : ISyntaxParser<IFieldSyntaxNode>
{
    public IFieldSyntaxNode? TryParse(SyntaxParserData context)
    {
        var typeName = GetIdentifier(new SyntaxParserData(context, context.Index++) );
        if (typeName is null) return null;

        var fieldName = GetIdentifier(new SyntaxParserData(context, context.Index++));
        if (fieldName is null) return null;

        
        
        
        //var initializer = IExpressionParser.Instance.TryParse(new SyntaxParserData(context, context.Index));
        
        var node = new FieldDefinitionNode(typeName, fieldName, initializer);
        return node;
    }

    private static string? GetIdentifier(
        SyntaxParserData context
    )
    {
        var currentToken = context.TokenStream[context.Index];
        return currentToken.Type == TokenType.Identifier
            ? currentToken.Value
            : null;
    }
}
