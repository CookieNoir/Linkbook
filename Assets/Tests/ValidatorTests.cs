using NUnit.Framework;

public class ValidatorTests
{
    [Test]
    public void IsNameValid_MoreThan15Characters_ReturnsFalse()
    {
        string name = "Too Long Name For This App";

        bool actual = Validator.IsNameValid(name);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsNameValid_LEqualThan15Characters_ReturnsTrue()
    {
        string name = "Simple Name";

        bool actual = Validator.IsNameValid(name);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void IsURLValid_ContainsHttpOrHttpsInTheBeginning_ReturnsFalse()
    {
        string url = "qwer.ty";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsURLValid_ContainsHttpInTheBeginning_ReturnsTrue()
    {
        string url = "http://test.org";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void IsURLValid_ContainsHttpsInTheBeginning_ReturnsTrue()
    {
        string url = "https://test.org";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(true, actual);
    }

    [Test]
    public void IsURLValid_LessThan1CharacterAfterProtocol_ReturnsFalse()
    {
        string url = "https://";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsURLValid_ContainsSpace_ReturnsFalse()
    {
        string url = "https://test .er";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsURLValid_MoreThan255CharactersAfterProtocol_ReturnsFalse()
    {
        string url = "https://wwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAAwwwwwAAAAA.de";

        bool actual = Validator.IsURLValid(url);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsTagValid_ContatinsHash_ReturnsFalse()
    {
        string tag = "#tag";

        bool actual = Validator.IsTagValid(tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsTagValid_LessThan1Character_ReturnsFalse()
    {
        string tag = "";

        bool actual = Validator.IsTagValid(tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsTagValid_MoreThan15Characters_ReturnsFalse()
    {
        string tag = "TooLong Tag For This App";

        bool actual = Validator.IsTagValid(tag);

        Assert.AreEqual(false, actual);
    }

    [Test]
    public void IsTagValid_CorrectTag_ReturnsTrue()
    {
        string tag = "Simple Tag";

        bool actual = Validator.IsTagValid(tag);

        Assert.AreEqual(true, actual);
    }
}