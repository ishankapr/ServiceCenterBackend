using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ServiceCenterBackend.BusinessLogic;
using ServiceCenterBackend.Models;
using ServiceCenterBackend.Models.ResponseModels;

namespace ServiceCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private IUserConnectLogic _userConnectLogic;

        public UserController(ILogger<UserController> logger, IUserConnectLogic userConnectLogic)
        {
            _logger = logger;
            _userConnectLogic = userConnectLogic;
            _logger.LogDebug("NLog injected into UserController");
        }

        [HttpPost]
        [Route("connect")]
        public ServiceEngineerConnectResponse ConnectEngineer(Customer customer) 
        {
            _logger.LogInformation($"{customer.Name} is trying to connect a service engineer");
            var response = _userConnectLogic.ConnectEngineer(customer);
            return response;
        }

        [HttpPost]
        [Route("disconnect")]
        public bool DisconnectEngineer(Customer customer)
        {
            _logger.LogInformation($"{customer.Name} is trying to disconnect service engineer");
            return _userConnectLogic.DisconnectEngineer(customer);
        }
    }
}
