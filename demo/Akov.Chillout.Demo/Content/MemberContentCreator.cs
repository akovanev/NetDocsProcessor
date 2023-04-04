using System.Text;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public class MemberContentCreator
{
    public static string Create(MemberDescription description)
    {
        var builder = new StringBuilder();

        builder.AppendLine(Format.H1(description.Self.DisplayName));

        builder.AppendLine(description.Summary?.ToMarkdownText());
        builder.AppendLine();
        if (description.Remarks is not null)
        {
            builder.AppendLine(Format.Italic(description.Remarks.ToMarkdownText()));
            builder.AppendLine();
        }

        if (description.Example is not null)
        {
            builder.AppendLine(description.Example?.ToMarkdownText());
            builder.AppendLine();
        }

        builder.Append("Type ");
        builder.AppendLine(Format.Url($"../../{description.Parent.Url.TrimBeforeLast('\\')}.md", description.Parent.DisplayName));
        
        return builder.ToString();
    }
}