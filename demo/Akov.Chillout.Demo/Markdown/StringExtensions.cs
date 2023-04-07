using System.Text;

namespace Akov.Chillout.Demo.Markdown;

public static class StringExtensions
{
    public static string? WithoutNewLines(this string? source)
        => source?.Replace(Environment.NewLine, " ")
            .Replace('\n', ' ');
    
    public static string ToMarkdownText(this string input)
        => string.Join(Environment.NewLine, string.Join(
            Environment.NewLine,
            input.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));
    
    public static string ToMarkdownTextWithReplacements(this string input)
        => string.Join(Environment.NewLine, string.Join(
                Environment.NewLine,
                input.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            .Replace("<code>", $"```csharp")
            .Replace("</code>", $"```{Environment.NewLine}")
            .Replace("<description>", Environment.NewLine)
            .Replace("</description>", Environment.NewLine));
    
    public static StringBuilder ForEach<T>(this StringBuilder builder, IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
        return builder;
    }
}