using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace SelenyumMicroService.Api.Client.BaseClients
{
    public abstract class JsonClient
    {
        protected readonly HttpClient httpClient;

        public JsonClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected virtual async Task<TReturn> PostForm<TReturn>(string method, params (string Key, string Value)[] formData)
        {
            var content = new MultipartFormDataContent();
            foreach (var (Key, Value) in formData)
            {
                content.Add(new StringContent(Value), Key);
            }
            try
            {
                var httpResponseMessage = await httpClient.PostAsync(method, content);
                ValidateResponse(httpResponseMessage);
                var response = await ReadResponseStream(httpResponseMessage);
                return Deserialize<TReturn>(response);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task PostForm(string method, params (string Key, string Value)[] formData)
        {
            var content = new MultipartFormDataContent();
            foreach (var (Key, Value) in formData)
            {
                content.Add(new StringContent(Value), Key);
            }
            try
            {
                var result = await httpClient.PostAsync(method, content);
                ValidateResponse(result);
                await ReadResponseStream(result);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task Post<T>(string method, T request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            try
            {
                var result = await httpClient.PostAsync(method, content);
                ValidateResponse(result);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task<TReturn> Post<TReturn, T>(string method, T request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(method, content);
                ValidateResponse(response);
                var result = ReadResponseStream(response);

                return Deserialize<TReturn>(result.Result);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task Get(string method)
        {
            try
            {
                var result = await httpClient.GetAsync(method);
                ValidateResponse(result);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task<TReturn> Get<TReturn>(string method)
        {
            try
            {
                var response = await httpClient.GetAsync(method);
                ValidateResponse(response);
                var result = ReadResponseStream(response);
                return Deserialize<TReturn>(result.Result);
            }
            catch
            {
                throw;
            }
        }

        private static async Task<string> ReadResponseStream(HttpResponseMessage response)
        {
            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var result = await streamReader.ReadToEndAsync();
            return result;
        }

        protected static string Serialize<T>(T data)
        {
            var options = new JsonSerializerOptions
            {
                MaxDepth = 0,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = false,
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            return JsonSerializer.Serialize(data, options);
        }

        protected static T Deserialize<T>(string data)
        {
            var options = new JsonSerializerOptions
            {
                MaxDepth = 0,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = true,
            };

            return JsonSerializer.Deserialize<T>(data, options);
        }

        private void ValidateResponse(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage?.IsSuccessStatusCode == true)
                return;
        }
    }
}