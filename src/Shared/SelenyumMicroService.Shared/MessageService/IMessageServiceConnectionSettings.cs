namespace SelenyumMicroService.Shared.MessageService
{
    public interface IMessageServiceConnectionSettings
    {
        string Protocol { get; set; }

        string Host { get; set; }

        string MessagePass { get; set; }

        string MessageService { get; }

        string MessageUser { get; set; }

        string VirtualHost { get; set; }
    }
}