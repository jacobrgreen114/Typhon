using System.Xml;
using Typhon.Core.LexicalAnalysis;
using Typhon.Core.SyntaxAnalysis.Parser;

namespace Typhon.Core.SyntaxAnalysis;

public interface ISyntaxAnalysisContext
{
    ISyntaxAnalyser SyntaxAnalyser { get; }
    ITokenStream TokenStream { get; }
    int CurrentIndex { get; set; }

    Token CurrentToken => TokenStream[CurrentIndex];

    ISyntaxTree Analyse();

    static ISyntaxAnalysisContext Create(
        ISyntaxAnalyser analyser, ITokenStream tokenStream
    ) =>
        new SyntaxAnalysisContext(analyser, tokenStream);
}

internal class SyntaxAnalysisContext : ISyntaxAnalysisContext
{
    public SyntaxAnalysisContext(
        ISyntaxAnalyser syntaxAnalyser, ITokenStream tokenStream
    )
    {
        SyntaxAnalyser = syntaxAnalyser;
        TokenStream = tokenStream;
    }

    public ISyntaxAnalyser SyntaxAnalyser { get; }
    public ITokenStream TokenStream { get; }
    public int CurrentIndex { get; set; } = 0;


    public ISyntaxTree Analyse()
    {
        var parser = new FieldDefinitionParser();

        var node = parser.TryParse(
            new SyntaxParserData(SyntaxAnalyser, TokenStream)
        );

        if (node is not null)
        {
            using var writer = XmlWriter.Create(
                $"Intermediates/SyntaxAnalysis/{Path.GetFileName(TokenStream.Source.Path.AbsolutePath)}.syntax.xml"
            );
            writer.WriteStartDocument();
            writer.WriteStartElement("SyntaxTree");
            node.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        throw new NotImplementedException();
    }
}
