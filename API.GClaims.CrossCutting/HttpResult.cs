using Microsoft.AspNetCore.Mvc;

namespace API.GClaims.CrossCutting
{
    public static class HttpResult<T>
    {
        public static Result<T> Result { get; set; }

        public static IActionResult Success(T data, string message)
        {
            Result = new Result<T>()
            {
                Success = true,
                Data = data,
                Message = message
            };

            return new ObjectResult(Result);
        }

        public static IActionResult Error(int code, string message)
        {
            Result = new Result<T>()
            {
                Success = false,
                ErrorCode = code,
                Message = message
            };

            return new ObjectResult(Result);
        }
    }
}
