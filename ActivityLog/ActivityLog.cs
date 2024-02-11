// ActivityLog singleton

using System;

namespace ActivityLog.App {

    class ActivityLog {

        private List<Activity> _activities;

        public ActivityLog () {
            this._activities = new List<Activity>();
            DateTime start = new DateTime(2024, 2, 5, 9, 0, 0);
            DateTime end = new DateTime(2024, 2, 5, 17, 0, 0);
            _activities.Add(new WorkActivity(start, end, 15, 400, "Builder's Guild", "Construction"));
            _activities.Add(new WorkActivity(start, end, 12.5, 0, "Lilly's Flower Shop", "Webapp contract"));
        }

        public List<Activity> GetActivities () {
            return _activities;
        }

        public string GetActivitiesInfo () {
            var stringBuilder = new System.Text.StringBuilder();
            foreach (Activity a in _activities) {
                stringBuilder.AppendLine(a.ToString());
            }
            return stringBuilder.ToString();
        }

    }

}