using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_5
{
    internal class TrackChanges

    {
        private static FileSystemWatcher fileWatcher;

        private static FileSystemWatcher dirWatcher;

        static TrackChanges()
        {
            dirWatcher = new FileSystemWatcher(Constants.SourceDirName);

            fileWatcher = new FileSystemWatcher(Constants.SourceDirName, "*.txt");
        }

        public static void BeginToWatch(string sourceDirName, string destSourceDirName, string destTempDirName)
        {
            FileWatcher(sourceDirName, destSourceDirName, destTempDirName);
            DirectoryWatcher();

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        private static void DirectoryWatcher()
        {
            dirWatcher.IncludeSubdirectories = true;
            dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
            dirWatcher.EnableRaisingEvents = true;

            dirWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
            dirWatcher.Created += new FileSystemEventHandler(OnCreated);
            dirWatcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        private static void FileWatcher(string sourceDirName, string destSourceDirName, string destTempDirName)
        {
            Watcher.SourceDirectoryCopy(sourceDirName, destSourceDirName, true);
            Watcher.TempDirectoryCopy(sourceDirName, destTempDirName, true);

            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName;

            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileWatcher.Created += new FileSystemEventHandler(OnCreated);
            fileWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
            fileWatcher.Renamed += new RenamedEventHandler(OnRenamed);

            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.InternalBufferSize = 1024 * 1024;
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (sender == fileWatcher)
                    {
                        LogingFile.LogEventInfo(sender, e);
                    }
                    else if (sender == dirWatcher)
                    {
                        LogingFile.LogEventInfo(sender, e);
                    }

                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void SleepEvent()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    var attributes = ElementISDirectory(e as RenamedEventArgs);

                    if (sender == fileWatcher && !((attributes)))
                    {
                        LogingFile.LogEventInfo(sender, e);
                        string temppath = GetTempPath(e);

                        if (!File.Exists(temppath))
                        {
                            File.Create(temppath).Close();
                        }
                    }
                    else if (sender == dirWatcher)
                    {
                        string temppath = GetTempPath(e);
                        Directory.CreateDirectory(temppath);

                        LogingFile.LogEventInfo(sender, e);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    var attributes = ElementISDirectory(e as RenamedEventArgs);

                    if (sender == fileWatcher && !attributes)
                    {
                        LogingFile.LogEventInfo(sender, e);

                        string temppath = GetTempPath(e);

                        if (!File.Exists(temppath))
                        {
                            File.Copy(e.FullPath, temppath);
                        }
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            while (true)
            {
                try
                {
                    var attributes = ElementISDirectory(e);

                    if (sender == fileWatcher && !((attributes)))
                    {
                        LogingFile.LogOnRenamedInfo(sender, e);
                    }
                    else if (sender == dirWatcher)
                    {
                        string temppath = GetTempPath(e);
                        Directory.CreateDirectory(temppath);
                        LogingFile.LogOnRenamedInfo(sender, e);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static string GetTempPath(FileSystemEventArgs e)
        {
            string line = e.FullPath;
            line = line.Replace(Constants.SourceDirName, Constants.DestTempDirName).Replace(Path.GetFileName(e.Name), "");
            string temppath = Path.Combine(line, $"${Constants.DateFormat(DateTime.Now)}${Path.GetFileName(e.Name)}");
            return temppath;
        }

        private static bool ElementISDirectory(RenamedEventArgs e)
        {
            return File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory);
        }
    }
}