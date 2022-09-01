using System;

[Serializable]
public class BlockLink: IComparable<BlockLink>
{
    public string Name { get; private set; }
    public string URL { get; private set; }
    public string Tag { get; private set; }

    public BlockLink(string newName, string newURL, string newTag)
    {
        Name = newName;
        URL = newURL;
        Tag = newTag;
    }

    public int CompareTo(BlockLink other)
    {
        return Name.CompareTo(other.Name);
    }

    public void SetTag(string newTag)
    {
        Tag = newTag;
    }
}