namespace Akov.Chillout.Demo.Helpers;

public static class FormatExtensions
{
    public static string? WithoutNewLines(this string? source)
        => source?.Replace(Environment.NewLine, " ")
            .Replace('\n', ' ');
}