using Akov.NetDocsProcessor.Input;
using FluentAssertions;
using Xunit;

#pragma warning disable CS8604

namespace Akov.NetDocsProcessor.Tests.Input;

public class AssemblyPathsTests
{
    [Theory]
    [InlineData(@"c:\dev\example.dll", null)]
    [InlineData(null, @"c:\dev\example.xml")]
    public void NewAssemblyPaths_NullValues_Throws(string? dllPath, string? xmlPath)
    {
        Action action = () => new AssemblyPaths(dllPath, xmlPath);
        action.Should().Throw<ArgumentNullException>();
    }
    
    [Theory]
    [InlineData(@"c:\dev\example", @"c:\dev\example.xml", nameof(dllPath), ".dll")]
    [InlineData(@"c:\dev\example.dll", @"c:\dev\example", nameof(xmlPath), ".xml")]
    public void NewAssemblyPaths_InvalidPaths_Throws(string dllPath, string xmlPath, string invalidInputParameterName, string invalidPathEnding)
    {
        Action action = () => new AssemblyPaths(dllPath, xmlPath);
        action.Should().Throw<ArgumentException>()
            .WithMessage($"The `{invalidInputParameterName}` should be ending with `{invalidPathEnding}`.");
    }
}