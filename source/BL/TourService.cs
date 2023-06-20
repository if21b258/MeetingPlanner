using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
using System.Drawing;
using System.Net.NetworkInformation;

namespace TourPlannerBL
{
    public class TourService
    {
        //private MapQuest mapQuest = new();
        public TourService() { 
        
        
        }

        public async Task GetMap(TourModel Tour)
        {
            MapQuest mapQuest = new(Tour);
            TourModel touri; 
            touri = await mapQuest.GetWay(Tour);
            SaveImageToFile(touri);
            


        }
        public void SaveImageToFile(TourModel Tour)
        {
            string filePath;
            filePath= "C:\\Users\\rif1wi\\Desktop\\FHTW\\TourPlanner\\source\\Ressources\\";
            try
            {
                using (MemoryStream fileStream = new MemoryStream(Tour.Map))
                {
                    
                    var image = Image.FromStream(fileStream);
                    image.Save(filePath + Tour.Name + Tour.Id + ".png");

                }
                Console.WriteLine("Bild erfolgreich gespeichert: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern des Bildes: " + ex.Message);
            }
        }
    }
}
