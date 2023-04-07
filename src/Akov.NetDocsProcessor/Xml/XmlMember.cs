using System.Xml;
using System.Xml.Serialization;

namespace Akov.NetDocsProcessor.Xml;

[Serializable]
public class XmlMember
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAnyElement("summary")]
    public XmlElement? Summary { get; set; }

    [XmlAnyElement("remarks")]
    public XmlElement? Remarks { get; set; }

    [XmlAnyElement("example")]
    public XmlElement? Example { get; set; }

    [XmlElement("exception")]
    public List<XmlException>? Exceptions { get; set; }

    [XmlElement("param")]
    public List<XmlParameter>? Parameters { get; set; }

    [XmlElement("typeparam")]
    public List<XmlTypeParameter>? TypeParameters { get; set; }

    [XmlAnyElement("returns")]
    public XmlElement? Returns { get; set; }

    [XmlElement("value")]
    public string? Value { get; set; }

    [XmlElement("seealso")]
    public List<XmlSeeAlso>? SeeAlso { get; set; }
}