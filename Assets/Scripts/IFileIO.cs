public interface IFileIO
{
    string[] ReadAllLines(string path);
    void WriteAllLines(string path, string[] contents);
}