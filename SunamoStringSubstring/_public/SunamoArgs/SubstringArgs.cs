namespace SunamoStringSubstring._public.SunamoArgs;

/// <summary>
/// Configuration arguments for substring operations.
/// </summary>
public class SubstringArgs
{
    /// <summary>
    /// Singleton instance with default settings.
    /// </summary>
    public static SubstringArgs Instance = new();

    /// <summary>
    /// When true, returns the original input instead of throwing when indexFrom exceeds indexTo.
    /// </summary>
    public bool IsReturningInputWhenIndexFromExceedsIndexTo { get; set; } = false;

    /// <summary>
    /// When true, returns the original input instead of empty string when input is shorter than indexTo.
    /// </summary>
    public bool IsReturningInputWhenShorterThanIndexTo { get; set; } = false;
}
