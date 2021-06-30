using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;

namespace DapiSDKExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DapiSDKRequestsController : ControllerBase
    {
        // if you plan to use this controller for both views and web APIs,
        // then make the base clase `Controller` instead of `ControllerBase`.

        private readonly ILogger<DapiSDKRequestsController> _logger;

        public DapiSDKRequestsController(ILogger<DapiSDKRequestsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Create([FromBody] JsonElement reqBody)
        {
            // Read the headers of the request, and prepare them to be passed to Dapi
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }

            // Call Dapi to handle the request, using the created DapiApp instance
            var resp = Startup.dapiApp.handleSDKRequest(reqBody.GetRawText(), requestHeaders);

            // Check the state of the response got from Dapi
            if (resp.IsSuccessful)
            {
                // Handle the response
                return resp.Content;
            }
            else
            {
                // Handle the error
                return resp.ErrorMessage;
            }
        }
    }
}
