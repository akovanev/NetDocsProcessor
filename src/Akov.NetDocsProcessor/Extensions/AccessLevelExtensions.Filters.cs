using System.Reflection;
using Akov.NetDocsProcessor.Input;

namespace Akov.NetDocsProcessor.Extensions;

internal static partial class AccessLevelExtensions
{
    public static IEnumerable<TypeInfo> OnlyVisible(this Assembly assembly, AccessLevel accessLevel)
        => assembly.DefinedTypes.Where(type => type.IsVisibleFor(accessLevel));
    
    public static IEnumerable<ConstructorInfo> OnlyVisible(this ConstructorInfo[] constructors, AccessLevel accessLevel)
        => constructors.Where(ctor => ctor.IsVisibleFor(accessLevel));
    
    public static IEnumerable<MethodInfo> OnlyVisible(this MethodInfo[] methods, AccessLevel accessLevel)
        => methods.Where(method => method.IsVisibleFor(accessLevel));
    
    public static IEnumerable<PropertyInfo> OnlyVisible(this PropertyInfo[] properties, AccessLevel accessLevel)
        => properties.Where(prop => prop.IsVisibleFor(accessLevel));
    
    public static IEnumerable<EventInfo> OnlyVisible(this EventInfo[] events, AccessLevel accessLevel)
        => events.Where(@event => @event.IsVisibleFor(accessLevel));
}