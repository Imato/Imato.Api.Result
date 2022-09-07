using System.Text.Json.Serialization;

namespace Imato.Api.Result
{
    public class ApiResult
    {
        /// <summary>
        /// Successful message
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Set true for return error in controller
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public bool IsFail { get; set; }

        /// <summary>
        /// Result object
        /// </summary>
        [JsonPropertyName("result")]
        public object? Result { get; set; }

        public static ApiResult Ok = new ApiResult
        {
            Message = "Ok"
        };

        public static ApiResult ServerError = new ApiResult
        {
            Error = "Unknown server error",
            IsFail = true
        };

        public static ApiResult Fail(string message) => new ApiResult { Error = message, IsFail = true };

        public static ApiResult Success(string message) => new ApiResult { Message = message };

        public static ApiResult Success(object value) => new ApiResult { Result = value };
    }

    public class ApiResult<T> : ApiResult where T : class
    {
        /// <summary>
        /// Result object
        /// </summary>
        [JsonPropertyName("result")]
        public new T? Result { get; set; }

        public static ApiResult<T> Ok = new ApiResult<T>
        {
            Message = "Ok"
        };

        public new static ApiResult<T> ServerError = new ApiResult<T>
        {
            Error = "Unknown server error",
            IsFail = true
        };

        public new static ApiResult<T> Fail(string message) => new ApiResult<T> { Error = message, IsFail = true };

        public new static ApiResult<T> Success(string message) => new ApiResult<T> { Message = message };

        public static ApiResult<T> Success(T value) => new ApiResult<T> { Result = value };
    }
}