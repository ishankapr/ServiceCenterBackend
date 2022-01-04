using ServiceCenterBackend.Enum;

namespace ServiceCenterBackend.Models
{
    public class Customer 
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public LanguageLevelEnum LanguageLevel { get; set; }
    }
}
