using Fibonacci.Algorithms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Fibonacci
{
    class Program
    {
        
        /// <summary>
        /// The application entrypoint.
        /// </summary>
        /// <param name="args">The app arguments.</param>
        static void Main(string[] args)
        {
            var (isValid, paramValue) = ParseFibonacciArguments(args);

            if (isValid)
            {
                var host = CreateHostBuilder(args).Build();

                var fibonacci = host.Services.GetService<IFibonacci>();

                var value = fibonacci.GetNthMember(paramValue);

                Console.WriteLine($"The value of fibonacci element number {paramValue} is: {value}");
            }
        }

        /// <summary>
        /// Creates the app host instance.
        /// </summary>
        /// <param name="args">The app params.</param>
        /// <returns>The instance of <see cref="IHostBuilder"/>.</returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(configHost =>
            {
                configHost.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                configHost.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(FibonacciFactory.Create(hostContext.Configuration));                
            });

        /// <summary>
        /// Parses the arguments and returns the parsing result and parsed value.
        /// </summary>
        /// <param name="args">The app arguments.</param>
        /// <returns>The <c>(bool,long)</c> tuple indicating parsing success and parsed value. </returns>
        private static (bool, long) ParseFibonacciArguments(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return (false, 0);
            }

            if (string.IsNullOrWhiteSpace(args[0]) || !long.TryParse(args[0], out var fibonacciParam) || fibonacciParam <= 0)
            {
                Console.WriteLine($"Fibonacci: Invalid fibonacci parameter value entered. Parameter should be a non-zero, positive int or a positive long number");
                Console.WriteLine();
                PrintUsage();
                return (false, 0);
            }

            return (true, fibonacciParam);
        }

        /// <summary>
        /// Prints the app usage hints.
        /// </summary>
        private static void PrintUsage()
        {
            Console.WriteLine($"Fibonacci - usage: \"Fibonacci fibonacci_param_value\",");
            Console.WriteLine($"where \"fibonacci_param_value\" is an int or a long number, starting from 1.");
            Console.WriteLine($"Example: Fibonacci 12");
        }
    }
}
