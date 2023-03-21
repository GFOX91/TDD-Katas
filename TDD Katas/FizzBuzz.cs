using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TDD_Katas;

/// <summary>
/// 1. Write a “fizzBuzz” method that accepts a number as input and returns it as a String
/// 
/// 2. For multiples of three return “Fizz” instead of the number
/// 
/// 3. For the multiples of five return “Buzz”
/// 
/// 4. For numbers that are multiples of both three and five return “FizzBuzz”.
/// 
//<see cref = "https://tddmanifesto.com/exercises/" />
public class FizzBuzz
{
    public string print(int number)
    {

        if ((number % 3) == 0 && (number % 5) == 0)
        {
            return "FizzBuzz";
        }

        if ((number % 3) == 0)
        {
            return "Fizz";
        }

        if ((number % 5) == 0)
        {
            return "Buzz";
        }

        return number.ToString();
    }
}
