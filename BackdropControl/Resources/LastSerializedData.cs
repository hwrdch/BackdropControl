using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public static class LastSerializedData
    {
        public static string MainWallpaperSettingsDirectory;
        public static TimeSpan MainWallpaperSettingsTimeOfChange;

        private static List<BackgroundPreset> _LoadedSerializedPresets;
        public static List<BackgroundPreset> LoadedSerializedPresets
        {
            get
            {
                return _LoadedSerializedPresets;
            }
            set
            {
                _LoadedSerializedPresets = value;
            }
        }

        static LastSerializedData()
        {
            MainWallpaperSettingsDirectory = string.Empty;
            MainWallpaperSettingsTimeOfChange = new TimeSpan();
            LoadedSerializedPresets = new List<BackgroundPreset>();
        }
    }
}
