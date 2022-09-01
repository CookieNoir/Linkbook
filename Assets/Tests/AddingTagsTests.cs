using NUnit.Framework;

public class AddingTagsTests
{
    [Test]
    public void AddNewTag_AddCorrectTag_ReturnsTrue()
    {
        TagHandler tagHandler = new TagHandler();
        string tag = "тестовый тег";

        bool actual = tagHandler.AddNewTag(tag);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void AddNewTag_AddIncorrectTag_ReturnsFalse()
    {
        TagHandler tagHandler = new TagHandler();
        string tag = "#tag";

        bool actual = tagHandler.AddNewTag(tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void AddNewTag_AddDefaultTag_ReturnsFalse()
    {
        TagHandler tagHandler = new TagHandler();
        string tag = TagHandler.DefaultTag;

        bool actual = tagHandler.AddNewTag(tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void AddNewTag_AddRemovedTag_ReturnsFalse()
    {
        TagHandler tagHandler = new TagHandler();
        string tag = TagHandler.RemovedTag;

        bool actual = tagHandler.AddNewTag(tag);

        Assert.AreEqual(false, actual);
    }
}