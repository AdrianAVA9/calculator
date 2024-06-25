using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calculator.UI.Core.Models.Api;
using Calculator.UI.Core.Validators;
using Calculator.UI.Core.Models;

namespace Calculator.UI.Controllers.Api
{
    [ApiController]
    [Route("api/calculators")]
    public class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("make-operation")]
        public IActionResult MakeOperation([FromBody] OperationValidator operation)
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
                var result = 0M;

                var apiResponse = new ApiResponse()
                {
                    Ok = true,
                    Message = "The operation was successfully",
                    Result = 0
                };

                switch (operation.Operation)
                {
                    case "+":
                        result = calculator.Add(operation.FirstNumber, operation.SecondNumber);
                        break;
                    case "-":
                        result = calculator.Subtract(operation.FirstNumber, operation.SecondNumber);
                        break;
                    case "/":
                        try
                        {
                            result = calculator.Divide(operation.FirstNumber, operation.SecondNumber);
                        }
                        catch (Exception ex)
                        {
                            apiResponse.Ok = false;
                            apiResponse.Message = ex.Message;
                        }
                        break;
                    case "x":
                        result = calculator.Multiply(operation.FirstNumber, operation.SecondNumber);
                        break;
                }

                apiResponse.Result = result;

                return Ok(apiResponse);
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
