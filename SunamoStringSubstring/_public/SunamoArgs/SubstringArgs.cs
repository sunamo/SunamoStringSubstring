namespace SunamoStringSubstring._public.SunamoArgs;

public class SubstringArgs
{
    public static SubstringArgs Instance = new();

    public bool IsReturningInputWhenIndexFromExceedsIndexTo { get; set; } = false;

    public bool IsReturningInputWhenShorterThanIndexTo { get; set; } = false;
}
