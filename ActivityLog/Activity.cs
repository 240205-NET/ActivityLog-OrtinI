namespace ActivityLog.App {

    abstract class Activity {

        public DateTime startTime {get; set;}
        public DateTime endTime {get; set;}
        public string? description {get; set;}

        public abstract string ToString ();

    }

}