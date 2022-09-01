using UnityEngine;
using UnityEngine.UI;

public class LinkOpener : MonoBehaviour
{
    [SerializeField] private Text _textComponent;

    public void OpenLink()
    {
        Application.OpenURL(_textComponent.text);      
    }
}