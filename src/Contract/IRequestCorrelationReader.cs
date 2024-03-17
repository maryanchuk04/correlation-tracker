namespace CorrelationTracking.Contract
{
    /// <summary>
    /// Read request correlationId from current context.
    /// </summary>
    public interface IRequestCorrelationReader
    {
        /// <summary>
        /// Get correlationId of current request.
        /// </summary>
        /// <returns>CorrelationId</returns>
        string GetCorrelationId();
    }
}
