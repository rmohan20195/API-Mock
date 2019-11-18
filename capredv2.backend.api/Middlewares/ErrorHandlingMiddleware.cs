using System;
using System.Net;
using System.Threading.Tasks;
using capredv2.backend.domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace capredv2.backend.api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is BusinessValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //Use this to Log Exception
                //await LogException(context.Request, exception);
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        //Use this to Log Exception
        //private static async Task LogException(HttpRequest request, Exception exception)
        //{
        //    var properties = new Dictionary<string, string>
        //    {
        //        {"request.Scheme", request.Scheme},
        //        {"request.Host", request.Host.ToString()},
        //        {"request.ContentType", request.ContentType},
        //        {"request.QueryString", request.QueryString.ToString()}
        //    };

        //    if (request.HasFormContentType)
        //    {
        //        var formData = request.Form.ToDictionary(_ => _.Key, _ => _.Value);

        //        foreach (var formDataItem in formData)
        //        {
        //            properties.Add(formDataItem.Key, formDataItem.Value);
        //        }
        //    }
        //    else
        //    {
        //        request.EnableRewind();
        //        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        //        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        //        var bodyAsText = Encoding.UTF8.GetString(buffer);
        //        request.Body.Position = 0;

        //        properties.Add("body", bodyAsText);
        //    }
        //}
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}

