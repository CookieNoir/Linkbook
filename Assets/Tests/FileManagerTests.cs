using NUnit.Framework;

public class FileManagerTests
{
    #region FileIO
    [Test]
    public void ReadAllLines_FileDoesntExist_ReturnLength0()
    {
        IFileIO fileIO = new MockFileIO();
        string path = "test.txt";

        string[] lines = fileIO.ReadAllLines(path);
        int length = lines.Length;

        Assert.AreEqual(0, length);
    }

    [Test]
    public void WriteAllLines_ContentsAreEmpty_ReturnLength0()
    {
        IFileIO fileIO = new MockFileIO();
        string path = "test.txt";
        string[] contents = { };

        fileIO.WriteAllLines(path, contents);
        string[] lines = fileIO.ReadAllLines(path);
        int length = lines.Length;

        Assert.AreEqual(0, length);
    }

    [Test]
    public void WriteAllLines_ContentsAreNotEmpty_ReturnLengthNot0()
    {
        IFileIO fileIO = new MockFileIO();
        string path = "Список ссылок.txt";
        string[] contents = {
            "Test 1 http://link1.org #Tag 1",
            "Test 2 https://link2.org #Tag 2",
        };

        fileIO.WriteAllLines(path, contents);
        string[] lines = fileIO.ReadAllLines(path);
        int length = lines.Length;

        Assert.AreNotEqual(0, length);
    }
    #endregion
    #region FileManager
    [Test]
    public void GetBlockLinksFromFiles_FilesDontExist_ReturnsCount0()
    {
        IFileIO fileIO = new MockFileIO();
        string generalFilePath = "Список ссылок.txt";
        string removedFilePath = "Корзина.txt";
        FileManager fileOperator = new FileManager(fileIO, generalFilePath, removedFilePath);
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();

        fileOperator.GetBlockLinksFromFiles(blockLinkHandler);
        int count = blockLinkHandler.Count;

        Assert.AreEqual(0, count);
    }

    [Test]
    public void GetBlockLinksFromFiles_FilesExist_ReturnsCount3()
    {
        IFileIO fileIO = new MockFileIO();
        string generalFilePath = "Список ссылок.txt";
        string[] generalContents = {
            "Test 1 http://link1.org #Tag 1",
            "Test 2 https://link2.org #Tag 2",
        };
        string removedFilePath = "Корзина.txt";
        string[] removedContents = {
            "Test 3 http://link3.org",
        };
        fileIO.WriteAllLines(generalFilePath, generalContents);
        fileIO.WriteAllLines(removedFilePath, removedContents);
        FileManager fileOperator = new FileManager(fileIO, generalFilePath, removedFilePath);
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();

        fileOperator.GetBlockLinksFromFiles(blockLinkHandler);
        int count = blockLinkHandler.Count;

        Assert.AreEqual(3, count);
    }

    [Test]
    public void GetTagsFromFile_FileDoesntExist_ReturnsCount0()
    {
        IFileIO fileIO = new MockFileIO();
        string tagsFilePath = "Список тегов.txt";
        FileManager fileOperator = new FileManager(fileIO, tagsFilePath);
        TagHandler tagHandler = new TagHandler();

        fileOperator.GetTagsFromFile(tagHandler);
        int count = tagHandler.Count;

        Assert.AreEqual(0, count);
    }

    [Test]
    public void GetTagsFromFile_FileExists_ReturnsCount2()
    {
        IFileIO fileIO = new MockFileIO();
        string tagsFilePath = "Список тегов.txt";
        string[] tagsContents = {
            "Tag 1",
            "Tag 2",
        };
        fileIO.WriteAllLines(tagsFilePath, tagsContents);
        FileManager fileOperator = new FileManager(fileIO, tagsFilePath);
        TagHandler tagHandler = new TagHandler();

        fileOperator.GetTagsFromFile(tagHandler);
        int count = tagHandler.Count;

        Assert.AreEqual(2, count);
    }

    [Test]
    public void WriteBlockLinksToFile_DoesntContainLinks_ReturnsLength0()
    {
        IFileIO fileIO = new MockFileIO();
        string generalFilePath = "Список ссылок.txt";
        string removedFilePath = "Корзина.txt";
        FileManager fileOperator = new FileManager(fileIO, generalFilePath, removedFilePath);
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();

        fileOperator.WriteBlockLinksToFile(blockLinkHandler);
        string[] lines = fileIO.ReadAllLines(generalFilePath);
        int length = lines.Length;

        Assert.AreEqual(0, length);
    }

    [Test]
    public void WriteBlockLinksToFile_ContainsLinkWithGeneralTag_ReturnsLength1()
    {
        IFileIO fileIO = new MockFileIO();
        string generalFilePath = "Список ссылок.txt";
        string removedFilePath = "Корзина.txt";
        FileManager fileOperator = new FileManager(fileIO, generalFilePath, removedFilePath);
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "test";
        string url = "http://test.io";
        string tag = TagHandler.DefaultTag;

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        fileOperator.WriteBlockLinksToFile(blockLinkHandler);
        string[] generalLines = fileIO.ReadAllLines(generalFilePath);
        int length = generalLines.Length;

        Assert.AreEqual(1, length);
    }

    [Test]
    public void WriteBlockLinksToFile_ContainsLinkWithRemovedTag_ReturnsLength1()
    {
        IFileIO fileIO = new MockFileIO();
        string generalFilePath = "Список ссылок.txt";
        string removedFilePath = "Корзина.txt";
        FileManager fileOperator = new FileManager(fileIO, generalFilePath, removedFilePath);
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "test";
        string url = "http://test.io";
        string tag = TagHandler.RemovedTag;

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        fileOperator.WriteBlockLinksToFile(blockLinkHandler);
        string[] removedLines = fileIO.ReadAllLines(removedFilePath);
        int length = removedLines.Length;

        Assert.AreEqual(1, length);
    }

    [Test]
    public void WriteTagsToFile_DoesntContainTags_ReturnsLength0()
    {
        IFileIO fileIO = new MockFileIO();
        string tagsFilePath = "Список тегов.txt";
        FileManager fileOperator = new FileManager(fileIO, tagsFilePath);
        TagHandler tagHandler = new TagHandler();

        fileOperator.WriteTagsToFile(tagHandler);
        string[] tagLines = fileIO.ReadAllLines(tagsFilePath);
        int length = tagLines.Length;

        Assert.AreEqual(0, length);
    }

    [Test]
    public void WriteTagsToFile_ContainsTag_ReturnsLength1()
    {
        IFileIO fileIO = new MockFileIO();
        string tagsFilePath = "Список тегов.txt";
        FileManager fileOperator = new FileManager(fileIO, tagsFilePath);
        TagHandler tagHandler = new TagHandler();
        string tag = "tag";

        tagHandler.AddNewTag(tag);
        fileOperator.WriteTagsToFile(tagHandler);
        string[] tagLines = fileIO.ReadAllLines(tagsFilePath);
        int length = tagLines.Length;

        Assert.AreEqual(1, length);
    }
    #endregion
}