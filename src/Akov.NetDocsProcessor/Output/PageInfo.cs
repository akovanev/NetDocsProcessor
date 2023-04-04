namespace Akov.NetDocsProcessor.Output;

/// <summary>
/// Represents a short page description.
/// </summary>
public class PageInfo
{
    
#if NET7_0_OR_GREATER

    /// <summary>
    /// The page display name.
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// The page relative url.
    /// </summary>
    public required string Url { get; set; }
    
#else

    /// <summary>
    /// The page display name.
    /// </summary>
    public string DisplayName { get; set; } = default!;

    /// <summary>
    /// The page relative url.
    /// </summary>
    public string Url { get; set; } = default!;
    
#endif
    
}