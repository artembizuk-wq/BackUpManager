using System;
using System.Collections.Generic;
using System.Text;

namespace _1СBackUpManager.Models
{
    public class BaseInfo
    {
        public string Name { get; set; } = "";

        public string Path { get; set; } = "";

        public DateTime? LastBackup { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
