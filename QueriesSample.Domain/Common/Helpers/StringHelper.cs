namespace QueriesSample.Domain.Common.Helpers;

public static class StringHelper
{
    public static bool IsEmpty(this string text)
        => string.IsNullOrEmpty(text)
        || string.IsNullOrWhiteSpace(text);

    public static bool HasUpperCase(this string text)
        => text.Any(char.IsUpper);

    public static bool HasLowerCase(this string text)
        => text.Any(char.IsLower);
    public static bool HasNumber(this string text)
        => text.Any(char.IsNumber);
    public static bool HasPunctuation(string text)
        => text.Any(char.IsPunctuation);

    public static bool HasSymbol(this string text)
        => text.Any(char.IsSymbol);

    public static bool HasSeparator(this string text)
        => text.Any(char.IsSeparator);

    public static bool HasSpecialChar(this string text)
        => HasPunctuation(text)
        || HasSymbol(text)
        || HasSeparator(text);
}