using System.Xml.Serialization;

namespace ActivityLog.App {

    public abstract class Activity {

        public DateTime startTime {get; set;}
        public DateTime endTime {get; set;}
        public string? description {get; set;}
        private XmlSerializer Serializer = new XmlSerializer(typeof(Activity));

        public string SerializeXML () {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

        public abstract override string ToString ();

    }

}