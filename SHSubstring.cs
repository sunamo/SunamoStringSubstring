namespace SunamoStringSubstring;

public class SHSubstring
{
    /// <summary>
    /// 1 of 2 method which call just BCL to use everywhere to disable message "IDE0057 Substring can be simplified"
    /// </summary>
    /// <param name="name"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static string SubstringStart(string name, int v1)
    {
        return name.Substring(v1);
    }

    public static string SubstringIfAvailableStart(string name, int v1)
    {
        if (name.Length > v1)
        {
            return name.Substring(v1);
        }

        return name;
    }


    public static string Substring(string sql, int indexFrom, int indexTo, bool returnInputIfInputIsShorterThanA3 = false)
    {
        return Substring(sql, indexFrom, indexTo, new SubstringArgs { returnInputIfInputIsShorterThanA3 = returnInputIfInputIsShorterThanA3 });
    }

    /// <summary>
    ///     Start at 0
    ///     Usage: MethodOfOccuredFromStackTrace
    /// </summary>
    /// <param name="input"></param>
    /// <param name="lenght"></param>
    /// <returns></returns>
    public static string SubstringIfAvailable(string input, int lenght)
    {
        return input.Length > lenght ? input.Substring(0, lenght) : input;
    }

    /// <summary>
    /// 2 of 2 method which call just BCL to use everywhere to disable message "IDE0057 Substring can be simplified"
    /// </summary>
    /// <param name="vr"></param>
    /// <param name="from"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    private static string SubstringLength(string vr, int from, int length)
    {
        if (from < vr.Length)
        {
            if (length < vr.Length)
            {
                return vr.Substring(from, length);
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// POZOR, tato metoda se změnila, nyní automaticky přičítá k indexu od 1
    /// When I want to include delimiter, add to A3 +1
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="p"></param>
    /// <param name="p_3"></param>
    public static string Substring(string sql, int indexFrom, int indexTo, SubstringArgs a = null)
    {
        if (a == null)
        {
            a = SubstringArgs.Instance;
        }

        if (sql == null)
        {
            return null;
        }

        int tl = sql.Length;

        if (indexFrom > indexTo)
        {
            if (a.returnInputIfIndexFromIsLessThanIndexTo)
            {
                return sql;
            }
            else
            {
                ThrowEx.ArgumentOutOfRangeException("indexFrom", "indexFrom is lower than indexTo");
            }
        }

        if (tl > indexFrom)
        {
            if (tl > indexTo)
            {
                return sql.Substring(indexFrom, indexTo - indexFrom);
            }
            else
            {
                if (a.returnInputIfInputIsShorterThanA3)
                {
                    return sql;
                }
            }
        }
        // must return string.Empty, not null, because null cant be save to many of columns in db
        return string.Empty;
    }
}
