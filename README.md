# NetDocsProcessor

### The project is not finished yet.

Unlike many libraries that produce output in predetermined HTML or Markdown formats, the NetDocsProcessor API provides a distinct approach for accessing data from an assembly and its associated XML file.

```csharp
List<NamespaceDescription> data = new DocsProcessorApi().ObtainDocumentation(
        new AssemblyPaths("path_to_dll.dll", "path_to_xml.xml"),
        new GenerationSettings { AccessLevel = AccessLevel.Protected })
    .ToList();
```

The [demo](https://github.com/akovanev/NetDocsProcessor/blob/main/demo/Akov.Chillout.Demo/Program.cs)  illustrates how to generate documentation files in Markdown format.