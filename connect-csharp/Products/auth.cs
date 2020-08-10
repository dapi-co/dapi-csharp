
namespace connect_csharp.Products
{
    public class Auth
    {
        public Auth()
        {
        }
        public static string GetPathExchangeToken()
        {
            return "/auth/ExchangeToken";
        }
        public static object getPostDataExchangeToken(string appSecret, string accessCode, string connectionID)
        {
            return new
            {
                appSecret = appSecret,
                accessCode = accessCode,
                connectionID = connectionID
            };
        }


        public static string GetPathRefreshAccessToken()
        {
            return "/auth/RefreshAccessToken";
        }
        public static object getPostDataRefreshAccessToken( string appSecret,string accessToken)
        {
            return new
            {
                appSecret = appSecret,
                accessToken = accessToken
            };
        }
        public static string getPathCheckLogin()
        {
            return "/auth/login/check";
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
            return "/Users/DelinkUser";
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
