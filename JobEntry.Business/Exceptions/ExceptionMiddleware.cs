using FluentValidation;
using JobEntry.Business.Bases;
using JobEntry.Business.Utilities.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Exceptions
{
	public class ExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}
		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			int statusCode = GetStatusCode(ex);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = statusCode;

            if (ex.GetType() == typeof(ValidationException))

                return context.Response.WriteAsync(new ServiceResponse<EmptyResponse>()
                {
                    Success = false,
                    Errors = ((ValidationException)ex).Errors.Select(x => x.ErrorMessage).ToList(),
                    StatusCode = statusCode
                }.ToString());

            List<string> errors = new List<string>()
            {
                ex.Message,
            };
            return context.Response.WriteAsync(new ServiceResponse<EmptyResponse>()
            {
                Success = false,
                Errors = errors,
                StatusCode = statusCode
            }.ToString());

        }
        private bool IsApiRequest(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/api") ||
                   context.Request.Headers["Accept"].ToString().Contains("application/json");
        }

        private static int GetStatusCode(Exception ex) =>
			ex switch
			{
				BaseException => StatusCodes.Status400BadRequest,
				BadRequestException => StatusCodes.Status400BadRequest,
				UnauthorizedException => StatusCodes.Status401Unauthorized,
				NotFoundException => StatusCodes.Status404NotFound,
				ValidationException => StatusCodes.Status400BadRequest,
				_ => StatusCodes.Status500InternalServerError
			};
	}
}
