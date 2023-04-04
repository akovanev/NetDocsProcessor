using System.Reflection;
using System.Xml.Serialization;
using Akov.NetDocsProcessor.Xml;

namespace Akov.NetDocsProcessor.Helpers;

internal class FileReader
{
    public static XmlDoc ReadXml(string path)
    {
        var serializer = new XmlSerializer(typeof(XmlDoc));
        using var reader = new StreamReader(path);
        var doc = (XmlDoc?)serializer.Deserialize(reader);
        return doc ?? throw new InvalidOperationException($"The xml file {path} was not deserialized correctly");
    }

    public static Assembly ReadAssembly(string path) => Assembly.LoadFile(path);
}