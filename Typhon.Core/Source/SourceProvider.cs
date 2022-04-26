namespace Typhon.Core.Source;

public interface ISourceProvider
{
    IEnumerable<ISource> Source { get; }

    static ISourceProvider Create() =>
        new SourceProvider(Environment.CurrentDirectory);
}

internal class SourceProvider : ISourceProvider
{
    public SourceProvider(string path)
    {
        Path = new Uri(path);
    }

    public Uri Path { get; }

    public IEnumerable<ISource> Source
    {
        get
        {
            var directoryInfo = new DirectoryInfo(Path.AbsolutePath);
            var files = directoryInfo.EnumerateFiles(
                "*.ty", SearchOption.AllDirectories
            );
            var filePaths = files.Select(info => info.FullName);
            return filePaths.Select(ISource.Create);
        }
    }
}
