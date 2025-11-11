using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Shared
{
    public class ApiResponse<T>
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMsg { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(string code, string msg, bool isSuccess, T? data)
        {
            ResponseCode = code;
            ResponseMsg = msg;
            IsSuccess = isSuccess;
            Data = data;
        }

        public static ApiResponse<T> Success(T data, string code = "200", string msg = "Success")
        {
            return new ApiResponse<T>(code, msg, true, data);
        }

        public static ApiResponse<T> Fail(string code = "0", string msg = "Failed")
        {
            return new ApiResponse<T>(code, msg, false, default);
        }
    }
}
