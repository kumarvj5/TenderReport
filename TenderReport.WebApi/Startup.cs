using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TenderReport.Core.Mapper;
using TenderReport.Core.Services;
using TenderReport.Data.Entities;
using TenderReport.Data.Repositories;
using TenderReport.WebApi.ExceptionMiddleware;

namespace TenderReport.WebApi
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
            services.AddControllers();
            services.AddDbContext<TendersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),opts =>
            {
                opts.EnableRetryOnFailure();
            }));

            services.AddScoped<ITenderTypeService, TenderTypeService>();
            services.AddScoped<ITenderTypeRepository, TenderTypeRepository>();

            services.AddScoped<IExpenditureTypeService, ExpenditureTypeService>();
            services.AddScoped<IExpenditureTypeRepository, ExpenditureTypeRepository>();

            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            //mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TenderReportProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tender API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
