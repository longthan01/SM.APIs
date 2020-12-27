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
    public class DeleteModel : PageModel
    {
        public IApiScopeService ApiScopeService { get; }
        public IMapper Mapper { get; }

        [BindProperty]
        public ApiScopeVM ApiScope { get; private set; }

        public DeleteModel(IApiScopeService apiScopeService, IMapper mapper)
        {
            ApiScopeService = apiScopeService;
            Mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }
            var scope = await this.ApiScopeService.GetAsync(id);
            this.ApiScope = Mapper.Map<ApiScopeVM>(scope);
            return Page();
        }
    }
}
