using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace SM.APIs.AuthServer.Services.Implementation
{
    public class ApiScopeService : IApiScopeService
    {
        public ApiScopeService(ConfigurationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ConfigurationDbContext DbContext { get; }

        public async Task<IEnumerable<ApiScope>> GetListAsync()
        {
            var result = this.DbContext.ApiScopes.ToList();
            return result;
        }
    }
}
