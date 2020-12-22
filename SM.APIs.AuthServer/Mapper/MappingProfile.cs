using System;
using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;

namespace SM.APIs.AuthServer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApiScope, ApiScopeVM>();
            CreateMap<ApiScopeVM, ApiScope>();

            CreateMap<ApiResource, ApiResourceVM>();
            CreateMap<ApiResourceVM, ApiResource>();
        }
    }
}
