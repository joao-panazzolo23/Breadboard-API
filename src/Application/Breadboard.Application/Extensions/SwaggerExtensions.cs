
namespace Breadboard.Application.Extensions
{
   public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication AddSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || true)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Breadboard API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            return app;
        }
    }
}