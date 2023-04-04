using Akov.NetDocsProcessor.Helpers;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;
using Akov.NetDocsProcessor.Processors;

namespace Akov.NetDocsProcessor.Api;

/// <summary>
/// The docs generator. 
/// </summary>
public class DocsProcessorApi
{
    private readonly IDocsProcessor _docsProcessor;

    public DocsProcessorApi(IDocsProcessor? docsProcessor = null)
    {
        _docsProcessor = docsProcessor ?? new DocsProcessor();
    }

    /// <summary>
    /// Obtains data from .net assemblies and generated xml documentation.
    /// </summary>
    /// <param name="assemblyPaths">Paths to the source files.</param>
    /// <param name="settings">The generation settings.</param>
    /// <returns></returns>
    public virtual IEnumerable<NamespaceDescription> ObtainDocumentation(
        AssemblyPaths assemblyPaths,
        GenerationSettings? settings = null)
    {
        var assembly = FileReader.ReadAssembly(assemblyPaths.DllPath);
        var xmlDoc = FileReader.ReadXml(assemblyPaths.XmlPath);
        settings ??= new GenerationSettings();

        var namespaceCollection = _docsProcessor.PopulateNamespaceCollection(assembly, xmlDoc, settings);
        _docsProcessor.AddXmlComments(namespaceCollection, xmlDoc, settings);
        return namespaceCollection;
    }
}