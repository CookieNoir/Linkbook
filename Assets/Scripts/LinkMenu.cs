using UnityEngine;
using UnityEngine.UI;

public class LinkMenu : WindowOpener
{
    [SerializeField] private Text _textField;
    private string _url;

    public void SetURLAndOpen(string url)
    {
        _url = url;
        _textField.text = _url;
        Open();
    }
}