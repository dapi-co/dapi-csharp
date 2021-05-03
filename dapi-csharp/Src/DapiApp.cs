using System;
using System.Collections.Generic;
using Dapi.Products;
using Dapi.Response;
using Dapi.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Dapi {
    /// <summary>
    /// DapiApp represents a client app that's using one or more of the Dapi products.
    /// </summary>
    public class DapiApp {
        private readonly string appSecret;
        private readonly Auth a;
        private readonly Data d;
        private readonly Payment p;
        private readonly Metadata m;

        public DapiApp(string appSecret) {
            this.appSecret = appSecret;
            this.a = new Auth(appSecret);
            this.d = new Data(appSecret);
            this.p = new Payment(appSecret);
            this.m = new Metadata(appSecret);
        }

        /// <summary>
        /// exchangeToken talks to the ExchangeToken endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accessCode">
        /// retrieved from user login.
        /// </param>
        /// <param name="connectionID">
        /// retrieved from user login.
        /// </param>
        public ExchangeTokenResponse exchangeToken(string accessCode, string connectionID) {
            return this.a.exchangeToken(accessCode, connectionID);
        }

        /// <summary>
        /// getIdentity talks to the GetIdentity endpoint of Dapi, with this DapiApps appSecret.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetIdentityResponse getIdentity(string accessToken, string userSecret) {
            return this.d.getIdentity(accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getIdentity talks to the GetIdentity endpoint of Dapi, with this {@link DapiApp}'s appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetIdentityResponse getIdentity(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.d.getIdentity(accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// getAccounts talks to the GetAccounts endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetAccountsResponse getAccounts(string accessToken, string userSecret) {
            return this.d.getAccounts(accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getAccounts talks to the GetAccounts endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetAccountsResponse getAccounts(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.d.getAccounts(accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// getBalance talks to the GetBalance endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accountID">
        /// the id of the account which this operation is about.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetBalanceResponse getBalance(string accountID, string accessToken, string userSecret) {
            return this.d.getBalance(accountID, accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getBalance talks to the GetBalance endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="accountID">
        /// the id of the account which this operation is about.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetBalanceResponse getBalance(string accountID, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.d.getBalance(accountID, accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// getTransactions talks to the GetTransactions endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accountID">
        /// the id of the account which this operation is about.
        /// </param>
        /// <param name="fromDate">
        /// the start date of the transactions we want.
        /// </param>
        /// <param name="toDate">
        /// the end date of the transactions we want.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetTransactionsResponse getTransactions(string accountID, DateTime fromDate, DateTime toDate, string accessToken, string userSecret) {
            return this.d.getTransactions(accountID, fromDate, toDate, accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getTransactions talks to the GetTransactions endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="accountID">
        /// the id of the account which this operation is about.
        /// </param>
        /// <param name="fromDate">
        /// the start date of the transactions we want.
        /// </param>
        /// <param name="toDate">
        /// the end date of the transactions we want.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetTransactionsResponse getTransactions(string accountID, DateTime fromDate, DateTime toDate, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.d.getTransactions(accountID, fromDate, toDate, accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// createBeneficiary talks to the CreateBeneficiary endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="beneficiary">
        /// the beneficiary that should be created.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public CreateBeneficiaryResponse createBeneficiary(Payment.BeneficiaryInfo beneficiary, string accessToken, string userSecret) {
            return this.p.createBeneficiary(beneficiary, accessToken, userSecret, "", null);
        }

        /// <summary>
        /// createBeneficiary talks to the CreateBeneficiary endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="beneficiary">
        /// the beneficiary that should be created.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public CreateBeneficiaryResponse createBeneficiary(Payment.BeneficiaryInfo beneficiary, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.p.createBeneficiary(beneficiary, accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// getBeneficiaries talks to the GetBeneficiaries endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetBeneficiariesResponse getBeneficiaries(string accessToken, string userSecret) {
            return this.p.getBeneficiaries(accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getBeneficiaries talks to the GetBeneficiaries endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetBeneficiariesResponse getBeneficiaries(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.p.getBeneficiaries(accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// createTransfer talks to the CreateTransfer endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="transfer">
        /// the details of the transfer that should be initiate.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public CreateTransferResponse createTransfer(Payment.Transfer transfer, string accessToken, string userSecret) {
            return this.p.createTransfer(transfer, accessToken, userSecret, "", null);
        }

        /// <summary>
        /// createTransfer talks to the CreateTransfer endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="transfer">
        /// the details of the transfer that should be initiate.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public CreateTransferResponse createTransfer(Payment.Transfer transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.p.createTransfer(transfer, accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// transferAutoflow talks to the TransferAutoflow endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="transferAutoflow">
        /// the details required to create a TransferAutoflow operation.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public TransferAutoflowResponse transferAutoflow(Payment.TransferAutoflow transferAutoflow, string accessToken, string userSecret) {
            return this.p.transferAutoflow(transferAutoflow, accessToken, userSecret, "", null);
        }

        /// <summary>
        /// transferAutoflow talks to the TransferAutoflow endpoint of Dapi, with this DapiApp's appSecret,
        /// to continue a previous operation that required to provide some userInputs.
        /// </summary>
        ///
        /// <param name="transferAutoflow">
        /// the details required to create a TransferAutoflow operation.
        /// </param>
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public TransferAutoflowResponse transferAutoflow(Payment.TransferAutoflow transferAutoflow, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.p.transferAutoflow(transferAutoflow, accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// getAccountsMetadata talks to the GetAccountsMetadata endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        public GetAccountsMetadataResponse getAccountsMetadata(string accessToken, string userSecret) {
            return this.m.getAccountsMetadata(accessToken, userSecret, "", null);
        }

        /// <summary>
        /// getAccountsMetadata talks to the GetAccountsMetadata endpoint of Dapi, with this DapiApp's appSecret.
        /// </summary>
        ///
        /// <param name="accessToken">
        /// retrieved from the ExchangeToken process.
        /// </param>
        /// <param name="userSecret">
        /// retrieved from the user login.
        /// </param>
        /// <param name="operationID">
        /// retrieved from the previous call's response.
        /// </param>
        /// <param name="userInputs">
        /// built from the previous call's response, and the required user input.
        /// </param>
        public GetAccountsMetadataResponse getAccountsMetadata(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            return this.m.getAccountsMetadata(accessToken, userSecret, operationID, userInputs);
        }

        /// <summary>
        /// handleSDKRequest injects this {@link DapiApp}'s appSecret in the passed request body, bodyJson, and then
        /// forwards the request to Dapi, with the passed headers, headersMap, and returns the RAW response got.
        /// </summary>
        ///
        /// <param name="bodyJson">
        /// the body of the request, in JSON format.
        /// </param>
        /// <param name="headers">
        /// any headers that needs to be passed with the request.
        /// </param>
        public IRestResponse handleSDKRequest(string bodyJson, ICollection<KeyValuePair<string, string>> headers) {
            var bodyMap = JsonConvert.DeserializeObject<JObject>(bodyJson, DapiRequest.jsonSettings);

            // add the appSecret field to the passed request body, ignoring it if it's already set
            bodyMap?.Remove("appSecret");
            bodyMap?.Add("appSecret", new JValue(this.appSecret));

            return DapiRequest.HandleSDK(bodyMap, headers);
        }

        /// <summary>
        /// handleSDKRequest injects this DapiApp's appSecret in the passed request body, bodyJson, and then
        /// forwards the request to Dapi, and returns the RAW response got.
        /// </summary>
        ///
        /// <param name="bodyJson">
        /// the body of the request, in JSON format.
        /// </param>
        public IRestResponse handleSDKRequest(string bodyJson) {
            return this.handleSDKRequest(bodyJson, new List<KeyValuePair<string, string>>());
        }
    }
}
