using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;

namespace SM.APIs.AuthServer.Services
{
    public interface IApiResourceService
    {
        Task<IEnumerable<ApiResource>> GetListAsync();
        Task<ApiResource> AddAsync(ApiResourceVM apiResources);
    }
}
