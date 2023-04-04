using System.Collections.Immutable;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace Akov.NetDocsProcessor.Extensions;

internal static class SymbolExtensions
{
    public static IMethodSymbol? FindBy(this ImmutableArray<IMethodSymbol>? methods, MethodBase method)
    {
        if (methods is null) return null;
        
        var methodParams = method.GetParameters().Select(p => p.ParameterType).ToList();
        
        foreach (var methodSymbol in methods)
        {
            var methodSymbolParams = methodSymbol.Parameters.Select(p => p.Type.MetadataName).ToArray();

            if (!methodSymbolParams.SequenceEqual(methodParams.Select(m => m.Name))) continue;

            if (methodSymbol.Parameters.Length == 0) return methodSymbol;
            
            for (int index = 0; index < methodSymbol.Parameters.Length; index++)
            {
                var typeArgsFromCompilation = methodSymbol.Parameters[index].Type.GetArgsTypeNames();
                var typeArgs = methodParams[index].GetArgsTypeNames();

                if (typeArgsFromCompilation.SequenceEqual(typeArgs))
                    return methodSymbol;
            }
        }

        return null;
    }

    public static IPropertySymbol? FindBy(this ImmutableArray<IPropertySymbol>? properties, PropertyInfo property)
        => properties?.SingleOrDefault(p => p.Name == property.Name);
    
    public static IEventSymbol? FindBy(this ImmutableArray<IEventSymbol>? events, EventInfo @event)
        => events?.SingleOrDefault(e => e.Name == @event.Name);
}