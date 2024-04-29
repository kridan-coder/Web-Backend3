using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Models
{
    public class QuizArithmeticOperation
    {
        public Int64 Operand1 { get; set; }
        public Int64 Operand2 { get; set; }
        public Operation Operation { get; set; }

        public String OperationToShow { get; set; }

        public String UserAnswer { get; set; }
        public Int64 CorrectAnswer { get; set; }

        public bool UserAnsweredCorrectly { get; set; }
    }
}
