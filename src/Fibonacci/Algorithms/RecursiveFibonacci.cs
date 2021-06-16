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

            return GetNthMemberInner(n);
        }

        /// <summary>
        /// Gets the value of the n-th fibonacci sequence member, starting from 1.
        /// </summary>
        /// <param name="n">The order number of the sequence member, starting from 1.</param>
        /// <returns>The value of the n-th sequence member.</returns>        
        private long GetNthMemberInner(long n)
        {            
            return n switch
            {
                1 => 0,
                2 => 1,
                _ => GetNthMemberInner(n - 1) + GetNthMemberInner(n - 2)
            };
        }
    }
}
