using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReceitasPerfeitas.Communication.Response;
using ReceitasPerfeitas.Exceptions;
using ReceitasPerfeitas.Exceptions.ExceptionsBase;
using System;
using System.Net;

namespace ReceitasPerfeitas.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    void IExceptionFilter.OnException(ExceptionContext context)
    { 
        if (context.Exception is ReceitasPerfeitasException)          
            HandleProjectException(context);        
        else
            ThrowUnknowException(context);
        
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErroOnValidationException)
        { 
            var exception = context.Exception as ErroOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErroJson(exception!.ErroMessages)); 
        }
    }
     
    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErroJson(ResourceMessageException.UNKNOWN_ERROR));
    }
}

