using System;
namespace TestCsharplibrary.Products
{
    public class jobs
    {
        public jobs()
        {
        }
        public static string getPathJobStatus()
        {
            return "v1/job/status";
        }
        public static object getPostDataJobStatus(string appSecret,string userSecret,string jobID)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = true,
            };
        }
        public static object getPostDataJobStatus(string appSecret, string userSecret, string jobID,string sync)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,
                sync = sync,
            };
        }
    }
}
