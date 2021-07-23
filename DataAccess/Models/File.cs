using System;

namespace Models
{
    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public char DriveLetter { get; set; }
        public string Content { get; set; }
        public DateTime? LastChanged { get; set; }
        public string FileType { get; set; }
    }
}
