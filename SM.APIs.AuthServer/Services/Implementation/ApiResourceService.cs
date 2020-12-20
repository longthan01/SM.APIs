using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource.Models;

namespace SM.APIs.AuthServer.Services.Implementation
{
    public class ApiResourceService : IApiResourceService
    {
        public ApiResourceService(ConfigurationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ConfigurationDbContext DbContext { get; }

        public async Task<ApiResource> AddAsync(ApiResourceVM apiResources)
        {
            var scopes = this.DbContext.ApiScopes.Where(x => apiResources.Scopes.Any(y => y == x.Name)).ToList();
            var res = this.DbContext.ApiResources.Add(new ApiResource()
            {
                Name = apiResources.Name,
                DisplayName = apiResources.DisplayName,
                Scopes = apiResources.Scopes.Select(x => new ApiResourceScope()
                {
                    Scope = x
                }).ToList()
            });
            await DbContext.SaveChangesAsync();
            return res.Entity;
        }

        public Task<IEnumerable<ApiResource>> GetListAsync()
        {
            var result = DbContext.ApiResources.Include(a => a.Scopes)
                .ToList();
            return Task.FromResult<IEnumerable<ApiResource>>(result);
        }
    }
}
