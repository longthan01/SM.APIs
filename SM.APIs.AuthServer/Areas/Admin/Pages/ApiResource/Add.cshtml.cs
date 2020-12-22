using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;
using SM.APIs.AuthServer.Services;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public ApiResourceVM ApiResources { get; set; }
        public IEnumerable<ApiScopeVM> ApiScopes { get; set; }

        public IApiScopeService ApiScopeService { get; }
        public IApiResourceService ApiResourceService { get; }

        public AddModel(IApiScopeService apiScopeService, IApiResourceService apiResourceService)
        {
            ApiScopeService = apiScopeService;
            ApiResourceService = apiResourceService;
        }
        public async Task OnGet()
        {
            this.ApiScopes = (await ApiScopeService.GetListAsync()).Select(x => new ApiScopeVM()
            {
                Name = x.Name,
                DisplayName = x.DisplayName
            });
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                await ApiResourceService.AddAsync(ApiResources);
            }
            return RedirectToPage("Index");
        }
    }
}
