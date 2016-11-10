using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_5
{
    internal class Backup
    {
        public static void BackupSystem(DateTime dateAndTime, string sourceDirName, string destSourceDirName)
        {
            ClearTrackingFolder(sourceDirName);
            Watcher.SourceDirectoryCopy(destSourceDirName, sourceDirName, true);
            List<StructureEventElement> logItems = new List<StructureEventElement>();
            using (StreamReader logFile = new StreamReader(Constants.LogPath))
            {
                string line;
                while ((line = logFile.ReadLine()) != null)
                {
                    try
                    {
                        var logitem = StructureEventElement.ParseLog(line);

                        if (logitem.TimeOfChanges > dateAndTime)
                            continue;
                        else
                        {
                            logItems.Add(logitem);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            try
            {
                foreach (var item in logItems)
                {
                    switch (item.TypeOfChanges)
                    {
                        case "Changed":
                            {
                                if (File.Exists(item.PathFile))
                                {
                                    File.Delete(item.PathFile);
                                }
                                string temppath = GetTempPath(item);
                                File.Copy(temppath, item.PathFile);
                                break;
                            }
                        case "Created":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    File.Create(item.PathFile).Close();
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    Directory.CreateDirectory(item.PathFile);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                        case "Deleted":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    File.Delete(item.PathFile);
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    Directory.Delete(item.PathFile, true);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                        case "Renamed":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    File.Delete(item.OldPathToFile);
                                    File.Create(item.PathFile).Close();
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    Directory.Delete(item.OldPathToFile, true);
                                    Directory.CreateDirectory(item.PathFile);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetTempPath(StructureEventElement item)
        {
            string line = item.PathFile;
            line = line.Replace(@"D:\Watcher", @".\temp").Replace(Path.GetFileName(item.PathFile), "");
            string temppath = Path.Combine(line, $"${StructureEventElement.DateFromLogToString(item.TimeOfChanges)}${Path.GetFileName(item.PathFile)}");
            return temppath;
        }

        private static void ClearTrackingFolder(string trackingFolderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(trackingFolderPath);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
            foreach (DirectoryInfo subdir in dirInfos)
            {
                Directory.Delete(subdir.FullName, true);
            }
            Directory.Delete(trackingFolderPath);
        }
    }
}