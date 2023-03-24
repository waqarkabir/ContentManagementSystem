using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            MvcOptions mvcOptions = new MvcOptions();

            //Note: To use Xml Serializer Formatter, just chain another method name "AddXmlSerializerFormatters()"
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                mvcOptions.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 3;
                })
                .AddEntityFrameworkStores<AppDbContext>();
            //Alternate method to Apply Password complexity
            //services.Configure<IdentityOptions>(options =>
            //        options.Password.RequiredLength = 3
            //    );



            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddScoped <IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                
                app.UseExceptionHandler("/Error");

                //Simple Server 404 Error
                //app.UseStatusCodePages();

                //Redirection technique not recommended
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                
                //ReExecute technique recommended
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

               
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseMvc(routes =>
            {
                routes.MapRoute("default", /*owner name can be embedded like cms/*/"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
