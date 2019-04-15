using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Cache.Filter
{
    public class ETagAttribute : ActionFilterAttribute
    {
        // 自定義判斷ETag
        private string _etag;

        public ETagAttribute()
        {
            _etag = "12345678";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requestHeaders = context.HttpContext.Request.Headers;
            if (requestHeaders.ContainsKey("If-None-Match") && requestHeaders["If-None-Match"] == $"\"{_etag}\"")
            {
                context.HttpContext.Response.Headers.Add("Cache-Control", "max-age=10");
                context.Result = new StatusCodeResult((int) HttpStatusCode.NotModified);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var requestHeaders = context.HttpContext.Request.Headers;
            if (!requestHeaders.ContainsKey("If-None-Match") )
            {
                context.HttpContext.Response.Headers.Add("Cache-Control", "max-age=10");
                context.HttpContext.Response.Headers.Add("ETag", $"\"{_etag}\"");
            }
        }
    }
}