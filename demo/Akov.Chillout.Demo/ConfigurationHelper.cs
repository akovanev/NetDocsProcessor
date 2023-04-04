using Akov.NetDocsProcessor.Input;

namespace Akov.Chillout.Demo;

public class ConfigurationHelper
{
    private const string DllPath = "Akov.Chillout.dll";
    private const string XmlPath = "Akov.Chillout.xml";

    public static AssemblyPaths GetAssemblyPaths()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fullDllPath = Path.Combine(currentDirectory, DllPath);
        string fullXmlPath = Path.Combine(currentDirectory, XmlPath);
        return new AssemblyPaths(fullDllPath, fullXmlPath);
    }
}