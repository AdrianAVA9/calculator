using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calculator.UI.Core.Api.Responses;
using Calculator.UI.Core.Models;
using Calculator.UI.Core.Api.Validators;
using Calculator.UI.Repositories;
using Calculator.UI.Core.Repositories;

namespace Calculator.UI.Controllers.Api
{
    [ApiController]
    [Route("api/calculators")]
    public class CalculatorController : ControllerBase
    {
        public ICalculatorRepository CalculatorRepository { get; set; }
        public CalculatorController(ICalculatorRepository calculatorRepository)
        {
            CalculatorRepository = calculatorRepository;
        }

        [HttpPost]
        [Route("make-operation")]
        public async Task<IActionResult> MakeOperation([FromBody] OperationValidator operation)
        {
            try
            {
                if (operation == null)
                    BadRequest(new ErrorResponse()
                    {
                        Ok = false,
                        Message = "The Operation is invalid!"
                    });

                var calculator = new BasicCalculator();
                var operationResult = new Operation()
                {
                    FirstNumber = operation.FirstNumber,
                    SecondNumber = operation.SecondNumber,
                    MathOperation = operation.Operation,
                };

                switch (operation.Operation)
                {
                    case "+":
                        operationResult.Result = calculator.Add(operation.FirstNumber, operation.SecondNumber);
                        break;
                    case "-":
                        operationResult.Result = calculator.Subtract(operation.FirstNumber, operation.SecondNumber);
                        break;
                    case "/":
                        operationResult.Result = calculator.Divide(operation.FirstNumber, operation.SecondNumber);
                        break;
                    case "x":
                        operationResult.Result = calculator.Multiply(operation.FirstNumber, operation.SecondNumber);
                        break;
                }

                await CalculatorRepository.AddAsync(operationResult);

                return Ok(new ApiResponse()
                {
                    Ok = true,
                    Message = "The operation was successfully",
                    Data = operationResult
                });
            }
            catch (ArgumentException ex)
            {
                return Ok(new ApiResponse()
                {
                    Ok = false,
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse()
                {
                    Ok = false,
                    Message = ex.Message
                });
            }
        }
    }
}
