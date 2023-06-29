using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerBL.Util;
using TourPlannerModel;

namespace TourPlannerTest.UI
{
    public class ValidationTests
    {

        //TourValidationTests
        [Test]
        public void CheckDescriptionValidation()
        {
            TourPlannerValidation validation = new TourPlannerValidation();

            TourModel Tour = new TourModel();
            Tour.Name = "6tdfntdmhgdmhgdm";
            Tour.Origin = "Origin";
            Tour.Destination = "Destination";
            Tour.TransportType = Transport.Fastest;
            Tour.Description = "Descriptionjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjrzkuzkztkzkztkztktzkkztkztkztkzkizttkztktktktikttktk";
            bool result = validation.ValidateTourInput(Tour);
            Assert.IsFalse(result);
        }
        [Test]
        public void CheckNameValidation()
        {

            TourPlannerValidation validation = new TourPlannerValidation();

            TourModel Tour = new TourModel();
            Tour.Name = "";
            Tour.Origin = "Origin";
            Tour.Destination = "Destination";
            Tour.TransportType = Transport.Fastest;
            Tour.Description = "Description ist super";
            bool result = validation.ValidateTourInput(Tour);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOriginValidation()
        {

            TourPlannerValidation validation = new TourPlannerValidation();

            TourModel Tour = new TourModel();
            Tour.Name = "Name";
            Tour.Origin = "";
            Tour.Destination = "Destination";
            Tour.TransportType = Transport.Fastest;
            Tour.Description = "Description ist super";
            bool result = validation.ValidateTourInput(Tour);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckDestinationValidation()
        {

            TourPlannerValidation validation = new TourPlannerValidation();

            TourModel Tour = new TourModel();
            Tour.Name = "Name";
            Tour.Origin = "Origin";
            Tour.Destination = "";
            Tour.TransportType = Transport.Fastest;
            Tour.Description = "Description ist super";
            bool result = validation.ValidateTourInput(Tour);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckGeneralValidation()
        {

            TourPlannerValidation validation = new TourPlannerValidation();

            TourModel Tour = new TourModel();
            Tour.Name = "Name";
            Tour.Origin = "Origin";
            Tour.Destination = "Destination";
            Tour.TransportType = Transport.Fastest;
            Tour.Description = "Description ist super";
            bool result = validation.ValidateTourInput(Tour);
            Assert.IsTrue(result);
        }

        //TourLogValidation

        [Test]
        public void CheckCommentValidation()
        {
            TourPlannerValidation validation = new TourPlannerValidation();

            TourLogModel TourLog = new TourLogModel();
            TourLog.Difficulty = 10;
            TourLog.Duration = TimeSpan.Parse("0.11:11:11");
            TourLog.Rating = 4;
            TourLog.Date = DateTime.Parse("1999/10/12");
            TourLog.Comment = "Commentjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjrzkuzkztkzkztkztktzkkztkztkztkzkizttkztktktktikttktk";
            bool result = validation.ValidateTourLogInput(TourLog);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckRatingValidation()
        {
            TourPlannerValidation validation = new TourPlannerValidation();

            TourLogModel TourLog = new TourLogModel();
            TourLog.Difficulty = 10;
            TourLog.Duration = TimeSpan.Parse("0.11:11:11");
            TourLog.Rating = 6;
            TourLog.Date = DateTime.Parse("1999/10/12");
            TourLog.Comment = "Comment";
            bool result = validation.ValidateTourLogInput(TourLog);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckDifficultyValidation()
        {
            TourPlannerValidation validation = new TourPlannerValidation();

            TourLogModel TourLog = new TourLogModel();
            TourLog.Difficulty = 120;
            TourLog.Duration = TimeSpan.Parse("0.11:11:11");
            TourLog.Rating = 5;
            TourLog.Date = DateTime.Parse("1999/10/12");
            TourLog.Comment = "Comment";
            bool result = validation.ValidateTourLogInput(TourLog);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckGeneralLogValidation()
        {
            TourPlannerValidation validation = new TourPlannerValidation();

            TourLogModel TourLog = new TourLogModel();
            TourLog.Difficulty = 10;
            TourLog.Duration = TimeSpan.Parse("0.11:11:11");
            TourLog.Rating = 5;
            TourLog.Date = DateTime.Parse("1999/10/12");
            TourLog.Comment = "Comment";
            bool result = validation.ValidateTourLogInput(TourLog);
            Assert.IsTrue(result);
        }
    }
}
