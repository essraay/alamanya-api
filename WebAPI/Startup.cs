using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var key = "D2E2fc3TH2HN5K6PbNluKFDJ6RJjSYS9mYsCMSKvnDGcSfnLXSioZB6IdfymCuG5";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(key));


            services.AddSingleton<IAgeRangeService, AgeRangeManager>();
            services.AddSingleton<IAgeRangeDal, AgeRangeDal>();

            services.AddSingleton<IApplicationFormService, ApplicationFormManager>();
            services.AddSingleton<IApplicationFormDal, ApplicationFormDal>();

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, CategoryDal>();

            services.AddSingleton<IDistrictService, DistrictManager>();
            services.AddSingleton<IDistrictDal, DistrictDal>();

            services.AddSingleton<IDocumentFileService, DocumentFileManager>();
            services.AddSingleton<IDocumentFileDal, DocumentFileDal>();

            services.AddSingleton<IGenderService, GenderManager>();
            services.AddSingleton<IGenderDal, GenderDal>();

            services.AddSingleton<IGermanLanguageLevelService, GermanLanguageLevelManager>();
            services.AddSingleton<IGermanLanguageLevelDal, GermanLanguageLevelDal>();

            services.AddSingleton<IGraduationService, GraduationManager>();
            services.AddSingleton<IGraduationDal, GraduationDal>();

            services.AddSingleton<INationalityService, NationalityManager>();
            services.AddSingleton<INationalityDal, NationalityDal>();

            services.AddSingleton<IOtherLanguageService, OtherLanguageManager>();
            services.AddSingleton<IOtherLanguageDal, OtherLanguageDal>();

            services.AddSingleton<IProvincesService, ProvincesManager>();
            services.AddSingleton<IProvincesDal, ProvincesDal>();

            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, UserDal>();

            services.AddCors(opt => opt.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()
            ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPP v1"));
            }

            app.UseDefaultFiles();
            app.UseSpaStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSpa(spa => { });
        }
    }
}
