using Contracts.Common.SharedVM;
using System.Collections.ObjectModel;

namespace Contracts.Modules.Find.FindVM
{
    public interface IFindViewModel
    {
        ObservableCollection<IDirectoryViewModel> DrivesToDisplay { get; }
        string ExcludedFileTypes { get; set; }
        string IncludedFileTypes { get; set; }
        string TextToSearch { get; set; }

        void MonitorUsbInputs();
    }
}
