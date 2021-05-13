namespace Fibonacci
{
    /// <summary>
    /// The iterative fibonacci algorithm calculator.
    /// </summary>
    public class IterativeFibonacci : IFibonacci
    {
        /// <inheritdoc/>
        public long GetNthMember(long n)
        {
            ValidationHelper.ThrowOnInvalidFibonacciArgumentValue(n);

            if (n == 1)
            {
                return 0;
            }

            long lesserPrevious = 0;
            long greaterPrevious = 1;
            long current = 1;

            for (long i = 2; i < n; i++)
            {
                current = lesserPrevious + greaterPrevious;
                lesserPrevious = greaterPrevious;
                greaterPrevious = current;
            }

            return current;
        }
    }
}
