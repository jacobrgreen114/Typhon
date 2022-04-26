// See https://aka.ms/new-console-template for more information


using Typhon.Core.Project;

namespace Typhon.Compiler;

internal static class Program
{
    private static int Main(string[] args)
    {
        var project = IProject.Load();

        var compiler = ICompiler.Create();

        compiler.Compile(project);

        return 0;
    }
}
