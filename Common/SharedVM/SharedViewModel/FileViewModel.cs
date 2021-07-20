using System;

namespace SharedViewModel
{
    public class FileViewModel : BaseViewModel
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        private char _driveLetter;

        public char DriveLetter
        {
            get { return _driveLetter; }
            set
            {
                _driveLetter = value;
                OnPropertyChanged();
            }
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _lastChanged;

        public DateTime? LastChanged
        {
            get { return _lastChanged; }
            set
            {
                _lastChanged = value;
                OnPropertyChanged();
            }
        }


        public FileViewModel(Models.File file)
        {
            FileName = file.FileName;
            Path = file.Path;
            DriveLetter = file.DriveLetter;
            Content = file.Content;
            LastChanged = file.LastChanged;
        }
    }
}
