using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace OrchardCore.Tests
{
    internal static class StartupRunner
    {
        public static async Task Run(Type startupType, string culture, string expected)
        {
            var webHostBuilder = new WebHostBuilder().UseStartup(startupType);
            var testHost = new TestServer(webHostBuilder);

            var client = testHost.CreateClient();
            var request = new HttpRequestMessage();
            var cookieValue = $"c={culture}|uic={culture}";
            request.Headers.Add("Cookie", $"{CookieRequestCultureProvider.DefaultCookieName}={cookieValue}");

            var response = await client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, await response.Content.ReadAsStringAsync());
        }

        public static async Task <string> RunWithPost(Type startupType, string culture, string expected = null, IEnumerable<KeyValuePair<string, string>> formData = null)
        {
            var webHostBuilder = new WebHostBuilder().UseStartup(startupType);
            var testHost = new TestServer(webHostBuilder);

            var client = testHost.CreateClient();
            client.BaseAddress = new Uri("http://localhost");
            var request = new HttpRequestMessage();
            var cookieValue = $"c={culture}|uic={culture}";
            request.Headers.Add("Cookie", $"{CookieRequestCultureProvider.DefaultCookieName}={cookieValue}");
            var response = await client.GetAsync("/Login");
            response = await client.PostAsync("/Login", content: null);// CreateFormContent(formData));
            
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, content);

            return content;
        }

        private static HttpContent CreateFormContent(IEnumerable<KeyValuePair<string, string>> data)
            => data == null ? null : new FormUrlEncodedContent(data);
    }
}