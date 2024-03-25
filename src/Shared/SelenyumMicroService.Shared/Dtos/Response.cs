namespace SelenyumMicroService.Shared.Dtos
{
    public record Response<T>(T Data, int StatusCode, bool IsSuccessful, List<string> Errors)
    {
        public static Response<T> Success(T data) => new(data, 200, true, null);

        public static Response<T> Success(T data, int statusCode) => new(data, statusCode, true, null);

        public static Response<T> Success(int statusCode) => new(default, statusCode, true, null);

        public static Response<T> Fail(string error) => new(default, 500, false, new List<string> { error });

        public static Response<T> Fail(string error, int statusCode) => new(default, statusCode, false, new List<string> { error });

        public static Response<T> Fail(List<string> errors) => new(default, 500, false, errors);

        public static Response<T> Fail(List<string> errors, int statusCode) => new(default, statusCode, false, errors);
    }
}