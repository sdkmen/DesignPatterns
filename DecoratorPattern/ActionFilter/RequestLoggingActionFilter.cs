using Microsoft.AspNetCore.Mvc.Filters;

namespace DecoratorPattern.ActionFilter
{
    public class RequestLoggingActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //do something
            await next(); //action working
            //do something
        }
    }
}
