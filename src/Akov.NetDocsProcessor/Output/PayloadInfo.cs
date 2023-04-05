using Akov.NetDocsProcessor.Common;
using Akov.NetDocsProcessor.Input;

namespace Akov.NetDocsProcessor.Output;

public class PayloadInfo
{
    // Base
    public AccessLevel AccessLevel { get; set; }
    public bool IsAbstract { get; set; }
    public bool IsOverride { get; set; }
    public bool IsSealed { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }
    
    // Type
    public bool IsGenericType { get; set; }
    
    // Method
    public bool? IsAsync { get; set; } 
    public bool? IsExtensionMethod { get; set; }
    public bool? IsGenericMethod { get; set; }
    public bool? IsReadOnlyMethod { get; set; }
    
    // Property
    public bool? HasGetMethod { get; set; } 
    public bool? HasSetMethod { get; set; }
    public bool? IsIndexer { get; set; }
    public bool? IsRequired { get; set; }
}