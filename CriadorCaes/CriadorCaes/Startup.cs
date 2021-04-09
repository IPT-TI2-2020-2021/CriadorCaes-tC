using CriadorCaes.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes {
   public class Startup {
      public Startup(IConfiguration configuration) {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services) {
         services.AddControllersWithViews();

         // configurar a aplica��o (o nosso sistema) para aceder � Base de Dados
         // e de que tipo ser�
         services.AddDbContext<CriadorCaesBD>(    // especifica q a BD 'CriadorCaesBD dever� ser usada pelo nosso projeto
            options => options.UseSqlServer(      // a BD ser� do tipo MS SqlServer
               Configuration.GetConnectionString("DefaultConnection")  // onde est� especificada a BD?
               )
            );


      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
         if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
         }
         else {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}
