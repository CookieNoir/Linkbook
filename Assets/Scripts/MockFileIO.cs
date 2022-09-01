using System.Collections.Generic;

public class MockFileIO : IFileIO
{
    private Dictionary<string, string[]> _files;

    public MockFileIO()
    {
        _files = new Dictionary<string, string[]>();
    }

    public string[] ReadAllLines(string path)
    {
        string[] result;
        if (_files.ContainsKey(path)) result = _files[path];
        else result = new string[0];
        return result;
    }

    public void WriteAllLines(string path, string[] contents)
    {
        if (_files.ContainsKey(path)) _files[path] = contents;
        else _files.Add(path, contents);
    }
}
