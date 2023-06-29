using System.Configuration;
using System.Drawing;
using TourPlannerModel;
using TourPlannerBL.Logging;

namespace TourPlannerBL.Service
{
    //Class to handle the file directory and the mapquest image
    public class FileService : IFileService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        public string GetFileDirectory()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string? configDir = ConfigurationManager.AppSettings["ImagePath"];
            return Path.Combine(baseDir, configDir);
        }

        public string GetFilePath(TourModel tour)
        {
            string filePath = GetFileDirectory() + tour.Id + ".png";
            return filePath;
        }

        public void SaveImageToFile(byte[] mapImage, TourModel tour)
        {
            string fileDir = GetFileDirectory();
            string filePath = GetFilePath(tour);
            try
            {
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                    log.Info("New image directory created");
                }
                if (mapImage == null)
                {
                    log.Warn("No image loaded");
                }
                else
                {
                    using (MemoryStream fileStream = new MemoryStream(mapImage))
                    {

                        var image = Image.FromStream(fileStream);
                        image.Save(filePath);

                    }
                    log.Info("Image successfully saved in: " + filePath);
                }

            }
            catch (Exception e)
            {
                log.Error("Error saving image: " + e.Message);
            }
        }

        public void DeleteImageFolder()
        {
            string fileDir = GetFileDirectory();
            try
            {
                if (Directory.Exists(fileDir))
                {
                    Directory.Delete(fileDir, true);
                    log.Info("Image folder successfully deleted");
                }
            }
            catch (Exception e)
            {
                log.Error("Error deleting image folder " + e.Message);
            }
        }

        //Deletes Image if tour does not exist anymore
        public void DeleteImage(TourModel tour)
        {
            string filePath = GetFilePath(tour);

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    log.Info("Image successfully deleted");
                }

            }
            catch (Exception e)
            {
                log.Error("Error deleting image " + e.Message);
            }
        }
    }
}
