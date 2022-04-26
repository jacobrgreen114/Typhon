using System.Xml;
using System.Xml.Serialization;
using Typhon.Core.Source;

namespace Typhon.Core.LexicalAnalysis;

public interface ITokenStream : IReadOnlyList<Token>
{
    ISource Source { get; }

    void Serialize();
}

[XmlRoot("TokenStream")]
public class TokenStream : List<Token>, ITokenStream
{
    private static readonly XmlSerializer Serializer = new(typeof(TokenStream));

    private static readonly XmlWriterSettings WriterSettings = new()
    {
        Indent = true
    };


    public TokenStream(ISource source)
    {
        Source = source;
    }

    public ISource Source { get; }

    public void Serialize()
    {
        using var writer = XmlWriter.Create(
            $"Intermediates/LexicalAnalysis/{Path.GetFileName(Source.Path.AbsolutePath)}.tokens.xml",
            WriterSettings
        );
        Serializer.Serialize(writer, this);
    }
}
