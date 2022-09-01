using UnityEngine;
using UnityEngine.UI;

public class TagCreator : WindowOpener
{
    [SerializeField] private InputField _tag;
    [SerializeField] private MessageWindow _errorMessage;
    [SerializeField] private MessageWindow _successMessage;
    public TagHandler Tags { get; private set; }

    public TagHandler Initialize()
    {
        Tags = new TagHandler();
        _tag.characterLimit = Validator.TagLength;
        return Tags;
    }

    protected override void OnClose()
    {
        _tag.text = "";
    }

    public void CreateTag()
    {
        string tag = _tag.text;
        bool result = Tags.AddNewTag(tag);
        if (result)
        {
            Close();
            _successMessage.ShowMessage('#' + tag);
        }
        else
        {
            _errorMessage.ShowMessage();
        }
    }
}
