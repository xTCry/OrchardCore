using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.Application.Pages;
using Xunit;

namespace OrchardCore.Tests.Localization
{
    public class DataAnnotationsLocalizationTests
    {
        [Fact]
        public async Task LocalizerReturnsDataAnnotationsTranslation()
        {
            var content = await StartupRunner.RunWithPost(typeof(DataAnnotationsLocalizationStartup), "ar", formData: new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Name", null)
            });

            Assert.Contains("حقل الإسم مطلوب.", content);
        }
    }
}
