namespace Akov.NetDocsProcessor.Input;

/// <summary>
/// Represents the access level for types and members that should be put into the documentation.
/// </summary>
public enum AccessLevel
{
    /// <summary>
    /// Only public members to documentation.
    /// </summary>
    Public,
    
    /// <summary>
    /// Public + protected members to documentation.
    /// </summary>
    Protected,
    
    /// <summary>
    /// Public + internal members to documentation.
    /// </summary>
    Internal,
    
    /// <summary>
    /// Public + protected + internal members to documentation. 
    /// </summary>
    ProtectedInternal,
    
    /// <summary>
    /// All members to documentation.
    /// </summary>
    Private
}