using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Location.Lib
{
    public class LocationUpdater
    {
        public static async void UpdateLocation(string name, string number, string bloodGroup, string hierarchy,
            string reserve, double latitude, double longitude)
        {
            var payload = new User();
            payload.BloodGroup = bloodGroup;
            payload.Hierarchy = hierarchy;
            payload.Latitude = latitude;
            payload.Longitude = longitude;
            payload.Name = name;
            payload.Phone = number;
            payload.Reserve = reserve;

            var stringPayload = JsonConvert.SerializeObject(payload);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            try
            {
                var myHttpClient = new HttpClient();
                
                //var response = await myHttpClient.PostAsync("http://resources.azurewebsites.net/api/resource", httpContent);
                var response = await myHttpClient.PostAsync("API address for Post", httpContent);   //update before you run
                //response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
