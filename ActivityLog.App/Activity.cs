using System.IO;
using System.Xml.Serialization;

namespace ActivityLog.App {

    [XmlInclude(typeof(Climbing))]
    [XmlInclude(typeof(WorkActivity))]
    [Serializable]
    public abstract class Activity {

        public DateTime startTime {get; set;}
        public DateTime endTime {get; set;}
        public string? description {get; set;}
        protected XmlSerializer Serializer;

        /*
        public string SerializeXML () {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
        */
        public virtual void SerializeXML (string path) {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            string[] content = {stringWriter.ToString()};
            File.WriteAllLines(path, content);
        }

        public abstract override string ToString ();

    }

}