using System;

namespace CorrelationTracking.Contract
{
    /// <summary>
    /// Write correlationId to current context.
    /// </summary>
    public interface IRequestCorrelationWritter
    {
        IDisposable SetCorrelationId(string value);
    }
}
