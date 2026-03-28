namespace SunamoStringSubstring._sunamo.SunamoExceptions;

/// <summary>
/// Provides helper methods for exception message formatting and stack trace inspection.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// Prepends a prefix to an error message if the prefix is not null or whitespace.
    /// </summary>
    /// <param name="prefix">The prefix to prepend, or null/empty for no prefix.</param>
    /// <returns>The formatted prefix followed by ": " or an empty string.</returns>
    internal static string CheckBefore(string prefix)
    {
        return string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix + ": ";
    }

    /// <summary>
    /// Retrieves the type name, method name, and full stack trace text of the calling code.
    /// </summary>
    /// <param name="isFillingAlsoFirstTwo">When true, also extracts the type and method name from the first non-ThrowEx frame.</param>
    /// <returns>A tuple containing type name, method name, and the joined stack trace lines.</returns>
    internal static Tuple<string, string, string> PlaceOfException(
        bool isFillingAlsoFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var index = 0;
        string typeName = string.Empty;
        string methodName = string.Empty;
        for (; index < lines.Count; index++)
        {
            var line = lines[index];
            if (isFillingAlsoFirstTwo)
                if (!line.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(line, out typeName, out methodName);
                    isFillingAlsoFirstTwo = false;
                }
            if (line.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(typeName, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Extracts the type name and method name from a single stack trace line.
    /// </summary>
    /// <param name="stackTraceLine">A single line from a stack trace.</param>
    /// <param name="typeName">The extracted type name.</param>
    /// <param name="methodName">The extracted method name.</param>
    internal static void TypeAndMethodName(string stackTraceLine, out string typeName, out string methodName)
    {
        var afterAt = stackTraceLine.Split("at ")[1].Trim();
        var qualifiedName = afterAt.Split("(")[0];
        var parts = qualifiedName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        typeName = string.Join(".", parts);
    }

    /// <summary>
    /// Returns the name of the calling method at the specified frame depth.
    /// </summary>
    /// <param name="frameDepth">The number of frames to skip in the call stack (default is 1).</param>
    /// <returns>The name of the calling method, or an error message if it cannot be determined.</returns>
    internal static string CallingMethod(int frameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameDepth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    /// <summary>
    /// Formats an argument-out-of-range exception message.
    /// </summary>
    /// <param name="prefix">A prefix identifying the location of the exception.</param>
    /// <param name="parameterName">The name of the parameter that is out of range.</param>
    /// <param name="message">Additional information about the exception.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? ArgumentOutOfRangeException(string prefix, string parameterName, string message)
    {
        return CheckBefore(prefix) + $"{parameterName} is out of range, another info: {message}";
    }
}
