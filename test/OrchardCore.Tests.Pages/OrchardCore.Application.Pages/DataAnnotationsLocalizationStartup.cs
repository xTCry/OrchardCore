using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OrchardCore.Application.Pages
{
    public class DataAnnotationsLocalizationStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLocalization();
            services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
            //services.Replace(ServiceDescriptor.Singleton<ILocalizationFileLocationProvider, StubPoFileLocationProvider>());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            var supportedCultures = new[] { "ar", "en" };
            app.UseRequestLocalization(options =>
                options
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures)
                    .SetDefaultCulture("ar")
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
