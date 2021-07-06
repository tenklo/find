using System.Collections.Generic;
using System.IO;

namespace FindBusinessLogic
{
    public class FindBusinessLogic
    {
        public void MonitorFileSystem(List<string> driveLetters)
        {
            foreach (var driveLetter in driveLetters)
            {
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(driveLetter);
                fileSystemWatcher.Changed += FileChanged;
                fileSystemWatcher.Deleted += FileDeleted;
                fileSystemWatcher.Renamed += FileRenamed;
                fileSystemWatcher.Created += FileCreated;

                fileSystemWatcher.IncludeSubdirectories = true;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
        }
    }
}
