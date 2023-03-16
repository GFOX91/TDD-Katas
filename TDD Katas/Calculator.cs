namespace TDD_Katas;
public class Calculator
{
    /// <summary>
    /// Create a simple String calculator with a method signature: int Add(string numbers)
    ///     - The method can any amount of numbers, separated by commas, and will return their sum.
    ///     - For example “” or “1” or “1,2” as inputs.
    ///     - For an empty string it will return 0.
    ///     - Allow the Add method to handle new lines between numbers (instead of commas)
    /// </summary>
    public object Add(string numbers)
    {
        var delmiters = new char[] {',', '\n'};

        var splitNumbers = numbers
            .Split(delmiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        return splitNumbers.Sum();
    }
}
