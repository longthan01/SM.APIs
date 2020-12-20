using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;

namespace SM.APIs.AuthServer.Services
{
    public interface IApiScopeService
    {
        Task<IEnumerable<ApiScope>> GetListAsync();
    }
}
