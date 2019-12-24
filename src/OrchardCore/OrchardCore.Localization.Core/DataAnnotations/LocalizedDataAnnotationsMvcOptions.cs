using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace OrchardCore.Localization.DataAnnotations
{
    internal class LocalizedDataAnnotationsMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LocalizedDataAnnotationsMvcOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Configure(MvcOptions options)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var localizer = serviceProvider.GetService<IStringLocalizerFactory>().Create(typeof(LocalizedDataAnnotationsMvcOptions));

                options.ModelMetadataDetailsProviders.Add(new LocalizedValidationMetadataProvider(localizer));
            }
        }
    }
}
