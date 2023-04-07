using Akov.Chillout.Demo;
using Akov.Chillout.Demo.FileSystem;
using Akov.Chillout.Demo.Generation;

var docsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Docs");

DirectoryHelper.PrepareFolder(docsFolder);

DocsFileGenerator.Run(docsFolder, ConfigurationHelper.GetAssemblyPaths());

Console.WriteLine("Done!");