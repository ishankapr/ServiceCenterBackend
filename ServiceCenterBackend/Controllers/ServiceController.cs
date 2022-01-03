using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ServiceCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
            _logger.LogDebug("NLog injected into ServiceController");
        }

        [HttpGet]
        [Route("initiate")]
        public string ServiceUp()
        {
            _logger.LogInformation($"Service Backend Started..");
            return "Service Center Backend Started..";
        }
    }
}
