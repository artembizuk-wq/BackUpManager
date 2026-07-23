using _1СBackUpManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1СBackUpManager.Models
{
    internal class BackupOptions
    {
        public string BackupFolder { get; set; } = string.Empty;

        public BackupType BackupType { get; set; } = BackupType.CD;

        public bool CompressToZip { get; set; }

        public string OneCExePath { get; set; } = string.Empty;
    }


}
