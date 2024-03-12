namespace SelenyumMicroService.Shared.MessageService
{
    public class MessageServiceConnectionSettings : IMessageServiceConnectionSettings
    {
        public string Protocol { get; set; }

        public string Host { get; set; }

        public string MessageService => $"{Protocol}://{Host}";

        public string MessageUser { get; set; }

        public string MessagePass { get; set; }

        public string VirtualHost { get; set; }
    }
}