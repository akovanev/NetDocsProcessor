using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlSeeAlso
{
    [XmlAttribute("cref")]
    public string? Reference { get; set; }

    [XmlElement("summary")]
    public string? Summary { get; set; }
}