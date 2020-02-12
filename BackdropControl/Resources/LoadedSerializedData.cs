using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public static class LastSavedSerializedData
    {
        public static string MainWallpaperSettingsDirectory;
        public static TimeSpan MainWallpaperSettingsTimeOfChange;
        public static List<BackgroundPreset> LoadedSerializedPresets;

        static LastSavedSerializedData()
        {
            MainWallpaperSettingsDirectory = string.Empty;
            MainWallpaperSettingsTimeOfChange = new TimeSpan();
            LoadedSerializedPresets = new List<BackgroundPreset>();
        }
    }
}
