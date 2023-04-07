using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Katas;

namespace UnitTests.Katas;
public class FizzBuzzTests
{
    [Theory]
    [InlineData(4, "4")]
    [InlineData(7, "7")]
    [InlineData(8, "8")]
    public void Print_ReturnsNumberAsString(int number, string output)
    {
        // Arrange
        var sut = new FizzBuzz();

        // Act
        var result = sut.print(number);

        // Assert
        result.Should().Be(output);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void Print_ReturnsFizz_WhenNumberMultipleOfThree(int number)
    {
        // Arrange
        var sut = new FizzBuzz();

        // Act
        var result = sut.print(number);

        // Assert
        result.Should().Be("Fizz");
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Print_ReturnsBuzz_WhenNumberMultipleOfFive(int number)
    {
        // Arrange
        var sut = new FizzBuzz();

        // Act
        var result = sut.print(number);

        // Assert
        result.Should().Be("Buzz");
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(60)]
    public void Print_ReturnsFizzzBuzz_WhenNumberMultipleOfThreeAndFive(int number)
    {
        // Arrange
        var sut = new FizzBuzz();

        // Act
        var result = sut.print(number);

        // Assert
        result.Should().Be("FizzBuzz");
    }
}
