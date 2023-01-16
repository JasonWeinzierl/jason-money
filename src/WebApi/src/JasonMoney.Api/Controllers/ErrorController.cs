using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JasonMoney.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
        => Problem(statusCode: GetStatusCode(HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error));

    private static int GetStatusCode(Exception? exception) =>
        exception switch
        {
            _ => StatusCodes.Status500InternalServerError,
        };
}
