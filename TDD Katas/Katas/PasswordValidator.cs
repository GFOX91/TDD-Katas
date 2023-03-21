using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
/// </summary>
/// <see cref = "https://tddmanifesto.com/exercises/" />
public class PasswordValidator
{

    public ValidationResult Validate(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            return new ValidationResult("Password must be at least 8 characters");
        }

        return ValidationResult.Success;
    }
}
