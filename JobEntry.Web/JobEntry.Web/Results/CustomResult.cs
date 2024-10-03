using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JobEntry.Web.Results
{
    public class CustomResult:IActionResult
    {
        private readonly object _data;
        private readonly int _statusCode;

        public CustomResult(object data, int statusCode = StatusCodes.Status200OK)
        {
            _data = data;
            _statusCode = statusCode;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = _statusCode;
            response.ContentType = "application/json";

            if (_data != null)
            {
                var json = JsonSerializer.Serialize(_data);
                await response.WriteAsync(json);
            }
        }
    }
}
