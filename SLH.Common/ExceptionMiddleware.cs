using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SLH.Common
{
    public class ExceptionMiddleware
    {
        private const string ErrorMessage = "An unexpected error has occurred.";
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>process request and return global error if any unhandled erros are occured</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (AggregateException aggEx) when (aggEx.InnerException is TokenGenerationException)
            {
                httpContext.Response.Redirect("/");
            }
            catch (InvalidOperationException invalidEx) when (invalidEx.InnerException is InvalidOperationException)
            {
                this.logger.LogError(invalidEx, $"Something went wrong: {invalidEx}");
                await httpContext.ChallengeAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>return exception</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrorResult errorResult = new ErrorResult();
            errorResult.Message.Add(exception.Message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResult, Formatting.Indented));
        }
    }
}
