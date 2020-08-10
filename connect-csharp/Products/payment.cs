using System;
namespace connect_csharp.Products
{
    public class payment
    {
        public payment()
        {
        }
        public static string getPathCreateTransfer()
        {
            return "v1/payment/transfer/create";
        }
        public static object getPostDataCreateTransfer(string appSecret, string userSecret, string receiverID, string senderID, string amount)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,

                sync = true,

                receiverID = receiverID,
                senderID = senderID,
                amount = amount
            };
        }

        public static string getPathCreateBeneficiary()
        {
            return "v1/payment/beneficiaries/create";
        }
        public static object getPostDataCreateBeneficiary(string appSecret, string userSecret, string name, string accountNumber, string type, string address, string bankName, string swiftCode)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,

                sync = true,
                name = name,
                accountNumber = accountNumber,
                swiftCode = swiftCode,
                bankName = bankName,
                address = address,
                type = type

            };

        }

        public static string getPathGetBeneficiary()
        {
            return "v1/payment/beneficiaries/get";
        }
        public static object getPostDataGetBeneficiary(string appSecret, string userSecret)
        {
            return new
            {
                appSecret = appSecret,
                userSecret = userSecret,

                sync = true,


            };
        }
    }
}
