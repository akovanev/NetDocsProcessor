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

#endif
    
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
    /// The list of the related references.
    /// </summary>
    public List<PageInfo>? SeeAlso { get; set; }
}