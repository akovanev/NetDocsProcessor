using System.Text;
using Akov.NetDocsProcessor.Common;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;

namespace Akov.Chillout.Demo.Helpers;

public static class PayloadInfoExtensions
{
    public static string GetFullNameWithSignature(this PayloadInfo payloadInfo, string signature, ElementType parentType, string? returnType = null)
    {
        var builder = new StringBuilder();

        if (payloadInfo.AccessLevel == AccessLevel.ProtectedInternal)
        {
            builder.Append("protected internal ");
        }
        else
        {
            builder.Append($"{payloadInfo.AccessLevel.ToString().ToLower()} ");
        }

        if (payloadInfo.IsAbstract && parentType is not ElementType.Interface)
        {
            builder.Append("abstract ");
        }

        if (payloadInfo.IsOverride)
        {
            builder.Append("override ");
        }

        if (payloadInfo.IsSealed)
        {
            builder.Append("sealed ");
        }

        if (payloadInfo.IsStatic)
        {
            builder.Append("static ");
        }

        if (payloadInfo.IsVirtual)
        {
            builder.Append("virtual ");
        }
        
        if (payloadInfo.IsAsync == true)
        {
            builder.Append("async ");
        }
        
        if (returnType is not null)
        {
            builder.Append($"{returnType.GetAliasOrName()} ");
        }

        builder.Append($"{signature} ");

        bool isPropertyAndHasGetter = payloadInfo.HasGetMethod == true;
        bool isPropertyAndHasSetter = payloadInfo.HasSetMethod == true;

        if (!isPropertyAndHasGetter && !isPropertyAndHasSetter) return builder.ToString();
        
        builder.Append(" { ");
            
        if (isPropertyAndHasGetter)
        {
            builder.Append("get; ");
        }
            
        if (isPropertyAndHasSetter)
        {
            builder.Append("set; ");
        }
            
        builder.Append(" } ");

        return builder.ToString();
    }
}