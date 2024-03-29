using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.HandleResponse
{
    public static class ResponseHandler
    {

        public static ResponseResult<T> Conflicted<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Conflict,
                _ISuccess = false,
                _Message = message
            };
        }

        public static ResponseResult<T> Created<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                _ISuccess = true,
                _Message = message
            };
        }

        public static ResponseResult<T> Deleted<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                _ISuccess = true,
                _Message = message
            };
        }

        public static ResponseResult<T> Success<T>(T data)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                _ISuccess = true,
                _Message = "Success",
                Result = data

            };
        }

        public static ResponseResult<T> Unauthorized<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                _ISuccess = true,
                _Message = message
            };
        }

        public static ResponseResult<T> BadRequest<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                _ISuccess = false,
                _Message = message
            };
        }

        public static ResponseResult<T> NotFound<T>(string message)
        {
            return new ResponseResult<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                _ISuccess = false,
                _Message = message
            };
        }



    }
}