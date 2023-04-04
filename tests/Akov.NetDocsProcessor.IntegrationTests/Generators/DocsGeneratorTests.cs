using Akov.NetDocsProcessor.Api;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.IntegrationTests.Helpers;
using FluentAssertions;
using Xunit;

namespace Akov.NetDocsProcessor.IntegrationTests.Generators;

public class DocsGeneratorTests
{
    private readonly DocsProcessorApi _docsGenerator = new();
    
    [Fact]
    public void ObtainDocumentation_SmokeTest()
    {
        var namespaces = _docsGenerator.ObtainDocumentation(
            ConfigurationHelper.GetAssemblyPaths(),
            new GenerationSettings { AccessLevel = AccessLevel.Protected }).ToList();
        
        namespaces.Should().NotBeNullOrEmpty();

        foreach (var @namespace in namespaces)
        {
            foreach (var type in @namespace.Types)
            {
                type.Summary.Should().NotBeNullOrEmpty();

                foreach (var constructor in type.Constructors)
                {
                    if(constructor.Name 
                       is "ctor"
                       or "ctor-crazytraveler"
                       or "ctor-traveler"
                       or "ctor-string-string") continue; //intentional skip
                    
                    constructor.Summary.Should().NotBeNullOrEmpty();
                }

                foreach (var method in type.Methods)
                    method.Summary.Should().NotBeNullOrEmpty();
                
                foreach (var property in type.Properties)
                    property.Summary.Should().NotBeNullOrEmpty();
                
                foreach (var @event in type.Events)
                    @event.Summary.Should().NotBeNullOrEmpty();
            }
        }
    }
}