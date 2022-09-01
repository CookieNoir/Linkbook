using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLinkSearcher : MonoBehaviour
{
    [SerializeField] private InputField _tagInputField;
    [SerializeField] private BlockLinkButtonHandler _buttonHandler;
    [SerializeField] private ContentFitterRefresher _contentFitterRefresher;
    private List<BlockLinkButton> _blockLinkButtons;

    private void Awake()
    {
        _tagInputField.characterLimit = Validator.TagLength;
        _buttonHandler.OnRebuild += OnChangeOfBlockListButtons;
    }

    public void OnChangeOfInputField()
    {
        if (_tagInputField.text.Length > 0)
        {
            ShowLinksWithTag(_tagInputField.text);
        }
        else
        {
            HideRemovedLinks();
        }
        _contentFitterRefresher.Refresh();
    }

    public void OnChangeOfBlockListButtons(in List<BlockLinkButton> blockLinkButtons)
    {
        _blockLinkButtons = blockLinkButtons;
        OnChangeOfInputField();
    }

    private void ShowLinksWithTag(string tag)
    {
        if (_blockLinkButtons != null)
        {
            foreach (BlockLinkButton blockLinkButton in _blockLinkButtons)
            {
                blockLinkButton.gameObject.SetActive(blockLinkButton.TagStartsWithSubstring(tag));
            }
        }
    }

    private void HideRemovedLinks()
    {
        if (_blockLinkButtons != null)
        {
            foreach (BlockLinkButton blockLinkButton in _blockLinkButtons)
            {
                blockLinkButton.gameObject.SetActive(!blockLinkButton.HasTag(TagHandler.RemovedTag));
            }
        }
    }
}