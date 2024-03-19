using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.HandleResponse
{
    public class ServiceResponse(bool _ISuccess, string _Message)
    {

        public bool ISuccess { get; set; } = _ISuccess;
        public string? Message { get; set; } = _Message;
    }
}