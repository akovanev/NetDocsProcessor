namespace Akov.Chillout.Demo.Markdown;

public class Format
{
    public static string H1(string text) => $"# {text}{Environment.NewLine}";
    public static string H2(string text) => $"## {text}{Environment.NewLine}";
    public static string H3(string text) => $"### {text}{Environment.NewLine}";
    public static string H4(string text) => $"#### {text}{Environment.NewLine}";
    public static string H5(string text) => $"##### {text}{Environment.NewLine}";
    public static string H6(string text) => $"###### {text}{Environment.NewLine}";
    
    public static string Bold(string text) => $"**{text}**";
    public static string Italic(string text) => $"*{text}*";
    public static string Underline(string text) => $"<u>{text}</u>";
    public static string CrossedOut(string text) => $"~~{text}~~";

    public static string Code(string text) => $"`{text}`";
    public static string CodeBlock(string code, string language = "csharp")
        => $"```{language}{Environment.NewLine}{code}{Environment.NewLine}```";
    
    public static string Url(string url, string linkText)
        => $"[{linkText}]({url})";
} 