using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using Microsoft.EntityFrameworkCore;
using DAL.Model;

namespace WebApi
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

           
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            services.AddMvc();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddScoped(typeof(IitemBAL), typeof(itemBAL));
            services.AddScoped(typeof(IitemDAL), typeof(ItemDAL));
            services.AddDbContext<tbl_itemsContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-GBRPOLT\SQLEXPRESS;Initial Catalog=tbl_items;Integrated Security=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            //cors  
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
        
            });

           
        }
    }
}
