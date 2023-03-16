namespace TDD_Katas;
public class Calculator
{
    /// <summary>
    /// Create a simple String calculator with a method signature: int Add(string numbers)
    ///     - The method can take up to two numbers, separated by commas, and will return their sum.
    ///     - For example “” or “1” or “1,2” as inputs.
    ///     - For an empty string it will return 0.
    /// </summary>
    public object Add(string numbers)
    {
        var splitNumbers = numbers.Split(',');

        if (!splitNumbers.Any())
        {
            return 0;
        }

        if (splitNumbers.Length == 1)
        {
            if (splitNumbers[0].Length == 0)
            {
                return 0;
            }
            return int.Parse(splitNumbers[0]);
        }

        return int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);
    }
}
