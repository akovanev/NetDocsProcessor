namespace Akov.NetDocsProcessor.Output;

/// <summary>
/// The type description for classes, interfaces, records, structs, enums and delegates.
/// </summary>
public class TypeDescription : IXmlMemberElement
{
    public TypeDescription()
    {
        Constructors = new List<MemberDescription>();
        Methods = new List<MemberDescription>();
        Properties = new List<MemberDescription>();
        Events = new List<MemberDescription>();
    }

#if NET7_0_OR_GREATER
    
    /// <summary>
    /// The main page element e.g. `Class`, `Interface`, `Record` etc. 
    /// </summary>
    public required string ElementType { get; set; }

    /// <summary>
    /// The type name.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// The type fullname.
    /// </summary>
    public required string FullName { get; set; }
    
    /// <summary>
    /// The type fullname.
    /// </summary>
    public required string CommentId { get; set; }

    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public required PageInfo Self { get; set; }
    
    /// <summary>
    /// The reference to the namespace page info.
    /// </summary>
    public required PageInfo Namespace { get; set; }

#else

    /// <summary>
    /// The main page element e.g. `Class`, `Interface`, `Record` etc. 
    /// </summary>
    public string ElementType { get; set; } = default!;
    
    /// <summary>
    /// The type name.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// The type fullname.
    /// </summary>
    public string FullName { get; set; } = default!;
    
    /// <summary>
    /// The type fullname.
    /// </summary>
    public string CommentId { get; set; } = default!;
    
    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public PageInfo Self { get; set; } = default!;

    /// <summary>
    /// The reference to the namespace page info.
    /// </summary>
    public PageInfo Namespace { get; set; } = default!;

#endif
    
    /// <summary>
    /// The title for the type.
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// The xml summary for the type.
    /// </summary>
    public string? Summary { get; set; }
    
    /// <summary>
    /// The xml example for the type.
    /// </summary>
    public string? Example { get; set; }
    
    /// <summary>
    /// The remarks for the type.
    /// </summary>
    public string? Remarks { get; set; }
    
    /// <summary>
    /// The list of constructors.
    /// </summary>
    public List<MemberDescription> Constructors { get; }
    
    /// <summary>
    /// The list of methods.
    /// </summary>
    public List<MemberDescription> Methods { get; }
    
    /// <summary>
    /// The list of properties.
    /// </summary>
    public List<MemberDescription> Properties { get; }
    
    /// <summary>
    /// The list of events.
    /// </summary>
    public List<MemberDescription> Events { get; }
    
    /// <summary>
    /// The list of the related references.
    /// </summary>
    public List<PageInfo>? SeeAlso { get; set; }
}