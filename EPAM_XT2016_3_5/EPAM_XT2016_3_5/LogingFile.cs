using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_5
{
    public class LogingFile
    {
        public static void LogOnRenamedInfo(object sender, RenamedEventArgs e)
        {
            
            
            using (StreamWriter writer = new StreamWriter(Constants.LogPath, true))
            {
                writer.WriteLine($"{Constants.DateFormat(DateTime.Now)}|{sender}|{e.OldFullPath}|{e.ChangeType}|{e.FullPath}");
            }
        }

        public static void LogEventInfo(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(Constants.LogPath, true))
            {
                writer.WriteLine($"{Constants.DateFormat(DateTime.Now)}|{sender}|{e.FullPath}|{e.ChangeType}");
            }
        }
    }
}