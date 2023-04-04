namespace Akov.NetDocsProcessor.Input;

/// <summary>
/// The set of settings for the documentation output.
/// </summary>
public class GenerationSettings
{
    /// <summary>
    /// Defines which types and members will be removed from the output.
    /// The default value is AccessLevel.Public.
    /// </summary>
    public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;
}