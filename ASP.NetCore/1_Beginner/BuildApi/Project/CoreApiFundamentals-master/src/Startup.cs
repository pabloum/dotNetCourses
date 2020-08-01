﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Controllers;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CoreCodeCamp
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CampContext>();
        services.AddScoped<ICampRepository, CampRepository>();

        services.AddAutoMapper();

        services.AddApiVersioning(opt => {
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(1, 1);
            opt.ReportApiVersions = true;
            //opt.ApiVersionReader = new QueryStringApiVersionReader(); // By default, and the strign is "api-version"
            //opt.ApiVersionReader = new QueryStringApiVersionReader("ver"); // If you just want to change the string
            //opt.ApiVersionReader = new HeaderApiVersionReader("X-Version"); // Name of the header.
            opt.ApiVersionReader = ApiVersionReader.Combine(
                new HeaderApiVersionReader("X-Version"), // Name of the header.
                new QueryStringApiVersionReader("version", "ver")
            );
            //opt.ApiVersionReader = new UrlSegmentApiVersionReader(); // Remember to change the routes. 

            // This is the same as what we did with the attributes.
            opt.Conventions.Controller<TalksController>()
                .HasApiVersion(1, 0)
                .HasApiVersion(1, 1)
                .Action(c => c.Delete(default(string), default(int)))
                    .MapToApiVersion(1,1)
            ;
        });


        services.AddMvc(opt => opt.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.UseMvc();
    }
  }
}
