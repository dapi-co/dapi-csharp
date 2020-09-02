using System;
namespace TestCsharplibrary.Products.Constants
{
    public class balanceResponse
    {

        public string jobID;
        public Boolean success;
        public string status;
        public Balance balance;
        public balanceResponse()
        {
            balance = new Balance();
        }
    }
    public class Balance
    {
        public Double amount;
        public Currency currency;
        public string accountNumber;
    }
}
