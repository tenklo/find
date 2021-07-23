using Contracts.Common.SharedBL;
using System.Collections.Generic;
using System.IO;

namespace SharedBusinessLogic
{
    public class SharedBusinessLogic : ISharedBusinessLogic
    {
        public List<Models.Directory> EnumerateDrives()
        {
            List<Models.Directory> drivesToDisplay = new List<Models.Directory>();

            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var driveType = drive.DriveType;
                if (drive.IsReady)
                    drivesToDisplay.Add(new Models.Directory()
                    {
                        Name = drive.Name,
                        Path = drive.Name
                    });
            }
            return drivesToDisplay;
        }


    }
}
