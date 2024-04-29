using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend3.Models;

namespace Backend3.Services
{
    public interface ICalculationService
    {
        Int64 Calculate(Int64 num1, Int64 num2, Operation operation);

/*        Int64 Addition(Int64 num1, Int64 num2);

        Int64 Substraction(Int64 num1, Int64 num2);

        Int64 Division(Int64 num1, Int64 num2);

        Int64 Multiplication(Int64 num1, Int64 num2);*/
    }
}
