namespace Akov.NetDocsProcessor.Output;

/// <summary>
/// The member description for constructors, methods, properties and events.
/// </summary>
public class MemberDescription : IXmlMemberElement
{
    
#if NET7_0_OR_GREATER
    
    /// <summary>
    /// The main page element e.g. `Method`, `Property`, `Event` etc. 
    /// </summary>
    public required string MemberType { get; set; }

    /// <summary>
    /// The type name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The type fullname.
    /// </summary>
    public required string CommentId { get; set; }

    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public required PageInfo Self { get; set; }
    
    /// <summary>
    /// The reference to the parent page info. This can be a class, struct, record or interface. 
    /// </summary>
    public required PageInfo Parent { get; set; }
    
    /// <summary>
    /// The payload.
    /// </summary>
    public required PayloadInfo PayloadInfo { get; set; }
    
#else

    /// <summary>
    /// The main page element e.g. `Method`, `Property`, `Event` etc. 
    /// </summary>
    public string MemberType { get; set; } = default!;
    
    /// <summary>
    /// The type name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The type fullname.
    /// </summary>
    public string CommentId { get; set; } = default!;
   
    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public PageInfo Self { get; set; } = default!;

    /// <summary>
    /// The reference to the parent page info. This can be a class, struct, record or interface. 
    /// </summary>
    public PageInfo Parent { get; set; } = default!;
    
    /// <summary>
    /// The payload.
    /// </summary>
    public PayloadInfo PayloadInfo { get; set; } = default!;

#endif
    
    /// <summary>
    /// The method, event or property return type.
    /// </summary>
    public string? ReturnType { get; set; }
    
    /// <summary>
    /// The title for the member.
    /// </summary>
    public string? Title { get; set; }
    
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
    /// The type parameters list.
    /// </summary>
    public List<TypeParameterInfo>? TypeParameters { get; set; }
    
    /// <summary>
    /// The parameters list.
    /// </summary>
    public List<ParameterInfo>? Parameters { get; set; }
    
    /// <summary>
    /// The returns for the method.
    /// </summary>
    public string? Returns { get; set; }
    
    /// <summary>
    /// The declared exceptions.
    /// </summary>
    public List<ExceptionInfo>? Exceptions { get; set; }
    
    /// <summary>
    /// The list of the related references.
    /// </summary>
    public List<PageInfo>? SeeAlso { get; set; }

    
}