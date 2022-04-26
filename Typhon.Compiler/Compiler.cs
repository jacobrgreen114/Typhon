using Typhon.Core.LexicalAnalysis;
using Typhon.Core.Project;
using Typhon.Core.SyntaxAnalysis;

namespace Typhon.Compiler;

public interface ICompiler
{
    ILexicalAnalyser LexicalAnalyser { get; }
    ISyntaxAnalyser SyntaxAnalyser { get; }

    void Compile(IProject project);

    static ICompiler Create() =>
        new Compiler(
            ILexicalAnalyser.Create(ILexicalRuleset.Instance),
            ISyntaxAnalyser.Create()
        );
}

internal class Compiler : ICompiler
{
    internal Compiler(
        ILexicalAnalyser lexicalAnalyser, ISyntaxAnalyser syntaxAnalyser
    )
    {
        LexicalAnalyser = lexicalAnalyser;
        SyntaxAnalyser = syntaxAnalyser;
    }

    public ILexicalAnalyser LexicalAnalyser { get; }
    public ISyntaxAnalyser SyntaxAnalyser { get; }


    public void Compile(IProject project)
    {
        var sourceFiles = project.SourceProvider.Source;

        var tokenStreams = LexicalAnalyser.Analyse(sourceFiles).ToArray();
        foreach (var tokenStream in tokenStreams) tokenStream.Serialize();

        var syntaxTrees = SyntaxAnalyser.Analyse(tokenStreams).ToArray();
    }
}
