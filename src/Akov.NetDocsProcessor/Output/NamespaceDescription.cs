namespace Akov.NetDocsProcessor.Output;

/// <summary>
/// The namespace container.
/// </summary>
public class NamespaceDescription
{
    
#if NET7_0_OR_GREATER
    
    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public required PageInfo Self { get; set; }
    
#else

    /// <summary>
    /// The reference to the page info.
    /// </summary>
    public PageInfo Self { get; set;} = default!;
    
#endif

    public string ElementType => Common.ElementType.Namespace;
    
    /// <summary>
    /// The list of type descriptions.
    /// </summary>
    public List<TypeDescription> Types { get; } = new();
}