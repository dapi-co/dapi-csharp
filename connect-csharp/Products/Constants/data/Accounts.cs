using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants
{

    public class accountsResponse
    {
        public string jobID;
        public Boolean success;
        public string status;
        public List<Accounts> accounts;
       
        public accountsResponse()
        {
            accounts = new List<Accounts>();
        }
    }
    public class Accounts
    {
        
           public string iban;
        public string number;
        public Currency currency;
        public string type;
        public string id;
        public Boolean? isFavourite =null;
        public string name;
        public Accounts()
        {
            
            currency = new Currency();

        }
    }

    public class Currency
    {
        public string code;
        public string name;
    }



 

}
