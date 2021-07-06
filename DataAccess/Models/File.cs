using System;

namespace Models
{
    public class File
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public char DriveLetter { get; set; }
        public string Content { get; set; }
        public DateTime? LastChanged { get; set; }
    }
}
