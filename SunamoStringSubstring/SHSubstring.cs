namespace SunamoStringSubstring;

public class SHSubstring
{
    public static string SubstringStart(string text, int startIndex)
    {
        return text.Substring(startIndex);
    }

    public static string SubstringIfAvailableStart(string text, int startIndex)
    {
        if (text.Length > startIndex) return text.Substring(startIndex);

        return text;
    }

    public static string? Substring(string? text, int indexFrom, int indexTo,
        bool isReturningInputWhenShorterThanIndexTo = false)
    {
        return Substring(text, indexFrom, indexTo,
            new SubstringArgs { IsReturningInputWhenShorterThanIndexTo = isReturningInputWhenShorterThanIndexTo });
    }

    public static string SubstringIfAvailable(string text, int length)
    {
        return text.Length > length ? text.Substring(0, length) : text;
    }

    public static string? Substring(string? text, int indexFrom, int indexTo, SubstringArgs? args = null)
    {
        if (args == null) args = SubstringArgs.Instance;

        if (text == null) return null;

        var textLength = text.Length;

        if (indexFrom > indexTo)
        {
            if (args.IsReturningInputWhenIndexFromExceedsIndexTo)
                return text;
            ThrowEx.ArgumentOutOfRangeException("indexFrom", "indexFrom is lower than indexTo");
        }

        if (textLength > indexFrom)
        {
            if (textLength > indexTo)
            {
                return text.Substring(indexFrom, indexTo - indexFrom);
            }

            if (args.IsReturningInputWhenShorterThanIndexTo) return text;
        }

        return string.Empty;
    }
}
