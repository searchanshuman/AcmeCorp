using AcmeCorp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorp.API.Services
{
    public interface IAuthenticateService
    {
        public User Authenticate(string userName, string password);
    }
}
