using UnityEngine;
using UnityEngine.UI;

public class ContentFitterRefresher : MonoBehaviour
{
    [SerializeField] private RectTransform[] _contentFitters;

    public void Refresh()
    {
        for (int i = 0; i < _contentFitters.Length; ++i)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_contentFitters[i]);
        }
    }
}
