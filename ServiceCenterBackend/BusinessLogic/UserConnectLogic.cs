using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ServiceCenterBackend.Models;
using ServiceCenterBackend.Models.ResponseModels;
using ServiceCenterBackend.Rules;
using System.Collections.Generic;
using System.Linq;

namespace ServiceCenterBackend.BusinessLogic
{
    public class UserConnectLogic : IUserConnectLogic
    {
        private IMemoryCache _cache;
        private readonly ILogger<UserConnectLogic> _logger;

        public UserConnectLogic(IMemoryCache cache, ILogger<UserConnectLogic> logger)
        {
            _cache = cache;
            _logger = logger;
            _logger.LogDebug("NLog injected into UserConnectLogic");
        }

        public ServiceEngineerConnectResponse ConnectEngineer(Customer customer)
        {
            _logger.LogInformation($"{ customer.Name } is trying to connect a service engineer..");
            var priorities = ProviderSelectionRule.GetPriorities(customer.Category, customer.LanguageLevel);
            List<ServiceEngineer> engineers = _cache.Get<List<ServiceEngineer>>("Engineers");
            ServiceEngineer selectedEngineer = null;
            ServiceEngineerConnectResponse engineerConnectResponse = null;

            foreach (var priority in priorities)
            {
                foreach (var engineer in engineers)
                {
                    if (!priority.Except(engineer.Groups).Any() && !engineer.IsAssigned)
                    {
                        selectedEngineer = engineer;
                    }

                    if (selectedEngineer != null) break;
                }

                if (selectedEngineer != null) break;
            }

            selectedEngineer = selectedEngineer == null ? engineers.Where(o => o.IsAssigned == false).FirstOrDefault() : selectedEngineer;

            if (selectedEngineer == null)
            {
                engineerConnectResponse = new ServiceEngineerConnectResponse()
                {
                    IsConnected = false,
                    IsAllEngineersBusy = true,
                    Text = "All service engineers are busy. Please wait.."
                };

                _logger.LogInformation($"{ customer.Name } could not find any service engineer..");
            }
            else
            {
                engineers.Remove(selectedEngineer);
                engineers.Add(new ServiceEngineer()
                {
                    AsignedCustomer = customer.Name,
                    Groups = selectedEngineer.Groups,
                    IsAssigned = true,
                    Name = selectedEngineer.Name
                });

                _cache.Remove("Engineers");
                _cache.Set("Engineers", engineers);

                engineerConnectResponse = new ServiceEngineerConnectResponse()
                {
                    IsConnected = true,
                    Text = $"{customer.Name} is now connected with {selectedEngineer.Name}",
                    ConnectedEngineer = selectedEngineer.Name
                };

                _logger.LogInformation($"{ customer.Name } successfully connected with service engineer..");
            }

            return engineerConnectResponse;
        }

       
    }
}
