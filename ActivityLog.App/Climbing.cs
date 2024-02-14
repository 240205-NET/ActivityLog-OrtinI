using System;

namespace ActivityLog.App {

    public class Climbing : Activity {

        //private string _routeDifficulties = ["RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "PURPLE", "BLACK"];
        public string difficultyRecord {get;}
        public int routesCompleted{get;}
        public string location {get;}

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

        public override string ToString () {
            return "climb it all";
        }

    }

}