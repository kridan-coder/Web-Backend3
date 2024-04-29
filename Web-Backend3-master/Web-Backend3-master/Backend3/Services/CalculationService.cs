using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend3.Models;

namespace Backend3.Services
{
    public class CalculationService : ICalculationService
    {
        public Int64 Calculate(Int64 num1, Int64 num2, Operation operation)
        {
            switch (operation)
            {
                case Operation.Addition:
                    return Addition(num1, num2);
                case Operation.Substraction:
                    return Substraction(num1, num2);
                case Operation.Multiplication:
                    return Multiplication(num1, num2);
                case Operation.Division:
                    return Division(num1, num2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private Int64 Addition(Int64 num1, Int64 num2)
        {
            return num1 + num2;
        }

        private Int64 Division(Int64 num1, Int64 num2)
        {
            return num1 / num2;
        }

        private Int64 Multiplication(Int64 num1, Int64 num2)
        {
            return num1 * num2;
        }

        private Int64 Substraction(Int64 num1, Int64 num2)
        {
            return num1 - num2;
        }
    }
}
