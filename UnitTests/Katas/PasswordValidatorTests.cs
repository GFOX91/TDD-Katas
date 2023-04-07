using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TDD_Katas.Katas;

namespace UnitTests.Katas;
public class PasswordValidatorTests
{
    [Theory]
    [InlineData("Pas@12")]
    [InlineData("Pass@12")]
    public void Validate_ReturnsError_WhenPasswordLessThen8Characters(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("Password must be at least 8 characters");
    }

    [Theory]
    [InlineData("P@ssword")]
    [InlineData("P@ssword1")]
    [InlineData("1P@ssword")]
    public void Validate_ReturnsError_WhenPasswordDoesntHave2Numbers(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("The password must contain at least 2 numbers");
    }

    [Theory]
    [InlineData("p@ssword12")]
    [InlineData("p@ssword21")]
    public void Validate_ReturnsError_WhenNoCapitalLetter(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("password must contain at least one capital letter");
    }

    [Theory]
    [InlineData("Password12")]
    [InlineData("Password21")]
    public void Validate_ReturnsError_WhenNoSpecialCharacter(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("password must contain at least one special character");
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
        result.ErrorMessage.Should().Be(
            "Password must be at least 8 characters" +
            "\nThe password must contain at least 2 numbers" +
            "\npassword must contain at least one capital letter" +
            "\npassword must contain at least one special character");
    }
}
