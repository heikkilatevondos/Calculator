using CalculatorAPI.Logics;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorAPITests
{
    public class MathUtilitiesTests
    {
        IMathUtilities sut;


        [SetUp]
        public void Setup()
        {
            sut = new MathUtilities();
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(67)]
        [TestCase(97)]
        [TestCase(7919)]
        public void CheckPrime_WhenPrimeValue_ReturnTrue(int subjectNumber)
        {
            Assert.IsTrue(sut.CheckPrime(subjectNumber));
        }

        [Test]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(30)]
        [TestCase(62)]
        [TestCase(68)]
        [TestCase(7918)]
        public void CheckPrime_WhenNonPrimeValue_ReturnFalse(int subjectNumber)
        {
            Assert.IsFalse(sut.CheckPrime(subjectNumber));

        }

        [Test]
        [TestCase(4, 2, 2)]
        [TestCase(3, 1, 2)]
        [TestCase(4, -1, 2,2)] // skip negative numbers
        public void Sum_WhenListOfNumbersArePrimeValues_Return(int expectedSum, params int[] numbers)
        {
            Assert.AreEqual(expectedSum, sut.SumOnlyPositiveIntegers(numbers));
        }
    }
}