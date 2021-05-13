using System;

namespace Fibonacci
{
    /// <summary>
    /// Validation logic helper methods.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Throws <see cref="ArgumentException"/> when the value of <see cref="n"/> is 0 or less.
        /// </summary>
        /// <param name="n">The order number of the fibonacci sequence member.</param>
        public static void ThrowOnInvalidFibonacciArgumentValue(long n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("The value of 'n' should be greater than 0.", nameof(n));
            }
        }
    }
}