using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Logics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorAPIController : ControllerBase
    {

        private readonly ILogger<CalculatorAPIController> _logger;

        readonly IMathUtilities mathUtilities;
        readonly IDataConverter dataConverter;

        public CalculatorAPIController(ILogger<CalculatorAPIController> logger, IMathUtilities mathUtilities, IDataConverter dataConverter)
        {
            _logger = logger;
            this.mathUtilities = mathUtilities;
            this.dataConverter = dataConverter;
        }

        [HttpGet]
        [Route("sum")]
        public SumResponse Sum(string numbers)
        {
            var integers = dataConverter.ConvertCSVStringToInts(numbers);

            var response = new SumResponse();
            response.Sum = (int)mathUtilities.SumOnlyPositiveIntegers(integers);
            response.IsPrime = mathUtilities.CheckPrime(response.Sum);

            return response;
        }

        [HttpGet]
        [Route("checkprime")]
        public bool CheckPrime(int number)
        {
            return mathUtilities.CheckPrime(number);
        }

        public class SumResponse
        {
            public int Sum { get; set; }
            public bool IsPrime { get; set; }
        }

    }
}
