namespace SelenyumMicroService.ServiceDiscovery.Consul
{
    public class ConsulSettings
    {
        public string ConsulAddress { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceHostUrl { get; set; }
        public string[] Tags { get; set; }
    }
}