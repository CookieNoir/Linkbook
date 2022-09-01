public static class URLHelper
{
    public static int GetURLLengthWithoutProtocol(string url)
    {
        int realLength = url.Length;
        if (url.Length >= 7 && string.Equals(url.Substring(0, 7), "http://"))
        {
            realLength -= 7;
        }
        else if (url.Length >= 8 && string.Equals(url.Substring(0, 8), "https://"))
        {
            realLength -= 8;
        }
        return realLength;
    }
}