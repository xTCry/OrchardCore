using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace OrchardCore.Localization.PortableObject
{
    internal class PortableObjectMvcDataAnnotationsLocalizationOptions : IConfigureOptions<MvcDataAnnotationsLocalizationOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PortableObjectMvcDataAnnotationsLocalizationOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Configure(MvcDataAnnotationsLocalizationOptions options)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var localizer = serviceProvider.GetService<IStringLocalizerFactory>().Create(typeof(PortableObjectStringLocalizer));

                options.DataAnnotationLocalizerProvider = (t, f) => localizer;
            }
        }
    }
}
