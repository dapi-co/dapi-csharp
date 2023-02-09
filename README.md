# dapi-csharp

A client library that talks to the [Dapi](https://dapi.com) [API](https://api.dapi.com).

## Quickstart

### Configure Project

1. First add the library from `nuget` to your project.

```xml

<PackageReference Include="Dapi" Version="1.0.0"/>
```

2. Import Dapi's library in your code.

```c#
using Dapi;
using Dapi.Products;
using Dapi.Response;
using Dapi.Types;
```

### Configure Library

1. Create a Dapi app with your App Secret

```c#
namespace TestConsoleApp {
    public class TestClass {
        private DapiApp myApp;

        public TestClass() {
            myApp = new DapiApp("YOUR_APP_SECRET");
        }
    }
}
```

2. Now you can use any of the functions of the `DapiApp` instance, `myApp`, to call Dapi with your `appSecret`.

```c#
namespace TestConsoleApp {
    public class TestClass {
        public void TestFunc() {
            var resp = myApp.getAccounts("YOUR_ACCESS_TOKEN", "YOUR_USER_SECRET");
            // do something with the resp
        }
    }
}
```

3. Or, you can use it inside your endpoint. Our code will basically update the request to add your app's `appSecret`
   to it, and forward the request to Dapi, then return the result.

```c#
namespace TestConsoleApp {
    public class TestClass {
        public void HandlerFunc(string requestBodyJson, ICollection<KeyValuePair<string, string>> requestHeaders) {
            var resp = myApp.handleSDKRequest(requestBodyJson, requestHeaders);
            //resp = myApp.handleSDKRequest(requestBodyJson); // or with no headers
            // do something with the resp
        }
    }
}
```

### Complete Example

You need to replace the placeholders in this code snippet(`appSecret`, `accessToken`, `userSecret`) with your own values, and to handle the response got.

```c#
using System.Collections.Generic;
using Dapi;
using Dapi.Products;
using Dapi.Response;
using Dapi.Types;


namespace TestConsoleApp {
    public class TestClass {
        private DapiApp myApp;

        public TestClass() {
            myApp = new DapiApp("YOUR_APP_SECRET");
        }

        public void TestFunc() {
            var resp = myApp.getAccounts("YOUR_ACCESS_TOKEN", "YOUR_USER_SECRET");
            // do something with the resp
        }

        public void HandlerFunc(string requestBodyJson, ICollection<KeyValuePair<string, string>> requestHeaders) {
            var resp = myApp.handleSDKRequest(requestBodyJson, requestHeaders);
            //resp = myApp.handleSDKRequest(requestBodyJson); // or with no headers
            // do something with the resp
        }
    }
}
```

## Reference

### BaseResponse

All the responses extend BaseResponse class. Meaning all the responses described below in the document will have following fields besides the ones specific to each response

| Parameter | Type | Description |
|---|---|---|
| operationID | `string` | Unique ID generated to identify a specific operation. |
| success | `Boolean` | Returns true if request is successful and false otherwise." |
| status | `APIStatus` (Enum) | The status of the job. <br><br> `done` - Operation Completed. <br> `failed` - Operation Failed. <br> `user_input_required` - Pending User Input. <br> `initialized` - Operation In Progress. <br><br> For further explanation see [Operation Statuses](https://dapi-api.readme.io/docs/operation-statuses). |
| userInputs | `UserInput[]` | Specifies the type of further information required from the user before the job can be completed. <br><br> Note: It's only returned if operation status is `user_input_required` |
| type | `string` | Type of error encountered. <br><br> Note: It's only returned if operation status is `failed` |
| msg | `string` | Detailed description of the error. <br><br> Note: It's only returned if operation status is `failed` |

#### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| query | `string` | Textual description of what is required from the user side. |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. In the response it will always be empty. |

### Methods

#### DapiApp.exchangeToken

Method is used to obtain user's permanent access token by exchanging it with access code received during the user authentication (user login).

##### Note:

You can read more about how to obtain a permanent token on [Obtain an Access Token](https://dapi-api.readme.io/docs/get-an-access-token).

##### Method Description

```c#
public ExchangeTokenResponse exchangeToken(string accessCode, string connectionID)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accessCode** <br> _REQUIRED_ | `string` | Unique code for a user’s successful login to **Connect**. Returned in the response of **UserLogin**. |
| **connectionID** <br> _REQUIRED_ | `string` | The `connectionID` from a user’s successful log in to **Connect**. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| **accessToken** | `string` | A unique permanent token linked to the user. |

---

#### DapiApp.getIdentity

Method is used to retrieve personal details about the user.

##### Method Description

```c#
public GetIdentityResponse getIdentity(string accessToken, string userSecret)

public GetIdentityResponse getIdentity(string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| identity | `Identity` | An object containing the identity data of the user. |

---

#### DapiApp.getAccounts

Method is used to retrieve list of all the bank accounts registered on the user. The list will contain all types of bank accounts.

##### Method Description

```c#
public GetAccountsResponse getAccounts(string accessToken, string userSecret)

public GetAccountsResponse getAccounts(string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| accounts | `Account[]` | An array containing the accounts data of the user. |

---

#### DapiApp.getBalance

Method is used to retrieve balance on specific bank account of the user.

##### Method Description

```c#
public GetBalanceResponse getBalance(string accountID, string accessToken, string userSecret)

public GetBalanceResponse getBalance(string accountID, string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accountID** <br> _REQUIRED_ | `string` | The bank account ID which its balance is requested. <br> Retrieved from one of the accounts returned from the `getAccounts` method. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be valid if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| balance | `Balance` | An object containing the account's balance information. |

---

#### DapiApp.getTransactions

Method is used to retrieve transactions that user has performed over a specific period of time from their bank account. The transaction list is unfiltered, meaning the response will contain all the transactions performed by the user (not just the transactions performed using your app).

Date range of the transactions that can be retrieved varies for each bank. The range supported by the users bank is shown in the response parameter `transactionRange` of Get Accounts Metadata endpoint.

##### Method Description

```c#
public GetTransactionsResponse getTransactions(string accountID, DateTime fromDate, DateTime toDate, string accessToken, string userSecret)

public GetTransactionsResponse getTransactions(string accountID, DateTime fromDate, DateTime toDate, string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accountID** <br> _REQUIRED_ | `string` | The bank account ID which its transactions are requested. <br> Retrieved from one of the accounts returned from the `getAccounts` method. |
| **fromDate** <br> _REQUIRED_ | `DateTime` | The start date of the transactions wanted. |
| **toDate** <br> _REQUIRED_ | `DateTime` | The end date of the transactions wanted. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be valid if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| transactions | `Transaction[]` | Array containing the transactional data for the specified account within the specified period. |

---

#### DapiApp.getBeneficiaries

Method is used to retrieve list of all the beneficiaries already added for a user within a financial institution.

##### Method Description

```c#
public GetBeneficiariesResponse getBeneficiaries(string accessToken, string userSecret)

public GetBeneficiariesResponse getBeneficiaries(string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| beneficiaries | `Beneficiary[]` | An array containing the beneficiary information. |

---

#### DapiApp.createBeneficiary

Method is used to retrieve list of all the beneficiaries already added for a user within a financial institution.

##### Method Description

```c#
public CreateBeneficiaryResponse createBeneficiary(Payment.BeneficiaryInfo beneficiary, string accessToken, string userSecret)

public CreateBeneficiaryResponse createBeneficiary(Payment.BeneficiaryInfo beneficiary, string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **beneficiary** <br> _REQUIRED_ | `Payment.BeneficiaryInfo` | An object that contains info about the beneficiary that should be added. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

Method returns only the fields defined in the BaseResponse.

---

#### DapiApp.createTransfer

Method is used to initiate a new payment from one account to another account.

##### Important

We suggest you use `transferAutoflow` method instead to initiate a payment. `transferAutoflow` abstracts all the validations and processing logic, required to initiate a transaction using `createTransfer` method.

You can read about `transferAutoFlow` further in the document.

##### Method Description

```c#
public CreateTransferResponse createTransfer(Payment.Transfer transfer, string accessToken, string userSecret)

public CreateTransferResponse createTransfer(Payment.Transfer transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **transfer** <br> _REQUIRED_ | `Payment.Transfer` | An object that contains info about the transfer that should be initiated. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| reference | `string` | Transaction reference string returned by the bank. |

---

#### DapiApp.transferAutoflow

Method is used to initiate a new payment from one account to another account, without having to care nor handle any special cases or scenarios.

##### Method Description

```c#
public TransferAutoflowResponse transferAutoflow(Payment.TransferAutoflow transferAutoflow, string accessToken, string userSecret)

public TransferAutoflowResponse transferAutoflow(Payment.TransferAutoflow transferAutoflow, string accessToken, string userSecret, string operationID, UserInput[] userInputs)
```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **transfer** <br> _REQUIRED_ | `Payment.TransferAutoflow` | An object that contains info about the transfer that should be initiated, and any other details that's used to automate the operation. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

###### UserInput Object

| Parameter | Type | Description |
|---|---|---|
| id | `UserInputID` (Enum) | Type of input required. <br><br> You can read more about user input types on [User Input Types](https://dapi-api.readme.io/docs/user-input-types). |
| index | `int` | Is used in case more than one user input is requested. <br> Will always be 0 If only one input is requested. |
| answer | `string` | User input that must be submitted. |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| reference | `string` | Transaction reference string returned by the bank. |

---


#### DapiApp.createACHPull

Method is used to initiate a new ACH pull create.

##### Method Description

```c#
public CreateACHPullResponse createACHPull(ACHPull transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs)

```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **transfer** <br> _REQUIRED_ | `ACH.ACHPull` | An object that contains info about the transfer that should be initiated. |
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

##### Response

Method returns only the fields defined in the BaseResponse.

---


#### DapiApp.getACHPull

Method is used to initiate a new get ACH pull.

##### Method Description

```c#
public GetACHPullResponse getACHPull(string accessToken, string userSecret, string operationID, UserInput[] userInputs)

```

##### Input Parameters

| Parameter | Type | Description |
|---|---|---|
| **accessToken** <br> _REQUIRED_ | `string` | Access Token obtained using the `exchangeToken` method. |
| **userSecret** <br> _REQUIRED_ | `string` | The `userSecret` from a user’s successful log in to **Connect**. |
| **operationID** <br> _OPTIONAL_ | `string` | The `operationID` from a previous call's response. <br> Required only when resuming a previous call that responded with `user_input_required` status, to provided user inputs. |
| **userInputs** <br> _OPTIONAL_ | `UserInput[]` | Array of `UserInput` object, that are needed to complete this operation. <br> Required only if a previous call responded with `user_input_required` status. <br><br> You can read more about user inputs specification on [Specify User Input](https://dapi-api.readme.io/docs/specify-user-input) |

##### Response

In addition to the fields described in the BaseResponse, it has the following fields, which will only be returned if the status is `done`:

| Parameter | Type | Description |
|---|---|---|
| transfer | `ACHGetTransfer` | ACH transfer details returned by the bank. |

---
