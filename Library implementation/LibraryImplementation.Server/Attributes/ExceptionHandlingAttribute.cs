using LibraryImplementation.Contracts;
using LibraryImplementation.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace LibraryImplementation.Server.Attributes
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case UserNotFoundException:
                    CreateContextResult(StatusCodes.Status404NotFound, context);
                    break;
                case InvalidUserEmailException:
                    CreateContextResult(StatusCodes.Status400BadRequest, context);
                    break;
                case InvalidUserPasswordException:
                    CreateContextResult(StatusCodes.Status400BadRequest, context);
                    break;
                case InvalidUserPhoneNumberException:
                    CreateContextResult(StatusCodes.Status400BadRequest, context);
                    break;
                default:
                    CreateContextResult(StatusCodes.Status500InternalServerError, context);
                    break;
            }
        }

        private void CreateContextResult(int statusCode, ExceptionContext context)
        {
            var standardExceptionResponse = new StandardExceptionResponseContract
            {
                Exception = context.Exception.GetType().Name,
                Message = context.Exception.Message
            };
            
            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(standardExceptionResponse),
                ContentType = "application/json",
                StatusCode = statusCode
            };
        }
    }
}