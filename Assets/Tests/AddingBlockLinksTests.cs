using NUnit.Framework;

public class AddingBlockLinksTests
{
    [Test]
    public void AddNewBlockLink_AddToEmptyContainerWithCorrectValues_ReturnsCount1()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "Test";
        string url = "http://testurl.org";
        string tag = "без категории";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        int count = blockLinkHandler.Count;

        Assert.AreEqual(1, count);
    }

    [Test]
    public void AddNewBlockLink_AddWithIncorrectURLToEmptyContainer_ReturnsFalse()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "name";
        string url = "ht//testurl";
        string tag = "без категории";

        bool actual = blockLinkHandler.AddNewBlockLink(name, url, tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void AddNewBlockLink_AddWithoutNameToEmptyContainer_ReturnsName()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = "без категории";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        name = blockLinkHandler[0].Name;

        Assert.AreEqual("testurl.org", name);
    }

    [Test]
    public void AddNewBlockLink_AddWithLongNameToEmptyContainer_ReturnsFalse()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "Too Long Name For This App";
        string url = "http://testurl.org";
        string tag = "без категории";

        bool actual = blockLinkHandler.AddNewBlockLink(name, url, tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void AddUniqueNameAndURL_AddUniqueValues_ReturnsTrue()
    {
        UniqueDataCollection uniqueData = new UniqueDataCollection();
        string name = "name";
        string url = "https://testurl.org";

        bool actual = uniqueData.AddUniqueNameAndURL(name, url);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void AddUniqueNameAndURL_AddSameValuesTwice_ReturnsFalse()
    {
        UniqueDataCollection uniqueData = new UniqueDataCollection();
        string name = "name";
        string url = "https://testurl.org";

        uniqueData.AddUniqueNameAndURL(name, url);
        bool actual = uniqueData.AddUniqueNameAndURL(name, url);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void AddNewBlockLink_AddTheSameBlock_ReturnsCount1()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        blockLinkHandler.AddNewBlockLink(name, url, tag);
        int count = blockLinkHandler.Count;

        Assert.AreEqual(1, count);
    }

    [Test]
    public void AddNewBlockLink_BlocksAreSortedByNameInAscendingOrder_ReturnsTrue()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name1 = "a";
        string name2 = "b";
        string url1 = "http://testurl1.org";
        string url2 = "http://testurl2.org";
        string tag = TagHandler.DefaultTag;

        blockLinkHandler.AddNewBlockLink(name2, url2, tag);
        blockLinkHandler.AddNewBlockLink(name1, url1, tag);
        bool actual = blockLinkHandler[0].Name == name1;

        Assert.AreEqual(true, actual);
    }
}