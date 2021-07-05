using Dapi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace LegacyDapiSDKExample.Controllers
{
    public class DapiSDKController : ApiController
    {
        // Create a DapiApp instance, using your AppSecret
        public static DapiApp dapiApp = new DapiApp("YOUR_APP_SECRET");

        [System.Web.Mvc.HttpPost]
        public async System.Threading.Tasks.Task<string> HandleSDKRequestsAsync()
        {
            // Read the body of the request
            string requestBody = await Request.Content.ReadAsStringAsync();

            // Read the headers of the request, and prepare them to be passed to Dapi
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value?.FirstOrDefault());
            }

            // Call Dapi to handle the request, using the created DapiApp instance
            var resp = dapiApp.handleSDKRequest(requestBody, requestHeaders);

            // Check the state of the response got from Dapi
            if (resp.IsSuccessful)
            {
                // Handle the response
                return resp.Content;
            }
            else if (resp.ErrorMessage != null)
            {
                // Handle the error
                return resp.ErrorMessage;
            }
            else
            {
                return resp.Content;
            }
        }
    }
}