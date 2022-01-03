using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceCenterBackend.Models;
using System;

namespace ServiceCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogDebug("NLog injected into UserController");
        }

        [HttpPost]
        [Route("connect")]
        public string ConnectEngineer([FromForm] Customer user) 
        {
            _logger.LogInformation($"{user.Name} is trying to connect a service engineer");
            return "";
        }

        [HttpPost]
        [Route("disconnect")]
        public bool DisconnectEngineer([FromForm] Customer user)
        {
            _logger.LogInformation($"{user.Name} is trying to disconnect service engineer");
            return true;
        }
    }
}
