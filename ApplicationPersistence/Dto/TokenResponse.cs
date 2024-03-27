using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationPersistence.Dto
{
    public class TokenResponse
    {
        public string? Token {get;set;}
        public RefreshToken? RefreshToken {get;set;}
        public DateTime TokenExpire {get;set;}
        public string? Message {get;set;}
    }
}