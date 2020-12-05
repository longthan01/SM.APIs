// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SM.APIs.AuthServer.Data;
using Microsoft.AspNetCore.Identity;

namespace SM.APIs.AuthServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            //services.AddControllersWithViews();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("ApplicationDbContextConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            string connectionString = Configuration.GetConnectionString("DefaultConnectionString");
            var migrationsAssembly = typeof(SeedData).GetTypeInfo().Assembly.GetName().Name;

            var builder = services.AddIdentityServer(options =>
            {
                //options.Events.RaiseErrorEvents = true;
                //options.Events.RaiseInformationEvents = true;
                //options.Events.RaiseFailureEvents = true;
                //options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder =>
                {
                    builder.UseSqlServer(connectionString, sql =>
                    sql.MigrationsAssembly(migrationsAssembly));
                };
            })// this adds the operational data from DB (codes, tokens, consents)
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));

                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
            })
            .AddAspNetIdentity<IdentityUser>();

            // not recommended for production - you need to store your key material somewhere secure

            builder.AddDeveloperSigningCredential();
            //services.AddAuthentication();
            //services.AddAuthorization();
            //services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //SeedData.EnsureSeedData(app);

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
