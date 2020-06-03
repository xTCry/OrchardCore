* Admin/
  * AdminSettings.cs
  > Defines the AdminSettings class which contains the flag DisplayMenuFilter ( (~) flag specifying whether to display the menu
  filter).
* Controllers/
  * AdminController.cs
    > AdminController.Index() returns an View() result (IActionResult)
* Drivers/
  * AdminSiteSettingsDisplayDriver.cs
    > AdminSiteSettingsDisplayDriver class allows you to change the model (EditAsync()) or update the settings (UpdateAsync()), 			returning the task with a display result
* Properties/ (skipped)
* ViewModels/
  * AdminSettingsViewModel.cs
    > Defines the class AdminSettingsViewModel with the flag field DisplayMenuFilter ( (~) to display the menu filter)
* Views/: cshtml templates
* AdminAreaControllerRouteMapper.cs
  > Defines the class AdminAreaControllerRouteMapper whitch forms the url pattern and tries to instantiate it by descriptor 
* AdminFilter.cs
  > Intercepts any request to check whether it applies to the admin site. If so it marks the request as such and ensures the         user as the right to access it.
* AdminPageRouteModelConvention.cs
  - Apply(): Trying to apply the specified prefix to the route template from the model
* AdminPageRouteModelProvider.cs
* AdminThemeSelector.cs
  > "Provides the theme defined in the site configuration for the current scope (request). The same "ThemeSelectorResult" is         returned if called multiple times during the same scope.
  - GetThemeAsync()
* AdminThemeService.cs: get/set admin theme, get admin theme name
* AdminZoneFilter.cs:
  > "This filter makes an controller that starts with Admin and Razor Pages in /Pages/Admin folder behave as it had the             "AdminAttribute"
* Permissions.cs
  - GetDefaultStereotypes()
    > administrator/editor/moderator/author/contributor
  - GetPermissions() -> AccessAdminPanel
* PermissionsAdminSettings.cs
  > permissions: Administrator: ManageAdminSettings
* Startup.cs
  - Startup.ConfigureServices()
  - AdminPagesStartup
    - AdminPagesStartup(): set admin options
    - ConfigureServices(): addnig options conventions
