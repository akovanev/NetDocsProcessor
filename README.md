# NetDocsProcessor

[![](https://img.shields.io/badge/.NET%20-6.0%20%7C%207.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) [![](https://img.shields.io/nuget/v/Akov.NetDocsProcessor)](https://www.nuget.org/packages/Akov.NetDocsProcessor/)

#### *The first demo version is released.*

Unlike many libraries that produce output in predetermined HTML or Markdown formats, the NetDocsProcessor API provides a distinct approach for accessing data from an assembly and its associated XML file.

```csharp
List<NamespaceDescription> data = new DocsProcessorApi().ObtainDocumentation(
        new AssemblyPaths("path_to_dll.dll", "path_to_xml.xml"),
        new GenerationSettings { AccessLevel = AccessLevel.Protected })
    .ToList();
```

The [demo](https://github.com/akovanev/NetDocsProcessor/blob/main/demo/Akov.Chillout.Demo/Program.cs)  illustrates how to generate documentation files in Markdown format.

### The list of supported xml tags

* `<example>`
* `<exception>`
* `<include>`
* `<remarks>` 
* `<returns>`
* `<param>`
* `<summary>`
* `<typeparam>`


The tags `<example>`, `<remarks>` and `<returns>` support internal tags. 
