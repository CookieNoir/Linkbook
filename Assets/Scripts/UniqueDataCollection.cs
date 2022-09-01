using System.Collections.Generic;

public class UniqueDataCollection
{
    private HashSet<string> _names = new HashSet<string>();
    private HashSet<string> _urls = new HashSet<string>();

    public bool AddUniqueNameAndURL(string name, string url)
    {
        if (!(_names.Contains(name) || _urls.Contains(url)))
        {
            _names.Add(name);
            _urls.Add(url);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool EditNameAndURL(string oldName, string newName, string oldUrl, string newUrl)
    {
        bool result = false;
        _names.Remove(oldName);
        _urls.Remove(oldUrl);
        if (!(_names.Contains(newName) || _urls.Contains(newUrl)))
        {
            _names.Add(newName);
            _urls.Add(newUrl);
            return true;
        }
        else
        {
            _names.Add(oldName);
            _urls.Add(oldUrl);
        }
        return result;
    }
}