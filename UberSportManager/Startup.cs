using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using USM_EF_Helper;
using USM_Model;
using Microsoft.EntityFrameworkCore;

namespace UberSportManager
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(Configuration["Data:USM:ConnectionString"]));
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IMemberRepository, EFMemberRepository>();
            services.AddTransient<IReservationRepository, EFReservationRepository>();
            services.AddAutoMapper();
            services.AddMvc();             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
