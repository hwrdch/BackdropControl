using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public class BackgroundPreset
    {
        private string _PresetName = string.Empty;
        public string PresetName
        {
            get { return _PresetName; }
            set { _PresetName = value; }
        }

        public BackgroundPreset(string s)
        {
            _PresetName = s;
        }

        private List<BackgroundPresetEntry> _PresetEntries = new List<BackgroundPresetEntry>();
        public List<BackgroundPresetEntry> PresetEntries
        {
            get { return _PresetEntries; }
            set { _PresetEntries = value; }
        }

        public void AddPresetEntry(BackgroundPresetEntry entry)
        {
            _PresetEntries.Add(entry);
        }
        public void RemovePreset(string name)
        {
            PresetEntries.RemoveAll(bp => bp.PictureFileName == name);
            //PresetEntries.RemoveAt(index);
            //for (int i = index; i < PresetEntries.Count(); i++)
            //{
            //    PresetEntries[i].PresetIndex -= 1;
            //}
        }

        public bool IsPresetEmpty()
        {
            return PresetEntries.Count == 0;
        }

        public List<string> GetPresetEntryNames()
        {
            List<string> list = new List<string>();
            foreach (BackgroundPresetEntry entry in _PresetEntries)
                list.Add(entry.PictureFileName);
            return list;
        }

        public List<BackgroundPresetEntry> GetPresetEntries()
        {
            return PresetEntries;
        }
    }
}
