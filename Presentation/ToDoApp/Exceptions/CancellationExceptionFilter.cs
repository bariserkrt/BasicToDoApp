using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoApp.Exceptions
{
    public class CancellationExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if(context.Exception is OperationCanceledException || context.Exception is TaskCanceledException)
            {
                context.Result = new EmptyResult();
                context.ExceptionHandled = true;
            }
            return Task.CompletedTask;
        }
    }
}
