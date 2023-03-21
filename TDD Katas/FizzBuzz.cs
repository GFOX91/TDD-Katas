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
//<see cref = "https://tddmanifesto.com/exercises/" />
public class FizzBuzz
{
    public string print(int number)
    {
        if ((number % 3) == 0)
        {
            return "Fizz";
        }

        return number.ToString();
    }
}
