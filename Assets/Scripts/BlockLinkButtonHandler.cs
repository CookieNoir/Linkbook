using System.Collections.Generic;
using UnityEngine;

public class BlockLinkButtonHandler : Connectable
{
    [SerializeField] private GameObject _blockLinkButtonPrefab;
    [SerializeField] private Transform _parentObject;
    [SerializeField] private LinkMenu _linkMenu;
    [SerializeField] private BlockLinkCreator _blockLinkCreator;
    [SerializeField] private ContentFitterRefresher _contentFitterRefresher;
    [SerializeField] private FileManagerHandler _fileManagerHandler;
    public delegate void OnRebuildDelegate(in List<BlockLinkButton> blockLinkButtons);
    public event OnRebuildDelegate OnRebuild;

    public override void Connect()
    {
        BlockLinkHandler blockLinkHandler = _blockLinkCreator.Initialize();
        _fileManagerHandler.FileManager.GetBlockLinksFromFiles(blockLinkHandler);
        blockLinkHandler.OnChanging += _Rebuild;
        blockLinkHandler.OnChanging += _fileManagerHandler.FileManager.WriteBlockLinksToFile;
        _Rebuild(blockLinkHandler);
    }

    private void _Rebuild(BlockLinkHandler blockLinks)
    {
        foreach (Transform child in _parentObject)
        {
            Destroy(child.gameObject);
        }
        int count = blockLinks.Count;
        List<BlockLinkButton> blockLinkButtons = new List<BlockLinkButton>(count);
        for (int i = 0; i < count; ++i)
        {
            GameObject newObject = Instantiate(_blockLinkButtonPrefab, _parentObject);
            BlockLinkButton newButton = newObject.GetComponent<BlockLinkButton>();
            if (newButton)
            {
                newButton.SetValues(blockLinks[i], _linkMenu, _blockLinkCreator);
                blockLinkButtons.Add(newButton);
            }
        }
        _contentFitterRefresher?.Refresh();
        OnRebuild?.Invoke(blockLinkButtons);
    }
}