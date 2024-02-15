using System;
using System.Xml.Serialization;

namespace ActivityLog.App {

    [XmlInclude(typeof(WorkActivity))]
    [Serializable]
    public class WorkActivity : Activity {

        public double wage {get; set;}
        public double materialsCost {get; set;}
        public string client {get;}
        
        public WorkActivity () {}

        public WorkActivity (DateTime startTime, DateTime endTime, double wage, double materialsCost, string client, string description = "") {
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

        public string SerializeXML () {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

        public override string ToString () {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"WORK ACTIVITY:\nStart Time: {this.startTime},\tEnd Time: {this.endTime},\nHourly Wage: ${this.wage},\tCost of Materials: ${this.materialsCost},\nClient: {this.client},\tDescription: {this.description}\n");
            return result.ToString();
        }

    }

}