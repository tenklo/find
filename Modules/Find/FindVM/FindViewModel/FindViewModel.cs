using SharedViewModel;
using System.Collections.ObjectModel;

namespace FindViewModel
{
    public class FindViewModel : BaseViewModel
    {
        private string _configurationText;

        public string ConfigurationText
        {
            get { return _configurationText; }
            set
            {
                _configurationText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DirectoryViewModel> DrivesToDisplay { get; } = new ObservableCollection<DirectoryViewModel>();

        public FindViewModel()
        {
            FindBusinessLogic.FindBusinessLogic findUpdaterBusinessLogic = new FindBusinessLogic.FindBusinessLogic();
            SharedBusinessLogic.SharedBusinessLogic sharedBusinessLogic = new SharedBusinessLogic.SharedBusinessLogic();


            sharedBusinessLogic.EnumerateDrives().ForEach(drive => DrivesToDisplay.Add(new DirectoryViewModel(drive)));

            //findUpdaterBusinessLogic.MonitorFileSystem(sharedBusinessLogic.EnumerateDrives());
        }

        public void SearchText()
        {

        }
    }
}
