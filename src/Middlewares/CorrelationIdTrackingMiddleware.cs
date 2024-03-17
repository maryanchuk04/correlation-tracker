using System;
using System.Linq;
using System.Threading.Tasks;
using CorrelationTracking.Constants;
using CorrelationTracking.Contract;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace CorrelationTracking.Middlewares
{
    internal sealed class CorrelationIdTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestCorrelationReader _reader;
        private readonly IRequestCorrelationWritter _writter;

        public CorrelationIdTrackingMiddleware(RequestDelegate next, IRequestCorrelationWritter writter, IRequestCorrelationReader reader)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _writter = writter ?? throw new ArgumentNullException(nameof(writter));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestId = context.Request.Headers[CorrelationConstants.CorrelationIdHeaderName].FirstOrDefault();

            // Push into Relevant.Info so we can use it downstream
            using (_writter.SetCorrelationId(requestId))
            {
                var correlationId = _reader.GetCorrelationId();

                // Also push into LogContext so it will show up in messages
                using (LogContext.PushProperty(CorrelationConstants.CorrelationIdHeaderName, correlationId))
                {
                    // Call the next delegate/middleware in the pipeline and add RequestCorrelationId to Response headers
                    context.Response.Headers.Add(CorrelationConstants.CorrelationIdHeaderName, correlationId);
                    await _next(context);
                }
            }
        }
    }
}