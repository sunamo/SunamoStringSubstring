namespace SunamoStringSubstring;

/// <summary>
/// Provides helper methods for safe substring operations that suppress IDE0057 analyzer messages.
/// </summary>
public class SHSubstring
{
    /// <summary>
    /// Returns a substring starting from the specified index to the end of the string.
    /// One of two methods that call BCL directly to suppress IDE0057 "Substring can be simplified" message.
    /// </summary>
    /// <param name="text">The source string to extract a substring from.</param>
    /// <param name="startIndex">The zero-based starting character position.</param>
    /// <returns>A substring starting at <paramref name="startIndex"/>.</returns>
    public static string SubstringStart(string text, int startIndex)
    {
        return text.Substring(startIndex);
    }

    /// <summary>
    /// Returns a substring starting from the specified index if the string is long enough; otherwise returns the original string.
    /// </summary>
    /// <param name="text">The source string to extract a substring from.</param>
    /// <param name="startIndex">The zero-based starting character position.</param>
    /// <returns>A substring starting at <paramref name="startIndex"/> if available; otherwise the original <paramref name="text"/>.</returns>
    public static string SubstringIfAvailableStart(string text, int startIndex)
    {
        if (text.Length > startIndex) return text.Substring(startIndex);

        return text;
    }

    /// <summary>
    /// Returns a substring between the specified indices with an option to return input if it is shorter than indexTo.
    /// </summary>
    /// <param name="text">The source string to extract a substring from.</param>
    /// <param name="indexFrom">The zero-based starting index.</param>
    /// <param name="indexTo">The zero-based ending index (exclusive).</param>
    /// <param name="isReturningInputWhenShorterThanIndexTo">When true, returns the original input if it is shorter than <paramref name="indexTo"/>.</param>
    /// <returns>The extracted substring, the original input, null if input is null, or an empty string depending on conditions.</returns>
    public static string? Substring(string? text, int indexFrom, int indexTo,
        bool isReturningInputWhenShorterThanIndexTo = false)
    {
        return Substring(text, indexFrom, indexTo,
            new SubstringArgs { IsReturningInputWhenShorterThanIndexTo = isReturningInputWhenShorterThanIndexTo });
    }

    /// <summary>
    /// Returns a substring of the specified length from the beginning if the string is long enough; otherwise returns the original string.
    /// </summary>
    /// <param name="text">The source string.</param>
    /// <param name="length">The maximum number of characters to return from the start.</param>
    /// <returns>A substring of the specified <paramref name="length"/> if available; otherwise the original <paramref name="text"/>.</returns>
    public static string SubstringIfAvailable(string text, int length)
    {
        return text.Length > length ? text.Substring(0, length) : text;
    }

    /// <summary>
    /// Returns a substring between the specified indices with configurable behavior via <see cref="SubstringArgs"/>.
    /// Automatically handles edge cases such as out-of-range indices.
    /// </summary>
    /// <param name="text">The source string to extract a substring from.</param>
    /// <param name="indexFrom">The zero-based starting index.</param>
    /// <param name="indexTo">The zero-based ending index (exclusive).</param>
    /// <param name="args">Optional configuration arguments controlling edge-case behavior.</param>
    /// <returns>The extracted substring, the original input, null if input is null, or an empty string depending on conditions and <paramref name="args"/>.</returns>
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
