namespace Fibonacci.Algorithms
{
    /// <summary>
    /// The recursive fibonacci algorithm calculator.
    /// </summary>
    public class RecursiveFibonacci : IFibonacci
    {
        /// <inheritdoc/>
        public long GetNthMember(long n)
        {
            ValidationHelper.ThrowOnInvalidFibonacciArgumentValue(n);

            return n switch
            {
                1 => 0,
                2 => 1,
                _ => GetNthMember(n - 1) + GetNthMember(n - 2)
            };
        }
    }
}
