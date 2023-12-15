using AnimalsService.Config;
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
      services.AddScoped<SieveProcessor>();
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
    }
  }
}
