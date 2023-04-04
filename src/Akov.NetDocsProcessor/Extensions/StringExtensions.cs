namespace Akov.NetDocsProcessor.Extensions;

public static class StringExtensions
{
    public static string TrimRoot(this string resource, string root)
        => resource.StartsWith(root) && resource.Length > root.Length
            ? resource[(root.Length + 1)..]
            : resource;

    public static string TrimBeforeLast(this string resource, char delimiter = '.')
    {
        int lastIndex = resource.LastIndexOf(delimiter);
        return resource[(lastIndex + 1)..];
    }
}