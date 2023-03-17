namespace TDD_Katas;
public class Calculator
{
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
        var delimiters = new List<string> { ",", "\n" };

        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        #region Process Delimiters 

        if (numbers.StartsWith("//"))
        {
            var splitOnFirstNewLine = numbers.Split(new char[] { '\n' }, 2); // splits the input on the delimiter
            var customDelimitersString = splitOnFirstNewLine[0].Replace("//", string.Empty); // Grabs the custom delimiter(s)

            var splitDelimitersString = customDelimitersString.Replace("][", "]-["); // add a seperator between delimiters
            var splitDelimiters = splitDelimitersString.Split('-'); // so that we can split the delimiters into seperate strings

            foreach (var delimiter in splitDelimiters)
            {
                var delmitorToAdd = delimiter;
                if (delimiter.StartsWith('[') && delimiter.EndsWith(']'))
                {
                    delmitorToAdd = delimiter.Split('[', ']')[1]; // extract customer delimiter from square brackets
                }

                delimiters.Add(delmitorToAdd); // and add it to the delimiter list
                numbers = splitOnFirstNewLine[1]; // mutate the incoming string to just get the numbers
            }
        }

        #endregion

        #region SplitNumbers

        var splitNumbers = SplitStringIntoNumbersList(numbers, delimiters);

        #endregion

        #region Check for negatives

        var negativeNumbers = splitNumbers.Where(x => x < 0).ToArray();

        // If any are found, throw an exception
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives are not allowed: {string.Join(",", negativeNumbers)}");
        }

        #endregion

        #region Remove numbers greater then 1000
        // Remove numbers bigger then 1000
        splitNumbers = splitNumbers.Where(x => x < 1001).ToArray();
        #endregion


        return splitNumbers.Sum();
    }

    private IEnumerable<int> SplitStringIntoNumbersList(string numbers, List<string> delimiters) => 
        numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse);

}
