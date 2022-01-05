namespace ServiceCenterBackend.Models.ResponseModels
{
    public class ServiceEngineerConnectResponse
    {
        public string Text { get; set; }
        public bool IsConnected { get; set; } = false;
        public string ConnectedEngineer { get; set; }
        public bool IsAllEngineersBusy { get; set; } = false;
    }
}
