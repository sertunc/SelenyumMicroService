namespace SelenyumMicroService.Caching
{
    public interface ICache
    {
        Task<string> GetValueAsync(string key);

        Task<bool> SetValueAsync(string key, object value);

        Task<bool> SetValueAsync(string key, object value, object options);

        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class;

        Task RemoveAsync(string key);
    }
}