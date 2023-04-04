using System.Reflection;
using System.Text;

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