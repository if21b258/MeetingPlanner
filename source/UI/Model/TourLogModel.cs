using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TourPlannerUI.Model
{
    public class TourLogModel
    {
        public int LogId { get; set; }
        public int TourId { get; set; }
        public string Date { get; set; }
        public TimeModel Time { get; set; }
        public string Comment { get; set; }
        public int Difficulty { get; set; }
        public  DurationModel Duration { get; set; }
        public int Rating { get; set; }

        public TourLogModel(string date, int hours, int minutes, string comment, int difficulty, int durationHours, int durationMinutes, int rating)
        {
            LogId = 0;
            TourId = 0;
            Date = date;
            Time = new TimeModel(hours, minutes);
            Comment = comment;
            Difficulty = difficulty;
            Duration = new DurationModel(durationHours, durationMinutes);
            Rating = rating;
        }
    }
}
