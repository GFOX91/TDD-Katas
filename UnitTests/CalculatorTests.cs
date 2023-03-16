﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Katas;

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
}

