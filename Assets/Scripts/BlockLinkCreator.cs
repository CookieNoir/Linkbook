using UnityEngine;
using UnityEngine.UI;

public class BlockLinkCreator : WindowOpener
{
    [SerializeField] private GameObject _createButton;
    [SerializeField] private GameObject _editButton;
    [SerializeField] private InputField _name;
    [SerializeField] private InputField _url;
    [SerializeField] private Text _tag;
    [SerializeField] private MessageWindow _errorMessage;
    [SerializeField] private MessageWindow _createdSuccessMessage;
    [SerializeField] private MessageWindow _editedSuccessMessage;
    [SerializeField] private WindowOpener _tagPopup;
    public BlockLinkHandler BlockLinks { get; private set; }
    private BlockLink _currentBlockLink;

    public BlockLinkHandler Initialize()
    {
        BlockLinks = new BlockLinkHandler();
        _name.characterLimit = Validator.NameLength;
        return BlockLinks;
    }

    protected override void OnClose()
    {
        _name.text = "";
        _url.text = "";
        _tag.text = '#' + TagHandler.DefaultTag;
        _currentBlockLink = null;
        _tagPopup?.Close();
    }

    public void Edit(BlockLink blockLink)
    {
        _currentBlockLink = blockLink;
        Open();
    }

    protected override void OnOpen()
    {
        if (_currentBlockLink == null)
        {
            _createButton.SetActive(true);
            _editButton.SetActive(false);
        }
        else
        {
            _createButton.SetActive(false);
            _editButton.SetActive(true);
            _name.text = _currentBlockLink.Name;
            _url.text = _currentBlockLink.URL;
            _tag.text = '#' + _currentBlockLink.Tag;
        }
    }

    public void CreateBlockLink()
    {
        _ChangeBlockLink(false, _createdSuccessMessage);
    }

    public void EditBlockLink()
    {
        _ChangeBlockLink(true, _editedSuccessMessage);
    }

    public void Remove(BlockLink blockLink)
    {
        BlockLinks.SetRemoved(blockLink);
    }

    private void _ChangeBlockLink(bool edit, MessageWindow successMessage)
    {
        string name = _name.text;
        string url = _url.text;
        string tagWithoutHash = _tag.text.Substring(1); // Т.к. символ Hash находится всегда спереди, берем подстроку, не включающую первый элемент
        bool result = edit ? BlockLinks.EditBlockLink(_currentBlockLink, name, url, tagWithoutHash) : BlockLinks.AddNewBlockLink(name, url, tagWithoutHash);
        if (result)
        {
            Close();
            successMessage.ShowMessage(name);
        }
        else
        {
            _errorMessage.ShowMessage();
        }
    }
}
