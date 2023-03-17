using System.Globalization;

namespace TDD_Katas;
public class Calculator
{
    private List<string> delimiters = new List<string> { ",", "\n" };

    private string numbersString = "";

    private IEnumerable<int> numbersToBeCalculated = new List<int>();

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
        if (!string.IsNullOrWhiteSpace(calculationString))
        {
            SeperateNumbersAndDelimiters(calculationString);

            ConvertStringOfNumbersToListOfInts();

            ThrowExceptionIfAnyNegativeNumbers();

            RemoveNumbersThatExceed1000();

            return numbersToBeCalculated.Sum();
        }
            
        return 0;  
    }

    private void SeperateNumbersAndDelimiters(string calculationString)
    {
        numbersString = calculationString;

        if (calculationString.StartsWith("//"))
        {
            // splits the input on the delimiter
            var (delimiters, numbers) = SplitDelmitersAndNumbers(numbersString);

            // update numbers string to only include numbers
            numbersString = numbers; 

            ProcessDelimiters(delimiters);
        }
    }

    private(string delimiters, string numbers) SplitDelmitersAndNumbers(string calculationString)
    {
        var splitOnFirstNewLine = calculationString.Split(new char[] { '\n' }, 2);

        return (splitOnFirstNewLine[0].Replace("//", string.Empty), // Remove beggining slashes from delimiters
                splitOnFirstNewLine[1]);
    }

    private void ProcessDelimiters(string delimiters)
    {
        // add a seperator if multiple delimiters
        var splitDelimitersString = delimiters.Replace("][", "]-[");
        // In order to split the delimiters into seperate strings
        var splitDelimiters = splitDelimitersString.Split('-').ToList();

        if (splitDelimiters.Any())
            AddAdditionalDelimiters(splitDelimiters);
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

    private IEnumerable<int> ConvertStringOfNumbersToListOfInts() => 
        numbersToBeCalculated = numbersString
        .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse);

    private void ThrowExceptionIfAnyNegativeNumbers()
    {
        var negativeNumbers = numbersToBeCalculated.Where(x => x < 0).ToArray();

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives are not allowed: {string.Join(",", negativeNumbers)}");
        }
    }

    private void RemoveNumbersThatExceed1000() => numbersToBeCalculated = numbersToBeCalculated.Where(x => x < 1001).ToArray();

}
