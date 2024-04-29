using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend3.Models;
using Backend3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend3.Controllers
{
    public class QuizController : Controller
    {
        private readonly ICalculationService calculationService;
        private readonly IRandomNumberInRangeService numberInRangeService;

        public QuizController(ICalculationService calculationService, IRandomNumberInRangeService randomNumberInRangeService)
        {
            this.calculationService = calculationService;
            this.numberInRangeService = randomNumberInRangeService;
        }

        private Operation randomOperation()
        {
            Array values = Enum.GetValues(typeof(Operation));
            Random random = new Random();
            return (Operation)values.GetValue(random.Next(values.Length));
        }

        private String convertOperationToString(Operation operation)
        {
            switch (operation)
            {
                case Operation.Addition:
                    return "+";
                case Operation.Substraction:
                    return "-";
                case Operation.Multiplication:
                    return "*";
                case Operation.Division:
                    return "/";
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }

        }

        public IActionResult Index()
        {
            var randOperation = randomOperation();
            var model = new QuizViewModel()
            {
                CurrentRandomOperand1 = numberInRangeService.GenerateRandomNumberInRange(1, 777),
                CurrentRandomOperand2 = numberInRangeService.GenerateRandomNumberInRange(1, 666),
                CurrentRandomOperation = randOperation,
                CurrentRandomOperationToShow = convertOperationToString(randOperation)
            };
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(QuizAction action, QuizViewModel model)
        {
            //this.ValidateCounter(model);
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            switch (action)
            {
                case QuizAction.Submit:
                    model.ArithmeticOperations.Add(
                        createArithmeticOperation
                            (
                                model.CurrentRandomOperand1,
                                model.CurrentRandomOperand2,
                                model.CurrentRandomOperation,
                                model.CurrentUserAnswer
                            ));
                    if (model.ArithmeticOperations[model.ArithmeticOperations.Count() - 1].UserAnsweredCorrectly)
                        model.CorrectAnswerCount++;
                    refreshQuiz(model);

                    return this.View(model);
                case QuizAction.Finish:
                    return this.View("Result", model);
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private void refreshQuiz(QuizViewModel model)
        {
            var randOperation = randomOperation();
            model.CurrentRandomOperand1 = numberInRangeService.GenerateRandomNumberInRange(1, 777);
            model.CurrentRandomOperand2 = numberInRangeService.GenerateRandomNumberInRange(1, 666);
            model.CurrentRandomOperation = randOperation;
            model.CurrentRandomOperationToShow = convertOperationToString(randOperation);
            model.CurrentUserAnswer = null;
            this.ModelState.Remove("CurrentUserAnswer");
            this.ModelState.Remove("CorrectAnswerCount");
            this.ModelState.Remove("CurrentRandomOperation");
            this.ModelState.Remove("CurrentRandomOperationToShow");
            this.ModelState.Remove("CurrentRandomOperand1");
            this.ModelState.Remove("CurrentRandomOperand2");
        }

        private QuizArithmeticOperation createArithmeticOperation(Int64 operand1, Int64 operand2, Operation operation, String userAnswer)
        {
            Int64 userIntAnswer;
            Int64 correctAnswer = calculationService.Calculate(operand1, operand2, operation);
            return new QuizArithmeticOperation()
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = operation,
                OperationToShow = convertOperationToString(operation),
                UserAnswer = userAnswer,
                CorrectAnswer = correctAnswer,
                UserAnsweredCorrectly = (Int64.TryParse(userAnswer, out userIntAnswer))
                ? userIntAnswer == correctAnswer : false
            };
        }

        private void ValidateCounter(CounterViewModel model)
        {
            var expectedCount = model.CurrentCount;
            var actualCount = model.Actions.Count(x => x == CounterAction.Increase) - model.Actions.Count(x => x == CounterAction.Decrease);
            if (expectedCount != actualCount)
            {
                this.ModelState.AddModelError("", "Counter state is invalid");
            }
        }
    }
}
