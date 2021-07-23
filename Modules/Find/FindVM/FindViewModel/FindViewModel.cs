using Contracts.Common.SharedBL;
using Contracts.Common.SharedVM;
using Contracts.Modules.Find.FindVM;
using Npgsql;
using SharedViewModel;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;

namespace FindViewModel
{
    public class FindViewModel : BaseViewModel, IFindViewModel
    {
        private readonly ISharedBusinessLogic _sharedBusinessLogic;
        private readonly SynchronizationContext _synchronizationContext;
        private const string _fileTypesRegex = @"^\.[a-zA-Z, .]+$";


        private string _textToSearch;

        public string TextToSearch
        {
            get { return _textToSearch; }
            set
            {
                _textToSearch = value;
                OnPropertyChanged();
            }
        }


        private string _includedFileTypes;

        public string IncludedFileTypes
        {
            get { return _includedFileTypes; }
            set
            {
                Regex regex = new Regex(_fileTypesRegex);

                if (regex.IsMatch(value))
                {
                    _includedFileTypes = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _excludedFileTypes;

        public string ExcludedFileTypes
        {
            get { return _excludedFileTypes; }
            set
            {
                Regex regex = new Regex(_fileTypesRegex);

                if (regex.IsMatch(value))
                {
                    _excludedFileTypes = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<IDirectoryViewModel> DrivesToDisplay { get; } = new ObservableCollection<IDirectoryViewModel>();
        public ObservableCollection<IFileViewModel> Files { get; } = new ObservableCollection<IFileViewModel>();


        public RelayCommand SearchTextCommand { get; }


        public FindViewModel(ISharedBusinessLogic sharedBusinessLogic)
        {
            _sharedBusinessLogic = sharedBusinessLogic;

            SearchTextCommand = new RelayCommand(unused => SearchText());
            _synchronizationContext = SynchronizationContext.Current;

            _sharedBusinessLogic.EnumerateDrives().ForEach(drive => DrivesToDisplay.Add(new DirectoryViewModel().CreateDirectoryViewModel(drive)));
            MonitorUsbInputs();
        }

        private void SearchText()
        {
            string sql = "SELECT * FROM \"tblFiles\"";

            string connectionString = string.Format("Server=10.194.9.131;Port=5432;User Id=postgres;Password=Vahpeiwoqu1Haex4cem6;Database=FindDB");

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);



            foreach (var row in dataSet.Tables[0].Rows)
            {
                if (row is DataRow dataRow)
                {
                    Files.Add(new FileViewModel()
                    {
                        Path = dataRow.ItemArray[1].ToString(),
                        Content = dataRow.ItemArray[2].ToString(),
                        Name = dataRow.ItemArray[3].ToString(),
                        DriveLetter = Convert.ToChar(dataRow.ItemArray[4].ToString()),
                        LastChanged = Convert.ToDateTime(dataRow.ItemArray[5].ToString()),
                        FileType = dataRow.ItemArray[6].ToString()
                    });
                }
            }

            connection.Close();
        }

        //TODO: Die watcher verallgemeinern
        public void MonitorUsbInputs()
        {
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher();
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher();
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");

            insertWatcher.EventArrived += new EventArrivedEventHandler(Watcher_UsbInserted);
            insertWatcher.Query = insertQuery;
            insertWatcher.Start();

            removeWatcher.EventArrived += new EventArrivedEventHandler(Watcher_UsbRemoved);
            removeWatcher.Query = removeQuery;
            removeWatcher.Start();
        }

        private void Watcher_UsbInserted(object sender, EventArrivedEventArgs e)
        {
            WatcherLogic();
        }
        private void Watcher_UsbRemoved(object sender, EventArrivedEventArgs e)
        {
            WatcherLogic();
        }

        private void WatcherLogic()
        {
            _synchronizationContext.Send(unused =>
            {
                DrivesToDisplay.Clear();
                _sharedBusinessLogic.EnumerateDrives().ForEach(drive => DrivesToDisplay.Add(new DirectoryViewModel().CreateDirectoryViewModel(drive)));
            }, null);
        }

    }
}
