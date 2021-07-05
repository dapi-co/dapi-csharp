# LegacyDapiSDKExample

This example shows how [Dapi's C# library](https://github.com/dapi-co/dapi-csharp) could be used as a server endpoint to handle Dapi requests forwarded to it, using old .NET technologies.

>The example shows a very basic server.   


**How to run it**:
- Open the example in VisualStudio (or any equivalent IDE).
- Edit the `Controller/DapiSDKController.cs` file to replace the `YOUR_APP_SECRET` constant passed to the `DapiApp` constructor, at the very start of the file, with you Dapi application's `AppSecret`.
- Run the example from VisualStudio.
- The server is now listening on: http://localhost:44395 (by default).
- The endpoint is now exposed on: http://localhost:43206/api/DapiSDK/HandleSDKRequestsAsync (by default).
- Use Postman (or any equivalent app), to POST valid Dapi requests to the endpoint `URL`.
  - All requests' bodies should be in `JSON` format.
- All requests should pass the `Authorization` header, with its value set to the `accessToken` as a `Bearer` token.
  - The `accessToken` is retrieved from the [ExchangeToken](https://dapi-api.readme.io/docs/exchange-token) process.
