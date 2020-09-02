using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants.payments
{
    public class GetBeneficiaryResponse
    {
        public string jobID;
        public Boolean success;
        public string status;

        public List<Beneficiaries> beneficiaries;
        public GetBeneficiaryResponse()
        {
            beneficiaries = new List<Beneficiaries>();
        }
    }
    public class Beneficiaries
    {
        public string name;
        public string iban;
        public string accountNumber;
        public string type;
        public string status;
        public string id;
    }
}
