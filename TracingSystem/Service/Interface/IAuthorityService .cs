using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TracingSystem.Models;

namespace TracingSystem.Service
{
    public interface IAuthorityService
    {
        public ServiceResult Login(string account, string pd);
    }
}
