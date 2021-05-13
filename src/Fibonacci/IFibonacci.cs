namespace Fibonacci
{
    /// <summary>
    /// The fibonacci calculator contract.
    /// </summary>
    public interface IFibonacci
    {
        /// <summary>
        /// Gets the value of the n-th fibonacci sequence member, starting from 1.
        /// </summary>
        /// <param name="n">The order number of the sequence member, starting from 1.</param>
        /// <returns>The value of the n-th sequence member.</returns>
        /// <exception cref="ArgumentException">Thrown on invalid n value (0 or less).</exception>
        public long GetNthMember(long n);
    }
}
