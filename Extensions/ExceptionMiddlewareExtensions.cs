using AngularWebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;


namespace AngularWebApp.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exception.Error.GetType().Name switch
                    {
                        "ArgumentException" => HttpStatusCode.BadRequest,
                        "ArgumentNullException" => HttpStatusCode.InternalServerError,
                        _ => HttpStatusCode.ServiceUnavailable
                    };


                    context.Response.StatusCode = (int)statusCode;
                    context.Response.ContentType = "application/json";

                    if ((int)statusCode == 500)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = (int) statusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                    else
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = (int)statusCode,
                            Message = exception.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}

