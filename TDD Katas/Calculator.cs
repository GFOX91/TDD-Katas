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
    public object Add(string calculationString)
    {
        if (string.IsNullOrWhiteSpace(calculationString))
            return 0;

        ProcessAnyAdditionalDelimiters(calculationString, out string numbersToBeCalculatedString);

        ConvertStringOfNumbersToListOfInts(numbersToBeCalculatedString, delimiters, out var numbersList);

        ThrowExceptionIfAnyNegatives(numbersList);

        numbersList = numbersList.Where(x => x < 1001).ToArray();

        return numbersList.Sum();
    }

    private string ProcessAnyAdditionalDelimiters(string calculationString, out string numbersToBeCalculated)
    {
        numbersToBeCalculated = calculationString;

        if (calculationString.StartsWith("//"))
        {
            // splits the input on the delimiter
            var splitOnFirstNewLine = calculationString.Split(new char[] { '\n' }, 2);

            // Grabs the custom delimiter(s)
            var customDelimitersString = splitOnFirstNewLine[0].Replace("//", string.Empty);

            // add a seperator if multiple delimiters
            var splitDelimitersString = customDelimitersString.Replace("][", "]-[");
            // In order to split the delimiters into seperate strings
            var splitDelimiters = splitDelimitersString.Split('-').ToList();

            numbersToBeCalculated = splitOnFirstNewLine[1]; // mutate the incoming string to just get the numbers

            if (splitDelimiters.Any())
                AddAdditionalDelimiters(splitDelimiters);
        }
      
        return numbersToBeCalculated;
    }

    private void AddAdditionalDelimiters(List<string> processedDelimiters)
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

    private IEnumerable<int> ConvertStringOfNumbersToListOfInts(string numbers, List<string> delimiters, out IEnumerable<int> numbersList) => 
        numbersList = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
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
