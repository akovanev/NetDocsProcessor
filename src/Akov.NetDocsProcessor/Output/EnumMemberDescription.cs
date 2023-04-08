namespace Akov.NetDocsProcessor.Output;

public class EnumMemberDescription : IXmlMemberBaseElement
{

    #if NET7_0_OR_GREATER
    
    /// <summary>
    /// The element name.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// The element fullname.
    /// </summary>
    public required string CommentId { get; set; }
    
    /// <summary>
    /// The reference to the enum page info. 
    /// </summary>
    public required PageInfo Parent { get; set; }
   
#else
    
    /// <summary>
    /// The element name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The element fullname.
    /// </summary>
    public string CommentId { get; set; } = default!;
    
    /// <summary>
    /// The reference to the enum page info. 
    /// </summary>
    public PageInfo Parent { get; set; } = default!;
    
#endif
    
    /// <summary>
    /// The xml summary for the member.
    /// </summary>
    public string? Summary { get; set; }
    
    /// <summary>
    /// The xml example for the member.
    /// </summary>
    public string? Example { get; set; }
    
    /// <summary>
    /// The remarks for the type.
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// TypeParameters don't exist for enumerations.
    /// </summary>
    public List<TypeParameterInfo>? TypeParameters
    {
        get => null;
        set {}
    }
}