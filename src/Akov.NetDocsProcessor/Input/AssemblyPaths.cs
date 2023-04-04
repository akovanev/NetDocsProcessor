namespace Akov.NetDocsProcessor.Input;

/// <summary>
/// Provides the paths for an assembly and its documentation.
/// </summary>
public class AssemblyPaths
{
    /// <summary>
    /// Fill out the paths for an assembly and its documentation.
    /// </summary>
    /// <param name="dllPath">The path to the assembly file.</param>
    /// <param name="xmlPath">The path to the generated documentation file.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public AssemblyPaths(string dllPath, string xmlPath)
    {
        DllPath = dllPath ?? throw new ArgumentNullException(nameof(dllPath));
        XmlPath = xmlPath ?? throw new ArgumentNullException(nameof(xmlPath));
        if (!dllPath.EndsWith(".dll"))
            throw new ArgumentException($"The `{nameof(dllPath)}` should be ending with `.dll`.");
        if (!xmlPath.EndsWith(".xml"))
            throw new ArgumentException($"The `{nameof(xmlPath)}` should be ending with `.xml`.");
    }

    /// <summary>
    /// The path to the assembly file.
    /// </summary>
    public string DllPath { get; }
    
    /// <summary>
    /// The path to the generated documentation file.
    /// </summary>
    public string XmlPath { get; }
}