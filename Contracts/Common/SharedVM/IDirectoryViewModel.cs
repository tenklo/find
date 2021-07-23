using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Contracts.Common.SharedVM
{
    public interface IDirectoryViewModel
    {
        string Name { get; set; }
        string Path { get; set; }
        bool IsDriveSelected { get; set; }

        ObservableCollection<IFileViewModel> FileViewModels { get; }

        IDirectoryViewModel CreateDirectoryViewModel(Models.Directory directory);
    }
}
