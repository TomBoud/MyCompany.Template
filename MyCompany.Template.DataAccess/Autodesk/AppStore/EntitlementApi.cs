
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;

namespace MyCompany.Template.DataAccess.Autodesk.AppStore
{
    public class EntitlementApi
    {

        private readonly string _baseUrl;
        private readonly string _endPoint;

        public EntitlementApi(string baseUrl, string endPoint)
        {
            _baseUrl = baseUrl;
            _endPoint = endPoint;
        }

        public bool CheckEntitlement(string appId, string userId)
        {
            try
            {
                // (1) Build request
                var client = new RestClient(_baseUrl);

                // Set resource/end point
                var request = new RestRequest();
                //"webservices/checkentitlement"
                request.Resource = _endPoint;
                request.Method = Method.Get;

                // Add parameters
                request.AddParameter(nameof(userId), userId);
                request.AddParameter(nameof(appId), appId);

                // (2) Execute request and get response
                var response = client.Execute(request);

                // (3) Parse the response and get the value of IsValid.
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = JsonConvert.DeserializeObject<EntitlementModel>(response.Content);
                    return responseContent.IsValid;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
            catch (WebException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
