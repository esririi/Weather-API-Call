
using Newtonsoft.Json;
using RestSharp;


namespace API
{
    public class APIManager
    {
        public WeatherData API(string city)
        {
            var client = new RestClient($"https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city={city}");
            var request = new RestRequest("", Method.Get);
            request.AddHeader("authorization", "apikey 1SjBTE9prnFzlBs2V91QFw:625Z0to3ITbrXNlPFqqDaG");
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);

            string result = response.Content;
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(result);

            return weatherData;
        }
    }
}
