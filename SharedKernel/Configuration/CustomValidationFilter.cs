using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.SharedObjects;

namespace SharedKernel.Configuration
{
    public class CustomValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new NewResponse
                {
                    StatusCode = 400,
                    Data = null,
                    Meta = null,
                    Errors = "O formulário não foi preenchido corretamente."
                };

                context.Result = new BadRequestObjectResult(result);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
