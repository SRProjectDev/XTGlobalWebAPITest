using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.Metadata;

namespace XTGlobalWebAPI.Filters
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public readonly ILogger<CustomExceptionHandler> _logger;
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called on Unhandled exception
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
            new
            {
                message = "Something went wrong, Please try again later!",
                isError = true,
                errorMessage = context.Exception.Message,
                exception = context.Exception
            });
            
            _logger.LogError("Exception Occured - " + context.Exception);

            response.ContentLength = result.Length;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Task.Run(async () => await response.WriteAsync(result));
        }
    }
}
