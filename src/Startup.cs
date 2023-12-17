using AnimalsService.Config;
using AnimalsService.Service;
using Sieve.Services;

namespace AnimalsService
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.ConfigureAuthentication();
      services.AddAuthorization();
      services.ConfigureCors();
      services.ConfigureSwagger();
      services.AddDbContext<ApplicationContext>();
      services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

      services.AddScoped<LegalTypeService>();
      services.AddScoped<OrganizationTypeService>();
      services.AddScoped<MunicipalityService>();
      services.AddScoped<OrganizationService>();
      services.AddScoped<ContractService>();
      services.AddScoped<ContractCostService>();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseCors("Default");
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      app.UseSwagger();
      app.UseSwaggerUI();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.Use(
        async (context, next) =>
        {
          if (context.Request.Path == "/")
          {
            context.Response.Redirect("/swagger");
          }
          else
          {
            await next();
          }
        }
      );
    }
  }
}
