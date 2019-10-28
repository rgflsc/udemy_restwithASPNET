using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Secao06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/Calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}", Name = "Sum")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
    
            return BadRequest("Invalid imput");
        }

        // GET: api/Calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}", Name = "Subtraction")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid imput");
        }

        // GET: api/Calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}", Name = "Division")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid imput");
        }

        // GET: api/Calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}", Name = "Multiplication")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid imput");
        }

        // GET: api/Calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}", Name = "Mean")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid imput");
        }

        // GET: api/Calculator/square-root/5
        [HttpGet("square-root/{number}", Name = "SquareRoot")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareroot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareroot.ToString());
            }

            return BadRequest("Invalid imput");
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;

            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string value)
        {
            double number;

            bool isNumber = double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
