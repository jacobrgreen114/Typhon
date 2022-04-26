namespace Typhon.Core.SyntaxAnalysis.Parser;

/**
 * <summary>
 *     Expected Pattern: <br />
 *     Token:KeywordFunction Syntax:Identifier <br />
 *     Token:ParenOpen [Syntax:DefinitionField] Token:ParenClose <br />
 *     Token:BraceOpen [Syntax:Statement] Token:BraceClose
 * </summary>
 */
/*
internal class FunctionDefinitionParser : ISyntaxParser
{
    public bool TryParse(
        ISyntaxAnalysisContext context,
        [NotNullWhen(true)] out ISyntaxNode? node
    )
    {
        var index = context.CurrentIndex;
        var currentToken = context.TokenStream[index++];


        if (currentToken.Type != TokenType.Class)
        {
            node = null;
            return false;
        }

        currentToken = context.TokenStream[index++];
        if (currentToken.Type != TokenType.Identifier) throw new Exception();
    }
}
*/
