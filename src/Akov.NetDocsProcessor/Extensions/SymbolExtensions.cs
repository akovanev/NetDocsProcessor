using System.Collections.Immutable;
using System.Reflection;
using System.Text.RegularExpressions;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;
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
            if(methodSymbol.Name != method.Name) continue;

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

    public static string? GetReturnType(this ISymbol symbol)
    {
        switch (symbol.Kind)
        {
            case SymbolKind.Method:
                var method = (IMethodSymbol)symbol;
                if (method.MethodKind != MethodKind.Constructor)
                    return method.ReturnType.Name;
                break;
            case SymbolKind.Property:
                return ((IPropertySymbol)symbol).Type.Name;
            case SymbolKind.Event:
                return ((IEventSymbol)symbol).Type.Name;
        }
        
        return null;
    }
    
    public static string? GetShortName(this ISymbol symbol)
    {
        switch (symbol.Kind)
        {
            case SymbolKind.Method:
                var method = (IMethodSymbol)symbol;
                return method.MethodKind == MethodKind.Constructor 
                    ? method.ContainingType.Name 
                    : symbol.Name;
            case SymbolKind.Property:
            case SymbolKind.Event:
                return symbol.Name;
        }
        
        return null;
    }
    
    public static string? GetDisplayName(this ISymbol? symbol)
    {
        string AddParametersIfMethod(string symbolAsString)
        {
            if (symbol!.Kind != SymbolKind.Method) return symbolAsString;
            
            var method = (IMethodSymbol)symbol;
            if (method.Parameters.Length == 0) return symbolAsString;
            
            var parametersMatch = Regex.Match(symbolAsString, @"\((.*?)\)");
            if (parametersMatch.Success)
            {
                symbolAsString = symbolAsString.Replace(
                    parametersMatch.Groups[1].Value,
                    string.Join(", ", method.Parameters.Select(m => m.ToString())));
            }

            return symbolAsString;
        }

        string? symbolAsString = symbol?.ToString();
        if (symbolAsString is null) return null;

        symbolAsString = AddParametersIfMethod(symbolAsString);

        // Remove namespaces and concat the substrings
        return string.Concat(
            Regex.Split(symbolAsString, @"(\(|\s|\)|>|<)")
                .Where(s => s != String.Empty)
                .Select(str => str.TrimBeforeLast()));
    }

    public static PayloadInfo GetPayload(this ISymbol symbol)
    {
        var payload = new PayloadInfo
        {
            AccessLevel = symbol.DeclaredAccessibility.ToAccessLevel(),
            IsAbstract = symbol.IsAbstract,
            IsOverride = symbol.IsOverride,
            IsSealed = symbol.IsSealed,
            IsStatic = symbol.IsStatic,
            IsVirtual = symbol.IsVirtual
        };
        
        switch (symbol)
        {
            case INamedTypeSymbol type:
                payload.IsGenericType = type.IsGenericType;
                break;
            case IMethodSymbol method:
                payload.IsAsync = method.IsAsync;
                payload.IsExtensionMethod = method.IsExtensionMethod;
                payload.IsGenericMethod = method.IsGenericMethod;
                payload.IsReadOnlyMethod = method.IsReadOnly;
                break;
            case IPropertySymbol property:
                payload.HasGetMethod = property.GetMethod is not null;
                payload.HasSetMethod = property.SetMethod is not null;
                payload.IsIndexer = property.IsIndexer;
                payload.IsRequired = property.IsRequired;
                break;
        }

        return payload;
    }

    public static bool IsSpecialMethod(this IMethodSymbol method)
        => method.MethodKind is MethodKind.Constructor
            or MethodKind.StaticConstructor
            or MethodKind.Destructor
            or MethodKind.PropertyGet
            or MethodKind.PropertySet
            or MethodKind.EventAdd
            or MethodKind.EventRaise
            or MethodKind.EventRemove
            or MethodKind.Conversion
            or MethodKind.ExplicitInterfaceImplementation
            or MethodKind.UserDefinedOperator;

    private static AccessLevel ToAccessLevel(this Accessibility accessibility)
        => accessibility switch
        {
            Accessibility.Public => AccessLevel.Public,
            Accessibility.Internal => AccessLevel.Internal,
            Accessibility.Protected => AccessLevel.Protected,
            Accessibility.ProtectedAndInternal => AccessLevel.ProtectedInternal,
            Accessibility.Private => AccessLevel.Private,
            _ => AccessLevel.Private
        };
}