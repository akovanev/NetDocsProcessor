using Akov.NetDocsProcessor.Output;
using Akov.NetDocsProcessor.Xml;

namespace Akov.NetDocsProcessor.Extensions;

internal static class XmlMemberElementExtensions
{
    public static void FillBy(this IXmlMemberElement element, XmlMember xmlMember)
    {
        element.Summary = xmlMember.Summary;
        element.Example = xmlMember.Example?.InnerXml;
        element.Remarks = xmlMember.Remarks;
    }
}