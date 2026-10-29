using Apitest.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Apitest.Controllers;

public class ServiceExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var status = context.Exception switch
        {
            ResourceNotFoundException => StatusCodes.Status404NotFound,
            BusinessRuleException => StatusCodes.Status400BadRequest,
            DataConflictException => StatusCodes.Status409Conflict,
            _ => 0
        };
        if (status == 0) return;
        context.Result = new ObjectResult(new ProblemDetails
        {
            Status = status,
            Title = context.Exception.Message
        }) { StatusCode = status };
        context.ExceptionHandled = true;
    }
}
