using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public class BackgroundPreset
    {
        private string _PresetName;
        public string PresetName
        {
            get { return _PresetName; }
            set { _PresetName = value; }
        }
        private List<BackgroundPresetEntry> _PresetEntries;
        public List<BackgroundPresetEntry> PresetEntries
        {
            get { return _PresetEntries; }
            set { _PresetEntries = value; }
        }

        public void AddPresetEntry(BackgroundPresetEntry entry)
        {
            _PresetEntries.Add(entry);
        }
        public void RemovePreset(int index)
        {
            PresetEntries.RemoveAt(index);
            for (int i = index; i < PresetEntries.Count(); i++)
            {
                PresetEntries[i].PresetIndex -= 1;
            }
        }
    }
}
