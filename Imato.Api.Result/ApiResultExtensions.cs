using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using static System.Net.Mime.MediaTypeNames;

namespace Imato.Api.Result
{
    public static class ApiResultExtensions
    {
        private static MediaTypeCollection contentTypes = new MediaTypeCollection { Application.Json };

        /// <summary>
        /// Add resutl
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ApiResult<T> Result<T>(this ApiResult<T> result, T value) where T : class
        {
            result.Result = value;
            return result;
        }

        /// <summary>
        /// Add result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ApiResult Result(this ApiResult result, object value)
        {
            result.Result = value;
            return result;
        }

        /// <summary>
        /// Add error message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ApiResult<T> Fail<T>(this ApiResult<T> result, string error) where T : class
        {
            result.Error = error;
            result.IsFail = true;
            return result;
        }

        /// <summary>
        /// Add error message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ApiResult Fail(this ApiResult result, string error)
        {
            result.Error = error;
            result.IsFail = true;
            return result;
        }

        /// <summary>
        /// Add message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<T> Success<T>(this ApiResult<T> result, string message) where T : class
        {
            result.Message = message;
            return result;
        }

        /// <summary>
        /// Add message
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult Success(this ApiResult result, string message)
        {
            result.Message = message;
            return result;
        }

        /// <summary>
        /// Add result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ApiResult<T> Success<T>(this ApiResult<T> result, T value) where T : class
        {
            result.Result = value;
            return result;
        }

        /// <summary>
        /// Add result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ApiResult Success(this ApiResult result, object value)
        {
            result.Result = value;
            return result;
        }

        /// <summary>
        /// Get result for controller action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ActionResult<T> ActionResult<T>(this ApiResult<T> result) where T : class
        {
            if (result == null)
            {
                return ApiResult<T>.ServerError.ActionResult();
            }

            if (result.IsFail)
            {
                return new BadRequestObjectResult(result);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get result for controller action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ActionResult ActionResult(this ApiResult result)
        {
            if (result == null)
            {
                return new BadRequestObjectResult(ApiResult.ServerError)
                {
                    ContentTypes = contentTypes
                };
            }

            if (result.IsFail)
            {
                return new BadRequestObjectResult(result)
                {
                    ContentTypes = contentTypes
                };
            }

            return new OkObjectResult(result)
            {
                ContentTypes = contentTypes
            };
        }
    }
}