namespace Breadboard.Presentation.Extensions;

public static class FileExtensions
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-10.0
    /// 
    /// With .NET 9 release, Static files received a new directive called by IApplicationBuilder.MapStaticFiles
    /// It does exactly the same as UseDefaultFiles + UseStaticFiles BUT it is much more sofisticated and automatic
    /// 
    /// "Build-time compression for all the assets in the app, including JavaScript (JS) and stylesheets but excluding image and font assets that are already compressed. 
    /// Gzip (Content-Encoding: gz) compression is used during development. Gzip and Brotli (Content-Encoding: br) compression are both used during publish.
    /// Fingerprinting for all assets at build time with a Base64-encoded string of the SHA-256 hash of each file's content. This prevents reusing an old version of a file, 
    /// even if the old file is cached. Fingerprinted assets are cached using the immutable directive, which results in the browser never requesting the asset again until it changes. 
    /// For browsers that don't support the immutable directive, a max-age directive is added.
    /// Even if an asset isn't fingerprinted, content based ETags are generated for each static asset using the fingerprint hash of the file as the ETag value. 
    /// This ensures that the browser only downloads a file if its content changes (or the file is being downloaded for the first time).
    /// Internally, the framework maps physical assets to their fingerprints, which allows the app to:
    /// Find automatically-generated assets, such as Razor component scoped CSS for Blazor's CSS isolation feature and JS assets described by JS import maps.
    /// Generate link tags in the<head> content of the page to preload assets."
    /// 
    /// Translating into human language, it detects automatically static files declared within assembly, compreesing and caching them
    ///
    /// And also, ShortCircuit interrupts pipeline execution, preventing static files to get inside middlewares later. 
    /// All other requests continue to be processed, since ShortCircuit just ignores static files only.
    /// 
    /// This should improve overall performance AND (MAYBE) don't break elsewhere. (I said Maybe.)
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication UseStaticFiles(this WebApplication app)
    {
        app.MapStaticAssets().ShortCircuit();

        return app;
    }
}