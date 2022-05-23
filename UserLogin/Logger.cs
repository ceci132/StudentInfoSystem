using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserLogin
{
    public class Logger
    {
        private static readonly string logFile = "logs.txt";
        private static List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + 
                LoginValidation.username + ";" + 
                LoginValidation.currentUserRole + ";" + 
                activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText(logFile, "\n" + activityLine);
        }

        public static IEnumerable<String> showLogs()
        {
            List<String> data = new List<string>();
            if (File.Exists(logFile) == true)
            {
                String logs = File.ReadAllText(logFile);
                data.Add(logs);
               // Console.WriteLine(logs);
            }

            return data;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(String filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }
    }
}
