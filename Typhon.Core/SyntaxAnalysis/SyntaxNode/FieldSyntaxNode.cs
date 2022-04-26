using System.Xml;

namespace Typhon.Core.SyntaxAnalysis.SyntaxNode;

public interface IFieldSyntaxNode : ISyntaxNode
{
    string TypeName { get; }
    string FieldName { get; }
    IExpressionSyntaxNode? Assignment { get; }
}

internal class FieldDefinitionNode : BaseSyntaxNode, IFieldSyntaxNode
{
    public FieldDefinitionNode(string typeName, string fieldName, IExpressionSyntaxNode? initializer = null) : base(SyntaxType.Field)
    {
        TypeName = typeName;
        FieldName = fieldName;
        Assignment = initializer;
    }

    public string TypeName { get; }
    public string FieldName { get; }
    public IExpressionSyntaxNode? Assignment { get; }

    public override void WriteXml(XmlWriter writer)
    {
        base.WriteXml(writer);
        writer.WriteAttributeString(nameof(TypeName), TypeName);
        writer.WriteAttributeString(nameof(FieldName), FieldName);
        if (Assignment is not null)
        {
            writer.WriteStartElement(nameof(Assignment));
            Assignment.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}