using System.Collections.Generic;

public class FileManager
{
    private IFileIO _fileIO;
    private string _generalFilePath;
    private string _removedFilePath;
    private string _tagsFilePath;

    public FileManager(IFileIO fileIO, string generalFilePath, string removedFilePath)
    {
        _fileIO = fileIO;
        _generalFilePath = generalFilePath;
        _removedFilePath = removedFilePath;
    }

    public FileManager(IFileIO fileIO, string tagsFilePath)
    {
        _fileIO = fileIO;
        _tagsFilePath = tagsFilePath;
    }

    public FileManager(IFileIO fileIO, string generalFilePath, string removedFilePath, string tagsFilePath)
    {
        _fileIO = fileIO;
        _generalFilePath = generalFilePath;
        _removedFilePath = removedFilePath;
        _tagsFilePath = tagsFilePath;
    }

    public void GetBlockLinksFromFiles(BlockLinkHandler blockLinkHandler)
    {
        try
        {
            string[] generalBlockLinks = _fileIO.ReadAllLines(_generalFilePath);
            string[] removedBlockLinks = _fileIO.ReadAllLines(_removedFilePath);
            for (int i = 0; i < generalBlockLinks.Length; ++i)
            {
                int hashPosition = generalBlockLinks[i].IndexOf('#');
                string tag = generalBlockLinks[i].Substring(hashPosition + 1);
                int urlStart = hashPosition - 10;
                while (generalBlockLinks[i][urlStart] != ' ') urlStart--;
                string url = generalBlockLinks[i][(urlStart + 1)..(hashPosition - 1)];
                string name = generalBlockLinks[i].Substring(0, urlStart);
                blockLinkHandler.AddNewBlockLink(name, url, tag);
            }
            for (int i = 0; i < removedBlockLinks.Length; ++i)
            {
                int urlStart = removedBlockLinks[i].LastIndexOf(' ');
                string url = removedBlockLinks[i].Substring(urlStart + 1);
                string name = removedBlockLinks[i].Substring(0, urlStart);
                string tag = TagHandler.RemovedTag;
                blockLinkHandler.AddNewBlockLink(name, url, tag);
            }
        }
        catch
        {
        }
    }

    public void GetTagsFromFile( TagHandler tagHandler)
    {
        try
        {
            string[] tags = _fileIO.ReadAllLines(_tagsFilePath);
            for (int i = 0; i < tags.Length; ++i)
            {
                tagHandler.AddNewTag(tags[i]);
            }
        }
        catch
        {        
        }
    }

    public void WriteBlockLinksToFile(BlockLinkHandler blockLinkHandler)
    {
        int count = blockLinkHandler.Count;
        List<string> generalContents = new List<string>();
        List<string> removedContents = new List<string>();
        for (int i = 0; i < count; ++i)
        {
            if (blockLinkHandler[i].Tag == TagHandler.RemovedTag)
            {
                removedContents.Add(blockLinkHandler[i].Name + ' ' + blockLinkHandler[i].URL);
            }
            else
            {
                generalContents.Add(blockLinkHandler[i].Name + ' ' + blockLinkHandler[i].URL + " #" + blockLinkHandler[i].Tag);
            }
        }
        _fileIO.WriteAllLines(_generalFilePath, generalContents.ToArray());
        _fileIO.WriteAllLines(_removedFilePath, removedContents.ToArray());
    }

    public void WriteTagsToFile(TagHandler tagHandler)
    {
        _fileIO.WriteAllLines(_tagsFilePath, tagHandler.ToArray());
    }
}
