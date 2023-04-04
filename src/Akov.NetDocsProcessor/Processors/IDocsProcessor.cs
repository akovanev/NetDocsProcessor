using System.Reflection;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;
using Akov.NetDocsProcessor.Xml;

namespace Akov.NetDocsProcessor.Processors;

/// <summary>
/// Represents an interface to populate data from the assembly and xml comments.
/// </summary>
public interface IDocsProcessor
{
    /// <summary>
    /// Populate the collection of NamespaceDescription.
    /// </summary>
    /// <param name="assembly">The source assembly.</param>
    /// <param name="xmlDoc">The source deserialized xml.</param>
    /// <param name="settings">The generation settings.</param>
    /// <returns>The collection of NamespaceDescription.</returns>
    List<NamespaceDescription> PopulateNamespaceCollection(Assembly assembly, XmlDoc xmlDoc, GenerationSettings settings);

    /// <summary>
    /// Add xml comments to the populated NamespaceDescription list.
    /// </summary>
    /// <param name="namespaces">The NamespaceDescription list.</param>
    /// <param name="xmlDoc">The source deserialized xml.</param>
    /// <param name="settings">The generation settings.</param>
    void AddXmlComments(List<NamespaceDescription> namespaces, XmlDoc xmlDoc, GenerationSettings settings);
}