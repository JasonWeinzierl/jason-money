using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace JasonMoney.Api.Controllers;

[ApiController]
[Route("api/healthcheck")]
public class HealthCheckController : ControllerBase
{
    private readonly HealthCheckService _healthCheckService;

    public HealthCheckController(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    /// <summary>
    /// Gets the aggregate status of all health checks.
    /// </summary>
    [HttpGet("status"), AllowAnonymous]
    public async Task<ActionResult<string>> Get()
        => Ok((await _healthCheckService.CheckHealthAsync()).Status.ToString());
}
