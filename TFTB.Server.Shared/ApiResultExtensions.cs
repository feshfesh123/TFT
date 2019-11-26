using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TFTB.Server.Shared
{
    public static class ApiResultExtensions
    {
        public static IActionResult ErrorResult(this ControllerBase controller, int errorCode, string errorMessage)
        {
            return JsonResult(new APIResponse<object>(errorCode, errorMessage));
        }

        public static IActionResult OkResult(this ControllerBase controller)
        {
            return JsonResult(new APIResponse<object>(true));
        }

        public static IActionResult OkResult(this ControllerBase controller, object result)
        {
            return JsonResult(new APIResponse<object>(result));
        }
        private static IActionResult JsonResult(object result, HttpStatusCode httpStatus = HttpStatusCode.OK)
        {
            return new ApiJsonResult(result, httpStatus);
        }
    }
}
