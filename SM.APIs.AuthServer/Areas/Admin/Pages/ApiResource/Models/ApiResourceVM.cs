using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.ApiResource.Models
{
    public class ApiResourceVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public IEnumerable<string> Scopes { get; set; }
    }
}
