using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlParameter
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlText]
    public string? Text { get; set; }
}