using AutoMapper;
using ManageStore.BusinessAccess;
using ManageStore.BusinessAccess.Helper;
using ManageStore.BusinessAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManageStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDataBase(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductLogRepository, ProductLogRepository>();
            services.AddScoped<IBillingRepository, BillingRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductLikeRepository, ProductLikeRepository>();
            services.AddHttpContextAccessor();
            services.AddSingleton<ITokenFactory, JwtFactory>();

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "ManageStoreOpenAPISpecification",
                    new Info
                    {
                        Title = "Manage Store API",
                        Version = "1.0.0",
                        Contact = new Contact
                        {
                            Email = "wilver.melendez@gmail.com",
                            Name = "Wilver Melendez",
                            Url = "https://github.com/wilvermelendez/ManageStore"
                        }
                    }
                );
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ManageStore.xml"));
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ManageStore.Models.xml"));
                setupAction.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                setupAction.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
                setupAction.DescribeAllEnumsAsStrings();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/ManageStoreOpenAPISpecification/swagger.json",
                    "Manage Store API"
                );
                setupAction.RoutePrefix = string.Empty;
            });

            app.UseMvc();

        }

        private void ConfigureDataBase(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext.ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
