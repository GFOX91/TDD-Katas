namespace TDD_Katas;
public class Calculator
{
    private List<string> delimiters = new List<string> { ",", "\n" };

    /// <summary>
    /// Create a simple String calculator with a method signature: int Add(string numbers)
    ///     1. The method can any amount of numbers, separated by commas, and will return their sum.
    ///     For example “” or “1” or “1,2” as inputs.
    ///     
    ///     2. For an empty string it will return 0.
    ///     
    ///     3. Allow the Add method to handle new lines between numbers (instead of commas)
    ///     
    ///     4. Support different delimiters:
    ///         - To change a delimiter, the beginning of the string will contain a separate 
    ///         line that looks like this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” 
    ///         should return three where the default delimiter is ‘;’.
    ///         
    ///     5. Calling Add with a negative number will throw an exception “negatives not allowed” 
    ///     and the negative that was passed. If there are multiple negatives, show all of them 
    ///     in the exception message.
    ///     
    ///     6.Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2
    ///     
    ///     7. Delimiters can be of any length with the following format: 
    ///     “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6
    ///     
    ///     8. Allow multiple delimiters like this: “//[delim1][delim2]\n” for example 
    ///     “//[*][%]\n1*2%3” should return 6.
    ///     
    ///     9. make sure you can also handle multiple delimiters with length longer than 
    ///     one char
    /// </summary>
    /// <see cref="https://osherove.com/tdd-kata-1/"/>
    public object Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        if (numbers.StartsWith("//"))
            numbers = ProcessAdditionalDelimiters(numbers);

        SplitStringIntoNumbersList(numbers, delimiters, out var splitNumbers);

        ThrowExceptionIfAnyNegatives(splitNumbers);

        splitNumbers = splitNumbers.Where(x => x < 1001).ToArray();

        return splitNumbers.Sum();
    }

    private string ProcessAdditionalDelimiters(string numbers)
    {
        var splitOnFirstNewLine = numbers.Split(new char[] { '\n' }, 2); // splits the input on the delimiter
        var customDelimitersString = splitOnFirstNewLine[0].Replace("//", string.Empty); // Grabs the custom delimiter(s)

        var splitDelimitersString = customDelimitersString.Replace("][", "]-["); // add a seperator between delimiters
        var splitDelimiters = splitDelimitersString.Split('-').ToList(); // so that we can split the delimiters into seperate strings

        numbers = splitOnFirstNewLine[1]; // mutate the incoming string to just get the numbers

        AddAdditionalProccessedDelimiters(splitDelimiters);

        return numbers;
    }

    private void AddAdditionalProccessedDelimiters(List<string> processedDelimiters)
    {
        foreach (var delimiter in processedDelimiters)
        {
            var delmitorToAdd = delimiter;

            // Remove square brackest from delimiter
            if (delimiter.StartsWith('[') && delimiter.EndsWith(']'))
                delmitorToAdd = delimiter.Split('[', ']')[1];

            // and add it to the delimiter list
            delimiters.Add(delmitorToAdd); 
        }
    }

    private IEnumerable<int> SplitStringIntoNumbersList(string numbers, List<string> delimiters, out IEnumerable<int> splitNumbers) => 
        splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse);

    private void ThrowExceptionIfAnyNegatives(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0).ToArray();

        // If any are found, throw an exception
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives are not allowed: {string.Join(",", negativeNumbers)}");
        }
    }

}
