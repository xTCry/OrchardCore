using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using OrchardCore.Localization;
using OrchardCore.Tests;
using Xunit;

namespace OrchardCore.Tests.Localization
{
    public class DataAnnotationsLocalizationTests
    {
        [Fact]
        public async Task LocalizerReturnsDataAnnotationsTranslationFromInnerClass()
            => await StartupRunner.Run(typeof(DataAnnotationsLocalizationStartup),"ar", "مرحبا");

        public class DataAnnotationsLocalizationStartup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
                services.AddLocalization();
                services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization/PoFiles");
                services.Replace(ServiceDescriptor.Singleton<ILocalizationFileLocationProvider, StubPoFileLocationProvider>());
            }

            public void Configure(
                IApplicationBuilder app,
                IStringLocalizer<Model> localizer)
            {
                var supportedCultures = new[] { "ar", "en" };
                app.UseRequestLocalization(options =>
                    options
                        .AddSupportedCultures(supportedCultures)
                        .AddSupportedUICultures(supportedCultures)
                        .SetDefaultCulture("ar")
                );

                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync(localizer["Hello"]);
                });
            }
        }

        public class Model
        {
            [Display(Name ="مرحبا")]
            public string Hello { get; set; }
        }
    }
}
