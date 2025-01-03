using System.IO;


namespace Engine;

public static class Assets
{
    public static string GetFilePath (string relativePath)
    {
        // Get the directory where the executable is located
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        // Combine it with the relative path
        string fullPath = Path.Combine(baseDir, "Assets", relativePath);

        return fullPath;
    }

    public static byte[] ReadAllBytes (string relativePath)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(baseDir, "Assets", relativePath);

        return File.ReadAllBytes(fullPath);
    }
}
