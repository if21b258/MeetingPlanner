using Newtonsoft.Json.Linq;
using System.Configuration;
using TourPlannerModel;
using TourPlannerBL.Logging;


namespace TourPlannerBL.Service
{
    //Class for requesting mapimage and further information
    public class MapQuestService : IMapQuestService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        public string Key;
        public string Origin;
        public string Destination;
        public string TransportType;
        public string Url;
        public string UrlRoute;


        public MapQuestService(TourModel tour)
        {
            //Getting Key from the Appconfig file
            Key = ConfigurationManager.AppSettings["MapQuestKey"];
            Origin = tour.Origin;
            Destination = tour.Destination;
            Url = $"https://www.mapquestapi.com/staticmap/v5/map?start={Uri.EscapeDataString(Origin)}&end={Uri.EscapeDataString(Destination)}&size=600,400&key={Key}";
            UrlRoute = $"http://www.mapquestapi.com/directions/v2/route?key={Key}&from={Uri.EscapeDataString(Origin)}&to={Uri.EscapeDataString(Destination)}&routeType={tour.TransportType}&unit=k";
        }

        //Getting further information about the route
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
                            log.Error("Route calculation failed.");
                            throw new Exception("Route calculation failed.");
                        }
                        else
                        {
                            var session = JsonContent["route"]["sessionId"].ToString();
                            var route = JsonContent["route"];
                            tourModel.Distance = (float)Math.Round(JsonContent["route"]["distance"].Value<double>(), 2);
                            float estimationTime = (float)Math.Round(JsonContent["route"]["realTime"].Value<float>(), 0);
                            tourModel.EstimatedTime = TimeSpan.FromSeconds(estimationTime);

                            log.Info($"Retrieved tour info for tour: {tourModel.Name}");

                            return await GetMap(tourModel);
                        }
                    }
                    else
                    {
                        log.Error("Error occurred while fetching route data.");
                        throw new HttpRequestException("Error occurred while fetching route data.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                log.Error("Error occurred while fetching route data: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                log.Error("Error occurred during route calculation: " + ex.Message);
                return null;
            }

        }

        //Requesting the Routeimage
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
                        log.Info($"Image for tour: {tourModel.Name} successfully retrieved.");

                        return image;
                    }
                    else
                    {
                        log.Error("Error occurred while fetching the map image.");
                        throw new HttpRequestException("Error occurred while fetching the map image.");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error occurred while fetching the map image: " + ex.Message);
                return null;
            }


        }
    }
}





