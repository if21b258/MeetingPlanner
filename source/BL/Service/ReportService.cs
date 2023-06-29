using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerBL.Logging;
using TourPlannerModel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using System.Collections.ObjectModel;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.StyledXmlParser.Css.Util;
using TourPlannerBL.Util;

namespace TourPlannerBL.Service
{
    public class ReportService : IReportService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();
        private FileService _fileService = new FileService();
        private TourCalculations _tourCalculations = new TourCalculations();


        public void GenerateTourReport(TourModel tour, string path)
        {
            log.Info("GenerateTourReport called");

            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Add title
            var title = new Paragraph("Tour Report")
                .SetBold()
                .SetFontSize(16)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20);
            document.Add(title);

            // Add image
            var image = new Image(ImageDataFactory.Create(_fileService.GetFilePath(tour)));
            image.SetWidth(UnitValue.CreatePercentValue(60));
            image.SetMarginBottom(20);
            image.SetProperty(Property.FLOAT, FloatPropertyValue.RIGHT);
            document.Add(image);

            // Add tour details
            document.Add(new Paragraph($"Tour ID: {tour.Id}"));
            document.Add(new Paragraph($"Tour Name: {tour.Name}"));
            document.Add(new Paragraph($"Origin: {tour.Origin}"));
            document.Add(new Paragraph($"Destination: {tour.Destination}"));
            document.Add(new Paragraph($"Transport Type: {tour.TransportType}"));
            document.Add(new Paragraph($"Description: {tour.Description}"));
            document.Add(new Paragraph($"Distance: {tour.Distance} km"));
            document.Add(new Paragraph($"Estimated Time: {tour.EstimatedTime} time?"));

            AddTourLogsToDocument(tour.Logs, document);

            document.Close();
        }

        public void GenerateSummaryReport(ObservableCollection<TourModel> tours, string path)
        {
            log.Info("GenerateSummaryReport called");

            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Add title
            var title = new Paragraph("Summary Report")
                .SetBold()
                .SetFontSize(16)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20);
            document.Add(title);

            var table = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();

            table.AddHeaderCell("Id");
            table.AddHeaderCell("Name");
            table.AddHeaderCell("Avg. Difficulty");
            table.AddHeaderCell("Avg. Duration");
            table.AddHeaderCell("Avg. Rating");

            if (tours.Count > 0)
            {
                foreach (var tour in tours)
                {
                    table.AddCell(tour.Id.ToString());
                    table.AddCell(tour.Name);
                    table.AddCell(_tourCalculations.GetAverageDifficulty(tour).ToString());
                    table.AddCell(_tourCalculations.GetAverageDuration(tour).ToString("dd'd 'hh'h 'mm'min'"));
                    table.AddCell(_tourCalculations.GetAverageRating(tour).ToString());
                }
                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Tours available."));
            }

            document.Close();
        }

        private void AddTourLogsToDocument(ICollection<TourLogModel>? tourLogs, Document document)
        {
            var table = new Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();

            table.AddHeaderCell("Id");
            table.AddHeaderCell("Date");
            table.AddHeaderCell("Comment");
            table.AddHeaderCell("Difficulty");
            table.AddHeaderCell("Duration");
            table.AddHeaderCell("Rating");

            if (tourLogs != null)
            {
                foreach (var tourLog in tourLogs)
                {
                    table.AddCell(tourLog.Id.ToString());
                    table.AddCell(tourLog.Date.ToString("dd'/'MM'/'yyyy' 'HH':'mm"));
                    table.AddCell(tourLog.Comment);
                    table.AddCell(tourLog.Difficulty.ToString());
                    table.AddCell(tourLog.Duration.ToString("dd'd 'hh'h 'mm'min'"));
                    table.AddCell(tourLog.Rating.ToString());
                }
                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Logs available."));
            }



        }
    }
}
