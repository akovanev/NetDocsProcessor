using Akov.NetDocsProcessor.Common;
using TypeInfo = System.Reflection.TypeInfo;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class TypeInfoExtensions
{
    public static string GetTypeName(this TypeInfo typeInfo)
    {
        if (!typeInfo.IsNested)
            return typeInfo.Name;
        
        int plusIndex = typeInfo.FullName!.IndexOf("+", StringComparison.Ordinal);
        string namespaceAndParentTypeName = typeInfo.FullName.Substring(0, plusIndex);
        int lastDotIndex = namespaceAndParentTypeName.LastIndexOf(".", StringComparison.Ordinal);
        string parentTypeName = namespaceAndParentTypeName.Substring(lastDotIndex + 1);
        string typeName = typeInfo.FullName[plusIndex..].Replace("+", ".");
        return string.Concat(parentTypeName, typeName);
    }
    
    // Record structs will be defined as structs.
    public static ElementType GetTypeElementType(this TypeInfo typeInfo)
    {
        if (typeof(Delegate).IsAssignableFrom(typeInfo))
            return ElementType.Delegate;
        
        if (typeInfo.GetMethod("<Clone>$") is not null)
            return ElementType.Record;
        
        return typeInfo switch
        {
            { IsClass: true } => ElementType.Class,
            { IsInterface: true } => ElementType.Interface,
            { IsValueType: true, IsEnum: false } => ElementType.Struct,
            { IsEnum: true } => ElementType.Enum,
            _ => throw new InvalidOperationException($"Cannot define the element for {typeInfo.FullName}")
        };
    }
}