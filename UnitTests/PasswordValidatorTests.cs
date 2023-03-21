using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TDD_Katas.Katas;

namespace UnitTests;
public class PasswordValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("pass")]
    [InlineData("passwo")]
    public void Validate_ReturnsInvalid_WhenPasswordLessThen8Characters(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("Password must be at least 8 characters");
    }
}
