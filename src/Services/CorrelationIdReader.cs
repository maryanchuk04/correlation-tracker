using Contextually;
using CorrelationTracking.Constants;
using CorrelationTracking.Contract;

namespace CorrelationTracking.Services
{
    internal sealed class CorrelationIdReader : IRequestCorrelationReader
    {
        public string GetCorrelationId()
        {
            return Relevant.Info()[CorrelationConstants.CorrelationIdHeaderName];
        }
    }
}
