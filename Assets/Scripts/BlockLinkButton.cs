using UnityEngine;
using UnityEngine.UI;

public class BlockLinkButton : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private LinkMenu _linkMenu;
    [SerializeField] private BlockLinkCreator _blockLinkCreator;
    public BlockLink BlockLink { get; private set; }

    public void SetValues(BlockLink blockLink, LinkMenu linkMenu, BlockLinkCreator blockLinkCreator)
    {
        BlockLink = blockLink;
        _name.text = blockLink.Name;
        _linkMenu = linkMenu;
        _blockLinkCreator = blockLinkCreator;
    }

    public bool TagStartsWithSubstring(string substring)
    {
        return BlockLink.Tag.StartsWith(substring);
    }

    public bool HasTag(string tag)
    {
        return BlockLink.Tag.Equals(tag);
    }

    public void Show()
    {
        _linkMenu.SetURLAndOpen(BlockLink.URL);
    }

    public void Edit()
    {
        _blockLinkCreator.Edit(BlockLink);
    }

    public void Remove()
    {
        _blockLinkCreator.Remove(BlockLink);
    }
}