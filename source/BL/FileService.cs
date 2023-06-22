using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
using System.Drawing;
using System.IO;

namespace TourPlannerBL
{
    public class FileService
    {
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
                }
                if(mapImage == null)
                {
                    Console.WriteLine("No Image loaded");
                }
                else
                {
                    using (MemoryStream fileStream = new MemoryStream(mapImage))
                    {

                        var image = Image.FromStream(fileStream);
                        image.Save(filePath);

                    }
                    Console.WriteLine("Picture successfully saved in " + filePath);

                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving picture " + e.Message);
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
                }
                Console.WriteLine("Picture folder successfully deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting picture folder " + e.Message);
            }
        }
    }
}
