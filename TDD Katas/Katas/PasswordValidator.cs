﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TDD_Katas.Katas;

/// <summary>
/// Create a function that can be used as a validator for the password field of a user registration form. 
/// The validation function takes a string as an input and returns a validation result. 
/// The validation result should contain a boolean indicating if the password is valid or not, 
/// and also a field with the possible validation errors.
/// 
/// Requirements
/// 1. The password must be at least 8 characters long. If it is not met, 
/// then the following error message should be returned: “Password must be at least 8 characters”
/// 
/// 2. The password must contain at least 2 numbers. If it is not met, 
/// then the following error message should be returned: “The password must contain at least 2 numbers”
/// 
/// 3. The validation function should handle multiple validation errors.For example, “somepassword” 
/// should an error message: “Password must be at least 8 characters\nThe password must contain at least 2 numbers”
/// 
/// 4. The password must contain at least one capital letter. If it is not met, then the following error message 
/// should be returned: “password must contain at least one capital letter”
/// </summary>
/// <see cref = "https://tddmanifesto.com/exercises/" />
public class PasswordValidator
{

    public ValidationResult Validate(string password)
    {
        var validationErrors = ReturnValidationErrors(password);

        ProcessValidationErrors(validationErrors, out var errorMessage);

        if (!string.IsNullOrEmpty(errorMessage)) 
        {
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }

    private List<string> ReturnValidationErrors(string password)
    {
        var validationErrors = new List<string>();

        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            validationErrors.Add("Password must be at least 8 characters");
        }

        if (PasswordHasLessThan2Numbers(password))
        {
            validationErrors.Add("The password must contain at least 2 numbers");
        }

        if (PasswordHasNoCapitals(password))
        {
            validationErrors.Add("password must contain at least one capital letter");
        }

        if (PasswordHasNoSpecialCharacters(password))
        {
            validationErrors.Add("password must contain at least one special character");
        }

        return validationErrors;
    }

    private bool PasswordHasLessThan2Numbers(string password) => !Regex.IsMatch(password, "\\d.*?\\d");
    private bool PasswordHasNoCapitals(string password) => !password.Any(c => char.IsUpper(c));
    private bool PasswordHasNoSpecialCharacters(string password) => Regex.IsMatch(password, "^[a-zA-Z0-9\x20]+$");

    private string ProcessValidationErrors(List<string> validationErrors, out string errorMessage)
    {
        errorMessage = "";

        if (validationErrors.Any())
        {
            for (int i = 0; i < validationErrors.Count; i++)
            {
                if (i > 0)
                {
                    errorMessage += "\n";
                }

                errorMessage += validationErrors[i];
            }
        }

        return errorMessage;
    }
}
