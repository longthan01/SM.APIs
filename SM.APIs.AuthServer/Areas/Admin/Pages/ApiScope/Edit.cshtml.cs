using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;
using SM.APIs.AuthServer.Services;
using SM.APIs.AuthServer.Validators;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiScope
{
    public class EditModel : PageModel
    {
        public EditModel(IApiScopeService apiScopeService, IMapper mapper)
        {
            ApiScopeService = apiScopeService;
            Mapper = mapper;
        }

        public IApiScopeService ApiScopeService { get; }
        public IMapper Mapper { get; }
        [BindProperty]
        [IdValidator]
        public ApiScopeVM ApiScope { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }
            var scope = await this.ApiScopeService.GetAsync(id);
            this.ApiScope = Mapper.Map<ApiScopeVM>(scope);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var scope = await this.ApiScopeService.UpdateAsync(Mapper.Map<IdentityServer4.EntityFramework.Entities.ApiScope>(this.ApiScope));
            }
            return RedirectToPage("Index");
        }
    }
}
