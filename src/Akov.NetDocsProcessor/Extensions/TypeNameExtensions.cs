using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class TypeNameExtensions
{
    public static string GetUniqueName(this ConstructorInfo constructor)
    {
        if (constructor.IsStatic)
            return "cctor";
        
        var parameters = constructor.GetParameters();
        
        return parameters.Length == 0 
            ? "ctor" 
            : $"ctor-{string.Join("-", parameters.Select(p => NormalizeTypeName(p.ParameterType.Name)?.ToLower()))}";
    }

    public static string GetUniqueName(this MethodInfo method)
    {
        var name = method.Name.ToLower();

        if (method.IsGenericMethod)
        {
            var genericArgsNames = method.GetGenericArguments().Select(arg => arg.Name).ToArray();
            name = $"{name}-{genericArgsNames.Length}";
        }

        var parameters = method.GetParameters();

        return parameters.Length == 0
            ? name
            : $"{name}-{string.Join("-", parameters.Select(p => NormalizeTypeName(p.ParameterType.Name)?.ToLower()))}";
    }

    public static string? GetTypeAliasOrName(this string? typeName)
    {
        if (typeName is null) return null;
        
        switch (typeName)
        {
            case "System.Boolean":
            case "Boolean":
                return "bool";
            case "System.Byte":
            case "Byte":
                return "byte";
            case "System.Char":
            case "Char":
                return "char";
            case "System.Decimal":
            case "Decimal":
                return "decimal";
            case "System.Double":
            case "Double":
                return "double";
            case "System.Single":
            case "Single":
                return "float";
            case "System.Int32":
            case "Int32":
                return "int";
            case "System.UInt32":
            case "UInt32":
                return "uint";
            case "System.Int64":
            case "Int64":
                return "long";
            case "System.UInt64":
            case "UInt64":
                return "ulong";
            case "System.Object":
            case "Object":
                return "object";
            case "System.Int16":
            case "Int16":
                return "short";
            case "System.UInt16":
            case "UInt16":
                return "ushort";
            case "System.String":
            case "String":
                return "string";
            case "Void":
                return "void";
            default:
                return typeName;
        }
    }
    
    public static string GetNullableTypeName(this string nullableTypeName)
    {
        if (string.IsNullOrEmpty(nullableTypeName))
            return nullableTypeName;

        var nullableRegex = new Regex(@"^Nullable<(.+)>");
        Match match = nullableRegex.Match(nullableTypeName);
        if (!match.Success) return nullableTypeName;
        
        string innerTypeName = match.Groups[1].Value;
        return innerTypeName.EndsWith("?") ? innerTypeName : $"{innerTypeName}?";
    }
    
    private static string NormalizeTypeName(string? typeName)
    {
        char[] charsToReplace = { '(', ')', '[', ']', '`' };

        var sb = new StringBuilder(typeName);

        foreach (char charToReplace in charsToReplace)
        {
            sb.Replace(charToReplace, '-');
        }

        return sb.ToString();
    }
}