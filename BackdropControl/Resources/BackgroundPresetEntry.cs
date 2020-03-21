using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackdropControl.Resources
{
    public class BackgroundPresetEntry
    {
        public BackgroundPresetEntry()
        {
            _DirectoryPath = string.Empty;
            TimeOfChange = TimeSpan.MinValue;
            this.ReassignID();
        }

        public BackgroundPresetEntry(string path, TimeSpan dt) : this()
        {
            _DirectoryPath = path;
            TimeOfChange = dt;
            _PictureFileName = Path.GetFileName(path);

            ImageWatcher.Path = DirectoryPath;
            ImageWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
        }
        public BackgroundPresetEntry(string path, TimeSpan dt, string id)
        {
            _DirectoryPath = path;
            TimeOfChange = dt;
            _PictureFileName = Path.GetFileName(path);
            EntryID = id;

            ImageWatcher.Path = DirectoryPath;
            ImageWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
        }

        private FileSystemWatcher ImageWatcher;

        public string EntryID;

        private string _PictureFileName;
        public string PictureFileName
        {
            get { return _PictureFileName; }
            set { _PictureFileName = value; }
        }

        private string _DirectoryPath;
        public string DirectoryPath 
        { 
            get { return _DirectoryPath; }
            set { 
                _DirectoryPath = value;
                _PictureFileName = Path.GetFileName(value);
                ImageWatcher.Path = value;
            }
        }

        private TimeSpan _TimeOfChange;
        public TimeSpan TimeOfChange
        {
            get { return _TimeOfChange; }
            set { _TimeOfChange = value; }
        }

        public string GetPresetEntryFileName()
        {
            return Path.GetFileNameWithoutExtension(_DirectoryPath);
        }

        public string GetTimeOfChangeString()
        {
            string time = string.Empty;
            time = TimeOfChange.ToString();
            time.Insert(2, ":");
            time.Insert(5, ":");
            return time;
        }

        public bool BackgroundExists()
        {
            return (System.IO.Directory.Exists(_DirectoryPath));
        }

        public void ReassignID()
        {
            Random random = new Random();
            EntryID = random.Next(1, 1000000000).ToString();
        }
    }
}
