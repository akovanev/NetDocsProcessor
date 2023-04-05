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
                ElementType = ElementType.Namespace
            }
        };

    public static TypeDescription CreateType(TypeInfo typeInfo, INamedTypeSymbol? symbol, PageInfo @namespace)
    {
        var elementType = typeInfo.GetTypeElementType();
        return new()
        {
            ElementType = elementType,
            Name = typeInfo.Name,
            FullName = typeInfo.FullName ?? typeInfo.Name,
            CommentId = symbol?.GetDocumentationCommentId() ?? Texts.XmlCommentNotFound,
            Self = new PageInfo
            {
                DisplayName = symbol?.Name ?? typeInfo.Name,
                Url = Path.Combine(@namespace.Url, typeInfo.GetTypeName()),
                ElementType = elementType
            },
            Namespace = @namespace,
            PayloadInfo = symbol?.GetPayload() ?? new PayloadInfo()
        };
    }

    public static MemberDescription CreateMember(string memberName, MemberTypes memberType, ISymbol? symbol, PageInfo parent)
    {
        string GetMemberFolder()
            => memberType == MemberTypes.Property
                ? "properties"
                : $"{memberType.ToString().ToLower()}s";

        return new()
        {
            Self = new PageInfo
            {
                DisplayName = symbol.GetDisplayName() ?? memberName,
                Url = Path.Combine(parent.Url, GetMemberFolder(), memberName),
            },
            CommentId = symbol?.GetDocumentationCommentId() ?? Texts.XmlCommentNotFound,
            MemberType = memberType.ToString(),
            Name = memberName,
            ReturnType = symbol?.GetReturnType(),
            Parent = parent,
            Title =  symbol?.GetShortName(),
            PayloadInfo = symbol?.GetPayload() ?? new PayloadInfo()
        };
    }
}