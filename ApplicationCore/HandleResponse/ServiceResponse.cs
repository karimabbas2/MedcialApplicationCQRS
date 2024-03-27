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
        public IList<string>? _Roles;
        public ApplicationDomain.User _User;
        public ServiceResponse(bool ISuccess, string Message)
        {
            _ISuccess = ISuccess;
            _Message = Message;
        }

        public ServiceResponse(bool ISuccess, string Message, ApplicationDomain.User user, IList<string>? Roles)
        {
            _ISuccess = ISuccess;
            _Message = Message;
            _Roles = Roles;
            _User = user;
        }

    }
}