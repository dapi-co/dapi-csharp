using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TestCsharplibrary.Products;
using TestCsharplibrary.Products.Constants;

namespace connect_csharp.Products
{
    public class Data : request
    {
        string appSecret;
        public identityResponse identity;
        public accountsResponse accounts;
        public balanceResponse balance;
        public transactionsResponse transactions;
        public accountsMetaDataResponse accountsMetaData;

        public Data(string appSecret, RestClient client) : base(client)

        {
            this.appSecret = appSecret;
            //identity = new identityResponse();
            //accountsResponse = new accountsResponse();

        }
        public static string GetPathIdentity()
        {
            return "/data/Identity/get";
        }
        public static object GetPostDataIdentity(string appSecret, string userSecret)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true
            };

        }
        //Identity

        public identityResponse getIdentity(string accessToken, string userSecret)
        {

            string data = authenticatedRequest(Data.GetPathIdentity(), Data.GetPostDataIdentity(this.appSecret, userSecret), accessToken);




            identityResponse root = new identityResponse();
            root = JsonConvert.DeserializeObject<identityResponse>(data);


            return root;

        }

        public accountsResponse getAccounts(string accessToken, string userSecret)
        {
            string response = authenticatedRequest(Data.GetPathAccounts(), Data.GetPostDataAccounts(this.appSecret, userSecret), accessToken);


            accountsResponse root = new accountsResponse();
            root = JsonConvert.DeserializeObject<accountsResponse>(response);
           
            return root;
        }




        public balanceResponse getBalance(string accessToken, string userSecret, string accountID)
        {
            string response = authenticatedRequest(Data.GetPathBalance(), Data.GetPostDataBalance(this.appSecret, userSecret, accountID), accessToken);

            balanceResponse root = new balanceResponse();
            root = JsonConvert.DeserializeObject<balanceResponse>(response);

            return root;
        }



        public transactionsResponse getTransactions(string accessToken, string userSecret, string accountID, string toDate, string fromDate)
        {
            string response = authenticatedRequest(Data.GetPathTransations(), Data.GetPostDataTransactions(this.appSecret, userSecret, accountID, toDate, fromDate), accessToken);

            transactionsResponse root = new transactionsResponse();
            root = JsonConvert.DeserializeObject<transactionsResponse>(response);

            return root;
        }

        public static string GetPathAccounts()
        {
            return "/data/accounts/get";
        }
        public static object GetPostDataAccounts(string appSecret, string userSecret)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true
            };

        }
        public static string GetPathBalance()
        {
            return "/data/balance/get";
        }

        public static object GetPostDataBalance(string appSecret, string userSecret, string accountID)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true,
                accountID = accountID
            };

        }

        public static string GetPathTransations()
        {
            return "/data/transactions/get";
        }
        public static object GetPostDataTransactions(string appSecret, string userSecret, string accountID, string toDate, string fromDate)
        {

            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,

                sync = true,
                fromDate = fromDate,
                toDate = toDate,
                accountID = accountID
            };
        }


        public static string GetPathMetaData()
        {
            return "/metadata/accounts/get";
        }
        public static object GetPostDataMetaData(string appSecret, string userSecret)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true
            };
        }
    }

    //public class Identity : baseResponse
    //{
    //    public string name;

    //    public string nationality;
    //    public string dateOfBirth;
    //    public string identification;
    //    //   "numbers": [
    //    //{
    //    //  "type": "mobile",
    //    //  "value": "201007679082"
    //    //}

    //    public string emailAddress;

    //    public Address address;
    //    public List< Numbers> numbers;
    //    public Identity() : base()
    //    {
    //      address=  new Address();
    //    }
    //}



    //public class Identity { 
    //    public string name;

    //    public string nationality;
    //    public string dateOfBirth;
    //    public string identification;
    //    //   "numbers": [
    //    //{
    //    //  "type": "mobile",
    //    //  "value": "201007679082"
    //    //}

    //    public string emailAddress;

    //    public Address address;
    //    public List<Numbers> numbers;
    //    public Identity() : base()
    //    {
    //        address = new Address();
    //    }
    //}


    //public class Address
    //{
    //    public string flat;
    //    public string building;
    //    public string full;
    //    public string area;
    //    public string poBox;
    //    public string city;
    //    public string state;
    //    public string country;

    //}

    //public class Numbers
    //{
    //    string value;
    //    string type;
    //}
    //public class baseResponse
    //{
    //    public string jobID = "test";
    //    public Boolean success = true;
    //    public string status = "done";
    //}
    //public class test
    //{
    //    public string jobID;
    //    public Boolean success;
    //    public string status;
    //    public Identity identity;
    //}

}
