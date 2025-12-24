
namespace Breadboard.Application.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UsePipelines(this WebApplication app)
    {
        app.UseAuthentication()
           .UseAuthorization()
           .UseStaticFiles()
           .UseHttpsRedirection()
           //use routing is supposed to be the last since it breaks method chaining
           .UseRouting();

        return app;
    }
}
