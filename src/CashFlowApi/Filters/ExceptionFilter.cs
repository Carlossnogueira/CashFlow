using CashFlow.Communication.Responses;
using CashFlow.Exception.ExeptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlowApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException)
            {
                /*or = context.Exception as ErrorOnValidationException */
                var ex = (ErrorOnValidationException)context.Exception;

                var errorResponse = new ResponseErrorJson(ex.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson("unknow error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }

    }
}
