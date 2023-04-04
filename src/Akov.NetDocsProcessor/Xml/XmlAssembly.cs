using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlAssembly
{
    [XmlElement("name")]
    public string? Name { get; set; }
}