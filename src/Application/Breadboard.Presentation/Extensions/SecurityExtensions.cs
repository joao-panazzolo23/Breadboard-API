using BreadBoard.Infra.JWTBearer.Extensions;

namespace Breadboard.Presentation.Extensions;

public static class SecurityExtensions
{
    public static WebApplicationBuilder AddSecurity(this WebApplicationBuilder builder)
    {
        builder.AddJwtBearerDependencies() ;

        builder.Services.AddAuthentication();

        return builder;
    }
}
