using Akov.NetDocsProcessor.Common;

namespace Akov.NetDocsProcessor.Output;

/// <summary>
/// The type description for classes, interfaces, records, structs, enums and delegates.
/// </summary>
public class TypeDescription : IXmlMemberBaseElement
{
    public TypeDescription()
    {
        Constructors = new List<MemberDescription>();
        Methods = new List<MemberDescription>();
        Properties = new List<MemberDescription>();
        Events = new List<MemberDescription>();
        EnumMembers = new List<EnumMemberDescription>();
    }

#if NET7_0_OR_GREATER
    
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
    
    /// <summary>
    /// The payload.
    /// </summary>
    public required PayloadInfo PayloadInfo { get; set; }

#else
    
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
    
    /// <summary>
    /// The payload.
    /// </summary>
    public PayloadInfo PayloadInfo { get; set; } = default!;

#endif
    
    /// <summary>
    /// The main page element e.g. `Class`, `Interface`, `Record` etc. 
    /// </summary>
    public ElementType ElementType { get; set; }
    
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
    /// The type parameters list.
    /// </summary>
    public List<TypeParameterInfo>? TypeParameters { get; set; }

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
    /// The list of enums members if type is enumeration.
    /// </summary>
    public List<EnumMemberDescription> EnumMembers { get; }
    
    /// <summary>
    /// The list of the related references.
    /// </summary>
    public List<PageInfo>? SeeAlso { get; set; }
}