using System.Text;
using Akov.Chillout.Demo.Helpers;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public static class MemberContentCreator
{
    public static string Create(MemberDescription description)
    {
        var builder = new StringBuilder();

        builder
            .AppendLine(Format.H1(description.Title ?? description.Self.DisplayName))
            .AppendLine(Format.CodeBlock(description.ToString()))
            .AppendLine(description.Summary?.ToMarkdownText())
            .AppendLine()
            .AppendLine(Format.Italic(description.Remarks?.ToMarkdownText()))
            .AppendLine()
            .AppendLine(description.Example?.ToMarkdownText())
            .AppendLine()
            .Append("Type ")
            .AppendLine(Format.Url($"../../{description.Parent.Url.TrimBeforeLast('\\')}.md", description.Parent.DisplayName));

        return builder.ToString();
    }
}