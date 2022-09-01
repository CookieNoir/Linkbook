using NUnit.Framework;

public class EditingBlockLinksTests
{
    [Test]
    public void EditBlockLink_SetSameValues_ReturnsTrue()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        BlockLink blockLink = blockLinkHandler[0];
        bool actual = blockLinkHandler.EditBlockLink(blockLink, blockLink.Name, blockLink.URL, blockLink.Tag);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void EditBlockLink_SetIncorrectURL_ReturnsFalse()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;
        string newUrl = "htp://test";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        BlockLink blockLink = blockLinkHandler[0];
        bool actual = blockLinkHandler.EditBlockLink(blockLink, blockLink.Name, newUrl, blockLink.Tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void EditBlockLink_SetDifferentValues_ReturnsCount1()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;
        string newName = "newName";
        string newUrl = "http://newtesturl.org";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        BlockLink blockLink = blockLinkHandler[0];
        blockLinkHandler.EditBlockLink(blockLink, newName, newUrl, blockLink.Tag);
        int count = blockLinkHandler.Count;

        Assert.AreEqual(1, count);
    }

    [Test]
    public void EditBlockLink_AddLinkWithValuesOfEditedLink_ReturnsFalse()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;
        string newName = "newName";
        string newUrl = "http://newtesturl.org";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        BlockLink blockLink = blockLinkHandler[0];
        blockLinkHandler.EditBlockLink(blockLink, newName, newUrl, blockLink.Tag);
        bool actual = blockLinkHandler.AddNewBlockLink(newName, newUrl, tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void EditBlockLink_AddLinkWithOldValuesOfEditedLink_ReturnsTrue()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name = "";
        string url = "http://testurl.org";
        string tag = TagHandler.DefaultTag;
        string newName = "newName";
        string newUrl = "http://newtesturl.org";

        blockLinkHandler.AddNewBlockLink(name, url, tag);
        BlockLink blockLink = blockLinkHandler[0];
        blockLinkHandler.EditBlockLink(blockLink, newName, newUrl, blockLink.Tag);
        bool actual = blockLinkHandler.AddNewBlockLink(name, url, tag);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void EditBlockLink_BlocksAreSortedByNameInAscendingOrder_ReturnsTrue()
    {
        BlockLinkHandler blockLinkHandler = new BlockLinkHandler();
        string name1 = "b";
        string name2 = "c";
        string name3 = "a";
        string url1 = "http://testurl1.org";
        string url2 = "http://testurl2.org";
        string tag = TagHandler.DefaultTag;

        blockLinkHandler.AddNewBlockLink(name1, url1, tag);
        blockLinkHandler.AddNewBlockLink(name2, url2, tag);
        blockLinkHandler.EditBlockLink(blockLinkHandler[1], name3, url2, tag);
        bool actual = blockLinkHandler[0].Name == name3;

        Assert.AreEqual(true, actual);
    }
}