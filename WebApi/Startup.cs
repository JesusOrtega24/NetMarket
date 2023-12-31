﻿using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.Interfaces;
using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Logic;
using WebApi.DTOs;
using WebApi.Middleware;

namespace WebApi;

public class Startup
{
    public Startup( IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices (IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));

        services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

        services.AddDbContext<MarketDBContext>(opt =>{
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddControllers();

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsRule", rule =>
            {
                rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
            });
        });
    }

    public void Configure(IApplicationBuilder App, IWebHostEnvironment env)
    {
        //if (env.IsDevelopment())
        //{
        //    App.UseDeveloperExceptionPage();
        //}

        App.UseMiddleware<ExceptionMiddleware>();

        App.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

        App.UseRouting();
        App.UseCors("CorsRule");
        App.UseAuthentication();
        App.UseAuthorization();
        App.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
