using System;
using System.Xml.Serialization;

namespace ActivityLog.App {

    [XmlInclude(typeof(WorkActivity))]
    [Serializable]
    public class WorkActivity : Activity {

        public double wage {get; set;}
        public double materialsCost {get; set;}
        public string client {get; set;}
        
        public WorkActivity () {
            Serializer = new XmlSerializer(typeof(WorkActivity));
        }

        public WorkActivity (DateTime startTime, DateTime endTime, double wage, double materialsCost, string client, string description = "") : this() {
            this.startTime = startTime;
            this.endTime = endTime;
            this.wage = wage;
            this.materialsCost = materialsCost;
            this.client = client;
            this.description = description;
        }

        public double GetRevenue () {
            System.TimeSpan hoursWorked = endTime - startTime;
            return hoursWorked.TotalHours * wage;
        }

        public double GetProfit () {
            return GetRevenue() - materialsCost;
        }

        public override void SerializeXML (string path) {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            string[] content = {stringWriter.ToString()};
            File.WriteAllLines(path, content);
        }

        public static WorkActivity DeserializeXML (string path) {
            XmlSerializer deSerializer = new XmlSerializer(typeof(WorkActivity));
            WorkActivity WA = new WorkActivity();
            
            if (!File.Exists(path)) {
                Console.WriteLine("File not found!");
                return null;
            }
            else {
                using StreamReader reader = new StreamReader(path);
                var record = (WorkActivity)deSerializer.Deserialize(reader);
                if (record is null) {
                    throw new InvalidDataException();
                    return null;
                }
                else  {
                    WA = record;
                }
            }
            return WA;
        }

        public override string ToString () {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"WORK ACTIVITY:\nStart Time: {this.startTime},\tEnd Time: {this.endTime},\nHourly Wage: ${this.wage},\tCost of Materials: ${this.materialsCost},\nClient: {this.client},\tDescription: {this.description}\n");
            return result.ToString();
        }

    }

}