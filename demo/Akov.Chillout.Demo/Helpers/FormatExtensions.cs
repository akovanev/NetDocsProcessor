namespace Akov.Chillout.Demo.Helpers;

public static class FormatExtensions
{
    public static string? WithoutNewLines(this string? source)
        => source?.Replace(Environment.NewLine, " ")
            .Replace('\n', ' ');
    
    public static string? GetAliasOrName(this string? typeName)
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
}