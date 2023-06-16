using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TourPlannerModel
{
    public class TourLogModel
    {
        public int Id { get; set; }
        public TourModel Tour { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int THours { get; set; }
        public int TMinutes { get; set; }
        public string Comment { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
        public int DHours { get; set; }
        public int DMinutes { get; set; }
        public int Rating { get; set; }


        public TourLogModel(string date, int hours, int minutes, string comment, int difficulty, int durationHours, int durationMinutes, int rating)
        {
            LogId = 0;
            Tour = null;
            Date = date;
            Time = hours + ":" + minutes;
            THours = hours;
            TMinutes = minutes;
            Comment = comment;
            Difficulty = difficulty;
            Duration = durationHours + ":" + durationMinutes;
            DHours = durationHours;
            DMinutes = durationMinutes;
            Rating = rating;
        }
    }
}
