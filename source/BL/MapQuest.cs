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


        public MapQuest(TourModel tour)
        {
            Key = ConfigurationManager.AppSettings["MapQuestKey"];
            Origin = tour.Origin;
            Destination = tour.Destination;
            TransportType = tour.TransportType;
            Url = $"https://www.mapquestapi.com/staticmap/v5/map?start={Uri.EscapeDataString(Origin)}&end={Uri.EscapeDataString(Destination)}&size=600,400&key={Key}";
            UrlRoute = $"http://www.mapquestapi.com/directions/v2/route?key={Key}&from={Uri.EscapeDataString(Origin)}&to={Uri.EscapeDataString(Destination)}&routeType={tour.TransportType}";
        }

        public async Task<byte[]> GetWay(TourModel tourModel)
        {
            try
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
                            throw new Exception("Route calculation failed.");
                        }
                        else
                        {
                            var session = JsonContent["route"]["sessionId"].ToString();
                            var route = JsonContent["route"];
                            tourModel.Distance = (float)Math.Round(JsonContent["route"]["distance"].Value<double>(), 2);
                            tourModel.EstimatedTime = (float)Math.Round(JsonContent["route"]["realTime"].Value<float>(), 0);

                            return await GetMap(tourModel);
                        }
                    }
                    else
                    {
                        throw new HttpRequestException("Error occurred while fetching route data.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error occurred while fetching route data: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during route calculation: " + ex.Message);
                return null;
            }

        }


        public async Task<byte[]> GetMap(TourModel tourModel)
        {
            try
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
                        throw new HttpRequestException("Error occurred while fetching the map image.");
                        Console.WriteLine("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while fetching the map image: " + ex.Message);
                return null;
            }


        }
    }
}





