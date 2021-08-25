using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        // ?? is null coalescing Operator,,,if null then do whats on right

        public int StatusCode { get; set; }

        public string Message { get; set; }


        private string GetDefaultMessageForStatusCode(int statusCode)
        {
           return statusCode switch{
               400=>"A Bad Request,You have made",
               401=>"You are Not Authorised",
               404=>"Resource Not Found",
               500=>"Server Error",
               _=>null
           };
        }
    }
}