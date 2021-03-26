using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.API.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new ApiError(context.Exception.Message));
        }
    }

    public class ApiError
    {
        public ApiError(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
