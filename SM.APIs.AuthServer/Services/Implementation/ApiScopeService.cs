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

        public async Task<ApiScope> AddAsync(ApiScope apiScope)
        {
            try
            {
                var result = await this.DbContext.AddAsync(apiScope);
                this.DbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<ApiScope> GetAsync(int? id)
        {
            try
            {
                var result = this.DbContext.ApiScopes.FirstOrDefault(x => x.Id == id);
                return Task.FromResult<ApiScope>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ApiScope>> GetListAsync()
        {
            try
            {
                var result = this.DbContext.ApiScopes.ToList();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ApiScope> UpdateAsync(ApiScope apiScope)
        {
            try
            {
                var result = this.DbContext.ApiScopes.FirstOrDefault(x => x.Id == apiScope.Id);
                if(result != null)
                {
                    result.Name = apiScope.Name;
                    result.DisplayName = apiScope.DisplayName;
                }
                var res = await this.DbContext.SaveChangesAsync();
                if(res == 0)
                {
                    // no item changes
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
