using System.Threading.Tasks;

namespace OrchardCore.Themes.Services
{
    public interface IThemeService
    {
        //allows you to turn on and off themes
        Task DisableThemeFeaturesAsync(string themeName);
        Task EnableThemeFeaturesAsync(string themeName);
    }
}
