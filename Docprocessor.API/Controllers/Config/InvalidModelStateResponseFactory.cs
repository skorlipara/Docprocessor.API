using Microsoft.AspNetCore.Mvc;
using Docprocessor.API.Extensions;
using Docprocessor.API.Resources;


namespace Docprocessor.API.Controllers.Config
{
    public class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}
