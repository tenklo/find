using Contracts.Common.SharedVM;
using System;

namespace SharedViewModel
{
    public class FileViewModel : BaseViewModel, IFileViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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

        private string _fileType;

        public string FileType
        {
            get { return _fileType; }
            set
            {
                _fileType = value;
                OnPropertyChanged();
            }
        }

        public IFileViewModel CreateFileViewModel(Models.File file)
        {
            Name = file.Name;
            Path = file.Path;
            DriveLetter = file.DriveLetter;
            Content = file.Content;
            LastChanged = file.LastChanged;
            FileType = FileType;

            return this;
        }

    }
}
