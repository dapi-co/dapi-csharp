using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products
{
    public class Auth
    {
        public Auth()
        {
        }
        public static string GetPathExchangeToken()
        {
            return "v1/auth/ExchangeToken";
        }
        public static object getPostDataExchangeToken(string appSecret, string accessToken, string connectionId)
        {
            return new
            {
                appSecret = appSecret,
                accessToken = accessToken,
                connectionId = connectionId
            };
        }


        public static string GetPathRefreshAccessToken()
        {
            return "v1/auth/RefreshAccessToken";
        }
        public static object getPostDataRefreshAccessToken(string accessToken, string appSecret)
        {
            return new
            {
                appSecret = appSecret,
                accessToken = accessToken
            };
        }
        public static string getPathCheckLogin()
        {
            return "v1/auth/login/check";
        }
        public static object getPostDataCheckLogin(string appSecret, string userSecret)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true
            };
        }
        public static string getPathDeLinkUser()
        {
            return "v1/Users/DelinkUser";
        }
        public static object getPostDataDeLinkUser(string appSecret)
        {
            return new
            {
                appSecret = appSecret
            };
        }

    }
}
