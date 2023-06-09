using System.Reflection;
using Akov.NetDocsProcessor.Input;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class AccessLevelExtensions
{
    public static bool IsVisibleFor(this TypeInfo typeInfo, AccessLevel accessLevel)
        => accessLevel switch
        {
            AccessLevel.Public => typeInfo.IsPublic,
            AccessLevel.Protected => typeInfo.IsPublic || typeInfo.IsNestedFamily,
            AccessLevel.Internal => typeInfo.IsPublic || typeInfo.IsNestedAssembly,
            AccessLevel.ProtectedInternal => typeInfo.IsPublic || typeInfo.IsNestedFamORAssem,
            AccessLevel.Private => true,
            _ => throw new InvalidOperationException(
                $"Method {nameof(IsVisibleFor)} is not defined for {nameof(AccessLevel)} {accessLevel}")
        };
    
    // Works for constructors and methods.
    public static bool IsVisibleFor(this MethodBase method, AccessLevel accessLevel)
        => IsVisibleForInternal(method, null, accessLevel);

    public static bool IsVisibleFor(this FieldInfo field, AccessLevel accessLevel)
        => IsVisibleForInternal(field, accessLevel);
    
    public static bool IsVisibleFor(this PropertyInfo property, AccessLevel accessLevel)
        => IsVisibleForInternal(property.GetGetMethod(), property.GetSetMethod(), accessLevel);
    
    public static bool IsVisibleFor(this EventInfo @event, AccessLevel accessLevel)
        => IsVisibleForInternal(@event.AddMethod, @event.RemoveMethod, accessLevel);

    private static bool IsVisibleForInternal(MethodBase? method1, MethodBase? method2, AccessLevel accessLevel)
        => accessLevel switch
        {
            AccessLevel.Public => (method1 is not null && method1.IsPublic) ||
                                  (method2 is not null && method2.IsPublic),
            AccessLevel.Protected => (method1 is not null && (method1.IsPublic || method1.IsFamily)) ||
                                     (method2 is not null && (method2.IsPublic || method2.IsFamily)),
            AccessLevel.Internal => (method1 is not null && (method1.IsPublic || method1.IsAssembly)) ||
                                    (method2 is not null && (method2.IsPublic || method2.IsAssembly)),
            AccessLevel.ProtectedInternal => (method1 is not null &&
                                              (method1.IsPublic || method1.IsFamilyOrAssembly)) ||
                                             (method2 is not null &&
                                              (method2.IsPublic || method2.IsFamilyOrAssembly)),
            AccessLevel.Private => true,
            _ => throw new InvalidOperationException(
                $"Method {nameof(IsVisibleFor)} is not defined for {nameof(AccessLevel)} {accessLevel}")
        };
    
    private static bool IsVisibleForInternal(FieldInfo? field, AccessLevel accessLevel)
        => accessLevel switch
        {
            AccessLevel.Public => field is not null && field.IsPublic,
            AccessLevel.Protected => field is not null && (field.IsPublic || field.IsFamily),
            AccessLevel.Internal => field is not null && (field.IsPublic || field.IsAssembly),
            AccessLevel.ProtectedInternal => field is not null && (field.IsPublic || field.IsFamilyOrAssembly),
            AccessLevel.Private => true,
            _ => throw new InvalidOperationException(
                $"Method {nameof(IsVisibleFor)} is not defined for {nameof(AccessLevel)} {accessLevel}")
        };
}