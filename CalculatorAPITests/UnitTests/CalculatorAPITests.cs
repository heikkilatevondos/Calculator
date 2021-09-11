using CalculatorAPI.Controllers;
using CalculatorAPI.Logics;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorAPITests
{
    public class CalculatorAPITests
    {
        CalculatorAPIController sut;

        IMathUtilities fakeMathUtils;
        IDataConverter fakeDataConverter;

        string inputNumberCsvString = "434";


        [SetUp]
        public void Setup()
        {
            ILogger<CalculatorAPIController> fakeLogger = Substitute.For<ILogger<CalculatorAPIController>>();
            fakeMathUtils = Substitute.For<IMathUtilities>();
            fakeDataConverter = Substitute.For<IDataConverter>();

            // Act
            sut = new CalculatorAPIController(fakeLogger, fakeMathUtils, fakeDataConverter);
        }

        [Test]
        public void CheckPrime_WhenMathUtilsCheckPrimeReturnsFalse_ReturnFalse()
        {
            fakeMathUtils.CheckPrime(0).ReturnsForAnyArgs(false);

            Assert.IsFalse(sut.CheckPrime(0));
        }
        public void CheckPrime_WhenMathUtilsCheckPrimeReturnsTrue_ReturnTrue()
        {
            fakeMathUtils.CheckPrime(0).ReturnsForAnyArgs(true);

            Assert.IsTrue(sut.CheckPrime(0));
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(200)]
        public void CheckPrime_PassInputNumberToMathUtilsCheckPrime(int number)
        {
            sut.CheckPrime(number);

            fakeMathUtils.Received().CheckPrime(number);
        }

        [Test]
        public void Sum_PassInputValueToConverter ()
        {
            // Act
            sut.Sum(inputNumberCsvString);

            fakeDataConverter.ConvertCSVStringToInts(inputNumberCsvString).Received(1);
        }

        [Test]
        public void Sum_PassConvertedInputValuesToMathUtilSum()
        {
            var convertedValues = new List<int> { 2, 3 };
            fakeDataConverter.ConvertCSVStringToInts(inputNumberCsvString).Returns(convertedValues);

            // Act
            sut.Sum(inputNumberCsvString);

            fakeMathUtils.Received(1).SumOnlyPositiveIntegers(convertedValues);
        }

        [Test]
        public void Sum_ReturnValueFromMathUtilities()
        {
            var expected = 4;
            var convertedValues = new List<int> { 2, 3 };
            fakeMathUtils.SumOnlyPositiveIntegers(convertedValues).ReturnsForAnyArgs(expected);

            // Act
            var actual = sut.Sum(inputNumberCsvString);

            Assert.AreEqual(expected, actual.Sum);
        }

        [Test]
        [TestCase(true)] // Prime
        [TestCase(false)] // Not Prime value
        public void Sum_SetIsPrimeToFalseIf(bool testForPrime)
        {
            fakeMathUtils.CheckPrime(0).ReturnsForAnyArgs(testForPrime);

            // Act
            var actual = sut.Sum(inputNumberCsvString);

            Assert.AreEqual(testForPrime, actual.IsPrime);
        }

        [Test]
        public void Sum_CheckPrimeBySumOfValuesCalculated()
        {
            var fakeSumOfValues = 334;
            fakeMathUtils.SumOnlyPositiveIntegers(null).ReturnsForAnyArgs(334);

            // Act
            var actual = sut.Sum(inputNumberCsvString);

            fakeMathUtils.Received(1).CheckPrime(fakeSumOfValues);
        }

    }
}