using Newtonsoft.Json;

namespace ServiceCenterBackend.Models
{
    public class ServiceEngineer
    {
        public string Name { get; set; }
        public string [] Groups { get; set; }
        public bool IsAssigned { get; set; } = false;
        public string AsignedCustomer { get; set; }
    }
}

