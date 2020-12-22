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
    public class AddModel : PageModel
    {
        [BindProperty]
        public ApiScopeVM ApiScope { get; set; }
        public IApiScopeService ApiScopeService { get; }
        public IMapper Mapper { get; }

        public AddModel(IApiScopeService apiScopeService, IMapper mapper)
        {
            ApiScopeService = apiScopeService;
            Mapper = mapper;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await ApiScopeService.AddAsync(Mapper.Map<IdentityServer4.EntityFramework.Entities.ApiScope>(this.ApiScope));
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
