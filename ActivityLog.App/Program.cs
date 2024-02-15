using System;
using System.Xml.Serialization;

namespace ActivityLog.App {

    public class Program {

        public static void Main (string[] args) {
            Console.WriteLine("Program running...");            
            try {
                ActivityLog someActivityLog = new ActivityLog();
                DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
                DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
                WorkActivity project = new WorkActivity(start, end, 8, 1, "Revature");
                Console.WriteLine(someActivityLog.GetActivitiesInfo());
                Console.WriteLine(project.ToString());

                Climbing weekend = new Climbing(start, end, "blue", 11, "Houston");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Program ending...");
        }

        static void WriteFile () {

        }

    }

}