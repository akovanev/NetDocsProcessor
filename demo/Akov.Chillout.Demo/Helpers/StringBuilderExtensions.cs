using System.Text;

namespace Akov.Chillout.Demo.Helpers;

public static class StringBuilderExtensions
{
    public static StringBuilder ForEach<T>(
        this StringBuilder builder,
        IEnumerable<T> collection,
        Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
        return builder;
    }
}