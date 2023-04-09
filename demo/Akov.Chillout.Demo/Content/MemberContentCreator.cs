using System.Text;
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
            .AppendLine(description.Summary?.ToMarkdownTextWithReplacements())
            .AppendLine()
            .AppendLine(Format.Italic(description.Remarks?.ToMarkdownTextWithReplacements()))
            .AppendLine()
            .AppendLine(description.Example?.ToMarkdownTextWithReplacements())
            .AppendLine();
            
        if (description.Parameters?.Any() == true)
        {
            builder.AppendLine(Format.H3("Parameters"))
                .Append(Table.CreateHeaders("Name", "Description"));
            foreach (var parameter in description.Parameters.Where(p => p.Name is not null))
            {
                builder.Append(Table.AddRow(parameter.Name!, parameter.Text ?? string.Empty));
            }
            builder.AppendLine();
        }

        if (description.Exceptions?.Any() == true)
        {
            builder.AppendLine(Format.H3("Exceptions"))
                .Append(Table.CreateHeaders("Name", "Description"));
            foreach (var exception in description.Exceptions.Where(e => e.Reference is not null))
            {
                builder.Append(Table.AddRow(exception.Reference!, exception.Text ?? string.Empty));
            }
            builder.AppendLine();
        }
         
        builder.Append("Type ")
            .AppendLine(Format.Url($"../../{description.Parent.Url.TrimBeforeLast('\\')}.md", description.Parent.DisplayName));

        return builder.ToString();
    }
}