using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public class BackgroundPresetEntry
    {
        public BackgroundPresetEntry (string s, DateTime dt)
        {

        }

        private string _DirectoryPath;
        public string DirectoryPath 
        { 
            get { return _DirectoryPath; }
            set{ _DirectoryPath = value; }
        }

        private DateTime _TimeOfChange;
        public DateTime TimeOfChange
        {
            get { return _TimeOfChange; }
            set { _TimeOfChange = value; }
        }

        private int _PresetIndex;
        public int PresetIndex
        {
            get { return PresetIndex; }
            set { _PresetIndex = value; }
        }

        public bool BackgroundExists()
        {
            return (System.IO.Directory.Exists(_DirectoryPath));
        }
    }
}
