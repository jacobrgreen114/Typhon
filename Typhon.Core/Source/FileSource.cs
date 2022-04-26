namespace Typhon.Core.Source;

public interface ISource
{
    Uri Path { get; }
    StreamReader OpenRead();

    static ISource Create(string filepath) => Create(new Uri(filepath));

    static ISource Create(Uri uri)
    {
        return uri.Scheme switch
        {
            "file" => new FileSource(uri),
            _ => throw new Exception()
        };
    }
}

internal class FileSource : ISource
{
    public FileSource(Uri uri)
    {
        Path = uri;
    }

    public Uri Path { get; }

    public StreamReader OpenRead() => new(Path.AbsolutePath);
}
