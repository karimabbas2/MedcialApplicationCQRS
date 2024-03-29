using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.HandleResponse
{
    public class ServiceResponse
    {
        public bool _ISuccess;
        public string? _Message;
        public ApplicationDomain.User _User;
        public ServiceResponse(bool ISuccess, string Message)
        {
            _ISuccess = ISuccess;
            _Message = Message;
        }

        public ServiceResponse(bool ISuccess, ApplicationDomain.User user)
        {
            _ISuccess = ISuccess;
            _User = user;
        }

    }
}