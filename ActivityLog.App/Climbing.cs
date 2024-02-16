using System;
using System.IO;
using System.Xml.Serialization;

namespace ActivityLog.App {

    [XmlInclude(typeof(Climbing))]
    [Serializable]
    public class Climbing : Activity {

        //private string _routeDifficulties = ["RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "PURPLE", "BLACK"];
        public string difficultyRecord {get; set;}
        public int routesCompleted{get; set;}
        public string location {get; set;}
        //private XmlSerializer Serializer = new XmlSerializer(typeof(Climbing));

        public Climbing () {
            Serializer = new XmlSerializer(typeof(Climbing));
        }
        public Climbing (DateTime startTime, DateTime endTime, string difficultyRecord, int routesCompleted, string location, string description = "") : this() {
            this.difficultyRecord = difficultyRecord.ToUpper().Trim();
            /*
            if (!this._routeDifficulties.Contains(this.difficultyRecord)) {
                Console.WriteLine("Please enter a valid route difficulty. The following colors are valid difficulties:");
                Console.WriteLine(_routeDifficulties.ToString());
                return;
            }
            */        
            this.startTime = startTime;
            this.endTime = endTime;
            this.routesCompleted = routesCompleted;
            this.location = location;
            this.description = description;
        }

        public override void SerializeXML (string path) {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            string[] content = {stringWriter.ToString()};
            File.WriteAllLines(path, content);
        }

        public static Climbing DeserializeXML (string path) {
            XmlSerializer deSerializer = new XmlSerializer(typeof(Climbing));
            Climbing C = new Climbing();
            
            if (!File.Exists(path)) {
                Console.WriteLine("File not found!");
                return null;
            }
            else {
                using StreamReader reader = new StreamReader(path);
                var record = (Climbing)deSerializer.Deserialize(reader);
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
            var result = new System.Text.StringBuilder();
            result.AppendLine($"CLIMBING:\nStart Time: {this.startTime},\tEnd Time: {this.endTime},\nHighest Difficulty Completed: {this.difficultyRecord}\tNumber of Routes Completed: {this.routesCompleted},\nDescription: {this.description}\n");
            return result.ToString();
        }

    }

}