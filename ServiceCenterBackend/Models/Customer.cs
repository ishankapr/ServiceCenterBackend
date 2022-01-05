using ServiceCenterBackend.Enum;

namespace ServiceCenterBackend.Models
{
    public class Customer 
    {
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public LanguageLevelEnum LanguageLevel { get; set; }
        public string ConnectedEngineer { get; set; }
        public bool IsConnected { get; set; }
    }
}
