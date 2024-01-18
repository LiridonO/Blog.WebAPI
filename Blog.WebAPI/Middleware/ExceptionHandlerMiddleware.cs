using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sentry;
using System;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ValidationException = Models.Exceptions.ValidationException;
using Models.Exceptions;
using Models.DTOs;

namespace Blog.WebAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }
        private Task ConvertException(HttpContext context, Exception exception)
        {
            var response = new DefaultResponse<bool>();

            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                    context.Response.StatusCode = (int)httpStatusCode;
                    return context.Response.WriteAsync(result);
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = ex.Message;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            if (result == string.Empty)
            {
                result = exception.Message;
            }

            response.Success = false;
            response.Message = result;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
