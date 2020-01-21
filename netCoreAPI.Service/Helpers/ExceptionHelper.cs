using netCoreAPI.Domain.Enums;
using System;

namespace netCoreAPI.Service.Helpers
{
    public static class ExceptionHelper
    {
        public static ResultCode ResponseException(Exception ex)
        {
            var resultCode = new ResultCode(500, ex.Message);
            return resultCode;
        }
    }
}