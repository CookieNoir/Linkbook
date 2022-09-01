using UnityEngine;
using UnityEngine.UI;

public class TagSetter : MonoBehaviour
{
    [SerializeField] private Text _tagText;
    [SerializeField] private Text _targetText;

    public void SetTextAndTarget(string text, Text targetText)
    {
        _tagText.text = "#" + text;
        _targetText = targetText;
    }

    public void SetTag()
    {
        if (_targetText) _targetText.text = _tagText.text; 
    }
}