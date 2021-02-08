using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace MovimentosManuais.API.Configurations
{
    public sealed class CustomExceptionFilterConfiguration : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var contextException = context.Exception;
            object result = new { ErrorCode = status, Errors = contextException };
            var messageException = contextException.InnerException != null 
                                    ? contextException.InnerException.Message 
                                    : contextException.Message;


            if (contextException.GetType() == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                result = new
                {
                    ErrorCode = HttpStatusCode.Unauthorized,
                    Error = messageException
                };
            }

            if (contextException.GetType() == typeof(NullReferenceException))
            {
                status = HttpStatusCode.NotFound;
                result = new
                {
                    ErrorCode = HttpStatusCode.NotFound,
                    Error = messageException
                };
            }


            if (contextException.GetType() != typeof(NullReferenceException) &&
                contextException.GetType() != typeof(UnauthorizedAccessException))
            {

                result = new
                {
                    ErrorCode = status,
                    Error = messageException
                };
            }

            var response = context.HttpContext.Response;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(result);
        }
    }
}
