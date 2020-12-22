using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;

namespace SM.APIs.AuthServer.Services
{
    public interface IApiScopeService
    {
        Task<IEnumerable<ApiScope>> GetListAsync();
        Task<ApiScope> AddAsync(ApiScope apiScope);
        Task<ApiScope> GetAsync(int? id);
        Task<ApiScope> UpdateAsync(ApiScope apiScope);
    }
}
