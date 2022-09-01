using UnityEngine;
using UnityEngine.UI;

public class TagButtonHandler : Connectable
{
    [SerializeField] private GameObject _tagButtonPrefab;
    [SerializeField] private Transform _parentObject;
    [SerializeField] private ContentFitterRefresher _contentFitterRefresher;
    [SerializeField] private TagCreator _tagCreator;
    [SerializeField] private Text _targetText;
    [SerializeField] private WindowOpener _popupMenu;
    [SerializeField] private FileManagerHandler _fileManagerHandler;

    public override void Connect()
    {
        TagHandler tagHandler = _tagCreator.Initialize();
        _fileManagerHandler.FileManager.GetTagsFromFile(tagHandler);
        tagHandler.OnAdding += _Rebuild;
        tagHandler.OnAdding += _fileManagerHandler.FileManager.WriteTagsToFile;
        _Rebuild(tagHandler);
    }

    private void _Rebuild(TagHandler tags)
    {
        foreach (Transform child in _parentObject)
        {
            Destroy(child.gameObject);
        }
        int count = tags.Count;
        for (int i = 0; i < count; ++i)
        {
            GameObject newObject = Instantiate(_tagButtonPrefab, _parentObject);
            newObject.GetComponent<TagButton>()?.SetValues(tags[i], _targetText, _popupMenu);
        }
        _contentFitterRefresher?.Refresh();
    }
}
