using TDD_Katas;

namespace UnitTests;

public class CalculatorTests
{
    /// <summary>
    /// 1. The method can take 2 numbers, separated by commas, and will return their sum.
    /// For example “” or “1” or “1,2” as inputs.
    /// </summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void Add_AddsUpToTwoNumbers_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }

    /// <summary>
    /// 1. The method can take any amount of numbers, separated by commas, and will return their sum.
    /// For example “” or “1” or “1,2” as inputs.
    /// </summary>
    [Theory]
    [InlineData("3", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("10,20,30,40,50", 150)]
    public void Add_AddsUpToAnyNumbers_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }

    /// <summary>
    /// 2. For an empty string it will return 0.
    /// </summary>
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Add_ReturnsZero_WhenStringIsNullOrEmpty(string numbers)
    {
        // Arrange 
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(0);
    }

    /// <summary>
    ///  3. Allow the Add method to handle new lines between numbers (instead of commas)
    /// </summary>
    [Theory]
    [InlineData("3", 3)]
    [InlineData("1\n2,3", 6)]
    [InlineData("10\n20,30\n40,50", 150)]
    public void Add_AddsNumbersUsingNewLineDelimiter_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }


    /// <summary>
    /// 4. Support different delimiters:
    /// - To change a delimiter, the beginning of the string will contain a separate 
    ///line that looks like this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” 
    ///should return three where the default delimiter is ‘;’.
    /// </summary>
    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2;4", 7)]
    public void Add_AddsNumbersUsingCustomDelimiter_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }

    /// <summary>
    /// 5. Calling Add with a negative number will throw an exception “negatives not allowed” 
    /// and the negative that was passed. If there are multiple negatives, show all of them 
    /// in the exception message.
    /// </summary>
    [Theory]
    [InlineData("1,2,-1", "-1")]
    [InlineData("//;\n1;-2;-4", "-2,-4")]
    public void Add_ShouldThrowAnException_WhenNegativeNumbersAreUsed(string numbers, string negativeNumbers)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = () => sut.Add(numbers);

        // Assert
        result.Should().Throw<Exception>().WithMessage($"Negatives are not allowed: {negativeNumbers}");
    }

    /// <summary>
    /// 6.Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2
    /// </summary>
    [Theory]
    [InlineData("1001", 0)]
    [InlineData("1\n2,3000", 3)]
    [InlineData("10\n20,30\n40,1002", 100)]
    public void Add_AddsNumbersBiggerThan1000AreIgnored_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }

    /// <summary>
    /// 7. Delimiters can be of any length with the following format: 
    /// “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6
    /// </summary>
    [Theory]
    [InlineData("//[***]\n1***2***3", 6)]
    [InlineData("//[****]\n1****2****4", 7)]
    public void Add_AddsNumbersUsingDelimiterOfAnyLength_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }

    /// <summary>
    /// 8. Allow multiple delimiters like this: “//[delim1][delim2]\n” for example 
    /// “//[*][%]\n1*2%3” should return 6.
    ///     
    /// 9. make sure you can also handle multiple delimiters with length longer than 
    /// one char
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="expected"></param>
    [Theory]
    [InlineData("//[*][%]\n1*2%3", 6)]
    [InlineData("//[*][%]\n1*2%4", 7)]
    [InlineData("//[**][%%]\n1**2%%3", 6)]
    [InlineData("//[**][%%]\n1**2%%4", 7)]
    public void Add_AddsNumbersUsingMultipleDelimiters_WhenStringIsValid(string numbers, int expected)
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(numbers);

        // Assert
        result.Should().Be(expected);
    }
}

