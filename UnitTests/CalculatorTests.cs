﻿using TDD_Katas;

namespace UnitTests;

public class CalculatorTests
{
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
}

