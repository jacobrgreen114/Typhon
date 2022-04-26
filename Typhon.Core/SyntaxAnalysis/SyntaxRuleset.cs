namespace Typhon.Core.SyntaxAnalysis;

public interface ISyntaxRuleset : IReadOnlyList<ISyntaxRule>
{
}

internal class SyntaxRuleset : List<ISyntaxRule>, ISyntaxRuleset
{
}
