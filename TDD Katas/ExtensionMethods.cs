namespace TDD_Katas;
public static class ExtensionMethods
{
    public static bool IsSurroundedBySquareBrackets(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        return str.StartsWith('[') && str.EndsWith(']');
    }
}
