using System.Text;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public class IndexContentCreator
{
    public static string Create(List<NamespaceDescription> namespaces)
    {
        var builder = new StringBuilder();

        builder
            .AppendLine(Format.H1("Namespaces"))
            .Append(Table.CreateHeaders("Namespace", "Link"))
            .ForEach(namespaces, @namespace =>
            {
                builder.Append(Table.AddRow(@namespace.Self.DisplayName, Format.Url($"{@namespace.Self.Url}.md", "Link")));
            });
        
        return builder.ToString();
    }
}