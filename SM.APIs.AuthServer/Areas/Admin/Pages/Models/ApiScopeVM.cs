using System;
using System.ComponentModel.DataAnnotations;

namespace SM.APIs.AuthServer.Areas.Admin.Pages.Models
{
    public class ApiScopeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
