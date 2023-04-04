using Microsoft.CodeAnalysis;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class TypeNameExtensions
{
    public static List<string> GetArgsTypeNames(this Type type)
        => type.IsGenericType
            ? type.GetGenericArguments().Select(x => x.Name).ToList()
            : new List<string> { type.Name };
    
    public static List<string> GetArgsTypeNames(this ITypeSymbol symbol)
    {
        if (symbol is ITypeParameterSymbol parameterSymbol)
            return new List<string> { parameterSymbol.Name };

        var typeSymbol = (INamedTypeSymbol)symbol;
        return typeSymbol.IsGenericType
            ? typeSymbol.TypeArguments.Select(x => x.Name).ToList()
            : new List<string> { typeSymbol.Name };
    }
}