﻿using Akov.Chillout.Demo;
using Akov.Chillout.Demo.Content;
using Akov.Chillout.Demo.Helpers;
using Akov.NetDocsProcessor.Api;
using Akov.NetDocsProcessor.Input;
using Akov.NetDocsProcessor.Output;

string docsFolder = FolderHelper.PrepareFolder();

// Retrieve documentation data
var data = new DocsProcessorApi().ObtainDocumentation(
    ConfigurationHelper.GetAssemblyPaths(),
    new GenerationSettings { AccessLevel = AccessLevel.Protected }).ToList();

// Create Index.md
var listMd = IndexContentCreator.Create(data);
File.WriteAllText(Path.Combine(docsFolder, "Index.md"), listMd);

// Create namespaces
foreach (var @namespace in data)
{
    var namespaceMd = NamespaceContentCreator.Create(@namespace);
    File.WriteAllText(Path.Combine(docsFolder, $"{@namespace.Self.Url}.md"), namespaceMd);

    Directory.CreateDirectory(Path.Combine(docsFolder, @namespace.Self.Url));
    
    // Create types
    foreach (var type in @namespace.Types)
    {
        var typeMd = TypeContentCreator.Create(type);
        File.WriteAllText(Path.Combine(docsFolder, $"{type.Self.Url}.md"), typeMd);

        CreateMemberContentIfAny(type.Constructors, docsFolder);
        CreateMemberContentIfAny(type.Methods, docsFolder);
        CreateMemberContentIfAny(type.Properties, docsFolder);
        CreateMemberContentIfAny(type.Events, docsFolder);
    }
}

Console.WriteLine("Done!");

// Program methods 

static void CreateMemberContentIfAny(List<MemberDescription> members, string docsPath)
{
    if(!members.Any()) return;

    string folderPath = Path.Combine(docsPath, GetMemberFolder(members.First()));
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }

    // Create members
    foreach (var member in members)
    {
        var memberMd = MemberContentCreator.Create(member);
        File.WriteAllText(Path.Combine(docsPath,$"{member.Self.Url}.md"), memberMd);
    }
}

static string GetMemberFolder(MemberDescription member)
{
    string memberUrl = member.Self.Url;
    int lastIndex = memberUrl.LastIndexOf('\\');
    return memberUrl[..lastIndex];
}