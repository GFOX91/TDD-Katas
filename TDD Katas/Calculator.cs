namespace TDD_Katas;
public class Calculator
{
    /// <summary>
    /// Create a simple String calculator with a method signature: int Add(string numbers)
    ///     1. The method can any amount of numbers, separated by commas, and will return their sum.
    ///     For example “” or “1” or “1,2” as inputs.
    ///     2.For an empty string it will return 0.
    ///     3.Allow the Add method to handle new lines between numbers (instead of commas)
    ///     4. Support different delimiters:
    ///         - To change a delimiter, the beginning of the string will contain a separate 
    ///         line that looks like this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” 
    ///         should return three where the default delimiter is ‘;’.
    /// </summary>
    public object Add(string numbers)
    {
        var delmiters = new List<char> {',', '\n'};

        if (numbers.StartsWith("//"))
        {
            var splitOnFirstNewLine = numbers.Split(new char[] { '\n' }, 2); // splits the input on the delimiter
            var customDelimiter = splitOnFirstNewLine[0].Replace("//", string.Empty).Single(); // Grabs the custom delimiter
            delmiters.Add(customDelimiter); // and add it to the delimiter list
            numbers = splitOnFirstNewLine[1]; // mutate the incoming string to just get the numbers
        }

        var splitNumbers = numbers
            .Split(delmiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        return splitNumbers.Sum();
    }
}
