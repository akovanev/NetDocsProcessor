namespace Akov.Chillout.Demo.Markdown;

public static class StringExtensions
{
    public static string ToMarkdownText(this string input)
    {
        string rows = string.Join(
                Environment.NewLine,
                input.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            .Replace("<code>", $"```csharp")
            .Replace("</code>", $"```{Environment.NewLine}")
            .Replace("<description>", Environment.NewLine)
            .Replace("</description>", Environment.NewLine);
     
        return string.Join(Environment.NewLine, rows);
    }
}