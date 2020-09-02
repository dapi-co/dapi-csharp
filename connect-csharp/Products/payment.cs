
using Newtonsoft.Json;
using RestSharp;
using TestCsharplibrary.Products;
using TestCsharplibrary.Products.Constants.payments;

namespace connect_csharp.Products
{
    public class Payment : request
    {

        string appSecret;

        public CreateBeneficiaryResponse createBeneficiaryResponse;
        public GetBeneficiaryResponse getBeneficiaryResponse;
        public CreateTransferResponse createTransferResponse;
        public Payment(string appSecret, RestClient client) : base(client)
        {
            this.appSecret = appSecret;
        }
        public static string getPathCreateTransfer()
        {
            return "/payment/transfer/create";
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
            return "/payment/beneficiaries/create";
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
            return "/payment/beneficiaries/get";
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


        public CreateTransferResponse createTransfer(string accessToken, string userSecret, string receiverID, string senderID, string amount)
        {
            string response = authenticatedRequest(getPathCreateTransfer(), getPostDataCreateTransfer(this.appSecret, userSecret, receiverID, senderID, amount), accessToken);
            CreateTransferResponse root = new CreateTransferResponse();
            root = JsonConvert.DeserializeObject<CreateTransferResponse>(response);

            return root;
        }
        public CreateBeneficiaryResponse createBeneficiary(string accessToken, string userSecret, string name, string accountNumber, string type, string address, string bankName, string swiftCode)
        {
            string response = authenticatedRequest(getPathCreateBeneficiary(), getPostDataCreateBeneficiary(this.appSecret, userSecret, name, accountNumber, type, address, bankName, swiftCode), accessToken);
            CreateBeneficiaryResponse root = new CreateBeneficiaryResponse();
            root = JsonConvert.DeserializeObject<CreateBeneficiaryResponse>(response);

            return root;
        }
        public GetBeneficiaryResponse getBeneficiary(string accessToken, string userSecret)
        {
            string response = authenticatedRequest(getPathGetBeneficiary(),getPostDataGetBeneficiary(appSecret, userSecret), accessToken);

            GetBeneficiaryResponse root = new GetBeneficiaryResponse();
            root = JsonConvert.DeserializeObject<GetBeneficiaryResponse>(response);

            return root;
        }
    }
}
