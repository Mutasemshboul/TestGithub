using learn.core.domain;
using learn.core.Repoisitory;
using learn.core.service;
using learn.infra.domain;
using learn.infra.Repoisitory;
using learn.infra.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGithub
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
            services.AddScoped<IDBContext, DbContext>();
            services.AddScoped<Icategoryrepoisitorycs, categoryrepoisitory>();
            services.AddScoped<Icourse_apirepoisitory, course_apirepoisitory>();

            services.AddScoped<Icategoryservice, categoryservice>();
            services.AddScoped<Icourseservice, courserservice>();

            services.AddScoped<Icourse_api_reposisitory, courseApi_repoisitory>();
            services.AddScoped<Icourse_api_service,courseApiservice>();

            services.AddScoped<IstudentRepo, studentrRepo>();
            services.AddScoped<Istudentservice, studentservice>();

            services.AddScoped<Iemp_apirepositiory, emp_apirepoisitory>();
            services.AddScoped<Iemp_service, emp_api_service>();

            services.AddScoped<Idepartment_apirepo, department_repo>();
            services.AddScoped<Idepartment_service, departmentservice>();
            
            services.AddScoped<Iemployee_apirepo, employee_repo>();
            services.AddScoped<Iempolyee_sevice, employeeservice>();

            services.AddScoped<Itask_apirepo, task_repo>();
            services.AddScoped<Itask_service, taskservice>();
            
            services.AddScoped<Ienrollmenttask_apirepo, enrollmenttask_repo>();
            services.AddScoped<Ienrollmenttask_service, enrollmaenttaskservice>();

            services.AddScoped<Idate_apirepo, date_repo>();
            services.AddScoped<Idateservice, dateservice>();

            services.AddScoped<IAuthentication, authentication>();
            services.AddScoped<IAuthenticationservice, authenticationservice>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

             ).AddJwtBearer(y =>
             {
                 y.RequireHttpsMetadata = false;
                 y.SaveToken = true;
                 y.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                     ValidateIssuer = false,
                     ValidateAudience = false,

                 };


             });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
