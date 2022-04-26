using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Typhon.Core.SyntaxAnalysis.SyntaxNode;

public interface ISyntaxNode : IXmlSerializable
{
    SyntaxType Type { get; }
}

internal abstract class BaseSyntaxNode : ISyntaxNode
{
    protected BaseSyntaxNode(SyntaxType type)
    {
        Type = type;
    }

    public virtual XmlSchema? GetSchema() => null;

    public virtual void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Type), Type.ToString());
    }

    public SyntaxType Type { get; }
}