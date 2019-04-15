using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Cache.Filter
{
    public class LastModifiedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers["If-Modified-Since"] == "Tue, 24 Feb 2019 08:01:04")
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.NotModified);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var requestHeaders = context.HttpContext.Request.Headers;
            var responseHeaders = context.HttpContext.Response.Headers;
            if (!requestHeaders.ContainsKey("If-Modified-Since"))
            {
                responseHeaders.Add("Last-Modified", "Tue, 24 Feb 2019 08:01:04");
                responseHeaders.Add("Cache-Control", "max-age=10");
            }
        }
    }
}