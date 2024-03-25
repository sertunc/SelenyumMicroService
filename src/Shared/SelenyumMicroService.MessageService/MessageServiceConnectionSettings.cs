namespace SelenyumMicroService.MessageService
{
    public record MessageServiceConnectionSettings
    {
        public string Protocol { get; init; }
        public string Host { get; init; }
        public string MessageUser { get; init; }
        public string MessagePass { get; init; }
        public string VirtualHost { get; init; }

        public MessageServiceConnectionSettings() { }

        public string MessageService => $"{Protocol}://{Host}";
    }
}