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
            PresetName = s;
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

        public int InsertPresetEntry(BackgroundPresetEntry entry)
        {
            int index = 0;

            if (PresetEntries.Count > 0)
            {
                if (PresetEntries.Count == 1)
                    index = PresetEntries[0].TimeOfChange.TotalSeconds > entry.TimeOfChange.TotalSeconds ? 0 : 1;
                else if (PresetEntries.Count > 1)
                { 
                    index = PresetEntries.IndexOf(PresetEntries.FirstOrDefault(s => s.TimeOfChange.TotalSeconds > entry.TimeOfChange.TotalSeconds));
                    if (index == -1)
                        index = PresetEntries.Count - 1;
                }
                PresetEntries.Insert(index, entry); 
            }
            else
                PresetEntries.Add(entry);
            return index;
        }

        public int EditPresetEntry(BackgroundPresetEntry entry, int index)
        {
            for (int i = 0; i < PresetEntries.Count; i++)
            {
                if (entry.TimeOfChange.TotalSeconds <= PresetEntries[i].TimeOfChange.TotalSeconds)
                {
                    PresetEntries[index] = PresetEntries[i];
                    PresetEntries[i] = entry;
                    return i;
                }
            }
            return -1;
        }
        public void RemovePreset(TimeSpan ts)
        {
            PresetEntries.RemoveAll(bp => bp.TimeOfChange == ts);
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
