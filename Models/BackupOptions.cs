using _1СBackUpManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1СBackUpManager.Models
{
    internal class BackupOptions
    {
        public string BackupFolder { get; set; }

        public BackupType BackupType { get; set; }

        public bool CompressToZip { get; set; }
    }


}
