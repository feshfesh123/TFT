using System;

namespace TFTB.Server.Shared
{
    public class APIResponse<T>
    {
        public bool Successful { get; set; }
        public T Result { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public APIResponse(T result)
        {
            Successful = true;
            Result = result;
        }
        public APIResponse(bool successful)
        {
            Successful = successful;
        }
        public APIResponse(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
