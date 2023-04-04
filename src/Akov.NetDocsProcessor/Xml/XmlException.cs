using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlException
{
    [XmlAttribute("cref")]
    public string? Reference { get; set; }

    [XmlText]
    public string? Text { get; set; }
}