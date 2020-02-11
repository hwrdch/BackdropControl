using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public static class SharedObjects
    {
        public static string DEFAULT_PRESET_PATH;
        public static string DEFAULT_APP_LOCATION_PATH;
        public static BindingList<BackgroundPreset> ListOfLoadedPresets;
        public static BackgroundPreset LastUsedPreset;
        public static BindingList<string> LoadedPresetNames;

        static SharedObjects()
        {
            DEFAULT_PRESET_PATH = string.Empty;
            DEFAULT_APP_LOCATION_PATH = string.Empty;
            ListOfLoadedPresets = new BindingList<BackgroundPreset>();
            LoadedPresetNames = new BindingList<string>();
        }
    }
}
