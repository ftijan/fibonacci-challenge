using Fibonacci.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fibonacci.Tests
{
    [TestClass]
    public class FibonacciTests
    {
        [DataTestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [DataRow(4, 2)]
        [DataRow(11, 55)]
        [DataRow(18, 1597)]
        [DataRow(22, 10946)]
        [DataRow(27, 121393)]
        public void RecursiveFibonacci_WillCalculate_ExpectedValues(long n, long expected)
        {
            // Arrange
            IFibonacci recursiveFibonacci = new RecursiveFibonacci();

            // Act
            var calculatedValue = recursiveFibonacci.GetNthMember(n);

            // Assert
            Assert.AreEqual(expected, calculatedValue);
        }

        [DataTestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [DataRow(4, 2)]
        [DataRow(11, 55)]
        [DataRow(18, 1597)]
        [DataRow(22, 10946)]
        [DataRow(27, 121393)]
        public void IterativeFibonacci_WillCalculate_ExpectedValues(long n, long expected)
        {
            // Arrange
            IFibonacci iterativeFibonacci = new IterativeFibonacci();

            // Act
            var calculatedValue = iterativeFibonacci.GetNthMember(n);

            // Assert
            Assert.AreEqual(expected, calculatedValue);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void RecursiveFibonacci_WillThrow_OnInvalidValue(long invalidValue)
        {
            // Arrange            
            IFibonacci recursiveFibonacci = new RecursiveFibonacci();

            // Act
            var calculatedValue = recursiveFibonacci.GetNthMember(invalidValue);

            // Assert - exception            
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void IterativeFibonacci_WillThrow_OnInvalidValue(long invalidValue)
        {
            // Arrange            
            IFibonacci iterativeFibonacci = new IterativeFibonacci();

            // Act
            var calculatedValue = iterativeFibonacci.GetNthMember(invalidValue);

            // Assert - exception            
        }
    }
}
