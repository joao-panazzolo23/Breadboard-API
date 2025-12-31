using BreadBoard.Infra.JWTBearer.Extensions;

namespace Breadboard.Presentation.Extensions;

public static class SecurityExtensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtBearerDependencies(configuration).AddAuthentication();
        return services;
    }
}
