using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mnemosyne.Infrastructure.EF.Context;
using Mnemosyne.Infrastructure.EF.Services;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.Web.Extensions;

namespace Mnemosyne.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Authentication
            //services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
            //    .AddAzureADB2C(options => Configuration.Bind("AzureAdB2C", options));
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            #region Database Context
            var databaseConnection = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(databaseConnection,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
            #endregion

            #region Dependency Injection
            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IApplicationContext, ApplicationDbContext>();
            
            services.AddTransient<IRolesQueryService, RolesQueryService>();
            services.AddTransient<ICategoriesQueryService, CategoriesQueryService>();
            services.AddTransient<IUsersQueryService, UsersQueryService>();
            services.AddTransient<INotesQueryService, NotesQueryService>();
            services.AddTransient<IGamesQueryService, GamesQueryService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            #endregion

            services.AddHealthChecks();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mnemosyne Api", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureCustomExceptionMiddleware();

            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mnemosyne API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
