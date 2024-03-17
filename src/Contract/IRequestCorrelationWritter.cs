using System;

namespace CorrelationTracking.Contract
{
    /// <summary>
    /// Write correlationId to current context.
    /// </summary>
    public interface IRequestCorrelationWritter
    {
        /// <summary>
        /// Set Correlation Id for request.
        /// </summary>
        /// <param name="value">New correlationId</param>
        IDisposable SetCorrelationId(string value);
    }
}
