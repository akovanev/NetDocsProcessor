namespace Akov.Chillout.Demo.Markdown;

public static class StringExtensions
{
    public static string ToMarkdownText(this string input)
    {
        string[] rows = input
            .Replace("<code>", "```csharp \n")
            .Replace("</code>", "```")
            .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
     
        return string.Join(Environment.NewLine, rows);
    }
}