using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class CustomException : ApplicationException
    {

        public readonly string? _Message;
        public readonly List<string>? _errros;
        public CustomException(string Message)
        {
            _Message = Message;
        }

        public CustomException(List<string> errors)
        {
            _errros = errors;
        }
    }
}