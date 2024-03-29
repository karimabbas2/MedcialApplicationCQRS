using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApplicationCore.HandleResponse
{
    public class ResponseResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool _ISuccess;
        public string? _Message;
        public T Result { get; set; }
        public ApplicationDomain.User _User;
        public ResponseResult()
        {
            
        }
        public ResponseResult(bool ISuccess, string Message, T data)
        {
            _ISuccess = ISuccess;
            _Message = Message;
            Result = data;

        }
        public ResponseResult(bool ISuccess, string Message)
        {
            _ISuccess = ISuccess;
            _Message = Message;

        }
        public ResponseResult(bool ISuccess, T data)
        {
            _ISuccess = ISuccess;
            Result = data;

        }
        public ResponseResult(bool ISuccess, ApplicationDomain.User user)
        {
            _ISuccess = ISuccess;
            _User = user;
        }

    }
}