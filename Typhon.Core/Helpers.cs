namespace Typhon.Core;

public static class Helpers
{
    public static IReadOnlyList<T> Combine<T>(
        params IEnumerable<T>[] enumerables
    )
    {
        var list = new List<T>();
        foreach (var enumerable in enumerables) list.AddRange(enumerable);

        return list;
    }
}
