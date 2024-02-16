using System;
using System.Xml.Serialization;

namespace ActivityLog.App {

    public class Program {

        static string textPath = @".\..\TextFile.txt";
        static string XmlPath = @".\..\XmlFile.txt";
        static ActivityLog someActivityLog;

        public static void Main (string[] args) {
            Console.WriteLine("Program running...");            
            try {
                someActivityLog = new ActivityLog();
                DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
                DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
                /*
                WorkActivity project = new WorkActivity(start, end, 8, 1, "Revature");
                Console.WriteLine(someActivityLog.GetActivitiesInfo());
                Console.WriteLine(project.ToString());

                Climbing weekend = new Climbing(start, end, "blue", 11, "Houston");
                */
                MenuLoop();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Program ending...");
        }

        public static void MenuLoop () {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to your activity logger!");
            Console.WriteLine("--------------------------------");

            bool run = true;
            while (run) {
                Console.WriteLine("Select an option from the following: ");
                Console.WriteLine("1. Add entry to your activity log.");
                Console.WriteLine("2. Read from file.");
                Console.WriteLine("3. Write to file.");
                Console.WriteLine("4. Create XML record.");
                Console.WriteLine("5. Read from XML record.");
                Console.WriteLine("0. Exit program.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        AddEntryOption();
                        break;
                    case "2":
                        ReadOption();
                        break;
                    case "3":
                        WriteOption();
                        break;
                    case "4":
                        //someActivityLog.GetActivities()[0].SerializeXML(XmlPath);
                        SerializeOption();
                        break;
                    case "5":
                        // Currently hard-coded for the case of WorkActivity
                        //WorkActivity wa = WorkActivity.DeserializeXML(XmlPath);
                        //Console.WriteLine("\n" + wa.ToString() + "\n");
                        DeserializeOption();
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddEntryOption () {
            Console.WriteLine("AddEntryOption() still on TODO!!\nPlease try again later!");
            bool run = true;
            while (run) {
                Console.WriteLine("Which type of activity would you like to add");
                Console.WriteLine("1. Work activity.");
                Console.WriteLine("2. Climbing session.");
                Console.WriteLine("0. RETURN to main menu.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        UserAddWorkActivity();
                        run = false;
                        break;
                    case "2":
                        UserAddClimbing();
                        run = false;
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void UserAddWorkActivity () {
            throw new NotImplementedException();
        }

        static void UserAddClimbing () {
            throw new NotImplementedException();
        }

        static void ReadOption () {
            bool run = true;
            while (run) {
                Console.WriteLine("Which file would you like to read from?");
                Console.WriteLine("1. Plaintext file.");
                Console.WriteLine("2. XML file.");
                Console.WriteLine("0. RETURN to main menu.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        ReadFile(textPath);
                        run = false;
                        break;
                    case "2":
                        ReadFile(XmlPath);
                        run = false;
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void WriteOption () {
            bool run = true;
            while (run) {
                Console.WriteLine("Which file would you like to write to?");
                Console.WriteLine("1. Plaintext file.");
                Console.WriteLine("2. XML file.");
                Console.WriteLine("0. RETURN to main menu.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        WriteFile(someActivityLog.GetActivities()[0], textPath);
                        run = false;
                        break;
                    case "2":
                        WriteFile(someActivityLog.GetActivities()[0], XmlPath);
                        run = false;
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void SerializeOption () {
            bool run = true;
            while (run) {
                Console.WriteLine("Which type of activity would you like to serialize?");
                Console.WriteLine("1. Work activity.");
                Console.WriteLine("2. Climbing session.");
                Console.WriteLine("0. RETURN to main menu.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        someActivityLog.GetActivities()[0].SerializeXML(XmlPath);
                        run = false;
                        break;
                    case "2":
                        someActivityLog.GetActivities()[2].SerializeXML(XmlPath);
                        run = false;
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DeserializeOption () {
            bool run = true;
            while (run) {
                Console.WriteLine("Which type of activity are you reading?");
                Console.WriteLine("1. Work activity.");
                Console.WriteLine("2. Climbing session.");
                Console.WriteLine("0. RETURN to main menu.");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        WorkActivity wa = WorkActivity.DeserializeXML(XmlPath);
                        Console.WriteLine("\n" + wa.ToString() + "\n");
                        run = false;
                        break;
                    case "2":
                        Climbing c = Climbing.DeserializeXML(XmlPath);
                        Console.WriteLine("\n" + c.ToString() + "\n");
                        run = false;
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ReadFile (string path) {
            Console.WriteLine("Reading from file...");

            if (File.Exists(path)) {
                string[] readText = File.ReadAllLines(path);
                Console.WriteLine();
                foreach (string s in readText) {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
            else {
                Console.WriteLine("Could not find the specified file!");
            }
        }

        static void WriteFile (Activity a, string path) {
            Console.WriteLine(a.ToString());
            Console.WriteLine("Writing the above object to file...");

            string[] content = {a.ToString()};
            if (File.Exists(path)) {
                File.AppendAllLines(path, content);
            }
            else {
                Console.WriteLine("Could not find specified file!\nCreating file...");
                File.WriteAllLines(path, content);
            }
        }

    }

}