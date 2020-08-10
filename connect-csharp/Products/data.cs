using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products
{
    public class Data
    {
        public Data()
        {
        }
        public static string GetPathIdentity()
        {
            return "v1/data/Identity/get";
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
        public static string GetPathAccounts()
        {
            return "v1/data/accounts/get";
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
            return "v1/data/balance/get";
        }

        public static object GetPostDataBalance(string appSecret, string userSecret,string accountID)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true,
                accountID=accountID
            };

        }

        public static string GetPathTransations()
        {
            return "v1/data/transactions/get";
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
            return "v1/metadata/accounts/get";
        }
        public static object GetPostDataMetaData(string appSecret, string userSecret, string accountID, string toDate, string fromDate)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true
            };
        }
    }

}
