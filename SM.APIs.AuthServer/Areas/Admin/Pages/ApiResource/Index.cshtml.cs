using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SM.APIs.AuthServer.Data;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource
{
    public class IndexModel : PageModel
    {
        public class ApiResourceVM
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public IEnumerable<string> Scopes { get; set; }
        }
        public IEnumerable<ApiResourceVM> ApiResources { get; set; }
        private ConfigurationDbContext DbContext { get; }

        public IndexModel(ConfigurationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ApiResources = DbContext.ApiResources.Include(a => a.Scopes)
                .Select(x => new ApiResourceVM()
                {
                    Scopes = x.Scopes.Select(y => y.Scope),
                    DisplayName = x.DisplayName,
                    Name = x.Name
                });
            return Page();
        }
    }
}
