using System.Text;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public class NamespaceContentCreator
{
    public static string Create(NamespaceDescription description)
    {
        var builder = new StringBuilder();

        builder
            .AppendLine(Format.H1(description.Self.DisplayName))
            .Append(Table.CreateHeaders("Type", "Description"))
            .ForEach(description.Types.OrderBy(t => t.Self.DisplayName), type =>
            {
                builder.Append(Table.AddRow(Format.Url($"{type.Self.Url}.md", type.Self.DisplayName), type.Summary?.WithoutNewLines() ?? ""));
            })
            .AppendLine()
            .Append("Index ")
            .AppendLine(Format.Url("index.md", "index.md"));
        
        return builder.ToString();
    }
}