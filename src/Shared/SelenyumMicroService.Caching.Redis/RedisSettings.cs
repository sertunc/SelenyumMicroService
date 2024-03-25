namespace SelenyumMicroService.Caching.Redis
{
    public record RedisSettings
    {
        public string[] Addresses { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }

        public RedisSettings()
        {
        }
    }
}