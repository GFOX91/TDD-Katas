﻿using System;
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
    [InlineData("Pass12")]
    [InlineData("Passw12")]
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
    [InlineData("Password")]
    [InlineData("Password1")]
    [InlineData("1Password")]
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
    [InlineData("password12")]
    [InlineData("password21")]
    public void Validate_ReturnsInvalid_WhenNoCapitalLetter(string password)
    {
        // arrange
        var sut = new PasswordValidator();

        // act
        var result = sut.Validate(password);

        // assert
        result.ErrorMessage.Should().Be("password must contain at least one capital letter");
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
            "\npassword must contain at least one capital letter");
    }
}
