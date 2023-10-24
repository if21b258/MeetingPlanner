using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MeetingPlannerBL.Logging;
using MeetingPlannerModel;

namespace MeetingPlannerBL.Service
{
    public class ReportService : IReportService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        public void GenerateMeetingReport(MeetingModel meeting, string path)
        {
            log.Info("GenerateMeetingReport called");

            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Add title
            var title = new Paragraph("Meeting Report")
                .SetBold()
                .SetFontSize(16)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20);
            document.Add(title);

            // Add meeting details
            document.Add(new Paragraph($"Meeting ID: {meeting.Id}"));
            document.Add(new Paragraph($"Meeting Title: {meeting.Title}"));
            document.Add(new Paragraph($"Meeting From: {meeting.From}"));
            document.Add(new Paragraph($"Meeting To: {meeting.To}"));
            document.Add(new Paragraph($"Meeting Agenda: {meeting.Agenda}"));


            AddMeetingNotesToDocument(meeting.MeetingNotes, document);

            document.Close();
        }

        private void AddMeetingNotesToDocument(ICollection<MeetingNoteModel>? meetingNotes, Document document)
        {
            var table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

            table.AddHeaderCell("Id");
            table.AddHeaderCell("Note");

            if (meetingNotes != null)
            {
                foreach (var meetingNote in meetingNotes)
                {
                    table.AddCell(meetingNote.Id.ToString());
                    table.AddCell(meetingNote.Note);
                }
                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Notes available."));
            }
        }
    }
}
