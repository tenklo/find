using System;

namespace Contracts.Common.SharedVM
{
    public interface IFileViewModel
    {
        string Name { get; set; }
        string Path { get; set; }
        string Content { get; set; }
        DateTime? LastChanged { get; set; }

        IFileViewModel CreateFileViewModel(Models.File file);
    }
}
