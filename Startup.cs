using marcore.api.Data;
using marcore.api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using marcore.Entities;
using marcore.Interfaces;
using marcore.Services;
using marcore.Extensions;
using marcore.Middleware;

namespace marcore.api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config);
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            // WARNING: In development moved into  !!!
            // services.AddApplicationServices(_config);
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(x =>
            {
                x.UseLazyLoadingProxies();
                x.UseSqlServer(_config.GetConnectionString("marDB"));
            });
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddIdentityServices(_config);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                options.AddPolicy("VipOnly", policy => policy.RequireRole("VIP"));
                options.AddPolicy("RequireMarRole", policy => policy.RequireRole("Mar"));
                options.AddPolicy("RequireMarEditRole", policy => policy.RequireRole("Maredit"));
            });

            // services.AddControllers();
            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddCors();
            services.AddAutoMapper(typeof(CompanyRepository).Assembly);
            services.Configure<CloudinarySettings>(_config.GetSection("CloudinarySettings"));
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            // services.Configure<FacebookAppSettings>(Configuration.GetSection("Authentication:Facebook"));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IVsoftMarRepository, VsoftMarRepository>();
            services.AddScoped<LogUserActivity>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarIntegraal API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            // app.UseDeveloperExceptionPage();
            // }
            // else
            // {
            // app.UseExceptionHandler(builder =>
            // {
            // builder.Run(async context =>
            // {
            // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // 
            // var error = context.Features.Get<IExceptionHandlerFeature>();
            // if (error != null)
            // {
            // context.Response.AddApplicationError(error.Error.Message);
            // await context.Response.WriteAsync(error.Error.Message);
            // }
            // });
            // });
            // app.UseHsts();
            // }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                /* .WithOrigins(
                    "https://mijn.rv.be",
                    "https://portfolio.rv.be",
                    "https://marintegraal.vsoft.be",
                    "http://localhost:4200",
                    "http://localhost:8100")); */
                .AllowAnyOrigin()); // needed for MS Identity authentication on Android app

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarIntegraal API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
