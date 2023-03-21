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
//<see cref = "https://tddmanifesto.com/exercises/" />
public class FizzBuzz
{
    public string print(int number)
    {
        return number.ToString();
    }
}
