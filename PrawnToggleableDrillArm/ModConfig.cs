using Nautilus.Json;
using Nautilus.Options.Attributes;

namespace PrawnToggleableDrillArm
{
    [Menu(PluginInfo.PLUGIN_NAME)]
    public class ModConfig : ConfigFile
    {
        [Toggle("Enable toggleable drill arm for the Prawn")]
        public bool IsEnabled = true;
    }
}
