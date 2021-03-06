using System.Collections.Generic;

namespace Models
{
    public class Directory
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDriveSelected { get; set; }
        public List<File> Files { get; set; } = new List<File>();
    }
}
