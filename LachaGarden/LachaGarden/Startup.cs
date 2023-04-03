using MailKit.Net.Smtp;
using AspNetCore.Firebase.Authentication.Extensions;
using Azure;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using DataAccessLayer.Models;
using LachaGarden.Models.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace LachaGarden
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
            services.AddDbContext<lachagardenContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            //Khai bao config cho gmail trong appsetting
            var emailConfig = Configuration
        .GetSection("EmailConfiguration");
            //Khai bao model for gmail
            services.AddSingleton(emailConfig);
            // khai bao controller
            services.AddScoped<IGardenPackageRepository, GardenPackageRepository>();
            services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<ITreeTypeRepository, TreeTypeRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IGardenRepository, GardenRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITreeCareRepository, TreeCareRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<BussinessLayer.ViewModels.GardenViewModel>();
            services.AddScoped<BussinessLayer.ViewModels.RoomViewModel>();
            services.AddScoped<BussinessLayer.ViewModels.TreeViewModel>();
            services.AddScoped<BussinessLayer.ViewModels.RequestViewModel>();
            services.AddScoped<BussinessLayer.ViewModels.ResultViewModels>();
            services.AddScoped<BussinessLayer.ViewModels.TreeCareViewModel>();

            services.AddMvcCore().AddApiExplorer();
            // Add authorization

            services.AddCors();

            services.AddFirebaseAuthentication("https://securetoken.google.com/lachagarden", "lachagarden");
            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "ApiKey",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
            }
            else
            {
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            }

            // Enable CORS before the endpoint routing middleware
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000", "https://lacha.netlify.app", "https://la-cha.vercel.app")
                       .AllowCredentials()
                       .AllowAnyHeader()
                       .AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "My Api v1");
            });
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}