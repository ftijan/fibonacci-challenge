using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Fibonacci.Algorithms
{
    /// <summary>
    /// The <see cref="IFibonacci"/> factory.
    /// </summary>
    public static class FibonacciFactory
    {
        /// <summary>
        /// The valid algorithms array, used in fibonacci calculator dependency injection.
        /// </summary>
        static readonly string[] ValidAlgorithms = new string[] { "Recursive", "Iterative" };

        /// <summary>
        /// Creates an instance of <see cref="IFibonacci"/> based on the configured settings.
        /// </summary>
        /// <param name="configuration">The configuration instance.</param>
        /// <returns>An instance of <see cref="IFibonacci"/>.</returns>
        public static IFibonacci Create(IConfiguration configuration)
        {            
            var algorithm = configuration.GetValue<string>("Algorithm");

            if (string.IsNullOrWhiteSpace(algorithm) || !ValidAlgorithms.Contains(algorithm) || algorithm == "Recursive")
            {
                return new RecursiveFibonacci();                
            }
            else // Iterative algorithm
            {
                return new IterativeFibonacci();                
            }
        }
    }
}
