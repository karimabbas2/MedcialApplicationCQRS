using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationPersistence.Dto
{
    public class TokenRequest
    {
        public string? Token {get;set;}
        public string? RefreshToken {get;set;}
    }
}