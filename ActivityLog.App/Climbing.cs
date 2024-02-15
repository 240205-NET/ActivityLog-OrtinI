using System;
using System.Xml.Serialization;


namespace ActivityLog.App {

    public class Climbing : Activity {

        //private string _routeDifficulties = ["RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "PURPLE", "BLACK"];
        public string difficultyRecord {get;}
        public int routesCompleted{get;}
        public string location {get;}

        public Climbing () {}
        public Climbing (DateTime startTime, DateTime endTime, string difficultyRecord, int routesCompleted, string location, string description = "") {
            this.difficultyRecord = difficultyRecord.ToUpper().Trim();
            /*if (!this._routeDifficulties.Contains(this.difficultyRecord)) {
                Console.WriteLine("Please enter a valid route difficulty. The following colors are valid difficulties:");
                Console.WriteLine(_routeDifficulties.ToString());
                return;
            } */        
            this.startTime = startTime;
            this.endTime = endTime;
            this.routesCompleted = routesCompleted;
            this.location = location;
            this.description = description;
        }

        public static Climbing DeserializeXML (string path) {
            XmlSerializer serializer = new XmlSerializer(typeof(Climbing));
            Climbing C = new Climbing();
            
            if (!File.Exists(path)) {
                Console.WriteLine("File not found!");
                return null;
            }
            else {
                using StreamReader reader = new StreamReader(path);
                var record = (Climbing)serializer.Deserialize(reader);
                if (record is null) {
                    throw new InvalidDataException();
                    return null;
                }
                else  {
                    C = record;
                }
            }
            return C;
        }

        public override string ToString () {
            return "climb it all";
        }

    }

}