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
        public string LogId { get; set; }
        public string TourId { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Difficulty { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }

        public TourLogModel(string logId, string tourId, string date, string comment, string difficulty, string duration, string rating)
        {
            LogId = logId;
            TourId = tourId;
            Date = date;
            Comment = comment;
            Difficulty = difficulty;
            Duration = duration;
            Rating = rating;
        }
    }
}
