using System;
using System.Globalization;
using System.Text;

namespace EPAM_XT2016_3_5
{
    internal class StructureEventElement
    {
        public DateTime TimeOfChanges { get; set; }
        public string TypeOfChanges { get; set; }
        public string PathFile { get; set; }
        public string OldPathToFile { get; set; }
        public string TypeOfObject { get; set; }

        public StructureEventElement(string dateAndTime, string typeOfObject, string path, string typeOfChanges)
        {
            this.TimeOfChanges = ParseDate(dateAndTime);
            this.TypeOfChanges = typeOfChanges;
            this.PathFile
                = path;
            this.TypeOfObject = typeOfObject;
        }

        public StructureEventElement(string dateAndTime, string typeOfObject, string oldPath, string typeOfChanges, string newPath)
            : this(dateAndTime, typeOfObject, typeOfChanges, newPath)
        {
            this.OldPathToFile = oldPath;
        }

        private static DateTime ParseDate(string dateAndTime)
        {
            string format = "dd/MM/yyyy HH:mm:ss";
            try
            {
                DateTime newDate = DateTime.ParseExact(dateAndTime, format, CultureInfo.CurrentCulture);
                return newDate;
            }
            catch
            {
                throw new ArgumentException("DateParse error");
            }
        }

        public static StructureEventElement ParseLog(string line)
        {
            string[] array = line.Split('|');

            string timeOfChanges = array[0];
            string typeOfObject = array[1];
            string typeOfChanges = array[3];

            if (array[3] == "Created" || array[3] == "Deleted" || array[3] == "Changed")

            {
                string path = array[2];

                return new StructureEventElement(timeOfChanges, typeOfObject, path, typeOfChanges);
            }
            else if (array[3] == "Renamed")
            {
                string oldPath = array[2];
                string newPath = array[4];
                return new StructureEventElement(timeOfChanges, typeOfObject, oldPath, typeOfChanges, newPath);
            }
            else
            {
                throw new ArgumentException("Change type error");
            }
        }

        public static string DateFromLogToString(DateTime date)
        {
            return Constants.DateFormat(date);
        }
      
    }
}