namespace Akov.Chillout.Demo.FileSystem;

public class DirectoryHelper
{
    public static void PrepareFolder(string docsFolder)
    {
        if(Directory.Exists(docsFolder))
            Directory.Delete(docsFolder, true);
        
        Directory.CreateDirectory(docsFolder);
    }
}