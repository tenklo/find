using System.Collections.ObjectModel;

namespace SharedViewModel
{
    public class DirectoryViewModel : BaseViewModel
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


        private bool _isDriveSelected;

        public bool IsDriveSelected
        {
            get { return _isDriveSelected; }
            set
            {
                _isDriveSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileViewModel> FileViewModels { get; } = new ObservableCollection<FileViewModel>();


        public DirectoryViewModel(Models.Directory directory)
        {
            Name = directory.Name;
            Path = directory.Path;
            IsDriveSelected = directory.IsDriveSelected;

            directory.Files.ForEach(file => FileViewModels.Add(new FileViewModel(file)));
        }
    }
}
