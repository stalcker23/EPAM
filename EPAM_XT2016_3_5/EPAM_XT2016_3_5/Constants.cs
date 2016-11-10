using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_5
{
    internal class Constants
    {
        public static string LogPath { get; }
        public static string SourceDirName { get; }
        public static string DestTempDirName { get; }
        public static string DestSourceDirName { get; }

        static Constants()
        {
            SourceDirName = ConfigurationManager.AppSettings["SourceDirName"];
            DestSourceDirName = ConfigurationManager.AppSettings["DestSourceDirName"];
            DestTempDirName = ConfigurationManager.AppSettings["DestTempDirName"];
            LogPath = ConfigurationManager.AppSettings["logPath"];
        }
        public static string DateFormat(DateTime item)
        {
            string format = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", item.Year, item.Month, item.Day, item.Hour, item.Minute, item.Second);
            return format;
        }
    }
}