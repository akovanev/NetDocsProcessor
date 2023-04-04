using System.Text;
using Akov.Chillout.Demo.Markdown;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Content;

public class TypeContentCreator
{
    public static string Create(TypeDescription description)
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

        string relativeTypeUrl = description.Self.Url.TrimRoot(description.Namespace.Url);
        AppendMembersIfAny(builder, "Constructors", relativeTypeUrl, description.Constructors);
        AppendMembersIfAny(builder, "Methods", relativeTypeUrl, description.Methods);
        AppendMembersIfAny(builder, "Properties", relativeTypeUrl, description.Properties);
        AppendMembersIfAny(builder, "Events", relativeTypeUrl, description.Events);

        builder.Append("Namespace ");
        builder.AppendLine(Format.Url($"../{description.Namespace.Url}.md", description.Namespace.DisplayName));
        
        return builder.ToString();
    }

    private static void AppendMembersIfAny(
        StringBuilder builder, 
        string name,
        string relativeParentUrl,
        List<MemberDescription> members)
    {
        if (!members.Any()) return;
        
        builder.AppendLine(Format.H3(name));
        
        builder.Append(Table.CreateHeaders("Name", "Description"));
        
        foreach (var member in members)
        {
            string relativePath = Path.Combine(relativeParentUrl, member.Self.Url.TrimRoot(member.Parent.Url));
            builder.Append(Table.AddRow(Format.Url($"{relativePath}.md",member.Self.DisplayName), member.Summary ?? ""));
        }

        builder.AppendLine();
    }
}