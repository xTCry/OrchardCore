using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Settings
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        //special menu possibilities for admins
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(S["Configuration"], configuration => configuration
                .Add(S["Settings"], "1", settings => settings
                    .Add(S["General"], "1", entry => entry
                        .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = "general" })
                        .Permission(Permissions.ManageGroupSettings)
                        .LocalNav()
                    )
                )
            );

            return Task.CompletedTask;
        }
    }
}
