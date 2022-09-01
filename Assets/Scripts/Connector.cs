using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] private Connectable[] _connectables;

    private void Start()
    {
        foreach (Connectable connectable in _connectables)
        {
            connectable.Connect();
        }
    }
}