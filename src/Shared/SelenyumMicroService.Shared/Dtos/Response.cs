namespace SelenyumMicroService.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; init; }
        public int StatusCode { get; init; }
        public bool IsSuccessful { get; init; }
        public List<string> Errors { get; init; }

        public static Response<T> Success(T data)
        {
            return new Response<T> { Data = data, StatusCode = 200, IsSuccessful = true };
        }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(string error)
        {
            return new Response<T> { Errors = new List<string>() { error }, StatusCode = 500, IsSuccessful = false };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string>() { error }, StatusCode = statusCode, IsSuccessful = false };
        }

        public static Response<T> Fail(List<string> errors)
        {
            return new Response<T> { Errors = errors, StatusCode = 500, IsSuccessful = false };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}