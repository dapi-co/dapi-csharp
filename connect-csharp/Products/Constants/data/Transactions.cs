using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants
{

    public class transactionsResponse
    {
        public string jobID;
        public Boolean success;
        public string status;

        List<Transactions> transactions;

        public transactionsResponse()
        {
            transactions = new List<Transactions>();
        }
    }
    public class Transactions
    {


        public double amount;
        public DateTime date;
        public string type;
        public string description;
        public string details;
        public Currency currency;
        public double beforeAmount;
        public double afterAmount;
        public string reference;
        public Transactions()
        {
            currency = new Currency();
        }
    }
}
