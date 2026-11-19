using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DNALabelSync
{
    internal class BCConnect
    {
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        private GlobalSettingsMgr _settingsMgr = null;
        string tenantId = "2f9111ab-7034-4cb0-9bda-644a4f79febc";
        string clientId = "a7271096-c240-43ad-8929-4ec8dcf2aeab";
        string clientSecret = "c_e8Q~GCe9Rm5GBAiWSXzKERuG-ghYyqQppNXbvw";

        public async Task<bool> GetAccessToken()
        {
            // Business Central's resource scope
            string[] scopes = new[] { "https://api.businesscentral.dynamics.com/.default" };

            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
                .Build();
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // 5 second timeout
            _settingsMgr = new GlobalSettingsMgr();
            AuthenticationResult result;
            try
            {
                result = await app.AcquireTokenForClient(scopes).ExecuteAsync(cts.Token);
                string accessToken = result.AccessToken;
                GlblSettings.AccessToken = accessToken;
                _settingsMgr.SaveSettings(GlblSettings);
                Console.WriteLine(accessToken);
            }
            catch (MsalServiceException ex)
            {
                Console.WriteLine($"Token acquisition failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Type: {ex.GetType().Name}, Message: {ex.Message}");
            }
            return true;
        }
        public async Task<string> GetSerialTrackingAsync()
        {
            if (string.IsNullOrEmpty(GlblSettings.AccessToken))
            {
                throw new InvalidOperationException("No access token available. Call GetAccessToken() first.");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", GlblSettings.AccessToken);
            /* https://api.businesscentral.dynamics.com/v2.0/UAT06042026/api/DNA/BC/v2.0/companies(b1623225-8ad1-ea11-bb85-000d3a2a9e6e)/UpdateSerialNoTrackerSet */

            string url = $"https://api.businesscentral.dynamics.com/v2.0/" + $"{GlblSettings.BCEnvironment}/api/DNA/BC/v2.0/companies({GlblSettings.BCCompanyId})/UpdateSerialNoTrackerSet";

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request failed: {response.StatusCode} - {error}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling Items API: {ex.Message}");
                return null;
            }
        }
        public async Task<BcApiResult> PostSerialTrackerToBusinessCentral(Serial_No__Tracker slt)
        {
            string bcApiUrl =  $"https://api.businesscentral.dynamics.com/v2.0/" + $"{GlblSettings.BCEnvironment}/api/DNA/BC/v2.0/companies({GlblSettings.BCCompanyId})/UpdateSerialNoTrackerSet";
            BCSerialTracker bcSerialTracker = new BCSerialTracker();
            bcSerialTracker.SerialNo = slt.Serial_No_;
            DateTime myDateTime = (DateTime)slt.Production_Date_Time;

            bcSerialTracker.ProductionDate = myDateTime.ToString("yyyy-MM-dd");
            bcSerialTracker.Location = slt.Location;
            bcSerialTracker.AssemblyLineNo = slt.Assembly_Line_No_.ToString();
            bcSerialTracker.ItemModelNo = slt.Item_Model_Number;
            bcSerialTracker.EngineSerialNo = slt.Engine_Serial_No_;
            var options = new JsonSerializerOptions { WriteIndented = false };
            string jsonString = JsonSerializer.Serialize(bcSerialTracker, options);
            jsonString = jsonString.Replace("\r", "").Replace("\n", "").Replace("\\", "");
            BcApiResult  result = await PostToBusinessCentral(jsonString, bcApiUrl, GlblSettings.AccessToken);
            return result;

        }
        public async Task<BcApiResult> PostToBusinessCentral(string jsonPayload, string bcApiUrl, string bearerToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(bcApiUrl, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new BcApiResult
                {
                    Success = true,
                    Message = responseBody,
                    StatusCode = (int)response.StatusCode
                };
            }
            else
            {
                return new BcApiResult
                {
                    Success = false,
                    Message = responseBody,
                    StatusCode = (int)response.StatusCode
                };
            }
        }


    }
    public class BcApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
