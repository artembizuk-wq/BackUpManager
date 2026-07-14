using System;
using System.Collections.Generic;
using System.Text;
using _1СBackUpManager.Models;


namespace _1СBackUpManager.Services
{
    internal class BaseFinder
    {
        public List<BaseInfo> FindBases()
        {
            List<BaseInfo> result = new();

            string fileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"1C\1CEStart\ibases.v8i");

            if (!File.Exists(fileName))
                return result;
            
                string[] lines = File.ReadAllLines(fileName);
                
                BaseInfo? currentBase = null;
                
                foreach (string line in lines)
                {

                    if (line.StartsWith("["))
                    {
                        currentBase = new BaseInfo();
                        string baseName = line.Substring(1);
                        baseName = baseName.Replace("]", "");
                        currentBase.Name = baseName;

                    }

                    if(line.StartsWith("Connect=File=") && currentBase != null) {

                        const string prefix = "Connect=File=";
                        string basePath = line.Substring(prefix.Length);
                        basePath = basePath.Replace("\"", "").Replace(";", "");
                        currentBase.Path = basePath;

                        result.Add(currentBase);
                    }

                }
                return result;   
           
        }
    }
}
