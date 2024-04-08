using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;


namespace MotApp.Clients
{
    public class VehicleClient(HttpClient httpClient)
    {
        public async Task<VehicleDTO> GetVehicleAsync(string registrationNumber)
        {
            // create request object
            var request = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + $"?registration={registrationNumber}");

            // add authorization header
            request.Headers.Add("x-api-key", "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno");

            // send request
            using var httpResponse = await httpClient.SendAsync(request);

            // convert http response data to UsersResponse object
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                var deserializedContent = JsonConvert.DeserializeObject<Vehicle>(responseContent.Substring(1, responseContent.Length - 2));

                VehicleDTO mappedVehicle = new VehicleDTO()
                {
                    Make = deserializedContent?.make,
                    Model = deserializedContent?.model,
                    Colour = deserializedContent?.primaryColour,
                    MOTexpiryDate = deserializedContent?.motTests?.Count > 0 ? deserializedContent?.motTests[0]?.expiryDate : null,
                    MileageAtLastMOT = deserializedContent?.motTests?.Count > 0 ? deserializedContent?.motTests[0]?.odometerValue.ToString() : "N/A",
                };

                return mappedVehicle;
            }
            else
            {
                VehicleDTO notFoundResult = new VehicleDTO()
                {
                    notFound = true
                };

                return notFoundResult;
            }
        }
    }
}
