using System.Text;
using Akov.Chillout.Demo.Helpers;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public static class TypeContentCreator
{
    public static string Create(TypeDescription description)
    {
        var builder = new StringBuilder();
        string relativeTypeUrl = description.Self.Url.TrimRoot(description.Namespace.Url);

        builder
            .AppendLine(Format.H1(description.Self.DisplayName))
            .AppendLine(description.Summary?.ToMarkdownText())
            .AppendLine()
            .AppendLine(Format.Italic(description.Remarks?.ToMarkdownText()))
            .AppendLine()
            .AppendLine(description.Example?.ToMarkdownText())
            .AppendLine()
            .AppendMembersIfAny("Constructors", relativeTypeUrl, description.Constructors)
            .AppendMembersIfAny("Methods", relativeTypeUrl, description.Methods)
            .AppendMembersIfAny("Properties", relativeTypeUrl, description.Properties)
            .AppendMembersIfAny("Events", relativeTypeUrl, description.Events)
            .Append("Namespace ")
            .AppendLine(Format.Url($"../{description.Namespace.Url}.md", description.Namespace.DisplayName));
        
        return builder.ToString();
    }

    private static StringBuilder AppendMembersIfAny(
        this StringBuilder builder, 
        string name,
        string relativeParentUrl,
        List<MemberDescription> members)
    {
        if (!members.Any()) return builder;

        builder
            .AppendLine(Format.H3(name))
            .Append(Table.CreateHeaders("Name", "Description"))
            .ForEach(members, member =>
            {
                string relativePath = Path.Combine(relativeParentUrl, member.Self.Url.TrimRoot(member.Parent.Url));
                builder.Append(Table.AddRow($"{Format.Url($"{relativePath}.md", member.Title ?? member.Self.DisplayName)}", member.Summary?.WithoutNewLines() ?? ""));
            })
            .AppendLine();
        
        return builder;
    }
}