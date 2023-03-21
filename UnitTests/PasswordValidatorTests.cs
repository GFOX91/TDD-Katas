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
    [InlineData("pass12")]
    [InlineData("passw12")]
    public void Validate_ReturnsInvalid_WhenPasswordLessThen8Characters(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("Password must be at least 8 characters");
    }

    [Theory]
    [InlineData("password")]
    [InlineData("password1")]
    [InlineData("1password")]
    public void Validate_ReturnsInvalid_WhenPasswordDoesntHave2Numbers(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("The password must contain at least 2 numbers");
    }

    [Theory]
    [InlineData("pass1")]
    [InlineData("passw1")]
    public void Validate_HandlesMultipleErrors_WhenMultipleValidationFails(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("Password must be at least 8 characters\nThe password must contain at least 2 numbers");
    }
}
