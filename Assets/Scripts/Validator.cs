public static class Validator
{
    public const int MinLength = 1;
    public const int NameLength = 15;
    public const int URLLength = 255;
    public const int TagLength = 15;

    public static bool IsNameValid(string name)
    {
        return (name.Length <= NameLength);
    }

    public static bool IsURLValid(string url)
    {
        int realLength = URLHelper.GetURLLengthWithoutProtocol(url);
        return (realLength < url.Length && realLength >= MinLength && !url.Contains(" ") && realLength <= URLLength);
    }

    public static bool IsTagValid(string tag)
    {
        return (!tag.Contains('#') && tag.Length >= MinLength && tag.Length <= TagLength);
    }
}