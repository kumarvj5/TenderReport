using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TenderReport.WebApi.ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var errorMessage = string.Empty;
            if (ex.InnerException != null)
                errorMessage = ex.InnerException.Message;
            else
                errorMessage = ex.Message;
            // adding cors in headers for error message in order to avoid misguiding every error as cors error
            context.Response.AddApplicationError(ex.Message);

            var result = JsonConvert.SerializeObject(new
            {
                status = code,
                message = errorMessage,
                instance = context.Request.Path,
                traceId = context.TraceIdentifier
            });

            return context.Response.WriteAsync(result);
        }
    }
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
