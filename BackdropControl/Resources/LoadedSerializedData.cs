using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public static class LoadedSerializedData
    {
        public static string MainWallpaperSettingsDirectory;
        public static TimeSpan MainWallpaperSettingsTimeOfChange;
        public static List<BackgroundPreset> LoadedSerializedPresets;
    }
}
