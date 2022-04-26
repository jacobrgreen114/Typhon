using Typhon.Core.Source;

namespace Typhon.Core.Project;

public interface IProject
{
    ISourceProvider SourceProvider { get; }

    static IProject Load() => new Project(ISourceProvider.Create());
}

internal class Project : IProject
{
    public Project(ISourceProvider sourceProvider)
    {
        SourceProvider = sourceProvider;
    }

    public ISourceProvider SourceProvider { get; }
}
