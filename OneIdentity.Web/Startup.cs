namespace OneIdentity.Web
{
   using System.IO;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Hosting;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   using OneIdentity.Business;
   using OneIdentity.Db.Models;
   using Swashbuckle.AspNetCore.Swagger;

   public class Startup
   {
      private const string ApiName = "OneIdentity";
      private const string ApiVersion = "v1";
      
      public Startup(IConfiguration configuration)
      {
         this.Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to configure the HTTP reOneIdentity pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseStaticFiles();

         app.UseSwagger();

         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiName} {ApiVersion}");
         });

         app.UseMvc(
            routes =>
            {
               routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
            });
      }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         var config = BuildConfig();

         services.AddMvc();

         services.AddSwaggerGen(c => {
            c.SwaggerDoc(ApiVersion, new Info { Title = ApiName, Version = ApiVersion });
         });

         services.AddSingleton<IHelper<User>>(new UserHelper<User>(config["connectionString"], config["database"]));
      }

      private static IConfigurationRoot BuildConfig()
      {
         var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Json");
         return builder.Build();
      }
   }
}