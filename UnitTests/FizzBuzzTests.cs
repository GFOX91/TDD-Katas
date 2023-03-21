using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Katas;

namespace UnitTests;
public class FizzBuzzTests
{
    [Theory]
    [InlineData(3, "3")]
    [InlineData(5, "5")]
    [InlineData(7, "7")]
    public void Print_ReturnsNumberAsString(int number, string output)
    {
        // Arrange
        var sut = new FizzBuzz();

        // Act
        var result = sut.print(number);

        // Assert
        result.Should().Be(output);
    }
}
