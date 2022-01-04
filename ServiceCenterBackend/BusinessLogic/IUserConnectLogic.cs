using ServiceCenterBackend.Models;
using ServiceCenterBackend.Models.ResponseModels;

namespace ServiceCenterBackend.BusinessLogic
{
    public interface IUserConnectLogic
    {
        public ServiceEngineerConnectResponse ConnectEngineer(Customer customer);
        public bool DisconnectEngineer(Customer customer);

    }
}
