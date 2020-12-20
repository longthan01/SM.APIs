using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SM.APIs.AuthServer.Areas.Admin.Pages
{
    public static class ManageNavPages
    {
        public static string ApiResource => "ApiResource";

        public static string ApiResourceNavlass(ViewContext viewContext) => PageNavClass(viewContext, ApiResource);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
