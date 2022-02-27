using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SmartCharging.Service.Common.ErrorHandling;
using SmartCharging.Service.Common.ErrorHandling.Exceptions;

namespace SmartCharging.Service.Extensions;

public static class GlobalErrorHandling
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature != null)
                {
                    bool shouldAddExceptionDetail = false;
                    switch(contextFeature.Error)
                    {
                        case AppException e:
                            // custom application error
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        case KeyNotFoundException e:
                            // not found error
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        default:
                            // unhandled error
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            shouldAddExceptionDetail = true;
                            break;
                    }
                    
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        ExceptionDetail = shouldAddExceptionDetail ? contextFeature.Error.StackTrace : null
                    }.ToString());
                }
            });
        });
    }
}