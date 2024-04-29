using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Models
{
    public class QuizViewModel
    {
        public Int64 CurrentRandomOperand1 { get; set; }
        public Int64 CurrentRandomOperand2 { get; set; }
        public Operation CurrentRandomOperation { get; set; }


        public String CurrentRandomOperationToShow { get; set; }
        public String CurrentUserAnswer { get; set; }

        public Int64 CorrectAnswerCount { get; set; }

        public List<QuizArithmeticOperation> ArithmeticOperations { get; set; } = new List<QuizArithmeticOperation>();
    }
}
