using System.Collections.Immutable;
using System.Reflection;
using Akov.NetDocsProcessor.Helpers;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;
using Microsoft.CodeAnalysis;
using TypeInfo = System.Reflection.TypeInfo;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class TypeInfoExtensions
{
    public static List<MemberDescription> PopulateConstructors(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<IMethodSymbol>? symbols, AccessLevel accessLevel)
        =>
            typeInfo
                .GetTypeConstructors()
                .OnlyVisible(accessLevel)
                .Select(constructor => 
                    DescriptionHelper.CreateMember(
                        constructor.GetUniqueName(), 
                        MemberTypes.Constructor,
                        symbols.FindBy(constructor),
                        parent.Self))
                .ToList();
    
    public static List<MemberDescription> PopulateFields(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<IFieldSymbol>? symbols, AccessLevel accessLevel)
        =>
            typeInfo
                .GetTypeFields()
                .OnlyVisible(accessLevel)
                .Select(field => 
                    DescriptionHelper.CreateMember(
                        field.Name, 
                        MemberTypes.Field,
                        symbols.FindBy(field),
                        parent.Self))
                .ToList();
    
    public static List<MemberDescription> PopulateMethods(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<IMethodSymbol>? symbols, AccessLevel accessLevel)
        =>
            typeInfo
                .GetTypeMethods()
                .OnlyVisible(accessLevel)
                .Select(method => 
                    DescriptionHelper.CreateMember(
                        method.GetUniqueName(), 
                        MemberTypes.Method,
                        symbols.FindBy(method),
                        parent.Self))
                .ToList();
    
    public static List<MemberDescription> PopulateProperties(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<IPropertySymbol>? symbols, AccessLevel accessLevel)
        =>
            typeInfo
                .GetTypeProperties()
                .OnlyVisible(accessLevel)
                .Select(property => 
                    DescriptionHelper.CreateMember(
                        property.Name, 
                        MemberTypes.Property, 
                        symbols.FindBy(property),
                        parent.Self))
                .ToList();
    
    public static List<MemberDescription> PopulateEvents(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<IEventSymbol>? symbols, AccessLevel accessLevel)
        =>
            typeInfo
                .GetTypeEvents()
                .OnlyVisible(accessLevel)
                .Select(@event => 
                    DescriptionHelper.CreateMember(
                        @event.Name, 
                        MemberTypes.Event,
                        symbols.FindBy(@event),
                        parent.Self))
                .ToList();

    public static List<EnumMemberDescription> PopulateEnumMembers(this TypeInfo typeInfo, TypeDescription parent, ImmutableArray<ISymbol>? symbols)
    {
        var result = new List<EnumMemberDescription>();
        if (!typeInfo.IsEnum || symbols is null) return result;

        result.AddRange(
            from ISymbol? symbol in symbols 
            select DescriptionHelper.CreateEnumMember(symbol, parent.Self));

        return result;
    }
    
    private static ConstructorInfo[] GetTypeConstructors(this TypeInfo typeInfo)
        => typeInfo
            .GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(m => m.DeclaringType == typeInfo)
            .ToArray();

    private static FieldInfo[] GetTypeFields(this TypeInfo typeInfo)
        => typeInfo
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(p => p.DeclaringType == typeInfo)
            .ToArray();
    
    private static MethodInfo[] GetTypeMethods(this TypeInfo typeInfo)
        => typeInfo
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(m => m.DeclaringType == typeInfo && !m.IsSpecialName && !m.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false))
            .ToArray();

    private static PropertyInfo[] GetTypeProperties(this TypeInfo typeInfo)
        => typeInfo
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(p => p.DeclaringType == typeInfo)
            .ToArray();

    private static EventInfo[] GetTypeEvents(this TypeInfo typeInfo)
        => typeInfo
            .GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(e => e.DeclaringType == typeInfo)
            .ToArray();
}