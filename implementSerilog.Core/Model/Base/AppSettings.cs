using System;
using System.Collections.Generic;
using System.Text;

namespace implement.Core.Model.Base
{
    public class AppSettings
    {
        public string TokenSecret { get; set; }
        public string LogFilePath { get; set; }
        public string LogFileName { get; set; }
        public int LogFileSizeMB { get; set; }
        public bool InsertLog { get; set; }
    }
}
