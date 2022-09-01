using System.IO;

public class FileIO : IFileIO
{
    public string[] ReadAllLines(string path)
    {
        string[] result;
        try { result = File.ReadAllLines(path); }
        catch { result = new string[0]; }
        return result;
    }

    public void WriteAllLines(string path, string[] contents)
    {
        File.WriteAllLines(path, contents);
    }
}
