using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace FindBusinessLogic
{
    public class FindBusinessLogic
    {
        private readonly Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public (bool wasSuccessful, Exception exception) AddFileToConfig(string keyToAdd)
        {
            try
            {
                keyToAdd = "*." + keyToAdd + ",";
                ConfigurationManager.AppSettings.Add("dataTypsToLoad", keyToAdd);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }

        public (bool wasSuccessful, Exception exception) DeleteFileFromConfig(string key)
        {
            try
            {
                configFile.AppSettings.Settings.Remove(key);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }

        public (string[] dataTypes, bool wasSuccessful, Exception exception) GetAllDataTypesFromConfig()
        {
            try
            {
                return (ConfigurationManager.AppSettings["dataTypesToLoad"].Split(','), true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex);
            }
        }

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
