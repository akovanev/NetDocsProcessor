using Akov.Chillout.Demo;
using Akov.Chillout.Demo.Helpers;

string docsFolder = FolderHelper.PrepareFolder();

DocsFileGenerator.Run(docsFolder, ConfigurationHelper.GetAssemblyPaths());

Console.WriteLine("Done!");