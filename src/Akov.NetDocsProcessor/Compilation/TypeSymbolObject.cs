using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using TypeInfo = System.Reflection.TypeInfo;

namespace Akov.NetDocsProcessor.Compilation;

internal class TypeSymbolObject
{
    private TypeSymbolObject() {}
    
    public static TypeSymbolObject Create(CSharpCompilation compilation, TypeInfo type)
    {
        var symbolObject = new TypeSymbolObject
        {
            Type = compilation.GetTypeByMetadataName(type.FullName ?? type.Name)
        };

        if (type.IsEnum)
        {
            symbolObject.InitializeEnumMembers();
        }
        else
        {
            symbolObject.InitializeMembers();
        }
        
        return symbolObject;
    }

    public INamedTypeSymbol? Type { get; private set; }
    public ImmutableArray<IMethodSymbol>? Constructors { get; private set; }
    public ImmutableArray<IMethodSymbol>? Methods { get; private set; }
    public ImmutableArray<IPropertySymbol>? Properties { get; private set; }
    public ImmutableArray<IEventSymbol>? Events { get; private set; }
    public ImmutableArray<ISymbol>? EnumMembers { get; private set; }

    private void InitializeMembers()
    {
        if (Type is null) return;

        Constructors = Type.Constructors;

        var methods = new List<IMethodSymbol>();
        var properties = new List<IPropertySymbol>();
        var events = new List<IEventSymbol>();
        
        foreach (var member in Type.GetMembers())
        {
            switch (member.Kind)
            {
                case SymbolKind.Field:
                    break;
                case SymbolKind.Property:
                    properties.Add((IPropertySymbol)member);
                    break;
                case SymbolKind.Method:
                    var method = (IMethodSymbol)member;
                    if (method.MethodKind != MethodKind.Constructor)
                        methods.Add(method);
                    break;
                case SymbolKind.Event:
                    events.Add((IEventSymbol)member);
                    break;
            }
        }

        Methods = methods.ToImmutableArray();
        Properties = properties.ToImmutableArray();
        Events = events.ToImmutableArray();
    }

    private void InitializeEnumMembers()
    {
        if (Type is null) return;
        EnumMembers = Type.GetMembers();
    }
}