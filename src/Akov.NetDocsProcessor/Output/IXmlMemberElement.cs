namespace Akov.NetDocsProcessor.Output;

public interface IXmlMemberElement : IXmlMemberBaseElement
{
    public string? Returns { get; set; }
    public List<ExceptionInfo>? Exceptions { get; set; }
    public List<ParameterInfo>? Parameters { get; set; }
}