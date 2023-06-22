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

namespace TourPlannerBL
{
    public class ReportService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();
        private FileService _fileService = new FileService();


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
            var image = new Image(ImageDataFactory.Create(_fileService.GetFilePath(tour)))
            .SetWidth(UnitValue.CreatePercentValue(50))
            .SetHorizontalAlignment(HorizontalAlignment.CENTER)
            .SetMarginTop(20)
            .SetMarginBottom(20);
            document.Add(image);

            // Add tour details
            document.Add(new Paragraph($"Tour ID: {tour.Id}"));
            document.Add(new Paragraph($"Tour Name: {tour.Name}"));
            document.Add(new Paragraph($"Origin: {tour.Origin}"));
            document.Add(new Paragraph($"Destination: {tour.Destination}"));
            document.Add(new Paragraph($"Transport Type: {tour.TransportType}"));
            document.Add(new Paragraph($"Description: {tour.Description}"));
            document.Add(new Paragraph($"Distance: {tour.Distance}"));
            document.Add(new Paragraph($"Estimated Time: {tour.EstimatedTime}"));

            AddTourLogsToDocument(tour.Logs, document);

            document.Close();
        }

        private void AddTourLogsToDocument(ICollection<TourLogModel> tourLogs, Document document)
        {
            document.Add(new Paragraph("Tour Logs"))
                .SetBold()
                .SetFontSize(14);

            foreach (var tourLog in tourLogs)
            {
                document.Add(new Paragraph($"Log ID: {tourLog.Id}"));
                document.Add(new Paragraph($"Date: {tourLog.Date}"));
                document.Add(new Paragraph($"Rating: {tourLog.Time}"));
                document.Add(new Paragraph($"Average Speed: {tourLog.Comment}"));
                document.Add(new Paragraph($"Max Speed: {tourLog.Difficulty}"));
                document.Add(new Paragraph($"Min Speed: {tourLog.Duration}"));
                document.Add(new Paragraph($"Average Step Count: {tourLog.Rating}"));
            }
        }

    }
}
