using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource.Models;
using SM.APIs.AuthServer.Data;
using SM.APIs.AuthServer.Services;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ApiResourceVM> ApiResources { get; set; }
        private ConfigurationDbContext DbContext { get; }
        public IApiResourceService ApiResourceService { get; }

        public IndexModel(IApiResourceService apiResourceService)
        {
            ApiResourceService = apiResourceService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApiResources = (await ApiResourceService.GetListAsync())
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
