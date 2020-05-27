using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    class ListFile
    {
        public static List<File> files = new List<File>();

    }
    class File
    {
        public string filename { get; set; }
        public string fileText { get; set; }

        public File(string filename, string fileText)
        {
            this.filename = filename;
            this.fileText = fileText;
        }
    }
}
