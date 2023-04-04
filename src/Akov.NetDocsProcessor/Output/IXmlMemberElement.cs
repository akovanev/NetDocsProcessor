namespace Akov.NetDocsProcessor.Output;

public interface IXmlMemberElement
{
    public string? Summary { get; set; }
    public string? Example { get; set; }
    public string? Remarks { get; set; }
}