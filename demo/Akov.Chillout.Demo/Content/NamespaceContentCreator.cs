using System.Text;
using Akov.Chillout.Demo.Helpers;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public class NamespaceContentCreator
{
    public static string Create(NamespaceDescription description)
    {
        var builder = new StringBuilder();

        builder.AppendLine(Format.H1(description.Self.DisplayName));

        builder.Append(Table.CreateHeaders("Type", "Description"));

        foreach (var type in description.Types.OrderBy(t => t.Self.DisplayName))
        {
            builder.Append(Table.AddRow(Format.Url($"{type.Self.Url}.md",type.Self.DisplayName), type.Summary?.WithoutNewLines() ?? ""));
        }

        builder.AppendLine(Format.Url("index.md", "index.md"));
        
        return builder.ToString();
    }
}