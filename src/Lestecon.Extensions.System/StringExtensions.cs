namespace System;

public static class StringExtensions
{
    public static string TrimEnd(this string source, string value, StringComparison comparisonType)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(value);

        int sourceLength = source.Length;
        int valueLength = value.Length;
        int count = sourceLength;

        while (source.LastIndexOf(value, count, comparisonType) == count - valueLength)
        {
            count -= valueLength;
        }

        return source[..count];
    }

    public static string TrimStart(this string source, string value, StringComparison comparisonType)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(value);

        int valueLength = value.Length;
        int startIndex = 0;

        while (source.IndexOf(value, startIndex, comparisonType) == startIndex)
        {
            startIndex += valueLength;
        }

        return source[startIndex..];
    }
}
