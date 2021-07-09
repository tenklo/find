using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SharedBusinessLogic
{
    public class SharedBusinessLogic
    {
        public List<string> EnumerateDrives()
        {
            List<string> driveLetters = new List<string>();

            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var driveType = drive.DriveType;
                if (driveType.Equals(DriveType.Fixed) && drive.IsReady)
                    driveLetters.Add(drive.Name);
            }
            return driveLetters;
        }


    }
}
