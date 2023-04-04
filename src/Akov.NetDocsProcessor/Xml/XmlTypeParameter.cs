using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlTypeParameter
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlElement("summary")]
    public string? Summary { get; set; }
}