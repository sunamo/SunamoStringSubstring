namespace SunamoStringSubstring._public.SunamoArgs;

/// <summary>
/// Represents the substring args type.
/// </summary>
public class SubstringArgs
{
    /// <summary>
    /// The instance.
    /// </summary>
    public static SubstringArgs Instance = new();

    /// <summary>
    /// Gets or sets the is returning input when index from exceeds index to.
    /// </summary>
    public bool IsReturningInputWhenIndexFromExceedsIndexTo { get; set; } = false;

    /// <summary>
    /// Gets or sets the is returning input when shorter than index to.
    /// </summary>
    public bool IsReturningInputWhenShorterThanIndexTo { get; set; } = false;
}
