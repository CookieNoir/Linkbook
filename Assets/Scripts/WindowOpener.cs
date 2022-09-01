using UnityEngine;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    public void Open()
    {
        _window.SetActive(true);
        OnOpen();
    }

    public void Close()
    {
        _window.SetActive(false);
        OnClose();
    }

    protected virtual void OnOpen()
    {
    
    }

    protected virtual void OnClose()
    {
    
    }
}
