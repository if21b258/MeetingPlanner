using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerModel; //Hier kann Fehler sein


namespace TourPlannerBL
{
    public class MapQuest
    {
        public string Key;
        public string Origin;
        public string Destination;
        public string TransportType;
        public string Url;
        public string UrlRoute;


        public MapQuest(TourModel Tour)
        {
            Key = ConfigurationManager.AppSettings["MapQuestKey"];
            Origin = Tour.Origin;
            Destination = Tour.Destination;
            TransportType = Tour.TransportType;
            Url = $"https://www.mapquestapi.com/staticmap/v5/map?start={Uri.EscapeDataString(Origin)}&end={Uri.EscapeDataString(Destination)}&size=600,400&key={Key}";
            UrlRoute = $"http://www.mapquestapi.com/directions/v2/route?key={Key}&from={Uri.EscapeDataString(Origin)}&to={Uri.EscapeDataString(Destination)}&routeType={Tour.TransportType}";
        }

        public async Task<TourModel> GetWay(TourModel tourModel)
        {
           
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(UrlRoute);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    JObject JsonContent = JObject.Parse(responseContent);

                    if (JsonContent["info"]["statuscode"].ToString() != "0") 
                    {
                        // throw Exception //To be Done
                        return null;
                    
                    }
                    else
                    {
                        var session = JsonContent["route"]["sessionId"].ToString();
                        var route = JsonContent["route"];
                        tourModel.Distance = (float)Math.Round(JsonContent["route"]["distance"].Value<double>(), 2);
                        tourModel.EstimatedTime = (float)Math.Round(JsonContent["route"]["realTime"].Value<float>(), 0);

                        
                        tourModel.Map = await GetMap(tourModel);

                        return tourModel;
                       
                    }

                    //return responseContent;
                }
                else
                {
                    // Handle the API request error
                    return null;
                }
            }

        }


        public async Task<byte[]> GetMap(TourModel tourModel)
        {
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    byte[] image = await response.Content.ReadAsByteArrayAsync();
                    return image;

                    // Process the image bytes as needed (e.g., save to a file, display in an Image control, etc.)
                }
                else
                {
                    throw new Exception();
                    Console.WriteLine("Error");
                }
            }

        }
    }
}
