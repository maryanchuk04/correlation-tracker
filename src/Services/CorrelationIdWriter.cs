using System;
using System.Collections.Specialized;
using Contextually;
using CorrelationTracking.Constants;
using CorrelationTracking.Contract;

namespace CorrelationTracking.Services
{
    internal class CorrelationIdWriter : IRequestCorrelationWritter
    {
        public IDisposable SetCorrelationId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = Guid.NewGuid().ToString();
            }

            var relevantContext = new NameValueCollection()
            {
                [CorrelationConstants.CorrelationIdHeaderName] = value,
            };

            // Push into Relevant.Info so we can use it downstream
            return Relevant.Info(relevantContext);
        }
    }
}
