using System;
using System.Collections.Generic;

public class TagHandler
{
    private List<string> _tags;
    public const string DefaultTag = "без категории";
    public const string RemovedTag = "корзина";
    public event Action<TagHandler> OnAdding;
    public int Count => _tags.Count;

    public string[] ToArray()
    {
        return _tags.ToArray();
    }

    public string this[int index]
    {
        get => _tags[index];
    }

    public TagHandler()
    {
        _tags = new List<string>();
    }

    public bool AddNewTag(string tag)
    {
        bool result = false;
        if (Validator.IsTagValid(tag) && !(_tags.Contains(tag) || tag == DefaultTag || tag == RemovedTag))
        {
            _tags.Add(tag);
            result = true;
            OnAdding?.Invoke(this);
        }
        return result;
    }
}