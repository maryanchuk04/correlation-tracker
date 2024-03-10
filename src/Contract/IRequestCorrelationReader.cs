namespace CorrelationTracking.Contract
{
    /// <summary>
    /// Read request correlationId from current context.
    /// </summary>
    public interface IRequestCorrelationReader
    {
        string GetCorrelationId();
    }
}
