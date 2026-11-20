namespace SunamoStringSubstring;

/// <summary>
/// Represents the SH substring type.
/// </summary>
public class SHSubstring
{
    /// <summary>
    /// Substring start.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="startIndex">The start index.</param>
    /// <returns>The substring start result.</returns>
    public static string SubstringStart(string text, int startIndex)
    {
        return text.Substring(startIndex);
    }

    /// <summary>
    /// Substring if available start.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="startIndex">The start index.</param>
    /// <returns>The substring if available start result.</returns>
    public static string SubstringIfAvailableStart(string text, int startIndex)
    {
        if (text.Length > startIndex) return text.Substring(startIndex);

        return text;
    }

    /// <summary>
    /// Substring.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="indexFrom">The index from.</param>
    /// <param name="indexTo">The index to.</param>
    /// <param name="isReturningInputWhenShorterThanIndexTo">The is returning input when shorter than index to.</param>
    /// <returns>The substring result.</returns>
    public static string? Substring(string? text, int indexFrom, int indexTo,
        bool isReturningInputWhenShorterThanIndexTo = false)
    {
        return Substring(text, indexFrom, indexTo,
            new SubstringArgs { IsReturningInputWhenShorterThanIndexTo = isReturningInputWhenShorterThanIndexTo });
    }

    /// <summary>
    /// Substring if available.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="length">The length.</param>
    /// <returns>The substring if available result.</returns>
    public static string SubstringIfAvailable(string text, int length)
    {
        return text.Length > length ? text.Substring(0, length) : text;
    }

    /// <summary>
    /// Substring.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="indexFrom">The index from.</param>
    /// <param name="indexTo">The index to.</param>
    /// <param name="args">The args.</param>
    /// <returns>The substring result.</returns>
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
