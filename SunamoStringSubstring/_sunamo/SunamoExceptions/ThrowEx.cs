namespace SunamoStringSubstring._sunamo.SunamoExceptions;

/// <summary>
/// Provides methods for throwing formatted exceptions with detailed context information.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> with the specified argument name and optional message.
    /// </summary>
    /// <param name="argumentName">The name of the argument that is out of range.</param>
    /// <param name="message">An optional message describing the error.</param>
    /// <returns>True if the exception message was not null.</returns>
    internal static bool ArgumentOutOfRangeException(string argumentName, string message = "")
    { return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argumentName, message)); }

    /// <summary>
    /// Returns the fully qualified name (type.method) of the code that is currently executing.
    /// </summary>
    /// <returns>A string in the format "TypeFullName.MethodName".</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Returns the fully qualified name (type.method) from the given type and method name.
    /// </summary>
    /// <param name="type">The type object, which can be a <see cref="Type"/>, <see cref="MethodBase"/>, string, or any object.</param>
    /// <param name="methodName">The method name, or null to determine it from the call stack.</param>
    /// <param name="isFromThrowEx">When true, adjusts the stack frame depth to account for the ThrowEx call chain.</param>
    /// <returns>A string in the format "TypeFullName.MethodName".</returns>
    private static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type typeValue)
        {
            typeFullName = typeValue.FullName ?? "Type cannot be get via type is Type type2";
        }
        else if (type is MethodBase methodBase)
        {
            typeFullName = methodBase.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = methodBase.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type objectType = type.GetType();
            typeFullName = objectType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception message is not null.
    /// </summary>
    /// <param name="exceptionMessage">The exception message to evaluate.</param>
    /// <param name="isReallyThrowing">When true, actually throws the exception; when false, only returns whether it would have thrown.</param>
    /// <returns>True if the exception message was not null; false otherwise.</returns>
    internal static bool ThrowIsNotNull(string? exceptionMessage, bool isReallyThrowing = true)
    {
        if (exceptionMessage != null)
        {
            Debugger.Break();
            if (isReallyThrowing)
            {
                throw new Exception(exceptionMessage);
            }
            return true;
        }
        return false;
    }
}
