namespace SelenyumMicroService.ServiceDiscovery.Consul
{
    public record ConsulSettings(string ConsulAddress, string ServiceId, string ServiceName, string ServiceHostUrl, string[] Tags);
}