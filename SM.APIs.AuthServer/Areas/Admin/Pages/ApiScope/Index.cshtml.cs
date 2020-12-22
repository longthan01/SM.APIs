using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;
using SM.APIs.AuthServer.Services;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiScope
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ApiScopeVM ApiScope { get; set; }
        public IEnumerable<ApiScopeVM> ApiScopes { get; set; }
        public IApiScopeService ApiScopeService { get; }
        public IMapper Mapper { get; }

        public IndexModel(IApiScopeService apiScopeService, IMapper mapper)
        {
            ApiScopeService = apiScopeService;
            Mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var scopes = await ApiScopeService.GetListAsync();
            this.ApiScopes = Mapper.Map<IEnumerable<IdentityServer4.EntityFramework.Entities.ApiScope>, IEnumerable<ApiScopeVM>>(scopes);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return null;
        }
    }
}
