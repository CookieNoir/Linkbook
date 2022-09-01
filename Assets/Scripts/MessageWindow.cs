using System;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : WindowOpener
{
    [SerializeField] private Text _textField;
    [SerializeField] private string _messageFormatted;
    private bool _addedNewlines = false;

    public void ShowMessage(string message)
    {
        _Format();
        _textField.text = string.Format(_messageFormatted, message);
        Open();
    }

    public void ShowMessage()
    {
        _Format();
        _textField.text = _messageFormatted;
        Open();
    }

    private void _Format()
    {
        if (!_addedNewlines)
        {
            _messageFormatted = _messageFormatted.Replace("\\n", "\n").Replace("\\t", "\t");
            _addedNewlines = true;
        }
    }
}
