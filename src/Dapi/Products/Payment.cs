using System.Collections.Generic;
using Dapi.Response;
using Dapi.Types;

namespace Dapi.Products {
    public class Payment {
        private string appSecret { get; }

        public Payment(string appSecret) {
            this.appSecret = appSecret;
        }

        public GetBeneficiariesResponse getBeneficiaries(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetBeneficiariesRequest(appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetBeneficiariesRequest, GetBeneficiariesResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetBeneficiariesResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public CreateBeneficiaryResponse createBeneficiary(BeneficiaryInfo beneficiary, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new CreateBeneficiariesRequest(beneficiary, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<CreateBeneficiariesRequest, CreateBeneficiaryResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new CreateBeneficiaryResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public CreateTransferResponse createTransfer(Transfer transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new CreateTransferRequest(transfer, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<CreateTransferRequest, CreateTransferResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new CreateTransferResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public TransferAutoflowResponse transferAutoflow(TransferAutoflow transferAutoflow, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new TransferAutoflowRequest(transferAutoflow, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<TransferAutoflowRequest, TransferAutoflowResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new TransferAutoflowResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public CreateACHTransferResponse createACHTransfer(ACHTransfer transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new CreateTransferRequest(transfer, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<CreateACHTransferRequest, CreateACHTransferResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new CreateACHTransferResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public class BeneficiaryInfo {
            public string name { get; }
            public string accountNumber { get; }
            public string iban { get; }
            public string swiftCode { get; }
            public Beneficiary.BeneficiaryType type { get; }
            public BeneficiaryAddress address { get; }
            public string country { get; }
            public string branchAddress { get; }
            public string branchName { get; }
            public string bankName { get; }
            public string phoneNumber { get; }
            public string sortCode { get; }
            public string nickname { get; }
            public string routingNumber { get; }

            /// <summary>
            /// Creates an object that holds all the info about some beneficiary.
            /// </summary>
            public BeneficiaryInfo(string name, string accountNumber, string iban, string swiftCode, Beneficiary.BeneficiaryType type, BeneficiaryAddress address,
                string country, string branchAddress, string branchName, string bankName, string phoneNumber, string sortCode, string nickname, string routingNumber) {
                this.name = name;
                this.accountNumber = accountNumber;
                this.iban = iban;
                this.swiftCode = swiftCode;
                this.type = type;
                this.address = address;
                this.country = country;
                this.branchAddress = branchAddress;
                this.branchName = branchName;
                this.bankName = bankName;
                this.phoneNumber = phoneNumber;
                this.sortCode = sortCode;
                this.nickname = nickname;
                this.routingNumber = routingNumber;
            }

            /// <summary>
            /// Creates an object that holds only the required info about some beneficiary.
            /// </summary>
            public BeneficiaryInfo(string name, string accountNumber, string iban, string swiftCode, Beneficiary.BeneficiaryType type, BeneficiaryAddress address,
                string country, string branchAddress, string branchName) {
                this.name = name;
                this.accountNumber = accountNumber;
                this.iban = iban;
                this.swiftCode = swiftCode;
                this.type = type;
                this.address = address;
                this.country = country;
                this.branchAddress = branchAddress;
                this.branchName = branchName;
                this.bankName = null;
                this.phoneNumber = null;
                this.sortCode = null;
                this.nickname = null;
                this.routingNumber = null;
            }
        }

        public class Transfer {
            public string senderID { get; }
            public float amount { get; }
            public string receiverID { get; }
            public string name { get; }
            public string iban { get; }
            public string accountNumber { get; }
            public string remark { get; }
            public string nickname { get; }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that requires the receiver to be already
            /// registered as a beneficiary to perform a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="receiverID">
            /// the id of the beneficiary which the money should be sent to.
            /// retrieved from one of the beneficiaries array returned from the getBeneficiaries method.
            /// </param>
            public Transfer(string senderID, float amount, string receiverID) {
                this.senderID = senderID;
                this.amount = amount;
                this.receiverID = receiverID;
                this.name = null;
                this.iban = null;
                this.accountNumber = null;
                this.remark = null;
                this.nickname = null;
            }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that requires the receiver to be already
            /// registered as a beneficiary to perform a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="receiverID">
            /// the id of the beneficiary which the money should be sent to.
            /// retrieved from one of the beneficiaries array returned from the getBeneficiaries method.
            /// </param>
            /// <param name="remark">
            /// the remark string that will be sent with this transfer.
            /// </param>
            public Transfer(string senderID, float amount, string receiverID, string remark) {
                this.senderID = senderID;
                this.amount = amount;
                this.receiverID = receiverID;
                this.remark = remark;
                this.name = null;
                this.iban = null;
                this.accountNumber = null;
                this.nickname = null;
            }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that handles the creation of beneficiaries
            /// on its own, internally, and doesn't require the receiver to be already registered as a beneficiary to perform
            /// a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="name">
            /// the name of receiver.
            /// </param>
            /// <param name="iban">
            /// the IBAN of the receiver's account.
            /// </param>
            /// <param name="accountNumber">
            /// the Account Number of the receiver's account.
            /// </param>
            public Transfer(string senderID, float amount, string name, string iban, string accountNumber) {
                this.senderID = senderID;
                this.amount = amount;
                this.name = name;
                this.iban = iban;
                this.accountNumber = accountNumber;
                this.receiverID = null;
                this.remark = null;
                this.nickname = null;
            }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that handles the creation of beneficiaries
            /// on its own, internally, and doesn't require the receiver to be already registered as a beneficiary to perform
            /// a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="name">
            /// the name of receiver.
            /// </param>
            /// <param name="iban">
            /// the IBAN of the receiver's account.
            /// </param>
            /// <param name="accountNumber">
            /// the Account Number of the receiver's account.
            /// </param>
            /// <param name="remark">
            /// the remark string that will be sent with this transfer.
            /// </param>
            /// <param name="nickname">
            /// the nickname of the receiver.
            /// </param>
            public Transfer(string senderID, float amount, string name, string iban, string accountNumber, string remark, string nickname) {
                this.senderID = senderID;
                this.amount = amount;
                this.name = name;
                this.iban = iban;
                this.accountNumber = accountNumber;
                this.remark = remark;
                this.nickname = nickname;
                this.receiverID = null;
            }
        }

        public class TransferAutoflow {
            public string bundleID { get; }
            public string appKey { get; }
            public string userID { get; }
            public string bankID { get; }
            public string senderID { get; }
            public float amount { get; }
            public BeneficiaryInfo beneficiary { get; }
            public string remark { get; }

            /// <summary>
            /// Create an object that holds the info needed for the transferAutoflow method.
            /// </summary>
            ///
            /// <param name="bundleID">
            /// one of the bundleIDs set for this app.
            /// </param>
            /// <param name="appKey">
            /// the appKey of this app.
            /// </param>
            /// <param name="userID">
            /// the userID of the user which is initiating this transfer.
            /// </param>
            /// <param name="bankID">
            /// the bankID of the user which is initiating this transfer.
            /// </param>
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="beneficiary">
            /// the required info about the beneficiary.
            /// </param>
            public TransferAutoflow(string bundleID, string appKey, string userID, string bankID, string senderID, float amount, BeneficiaryInfo beneficiary) {
                this.bundleID = bundleID;
                this.appKey = appKey;
                this.userID = userID;
                this.bankID = bankID;
                this.senderID = senderID;
                this.amount = amount;
                this.beneficiary = beneficiary;
                this.remark = null;
            }

            /// <summary>
            /// Create an object that holds the info needed for the transferAutoflow method.
            /// </summary>
            ///
            /// <param name="bundleID">
            /// one of the bundleIDs set for this app.
            /// </param>
            /// <param name="appKey">
            /// the appKey of this app.
            /// </param>
            /// <param name="userID">
            /// the userID of the user which is initiating this transfer.
            /// </param>
            /// <param name="bankID">
            /// the bankID of the user which is initiating this transfer.
            /// </param>
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="beneficiary">
            /// the required info about the beneficiary.
            /// </param>
            /// <param name="remark">
            /// the remark string that will be sent with this transfer.
            /// </param>
            public TransferAutoflow(string bundleID, string appKey, string userID, string bankID, string senderID, float amount, BeneficiaryInfo beneficiary, string remark) {
                this.bundleID = bundleID;
                this.appKey = appKey;
                this.userID = userID;
                this.bankID = bankID;
                this.senderID = senderID;
                this.amount = amount;
                this.beneficiary = beneficiary;
                this.remark = remark;
            }
        }

        public class ACHTransfer {
            public string senderID { get; }
            public float amount { get; }
            public string description { get; }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that requires the receiver to be already
            /// registered as a beneficiary to perform a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="description">
            /// the id of the beneficiary which the money should be sent to.
            /// retrieved from one of the beneficiaries array returned from the getBeneficiaries method.
            /// </param>
            public ACHTransfer(string senderID, float amount, string description) {
                this.senderID = senderID;
                this.amount = amount;
                this.description = description;
            }
        }

        private class GetBeneficiariesRequest : DapiRequest.BaseRequest {
            internal string action => "/payment/beneficiaries/get";

            public GetBeneficiariesRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
            }
        }

        private class CreateBeneficiariesRequest : DapiRequest.BaseRequest {
            internal string action => "/payment/beneficiaries/create";

            public string name { get; }
            public string accountNumber { get; }
            public string iban { get; }
            public string swiftCode { get; }
            public Beneficiary.BeneficiaryType type { get; }
            public BeneficiaryAddress address { get; }
            public string country { get; }
            public string branchAddress { get; }
            public string branchName { get; }
            public string bankName { get; }
            public string phoneNumber { get; }
            public string sortCode { get; }
            public string nickname { get; }
            public string routingNumber { get; }

            public CreateBeneficiariesRequest(BeneficiaryInfo beneficiary, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.name = beneficiary.name;
                this.accountNumber = beneficiary.accountNumber;
                this.iban = beneficiary.iban;
                this.swiftCode = beneficiary.swiftCode;
                this.type = beneficiary.type;
                this.address = beneficiary.address;
                this.country = beneficiary.country;
                this.branchAddress = beneficiary.branchAddress;
                this.branchName = beneficiary.branchName;
                this.bankName = beneficiary.bankName;
                this.phoneNumber = beneficiary.phoneNumber;
                this.sortCode = beneficiary.sortCode;
                this.nickname = beneficiary.nickname;
                this.routingNumber = beneficiary.routingNumber;
            }
        }

        private class CreateTransferRequest : DapiRequest.BaseRequest {
            internal string action => "/payment/transfer/create";

            public string senderID { get; }
            public float amount { get; }
            public string receiverID { get; }
            public string name { get; }
            public string iban { get; }
            public string accountNumber { get; }
            public string remark { get; }
            public string nickname { get; }

            public CreateTransferRequest(Transfer transfer, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.senderID = transfer.senderID;
                this.amount = transfer.amount;
                this.receiverID = transfer.receiverID;
                this.name = transfer.name;
                this.iban = transfer.iban;
                this.accountNumber = transfer.accountNumber;
                this.remark = transfer.remark;
                this.nickname = transfer.nickname;
            }
        }

        private class TransferAutoflowRequest : DapiRequest.BaseRequest {
            internal string action => "/payment/transfer/autoflow";

            public string bundleID { get; }
            public string appKey { get; }
            public string userID { get; }
            public string bankID { get; }
            public string senderID { get; }
            public float amount { get; }
            public BeneficiaryInfo beneficiary { get; }
            public string remark { get; }

            public TransferAutoflowRequest(TransferAutoflow transferAutoflow, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.bundleID = transferAutoflow.bundleID;
                this.appKey = transferAutoflow.appKey;
                this.userID = transferAutoflow.userID;
                this.bankID = transferAutoflow.bankID;
                this.senderID = transferAutoflow.senderID;
                this.amount = transferAutoflow.amount;
                this.beneficiary = transferAutoflow.beneficiary;
                this.remark = transferAutoflow.remark;
            }
        }

        private class CreateACHTransferRequest : DapiRequest.BaseRequest {
            internal string action => "/ach/pull/create";

            public string senderID { get; }
            public float amount { get; }
            public string description { get; }

            public CreateACHTransferRequest(Transfer transfer, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.senderID = transfer.senderID;
                this.amount = transfer.amount;
                this.description = transfer.description;
            }
        }
    }
}
