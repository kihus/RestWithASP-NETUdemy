using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASP_NETUdemy.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{

		private readonly ILogger<PersonController> _logger;

		public PersonController(ILogger<PersonController> logger)
		{
			_logger = logger;
		}
		// Sum
		[HttpGet("sum/{firstNumber}/{secondNumber}")]
		public IActionResult GetSum(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);
				var num2 = ConvertToDecimal(secondNumber);

				var sum = num1 + num2;
				return Ok(sum.ToString());
			}
			return BadRequest("Invalid Input");
		}

		// Subtraction
		[HttpGet("sub/{firstNumber}/{secondNumber}")]
		public IActionResult GetSub(string firstNumber, string secondNumber)
		{
			if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);
				var num2 = ConvertToDecimal(secondNumber);

				var sub = num1 - num2;
				return Ok(sub.ToString());
			}
			return BadRequest("Invalid Input");
		}

		// Multiplication
		[HttpGet("mult/{firstNumber}/{secondNumber}")]
		public IActionResult GetMult(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);
				var num2 = ConvertToDecimal(secondNumber);

				var mult = num1 * num2;

				return Ok(mult.ToString());
			}
			return BadRequest("Invalid Input");
		}

		// Division
		[HttpGet("div/{firstNumber}/{secondNumber}")]
		public IActionResult GetDiv(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);
				var num2 = ConvertToDecimal(secondNumber);

				var div = num1 > num2
					? num1 / num2
					: num2 / num1;

				return Ok(div.ToString());
			}
			return BadRequest("Invalid Input");
		}

		// Avarage
		[HttpGet("avg/{firstNumber}/{secondNumber}/{thirdNumber}")]
		public IActionResult GetAvg(string firstNumber, string secondNumber, string thirdNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);
				var num2 = ConvertToDecimal(secondNumber);
				var num3 = ConvertToDecimal(thirdNumber);

				var avg = (num1 + num2 + num3)/3;

				return Ok(avg.ToString());
			}
			return BadRequest("Invalid Input");
		}

		// Square root
		[HttpGet("sqrt/{firstNumber}")]
		public IActionResult GetSqrt(string firstNumber)
		{
			if (IsNumeric(firstNumber))
			{
				var num1 = ConvertToDecimal(firstNumber);

				var sqrt = Math.Sqrt((double) num1);

				return Ok(sqrt.ToString());
			}
			return BadRequest("Invalid Input");
		}



		private bool IsNumeric(string strNumber)
		{ 
			bool isNumber = double.TryParse(strNumber, CultureInfo.InvariantCulture, result: out _);
			return isNumber;
		}

		private decimal ConvertToDecimal(string num1)
		{
			if (!decimal.TryParse(num1, out var decimalValue))
			{
				return 0;
			}
			return decimalValue;
		}

	}
}
