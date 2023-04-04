using System.Reflection;
using Akov.NetDocsProcessor.Common;
using Akov.NetDocsProcessor.Compilation;
using Akov.NetDocsProcessor.Extensions;
using Akov.NetDocsProcessor.Helpers;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;
using Akov.NetDocsProcessor.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Akov.NetDocsProcessor.Processors;

internal class DocsProcessor : IDocsProcessor
{
    public List<NamespaceDescription> PopulateNamespaceCollection(Assembly assembly, XmlDoc xmlDoc, GenerationSettings settings)
    {
        var result = new List<NamespaceDescription>();
        string rootNamespace = xmlDoc.Assembly?.Name ?? "global::";
        var compilation = CSharpCompilation.Create(null)
            .AddReferences(MetadataReference.CreateFromFile(assembly.Location));
        
        var types = assembly.OnlyVisible(settings.AccessLevel).ToList();
        var namespaceNames = types.GetAllNamespaces().ToList();
        
        foreach (var namespaceName in namespaceNames)
        {
            var namespaceDescription = DescriptionHelper.CreateNamespace(namespaceName, rootNamespace);
            var filteredTypes = types.FilterByNamespace(namespaceName);

            foreach (var filteredType in filteredTypes)
            {
                var symbolObject = TypeSymbolObject.Create(compilation, filteredType);
                var typeDescription = DescriptionHelper.CreateType(filteredType, symbolObject.Type, namespaceDescription.Self);

                // No nested objects for members for delegates or enums needed
                if(typeDescription.ElementType is ElementType.Delegate or ElementType.Enum) continue;
                
                var constructors = filteredType.PopulateConstructors(typeDescription, symbolObject.Constructors, settings.AccessLevel);
                typeDescription.Constructors.AddRange(constructors);
                
                var methods = filteredType.PopulateMethods(typeDescription, symbolObject.Methods, settings.AccessLevel);
                typeDescription.Methods.AddRange(methods);
                
                var properties = filteredType.PopulateProperties(typeDescription, symbolObject.Properties, settings.AccessLevel);
                typeDescription.Properties.AddRange(properties);
                
                var events = filteredType.PopulateEvents(typeDescription, symbolObject.Events, settings.AccessLevel);
                typeDescription.Events.AddRange(events);              
                
                namespaceDescription.Types.Add(typeDescription);
            }
            
            result.Add(namespaceDescription);
        }

        return result;
    }

    public void AddXmlComments(List<NamespaceDescription> namespaces, XmlDoc xmlDoc, GenerationSettings settings)
    {
        if(xmlDoc.Members is null) return;
        
        foreach (var namespaceDescription in namespaces)
        {
            foreach (var typeDescription in namespaceDescription.Types)
            {
                DescriptionHelper.UpdateTypeSummary(typeDescription, xmlDoc.Members);

                // No nested objects for members for delegates or enums needed
                if(typeDescription.ElementType is ElementType.Delegate or ElementType.Enum) continue;

                if (typeDescription.ElementType is not ElementType.Record)
                {
                    DescriptionHelper.UpdateMembers(typeDescription.Constructors, xmlDoc.Members);
                }
                
                DescriptionHelper.UpdateMembers(typeDescription.Methods, xmlDoc.Members);
                DescriptionHelper.UpdateMembers(typeDescription.Properties, xmlDoc.Members);
                DescriptionHelper.UpdateMembers(typeDescription.Events, xmlDoc.Members);
            }
        }
    }
}
