using UnityEngine;
using UnityEngine.UI;

public class TagButton : MonoBehaviour
{
    [SerializeField] private TagSetter _tagSetter;
    private WindowOpener _popupMenu;

    public void SetValues(string text, Text targetText, WindowOpener popupMenu)
    {
        _tagSetter.SetTextAndTarget(text, targetText);
        _popupMenu = popupMenu;
    }

    public void Select()
    {
        _tagSetter.SetTag();
        _popupMenu.Close();
    }
}