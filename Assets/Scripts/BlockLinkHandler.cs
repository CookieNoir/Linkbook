using System;
using System.Collections.Generic;

public class BlockLinkHandler
{
    private List<BlockLink> _blockLinks;
    public event Action<BlockLinkHandler> OnChanging;
    private UniqueDataCollection _uniqueData;

    public int Count => _blockLinks.Count;

    public BlockLink this[int index]
    {
        get => _blockLinks[index];
    }

    public BlockLinkHandler()
    {
        _blockLinks = new List<BlockLink>();
        _uniqueData = new UniqueDataCollection();
    }

    public bool AddNewBlockLink(string name, string url, string tag)
    {
        bool result = false;
        if (Validator.IsURLValid(url))
        {
            if (name.Length == 0)
            {
                name = _SetNameByURL(url);
            }
            if (Validator.IsNameValid(name))
            {
                if (_uniqueData.AddUniqueNameAndURL(name, url))
                {
                    BlockLink block = new BlockLink(name, url, tag);
                    _blockLinks.Add(block);
                    _blockLinks.Sort();
                    result = true;
                    OnChanging?.Invoke(this);
                }
            }
        }
        return result;
    }

    private string _SetNameByURL(string url)
    {
        string result;
        int realLength = URLHelper.GetURLLengthWithoutProtocol(url);
        if (realLength < Validator.NameLength) result = url.Substring(url.Length - realLength);
        else result = url.Substring(url.Length - realLength, Validator.NameLength);
        return result;
    }

    public bool EditBlockLink(BlockLink editableBlockLink, string name, string url, string tag)
    {
        bool result = false;
        if (Validator.IsURLValid(url))
        {
            if (name.Length == 0)
            {
                name = _SetNameByURL(url);
            }
            if (Validator.IsNameValid(name))
            {
                if (editableBlockLink.Name == name && editableBlockLink.URL == url && editableBlockLink.Tag == tag)
                {
                    result = true;
                }
                else if (_uniqueData.EditNameAndURL(editableBlockLink.Name, name, editableBlockLink.URL, url))
                {
                    _blockLinks.Remove(editableBlockLink);
                    BlockLink block = new BlockLink(name, url, tag);
                    _blockLinks.Add(block);
                    _blockLinks.Sort();
                    result = true;
                    OnChanging?.Invoke(this);
                }
            }
        }
        return result;
    }

    public bool SetRemoved(BlockLink blockLink)
    {
        bool result = false;
        if (blockLink != null && _blockLinks.Contains(blockLink))
        {
            blockLink.SetTag(TagHandler.RemovedTag);
            result = true;
            OnChanging?.Invoke(this);
        }
        return result;
    }
}
