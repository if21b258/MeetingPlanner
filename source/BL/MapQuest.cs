using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerModel; //Hier kann Fehler sein


namespace TourPlannerBL
{
    public class MapQuest
    {

        //public string Key = "yN4eflLMNbDl3WCx0xTc9fX93CdrKUrV";
        public string Key;
        public string Origin;
        public string Destination;
        public string TransportType;
        public string Url;


        public MapQuest(TourModel Tour)
        {
            Key = "yN4eflLMNbDl3WCx0xTc9fX93CdrKUrV";
            Origin = Tour.Origin;
            Destination = Tour.Destination;
            TransportType = Tour.TransportType;
            Url = $"https://www.mapquestapi.com/staticmap/v5/map?start={Uri.EscapeDataString(Origin)}&end={Uri.EscapeDataString(Destination)}&size=600,400&key={Key}";

        }

        public async Task<Route> GetMap(TourModel)
        {
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) t
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                    // Process the image bytes as needed (e.g., save to a file, display in an Image control, etc.)
                }
            else
                {
                    throw new Exception;
                    Console.WriteLine("Error");
                }
            }

        }
    }


}
