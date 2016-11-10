using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace EPAM_XT2016_3_5
{
    internal class Watcher
    {
        public static void Main()
        {

            Console.WriteLine("Track changes, press 1");
            Console.WriteLine("Backup folder, press 2");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Program in tracking mode");
                        TrackChanges.BeginToWatch(Constants.SourceDirName, Constants.DestSourceDirName, Constants.DestTempDirName);
                        break;
                    }
                case "2":
                    {
                        try
                        {
                            Console.WriteLine("Enter date and time");
                            DateTime dateEndTime = DateTime.Parse(Console.ReadLine());
                            Backup.BackupSystem(dateEndTime, Constants.SourceDirName, Constants.DestSourceDirName);
                            break;
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                            break;
                        }
                    }
                default:
                    {
                        Console.WriteLine("Invalid key");
                        break;
                    }
            }
        }

        public static void SourceDirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (Directory.Exists(destDirName))
                return;
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.Name.EndsWith(".txt"))
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    SourceDirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static void TempDirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (Directory.Exists(destDirName))
                return;
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.Name.EndsWith(".txt"))
                {
                    string temppath = Path.Combine(destDirName, $"${Constants.DateFormat(DateTime.Now)}${file.Name}");
                    file.CopyTo(temppath, true);
                }
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    TempDirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}