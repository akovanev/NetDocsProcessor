using System.Reflection;
using System.Text.RegularExpressions;
using Akov.NetDocsProcessor.Common;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Output;
using Microsoft.CodeAnalysis;
using TypeInfo = System.Reflection.TypeInfo;

namespace Akov.NetDocsProcessor.Helpers;

internal partial class DescriptionHelper
{
    public static NamespaceDescription CreateNamespace(string currentNamespace, string rootNamespace)
        => new()
        {
            Self = new PageInfo
            {
                DisplayName = currentNamespace,
                Url = currentNamespace.TrimRoot(rootNamespace),
            }
        };

    public static TypeDescription CreateType(TypeInfo typeInfo, INamedTypeSymbol? symbol, PageInfo @namespace)
        => new ()
        {
            ElementType = typeInfo.GetTypeElementType(),
            Name = typeInfo.Name,
            FullName = typeInfo.FullName ?? typeInfo.Name,
            CommentId = symbol?.GetDocumentationCommentId() ?? Texts.XmlCommentNotFound,
            Self = new PageInfo
            {
                DisplayName = symbol?.Name ?? typeInfo.Name,
                Url = Path.Combine(@namespace.Url, typeInfo.GetTypeName()),
            },
            Namespace = @namespace
        };
    
    public static MemberDescription CreateMember(string memberName, MemberTypes memberType, ISymbol? symbol, PageInfo parent)
    {
        string GetMemberFolder()
            => memberType == MemberTypes.Property
                ? "properties"
                : $"{memberType.ToString().ToLower()}s";

        string? GetDisplayName()
        {
            string? symbolAsString = symbol?.ToString();
            if (symbolAsString is null) return null;

            // Remove namespaces and concat the substrings
            return string.Concat(
                Regex.Split(symbolAsString, @"(\(|\s|\)|>)")
                    .Where(s => s != String.Empty)
                    .Select(str => str.TrimBeforeLast()));
        }

        return new()
        {
            Self = new PageInfo
            {
                DisplayName = GetDisplayName() ?? memberName,
                Url = Path.Combine(parent.Url, GetMemberFolder(), memberName),
            },
            CommentId = symbol?.GetDocumentationCommentId() ?? Texts.XmlCommentNotFound,
            MemberType = memberType.ToString(),
            Name = memberName,
            Parent = parent
        };
    }
}