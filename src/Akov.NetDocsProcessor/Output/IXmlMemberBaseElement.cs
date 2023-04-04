namespace Akov.NetDocsProcessor.Output;

public interface IXmlMemberBaseElement
{
    public string? Summary { get; set; }
    public string? Example { get; set; }
    public string? Remarks { get; set; }
    public List<TypeParameterInfo>? TypeParameters { get; set; }
}