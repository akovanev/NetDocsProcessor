using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable, XmlRoot("doc")]
public class XmlDoc
{
    [XmlElement("assembly")]
    public XmlAssembly? Assembly { get; set; }
    
    [XmlArray("members")]
    [XmlArrayItem("member")]
    public List<XmlMember>? Members { get; set; }
}