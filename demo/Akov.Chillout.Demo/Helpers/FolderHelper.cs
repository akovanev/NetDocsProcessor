namespace Akov.Chillout.Demo.Helpers;

public class FolderHelper
{
    public static string PrepareFolder()
    {
        var docsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Docs");
        
        if(Directory.Exists(docsFolder))
            Directory.Delete(docsFolder, true);
        
        Directory.CreateDirectory(docsFolder);
        
        return docsFolder;
    }
}