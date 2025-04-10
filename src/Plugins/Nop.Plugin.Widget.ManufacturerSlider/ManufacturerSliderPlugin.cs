using Nop.Core;
using Nop.Plugins;
using Nop.Services.Cms;
using Nop.Services.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Widget.ManufacturerSlider
{
    public class ManufacturerSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;

        public ManufacturerSliderPlugin(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "ManufacturerSlider";
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string>
            {
                PublicWidgetZones.HomepageTop,
                PublicWidgetZones.HomepageBeforeCategories
            });
        }

        public override async Task InstallAsync()
        {
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.ManufacturerSlider.Title"] = "Our Brands"
            });

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.ManufacturerSlider");
            await base.UninstallAsync();
        }
    }
}